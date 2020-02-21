using EmployeeTaxCalculator.Entities;
using System;
using System.Linq;

namespace EmployeeTaxCalculator.Builders
{
    public class PaySlipBuilder
    {
        protected PaySlip _paySlip;

        public PaySlipBuilder(Employee employee)
        {
            _paySlip = new PaySlip(employee);
        }

        public PaySlipBuilder AddGrossSalary(decimal value)
        {
            _paySlip.GrossSalary = value;

            return this;
        }

        public PaySlipBuilder AddMedicalAid(decimal value)
        {
            _paySlip.BenefitItems.Add(new Benefit
            {
                Name = "Medical Aid",
                Taxable = false,
                Value = value
            });

            return this;
        }

        public PaySlipBuilder AddPension(decimal value)
        {
            _paySlip.DeductionItems.Add(new Deduction
            {
                Name = "Pension (Employee)",
                Taxable = false,
                Value = value / 2
            });

            _paySlip.BenefitItems.Add(new Benefit
            {
                Name = "Pension (Company)",
                Taxable = false,
                Value = value / 2
            });

            return this;
        }

        public PaySlipBuilder AddVitality(decimal value)
        {
            _paySlip.DeductionItems.Add(new Deduction
            {
                Name = "Vitality",
                Taxable = true,
                Value = value
            });

            return this;
        }

        public PaySlipBuilder AddParking(decimal value)
        {
            _paySlip.DeductionItems.Add(new Deduction
            {
                Name = "Parking",
                Taxable = true,
                Value = value
            });

            return this;
        }

        public PaySlip Build()
        {
            return _paySlip;
        }
    }
}
