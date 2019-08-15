using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            //一般員工
            using (IUnityContainer container = new UnityContainer())
            {
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                //只有container不同
                section.Configure(container, "containerEmployee");
                //其他code完全相同
                SalaryCalculator SC = container.Resolve<SalaryCalculator>();
                float amount = SC.Calculate(8 * 19, 200, 8);
                Console.Write("\ncontainerEmployee SalaryFormula--->amount:" + amount);
                Console.ReadKey();
            }

            //老闆
            using (IUnityContainer container = new UnityContainer())
            {
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                //只有container不同
                section.Configure(container, "containerBoss");
                //其他code完全相同
                SalaryCalculator SC = container.Resolve<SalaryCalculator>();
                float amount = SC.Calculate(8 * 19, 200, 8);
                Console.Write("\ncontainerBoss SalaryFormula--->amount:" + amount);
                Console.ReadKey();
            }
        }
    }
}
