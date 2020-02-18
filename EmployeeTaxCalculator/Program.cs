using EmployeeTaxCalculator.Entities;
using System;
using System.Collections.Generic;

namespace EmployeeTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            var year = 2020;

            var employee = new Employee
            {
                Id = 8001185051083,
                FirstName = "Stuart",
                Surname = "Green",
                Age = 39,
                CostToCompany = new CostToCompany
                {
                    Value = 40000m,
                    Benefits = new List<Benefit>()
                    {
                        new Benefit() {
                            Name = "Medical Aid",
                            Amount = 2500m,
                            Taxable = false
                        },
                        new Benefit() {
                            Name = "Pension (Company)",
                            Amount = 2000m,
                            Taxable = false
                        },
                    },
                    Deductions = new List<Deduction>()
                    {
                        new Deduction()
                        {
                            Name = "Pension (Employee)",
                            Amount = 2000m,
                            Taxable = false
                        },
                        new Deduction()
                        {
                            Name = "Discovery Vitality",
                            Amount = 250m,
                            Taxable = true
                        },
                        new Deduction()
                        {
                            Name = "Parking",
                            Amount = 150m,
                            Taxable = true
                        }
                    }
                }
            };

            Console.WriteLine(
                (int)Math.Ceiling(employee.CostToCompany.GetMonthlyTax(year))
            );

        }
    }
}
