using EmployeeTaxCalculator.Entities;
using EmployeeTaxCalculator.Repositories;
using System;
using System.Collections.Generic;

namespace EmployeeTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            var employee = new Employee
            {
                Id = 8001185051083,
                FirstName = "Stuart",
                Surname = "Green",
                Age = 39,
                CostToCompany = new CostToCompany(new TaxBracketRepository())
                {
                    Value = 40000m,
                    Benefits = new List<Benefit>()
                    {
                        new Benefit() {
                            Name = "Medical Aid",
                            Value = 2500.5m,
                            Taxable = false
                        },
                        new Benefit() {
                            Name = "Pension (Company)",
                            Value = 2000m,
                            Taxable = false
                        },
                    },
                    Deductions = new List<Deduction>()
                    {
                        new Deduction()
                        {
                            Name = "Pension (Employee)",
                            Value = 2000m,
                            Taxable = false
                        },
                        new Deduction()
                        {
                            Name = "Discovery Vitality",
                            Value = 250m,
                            Taxable = true
                        },
                        new Deduction()
                        {
                            Name = "Parking",
                            Value = 150m,
                            Taxable = true
                        }
                    }
                }
            };
            
            Console.WriteLine(
                (int)Math.Ceiling(employee.CostToCompany.GetMonthlyPaye())
            );

            Console.WriteLine(
                (int)Math.Ceiling(employee.CostToCompany.GetNetSalary())
            );

            Console.WriteLine(employee.CostToCompany.GetUif());

        }
    }
}
