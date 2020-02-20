﻿using EmployeeTaxCalculator.Builders;
using EmployeeTaxCalculator.Entities;
using System;

namespace EmployeeTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            var paySlipBuilder = new PaySlipBuilder();

            paySlipBuilder.AddGrossSalary(40000);
            paySlipBuilder.AddMedicalAid(2500);
            paySlipBuilder.AddPension(5000);
            paySlipBuilder.AddParking(150);
            paySlipBuilder.AddVitality(250);

            var paySlip = paySlipBuilder.Build();


            Console.WriteLine(
                "Cost to Company: " + paySlip.GetCostToCompany() +
                "\nTotal Benefits: " + paySlip.GetTotalBenefits() +
                "\nTotal Deductions: " + paySlip.GetTotalDeductions() +
                "\nUIF: " + paySlip.GetUif() +
                "\nPAYE: " + paySlip.GetPaye() +
                "\nNet Salary: " + paySlip.GetNetSalary()
            );

        }
    }
}
