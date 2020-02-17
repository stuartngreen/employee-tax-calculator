using Project1.Entities;
using System;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {

            int year = 2019;

            var employee = new Employee
            {
                Id = 8001185051083,
                FirstName = "Stuart",
                Surname = "Green",
                Age = 39,
                CostToCompany = new CostToCompany
                {
                    Value = 40000m,
                    Benefits = new List<Triple>()
                    {
                        new Triple() {
                            Name = "Medical Aid",
                            Amount = 2500m,
                            Taxable = false
                        },
                        new Triple() {
                            Name = "Pension (Company)",
                            Amount = 2000m,
                            Taxable = false
                        },
                    },
                    Deductions = new List<Triple>()
                    {
                        new Triple()
                        {
                            Name = "Pension (Employee)",
                            Amount = 2000m,
                            Taxable = false
                        },
                        new Triple()
                        {
                            Name = "Discovery Vitality",
                            Amount = 250m,
                            Taxable = true
                        },
                        new Triple()
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
