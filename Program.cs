using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SalaryCalculator.Models;
using SalaryCalculator.SuperAnnuation;
using SalaryCalculator.TaxCalculator;


namespace SalaryCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IIncomeTax, IncomeTax>()
                .AddSingleton<ISuperAnnuantion, SuperAnnuationCalculator>()
                .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>();
                
            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            

            Console.Write("Enter your salary package amount:");
            var baseSalary = Console.ReadLine();            
            Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly):");
            var payFrequency = Console.ReadLine();

            try
            {
               
                var salary = new Salary().ToInt(baseSalary);

                Console.WriteLine("\n\nCalculating salary details...\n\n");
                Console.WriteLine($"Gross package:${baseSalary}");

                //calculate Super annuation
                var superProvider = serviceProvider.GetRequiredService<ISuperAnnuantion>();
                var superContribution = superProvider.CalculateSuper(salary);

                Console.WriteLine($"Superannuation: ${superContribution}\n\n");
                Console.WriteLine($"Taxable income: ${salary - superContribution}\n\n");
                Console.WriteLine($"Deductions:");

                //calculate salary
                //var incomeTax = serviceProvider.GetService<IIncomeTax>();
                //var salaryPostTax = incomeTax.CalculateTax(salary);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            
        }
    }
}
