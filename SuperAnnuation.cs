using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.SuperAnnuation
{
    public class SuperAnnuationCalculator : ISuperAnnuantion
    {
        /// <summary>
        /// Calculate Super Annuation based on the base salary and reading the
        /// Super annuation config from the json file.
        /// </summary>
        /// <param name="baseSalary"></param>
        /// <returns></returns>
        public int CalculateSuper(int baseSalary)
        {
            //Get super annuation rate from the config file.
            JObject data = JObject.Parse(File.ReadAllText("C:\\SampleCodeMaker\\Attura_Assignment\\AtturaSalaryCalculatorAssignment\\SalaryCalculator\\SuperAnnuation\\SuperConfig.json"));
            var superPercent = data["SuperAnnuationPercentage"].Value<float>();

            var super = (int)Math.Round((baseSalary*superPercent)/100);

            return super;
        }
    }
}
