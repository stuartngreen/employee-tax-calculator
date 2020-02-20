using EmployeeTaxCalculator.Entities;
using System;
using Xunit;

namespace EmployeeTaxCalculator.Test
{
    public class PaySlipTests
    {
        [Fact]
        public void GetPaye_GivenNoGrossSalary_ThrowsException()
        {
            // Arrange
            var paySlip = new PaySlip();

            // Assert
            Assert.Throws<System.ArgumentException>(() => paySlip.GetPaye());
        }

        [Fact]
        public void GetPaye_GivenGrossSalaryAndDeductionsAndYear2019_ReturnsCorrectValue()
        {
            // Arrange
            var paySlip = new PaySlip();
            var taxYear = 2019;
            var expected = 9156.21m;

            // Act
            paySlip.GrossSalary = 40000m;
            paySlip.DeductionItems.Add(new Deduction
            {
                Name = "Pension",
                Taxable = false,
                Value = 2500m
            });
            paySlip.DeductionItems.Add(new Deduction
            {
                Name = "Vitality",
                Taxable = true,
                Value = 250m
            });
            paySlip.DeductionItems.Add(new Deduction
            {
                Name = "Parking",
                Taxable = true,
                Value = 150m
            });

            // Assert
            Assert.Equal(expected, Math.Round(paySlip.GetPaye(taxYear), 2));
        }

    }
}
