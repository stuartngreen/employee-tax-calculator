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
                    2014,
                    new TaxBracketBuilder()
                        .AddBracket(0m, 165600m, 18m)
                        .AddBracket(165600.01m, 258750m, 25m)
                        .AddBracket(258750.01m, 358110m, 30m)
                        .AddBracket(358110.01m, 500940m, 35m)
                        .AddBracket(500940.01m, 638600m, 38m)
                        .AddBracket(638600.01m, decimal.MaxValue, 40m)
                        .Build()
                },
                {
                    2015,
                    new TaxBracketBuilder()
                        .AddBracket(0m, 174550m, 18m)
                        .AddBracket(174550.01m, 272700m, 25m)
                        .AddBracket(272700.01m, 377450m, 30m)
                        .AddBracket(377450.01m, 528000m, 35m)
                        .AddBracket(528000.01m, 673100m, 38m)
                        .AddBracket(673100.01m, decimal.MaxValue, 40m)
                        .Build()
                },
                {
                    2016,
                    new TaxBracketBuilder()
                        .AddBracket(0m, 181900m, 18m)
                        .AddBracket(181900.01m, 284100m, 26m)
                        .AddBracket(284100.01m, 393200m, 31m)
                        .AddBracket(393200.01m, 550100m, 36m)
                        .AddBracket(550100.01m, 701300m, 39m)
                        .AddBracket(701300.01m, decimal.MaxValue, 41m)
                        .Build()
                },
                {
                    2017,
                    new TaxBracketBuilder()
                        .AddBracket(0m, 188000m, 18m)
                        .AddBracket(188000.01m, 293600m, 26m)
                        .AddBracket(293600.01m, 406400m, 31m)
                        .AddBracket(406400.01m, 550100m, 36m)
                        .AddBracket(550100.01m, 701300m, 39m)
                        .AddBracket(701300.01m, decimal.MaxValue, 41m)
                        .Build()
                },
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
