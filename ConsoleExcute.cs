using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV文件操作集合程序
{
    public static class ConsoleExcute
    {
        public static  void consoleRecurrence()
        {
            try
            {
                Console.WriteLine("请选择一个操作模式：");
                Console.WriteLine("1. 结构化数据库CSV拆分");
                Console.WriteLine("2. 合并CSV-时间模式");
                Console.WriteLine("3. 合并CSV-txt模式");
                Console.WriteLine("4. 去除CSV头部信息");
                Console.WriteLine("********************请输入序号并按回车********************\"");
                string? yesorno = "n";
                int value = 0;
                while (yesorno != "y")
                {
                    var index = Console.ReadLine();
                    if (int.TryParse(index, out value))
                    {
                        if (value > 0 && value < 5)
                        {
                            Console.WriteLine($"你输入的序号为{index}，确定执行吗？确定请输入y，取消请输入任意其他");
                            yesorno = Console.ReadLine()?.ToLower();
                            if (yesorno == "y")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("请重新输入序号");
                            }
                        }
                        else
                        {
                            Console.WriteLine("你输入的数字有误，请重新输入：");
                        }
                    }
                    else
                    {
                        Console.WriteLine("你输入的不是数字请重新输入：");
                    }
                }
                if (yesorno == "y")
                {
                   var t= Task.Run(() => {
                       Console.WriteLine($"开始执行序号为{value}的操作……");
                       switch (value)
                       {
                           case 1:
                               {
                                   ExcuteOperation.excuteFirst();
                               }
                               break;
                           case 2:
                               {
                                   ExcuteOperation.excuteSecond();
                               }
                               break;
                           case 3:
                               {
                                   ExcuteOperation.excuteThird();
                               }
                               break;
                           case 4:
                               {
                                   ExcuteOperation.excuteFourth();
                               }
                               break;
                       }

                   });
                    t.GetAwaiter().OnCompleted(() =>
                    {
                        consoleRecurrence();
                    });

                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
        }
    }
}
