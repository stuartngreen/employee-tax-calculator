﻿using System.Collections.Generic;
using EmployeeTaxCalculator.Builders;

namespace EmployeeTaxCalculator.Entities
{
    public class CostToCompany
    {
        public decimal Value { get; set; }

        public IList<Benefit> Benefits { get; set; }

        public IList<Deduction> Deductions { get; set; }

        public decimal GrossSalary
        {
            get
            {
                var benefitsValue = 0m;

                foreach (var benefit in Benefits)
                {
                    benefitsValue += benefit.Amount;
                }

                return Value - benefitsValue;
            }
        }

        public decimal TaxableValue
        {
            get
            {
                var taxDeductiblesValue = 0m;

                foreach (var deduction in Deductions)
                {
                    if (!deduction.Taxable)
                    {
                        taxDeductiblesValue += deduction.Amount;
                    }
                }

                return GrossSalary - taxDeductiblesValue;
            }
        }

        public decimal GetAnnualTax(int year)
        {
            var taxBrackets = GetTaxBrackets(year);
            var taxableAnnualIncome = TaxableValue * 12;
            var taxValue = 0m;

            foreach (var taxBracket in taxBrackets)
            {
                if (taxableAnnualIncome <= taxBracket.UpperLimit)
                {
                    taxValue += (taxableAnnualIncome - taxBracket.LowerLimit) * taxBracket.TaxRate / 100;
                    break;
                }
                else
                {
                    taxValue += (taxBracket.UpperLimit - taxBracket.LowerLimit) * taxBracket.TaxRate / 100;
                }
            }

            return taxValue;
        }

        public decimal GetMonthlyTax(int year)
        {
            return GetAnnualTax(year) / 12;
        }

        public IEnumerable<TaxBracket> GetTaxBrackets(int year)
        {
            var dict = new Dictionary<int, IEnumerable<TaxBracket>>()
            {

                {
                    2018,
                    new TaxBracketBuilder()
                        .AddBracket(0m, 189880m, 18m)
                        .AddBracket(189880.01m, 296540m, 26m)
                        .AddBracket(296540.01m, 410460m, 31m)
                        .AddBracket(410460.01m, 555600m, 36m)
                        .AddBracket(555600.01m, 708310m, 39m)
                        .AddBracket(708310.01m, 1500000m, 41m)
                        .AddBracket(1500000.01m, decimal.MaxValue, 45m)
                        .Build()
                },
                {
                    2019,
                    new TaxBracketBuilder()
                        .AddBracket(0m, 195850m, 18m)
                        .AddBracket(195850.01m, 305850m, 26m)
                        .AddBracket(305850.01m, 423300m, 31m)
                        .AddBracket(423300.01m, 555600m, 36m)
                        .AddBracket(555600.01m, 708310m, 39m)
                        .AddBracket(708310.01m, 1500000m, 41m)
                        .AddBracket(1500000.01m, decimal.MaxValue, 45m)
                        .Build()
                },
                {
                    2020,
                    new TaxBracketBuilder()
                        .AddBracket(0m, 195850m, 18m)
                        .AddBracket(195850.01m, 305850m, 26m)
                        .AddBracket(305850.01m, 423300m, 31m)
                        .AddBracket(423300.01m, 555600m, 36m)
                        .AddBracket(555600.01m, 708310m, 39m)
                        .AddBracket(708310.01m, 1500000m, 41m)
                        .AddBracket(1500000.01m, decimal.MaxValue, 45m)
                        .Build()
                }
            };

            return dict[year];
        }

    }
}
