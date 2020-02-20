using EmployeeTaxCalculator.Builders;
using System;
using Xunit;

namespace EmployeeTaxCalculator.Test
{
    public class PaySlipBuilderTests
    {
        [Fact]
        public void GetUif_GivenAboveCeilingGrossSalary_ReturnsMaximumUifValue()
        {
            // Arrange
            var paySlipBuilder = new PaySlipBuilder();
            var expected = 148.72m;

            paySlipBuilder.AddGrossSalary(40000m);

            // Act
            var paySlip = paySlipBuilder.Build();

            // Assert
            Assert.Equal(expected, paySlip.GetUif());
        }

        [Fact]
        public void GetUif_GivenBelowCeilingGrossSalary_ReturnsCalculatedUifValue()
        {
            // Arrange
            var paySlipBuilder = new PaySlipBuilder();
            var expected = 140;

            paySlipBuilder.AddGrossSalary(14000m);

            // Act
            var paySlip = paySlipBuilder.Build();

            // Assert
            Assert.Equal(expected, paySlip.GetUif());
        }

        [Fact]
        public void GetCostToCompany_GivenGrossSalaryAndBenefits_ReturnsCorrectTotal()
        {
            // Arrange
            var paySlipBuilder = new PaySlipBuilder();
            var expected = 45000m;

            paySlipBuilder.AddGrossSalary(40000m);
            paySlipBuilder.AddMedicalAid(2500m);
            paySlipBuilder.AddPension(5000m);

            // Act
            var paySlip = paySlipBuilder.Build();

            // Assert
            Assert.Equal(expected, paySlip.GetCostToCompany());
        }

        [Fact]
        public void GetNetSalary_GivenGrossSalaryAndDeductionsAndTaxYear_ReturnsCorrectTotal()
        {
            // Arrange
            var paySlipBuilder = new PaySlipBuilder();
            var year = 2019;
            var expected = 27795.07m;

            paySlipBuilder.AddGrossSalary(40000m);
            paySlipBuilder.AddPension(5000m);
            paySlipBuilder.AddVitality(250m);
            paySlipBuilder.AddParking(150m);

            // Act
            var paySlip = paySlipBuilder.Build();

            // Assert
            Assert.Equal(expected, Math.Round(paySlip.GetNetSalary(year), 2));
        }

        [Fact]
        public void GetTotalBenefits_GivenBenefits_ReturnsCorrectTotal()
        {
            // Arrange
            var paySlipBuilder = new PaySlipBuilder();
            var expected = 5000m;

            paySlipBuilder.AddMedicalAid(2500m);
            paySlipBuilder.AddPension(5000m);

            // Act
            var paySlip = paySlipBuilder.Build();

            // Assert
            Assert.Equal(expected, paySlip.GetTotalBenefits());
        }

        [Fact]
        public void GetTotalDeductions_GivenGrossSalaryAndDeductions_ReturnsCorrectTotal()
        {
            // Arrange
            var paySlipBuilder = new PaySlipBuilder();
            var expected = 12204.93m;

            paySlipBuilder.AddGrossSalary(40000m);
            paySlipBuilder.AddPension(5000m);
            paySlipBuilder.AddVitality(250m);
            paySlipBuilder.AddParking(150m);

            // Act
            var paySlip = paySlipBuilder.Build();

            // Assert
            Assert.Equal(expected, Math.Round(paySlip.GetTotalDeductions(), 2));
        }
    }
}
