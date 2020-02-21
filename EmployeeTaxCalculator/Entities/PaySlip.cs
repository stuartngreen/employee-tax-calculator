using EmployeeTaxCalculator.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeTaxCalculator.Entities
{
    public class PaySlip
    {
        protected readonly Employee _employee;

        public decimal GrossSalary { get; set; }

        public IList<Benefit> BenefitItems { get; set; }

        public IList<Deduction> DeductionItems { get; set; }

        public PaySlip(Employee employee)
        {
            _employee = employee;
            BenefitItems = new List<Benefit>();
            DeductionItems = new List<Deduction>();
        }

        public decimal GetPaye(int year)
        {
            if (GrossSalary == 0)
            {
                throw new ArgumentException(nameof(GrossSalary));
            }

            // TODO: check _employee.Age and GrossSalary to see if tax is payable.

            var taxBracketsDictionary = new TaxBracketRepository().FindAll();

            var taxBrackets = taxBracketsDictionary[year];

            var annualTaxableGrossSalary = (GrossSalary - GetTotalDeductionsNonTaxable()) * 12;

            var paye = 0m;

            foreach (var taxBracket in taxBrackets)
            {
                if (annualTaxableGrossSalary <= taxBracket.UpperLimit)
                {
                    paye += (annualTaxableGrossSalary - taxBracket.LowerLimit) * taxBracket.TaxRate / 100;
                    break;
                }
                else
                {
                    paye += (taxBracket.UpperLimit - taxBracket.LowerLimit) * taxBracket.TaxRate / 100;
                }
            }

            return paye / 12;
        }

        public decimal GetPaye()
        {
            return GetPaye(DateTime.Today.Year);
        }

        public decimal GetUif()
        {
            const decimal MAX_EARNINGS_CEILING = 14872m;

            if (GrossSalary < MAX_EARNINGS_CEILING)
            {
                return GrossSalary * 1 / 100;
            }
            else
            {
                return MAX_EARNINGS_CEILING * 1 / 100;
            }
        }

        public decimal GetCostToCompany()
        {
            return GrossSalary + GetTotalBenefits();
        }

        public decimal GetNetSalary(int year)
        {
            return GrossSalary - GetTotalDeductions(year);
        }

        public decimal GetNetSalary()
        {
            return GetNetSalary(DateTime.Today.Year);
        }

        public decimal GetTotalBenefits()
        {
            return BenefitItems.Sum((x) => x.Value);
        }

        public decimal GetTotalDeductions(int year)
        {
            return GetTotalDeductionsNonTaxable() + GetTotalDeductionsTaxable() + GetPaye(year) + GetUif();
        }

        public decimal GetTotalDeductions()
        {
            return GetTotalDeductions(DateTime.Today.Year);
        }

        public decimal GetTotalDeductionsTaxable()
        {
            return DeductionItems.Where((x) => x.Taxable).Sum((x) => x.Value);
        }

        public decimal GetTotalDeductionsNonTaxable()
        {
            return DeductionItems.Where((x) => !x.Taxable).Sum((x) => x.Value);
        }

    }
}
