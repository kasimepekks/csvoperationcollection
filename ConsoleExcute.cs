using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSV文件操作集合程序
{
    public static class ConsoleExcute
    {
     
        public static  async Task consoleRecurrence(int whoconfig)
        {
            List<string> namelist = new List<string>()
            {
                "CSV清洗程序（可改名，值替换）", "合并CSV-时间模式","合并CSV-txt模式","合并CSV-里程模式","CSV去除毛刺","结构化数据库CSV拆分","去除CSV头部信息"
            };
            try
            {
                Console.WriteLine("请选择一个操作模式：");
                Console.WriteLine("0. CSV清洗程序（可改名，值替换）");
                Console.WriteLine("1. 合并CSV-时间模式");
                Console.WriteLine("2. 合并CSV-txt模式");
                Console.WriteLine("3. 合并CSV-里程模式");
                Console.WriteLine("4. CSV去除毛刺");
                Console.WriteLine("5. 结构化数据库CSV拆分");
                Console.WriteLine("6. 去除CSV头部信息");
                Console.WriteLine("********************请输入序号并按回车********************\"");
                string? yesorno = "n";
                int value = 0;
                while (yesorno != "y")
                {
                    var index = Console.ReadLine();
                    if (int.TryParse(index, out value))
                    {
                        if (value >= 0 && value < 6)
                        {
                            Console.WriteLine($"你输入的序号为{index}，确定执行'{namelist[value]}'吗？确定请输入y，取消请输入任意其他");
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
                   await Task.Run(async () => {
                       Console.WriteLine($"开始执行序号为{value}的操作……");
                       switch (value)
                       {
                           case 0:
                               {
                                   Console.WriteLine("开始执行：CSV清洗程序");
                                  await ExcuteOperation.excute0(whoconfig);
                               }
                               break;
                          
                           case 1:
                               {
                                   Console.WriteLine("开始执行：合并CSV-时间模式");
                                   ExcuteOperation.excute1(whoconfig);
                               }
                               break;
                           case 2:
                               {
                                   Console.WriteLine("开始执行：合并CSV-txt模式");
                                   ExcuteOperation.excute2(whoconfig);
                               }
                               break;
                           case 3:
                               {
                                   Console.WriteLine("开始执行：合并CSV-里程模式");
                                   ExcuteOperation.excute3(whoconfig);
                               }
                               break;

                           case 4:
                               {
                                   Console.WriteLine("开始执行：合并CSV-去除毛刺");
                                  await ExcuteOperation.excute4(whoconfig);
                               }
                               break;
                           case 5:
                               {
                                   Console.WriteLine("开始执行：结构化数据库CSV拆分");
                                   ExcuteOperation.excute5(whoconfig);
                               }
                               break;
                           case 6:
                               {
                                   Console.WriteLine("开始执行：去除CSV头部信息");
                                  await ExcuteOperation.excute6(whoconfig);
                               }
                               break;
                       }

                   });
                    //t.GetAwaiter().OnCompleted(() =>
                    //{
                    //    consoleRecurrence();
                    //});

                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
        }

        /// <summary>
        /// 选择谁的配置文件
        /// </summary>
        /// <returns></returns>
        public static async Task consoleSelectName()
        {
            List<string> namelist = new List<string>()
            {
                "俞晓辉", "俞晓辉","邱宇","陈海江","李文魁","施之暄","刘粟涛"
            };
            try
            {
                Console.WriteLine("请选择配置文件：");
                Console.WriteLine("1. 俞晓辉");
                Console.WriteLine("2. 邱宇");
                Console.WriteLine("3. 陈海江");
                Console.WriteLine("4. 李文魁");
                Console.WriteLine("5. 施之暄");
                Console.WriteLine("6. 刘粟涛");
                Console.WriteLine("********************请输入序号并按回车********************\"");
                string? yesorno = "n";
                int value = 0;
                while (yesorno != "y")
                {
                    var index = Console.ReadLine();
                    if (int.TryParse(index, out value))
                    {
                        if (value >= 0 && value < 7)
                        {
                            Console.WriteLine($"你输入的序号为{index}，确定选择'{namelist[value]}'的配置文件吗？确定请输入y，取消请输入任意其他");
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
                    await consoleRecurrence(value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
        }
    }
}
