using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Models
{    
    public  class Salary
    {
        private  int basesalary;
        public  int BaseSalary
        {
            get { return BaseSalary; }
            set { BaseSalary = value; }
        }
        public byte Frequency { get; set; }

        public int ToInt(string value)
        {
           if(int.TryParse(value, out int result))
            {
                return result;
            }
            throw new Exception("Base salary should be a whole number.");
        }
    }
}
