using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//注意切出獨立HR模塊了(為待會切.dll鋪路)
namespace HR
{
    /// <summary>
    /// 計算薪資的類別
    /// </summary>
    public class SalaryCalculator
    {
        /// <summary>
        /// 計算薪資的公式物件
        /// </summary>
        private ISalaryFormula _SalaryFormula;
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="SalaryFormula"></param>
        public SalaryCalculator(ISalaryFormula SalaryFormula)
        {
            _SalaryFormula = SalaryFormula;
        }
        /// <summary>
        /// 計算薪資
        /// </summary>
        /// <param name="WorkHours">工時</param>
        /// <param name="Hourly">時薪</param>
        /// <param name="PrivateDayOff">請假天數</param>
        /// <returns></returns>
        public float Calculate(float WorkHours, int Hourly, int PrivateDayOffHours)
        {
            return _SalaryFormula.Execute(WorkHours, Hourly, PrivateDayOffHours);
        }
    }


    /// <summary>
    /// 計算薪資的公式的介面
    /// </summary>
    public interface ISalaryFormula
    {
        //薪資=工時*時薪-(事假時數*時薪)
        float Execute(float WorkHours, int Hourly, int PrivateDayOffHours);
    }

    /// <summary>
    /// 計算薪資的公式的類別
    /// </summary>
    public class SalaryFormula : ISalaryFormula
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
            return WorkHours * Hourly - (PrivateDayOffHours * Hourly );
        }
    }

    //老闆
    public class BossSalaryFormula : ISalaryFormula
    {
        public float Execute(float WorkHours, int Hourly, int PrivateDayOffHours)
        {
            //老闆請假不扣薪
            return WorkHours * Hourly - (PrivateDayOffHours * Hourly * 0);
        }
    }

}
