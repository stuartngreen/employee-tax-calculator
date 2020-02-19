using System.Collections.Generic;
using System;
using EmployeeTaxCalculator.Interfaces;

namespace EmployeeTaxCalculator.Entities
{
    public class CostToCompany
    {
        public decimal Value { get; set; }

        public IList<Benefit> Benefits { get; set; }

        public IList<Deduction> Deductions { get; set; }

        protected decimal _grossSalary
        {
            get
            {
                var totalBenefits = 0m;

                foreach (var benefit in Benefits)
                {
                    totalBenefits += benefit.Value;
                }

                return Value - totalBenefits;
            }
        }

        protected decimal _taxableValue
        {
            get
            {
                var totalTaxDeductibles = 0m;

                foreach (var deduction in Deductions)
                {
                    if (!deduction.Taxable)
                    {
                        totalTaxDeductibles += deduction.Value;
                    }
                }

                return _grossSalary - totalTaxDeductibles;
            }
        }

        protected readonly ITaxBracketRepository _taxBracketRepository;

        public CostToCompany(ITaxBracketRepository taxBracketRepository)
        {
            _taxBracketRepository = taxBracketRepository;
        }

        public decimal GetAnnualPaye(int year)
        {
            var taxBrackets = GetTaxBrackets(year);
            var annualTaxableValue = _taxableValue * 12;
            var paye = 0m;

            foreach (var taxBracket in taxBrackets)
            {
                if (annualTaxableValue <= taxBracket.UpperLimit)
                {
                    paye += (annualTaxableValue - taxBracket.LowerLimit) * taxBracket.TaxRate / 100;
                    break;
                }
                else
                {
                    paye += (taxBracket.UpperLimit - taxBracket.LowerLimit) * taxBracket.TaxRate / 100;
                }
            }

            return paye;
        }

        public decimal GetMonthlyPaye(int year)
        {
            return GetAnnualPaye(year) / 12;
        }

        public decimal GetMonthlyPaye()
        {
            return GetAnnualPaye(DateTime.Today.Year) / 12;
        }

        public decimal GetUif()
        {
            const decimal MAX_EARNINGS_CEILING = 178464m;

            if (_grossSalary < MAX_EARNINGS_CEILING)
            {
                return _grossSalary * 1 / 100;
            }
            else
            {
                return MAX_EARNINGS_CEILING * 1 / 100;
            }
        }

        public decimal GetNetSalary(int year)
        {
            var totalDeductions = 0m;

            foreach (var deduction in Deductions)
            {
                if (deduction.Taxable)
                {
                    totalDeductions += deduction.Value;
                }
            }

            totalDeductions += GetMonthlyPaye(year);
            totalDeductions += GetUif();

            return _taxableValue - totalDeductions;
        }

        public decimal GetNetSalary()
        {
            return GetNetSalary(DateTime.Today.Year);
        }

        private IEnumerable<TaxBracket> GetTaxBrackets(int year)
        {
            var dict = _taxBracketRepository.FindAll();

            return dict[year];
        }

    }
}
