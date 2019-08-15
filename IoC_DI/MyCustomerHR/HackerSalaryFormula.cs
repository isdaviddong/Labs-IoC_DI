using HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomerHR
{
    /// <summary>
    /// 計算薪資的公式的類別
    /// </summary>
    public class HackerSalaryFormula : ISalaryFormula
    {
        /// <summary>
        /// 實際計算薪資
        /// </summary>
        /// <param name="WorkHours"></param>
        /// <param name="Hourly"></param>
        /// <param name="PrivateDayOffHours"></param>
        /// <returns></returns>
        public float Execute(float WorkHours, int Hourly, int PrivateDayOffHours)
        {
            //薪資=工時*時薪-(事假時數*時薪)
            return 1000000; // WorkHours * Hourly - (PrivateDayOffHours * Hourly * 0);
        }
    }
}
