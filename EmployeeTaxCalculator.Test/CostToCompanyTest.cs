using EmployeeTaxCalculator.Entities;
using EmployeeTaxCalculator.Repositories;
using System.Collections.Generic;
using Xunit;

namespace EmployeeTaxCalculator.Test
{
    public class CostToCompanyTest
    {
        [Fact]
        public void GetUif_GivenLimitedParameters_ThrowsException()
        {
            var ctc = new CostToCompany(new TaxBracketRepository());

            Assert.Throws<System.ArgumentNullException>(() => ctc.GetUif());
        }

        [Fact]
        public void GetUif_GivenValueAndBenefits_ReturnsMaximumUifValue()
        {
            var expected = 148.72m;

            var ctc = new CostToCompany(new TaxBracketRepository())
            {
                Value = 40000m,
                Benefits = new List<Benefit>()
                {
                    new Benefit() {
                        Value = 2500m
                    },
                    new Benefit() {
                        Value = 2000m
                    },
                }
            };

            Assert.Equal(expected, ctc.GetUif());
        }
    }
}
