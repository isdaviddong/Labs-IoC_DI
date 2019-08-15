using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //一般員工 SalaryFormula
            SalaryCalculator SC = new SalaryCalculator(new SalaryFormula());
            //注意參數完全相同
            float amount = SC.Calculate(8 * 19, 200, 8);
            Console.Write("\nSalaryFormula--->amount:" + amount);

            //老闆 BossSalaryFormula
            SC = new SalaryCalculator(new BossSalaryFormula());
            //注意參數完全相同
            amount = SC.Calculate(8 * 19, 200, 8); //即便與員工相同
            //但計算出的結果不同
            Console.Write("\nBoss SalaryFormula--->amount:" + amount);
            Console.ReadKey();
        }

        //老闆薪資計算公式
        class BossSalaryFormula : ISalaryFormula
        {
            public float Execute(float WorkHours, int Hourly, int PrivateDayOffHours)
            {
                //老闆請假不扣薪!!!!!!!
                return WorkHours * Hourly - (PrivateDayOffHours * Hourly * 0);
            }
        }
    }
}
