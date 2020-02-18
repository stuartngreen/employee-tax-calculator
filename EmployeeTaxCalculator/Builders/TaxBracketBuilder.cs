using EmployeeTaxCalculator.Entities;
using System.Collections.Generic;

namespace EmployeeTaxCalculator.Builders
{
    class TaxBracketBuilder
    {
        private List<TaxBracket> TaxBrackets = new List<TaxBracket>();

        public TaxBracketBuilder(int year)
        {
            // TODO: build list based on year and other factors
        }

        public TaxBracketBuilder AddBracket(decimal lowerLimit, decimal upperLimit, decimal taxRate)
        {
            var taxBracket = new TaxBracket
            {
                LowerLimit = lowerLimit,
                UpperLimit = upperLimit,
                TaxRate = taxRate
            };

            TaxBrackets.Add(taxBracket);

            return this;
        }

        public List<TaxBracket> Build()
        {
            return TaxBrackets;
        }
    }
}
