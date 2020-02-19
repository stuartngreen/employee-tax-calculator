using EmployeeTaxCalculator.Builders;
using EmployeeTaxCalculator.Entities;
using EmployeeTaxCalculator.Interfaces;
using System.Collections.Generic;

namespace EmployeeTaxCalculator.Repositories
{
    public class TaxBracketRepository : ITaxBracketRepository
    {
        public IDictionary<int, IEnumerable<TaxBracket>> FindAll()
        {
            return new Dictionary<int, IEnumerable<TaxBracket>>()
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
        }
    }
}
