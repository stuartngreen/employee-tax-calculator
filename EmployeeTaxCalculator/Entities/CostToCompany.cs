using System.Collections.Generic;

namespace EmployeeTaxCalculator.Entities
{
    public class CostToCompany
    {
        public decimal Value { get; set; }

        public List<Benefit> Benefits { get; set; }

        public List<Deduction> Deductions { get; set; }

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

            // TODO: get tax bracket using 'year'
            var taxBrackets = new TaxBracket[]
            {
                new TaxBracket { LowerLimit = 0m, UpperLimit = 195850m, TaxRate = 18m },
                new TaxBracket { LowerLimit = 195850.01m, UpperLimit = 305850m, TaxRate = 26m },
                new TaxBracket { LowerLimit = 305850.01m, UpperLimit = 423300m, TaxRate = 31m },
                new TaxBracket { LowerLimit = 423300.01m, UpperLimit = 555600m, TaxRate = 36m },
                new TaxBracket { LowerLimit = 555600.01m, UpperLimit = 708310m, TaxRate = 39m },
                new TaxBracket { LowerLimit = 708310.01m, UpperLimit = 1500000m, TaxRate = 41m },
                new TaxBracket { LowerLimit = 1500000.01m, UpperLimit = decimal.MaxValue, TaxRate = 45m }
            };

            //TODO: new TaxBracketBuilder().AddBracket().AddBracket().AddBracket().Build();

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

        // TODO: getTaxBrackets(int year)

    }
}
