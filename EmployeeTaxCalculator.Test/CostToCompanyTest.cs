using EmployeeTaxCalculator.Entities;
using EmployeeTaxCalculator.Repositories;
using System.Collections.Generic;
using Xunit;

namespace EmployeeTaxCalculator.Test
{
    public class CostToCompanyTest
    {
        [Fact]
        public void GetUif_ReturnsCorrectValue()
        {
            var ctc = new CostToCompany(new TaxBracketRepository())
            {
                Value = 40000m,
                Benefits = new List<Benefit>()
                {
                    new Benefit() {
                        Value = 2500.5m
                    },
                    new Benefit() {
                        Value = 2000m
                    },
                }
            };

            var uif = ctc.GetUif();

            Assert.Equal(354.995m, uif);
        }
    }
}