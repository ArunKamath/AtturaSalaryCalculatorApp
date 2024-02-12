using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.TaxCalculator
{
    public interface IIncomeTax
    {
        int CalculateTax(int Baseslary);
    }
}
