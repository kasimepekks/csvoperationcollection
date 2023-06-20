// See https://aka.ms/new-console-template for more information
using CSV文件操作集合程序;
using System.Collections;
using System.Configuration;

using YXH_Tools_Files.Tools_Configure;
using YXH_Tools_Files.Tools_Excute;



try
{
    await ConsoleExcute.consoleSelectName();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadLine();
}

