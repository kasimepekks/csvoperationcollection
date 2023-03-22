using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXH_Tools_Files.Tools_Configure;
using YXH_Tools_Files.Tools_DirectoryandFile;
using YXH_Tools_Files.Tools_Excute;

namespace CSV文件操作集合程序
{
    public static class ExcuteOperation
    {
        /// <summary>
        /// 执行第一个操作
        /// </summary>
        public static void excuteFirst()
        {
            var orignaldatapath = XMLConfigure.YXHGetXMLConfigSection("结构化数据库CSV拆分", "orignaldatapath");
            var conditionmodelpath = XMLConfigure.YXHGetXMLConfigSection("结构化数据库CSV拆分", "conditionmodelpath");
            var savedatapath = XMLConfigure.YXHGetXMLConfigSection("结构化数据库CSV拆分", "savedatapath");
            var saveconditionpath = XMLConfigure.YXHGetXMLConfigSection("结构化数据库CSV拆分", "saveconditionpath");
            var standard = XMLConfigure.YXHGetXMLConfigSection("结构化数据库CSV拆分", "standard");
            var phase = XMLConfigure.YXHGetXMLConfigSection("结构化数据库CSV拆分", "phase");
            var ballast = XMLConfigure.YXHGetXMLConfigSection("结构化数据库CSV拆分", "ballast");
            var selectedcollumn = XMLConfigure.YXHGetXMLConfigSection("结构化数据库CSV拆分", "selectedcollumn");
            if (standard != null && phase != null && ballast != null && selectedcollumn != null)
            {
                var standardarray = standard.Split(",");
                var phasearray = phase.Split(",");
                var ballastarray = ballast.Split(",");
                var selectedcollumnarray = selectedcollumn.Split(",");
                if (standardarray != null && phasearray != null && ballastarray != null
               && selectedcollumnarray != null && orignaldatapath != null
               && conditionmodelpath != null && savedatapath != null && saveconditionpath != null)
                {
                    orignaldatapath=orignaldatapath.YXHPathReplace();
                    conditionmodelpath = conditionmodelpath.YXHPathReplace();
                    savedatapath = savedatapath.YXHPathReplace();
                    saveconditionpath = saveconditionpath.YXHPathReplace();
                    Tools_Excute_CSVSplitforDatabase.YXHExcuteCSVSplit(orignaldatapath, selectedcollumnarray, standardarray, phasearray, ballastarray, conditionmodelpath, savedatapath, saveconditionpath);
                }
                else
                {
                    Console.WriteLine("配置文件填写有误，请检查！");
                }
            }
            else
            {
                Console.WriteLine("配置文件填写有误，请检查！");
            }
        }
        public static void excuteSecond()
        {
            var orignaldatapath = XMLConfigure.YXHGetXMLConfigSection("合并CSV-时间模式", "orignaldatapath");
            var savedatapath = XMLConfigure.YXHGetXMLConfigSection("合并CSV-时间模式", "savedatapath");
            var selectdatefile = XMLConfigure.YXHGetXMLConfigSection("合并CSV-时间模式", "selectdatefile");
            if(selectdatefile != null)
            {
                var selectdatefilearray = selectdatefile.Split('t');
                if(orignaldatapath!=null && savedatapath!=null && selectdatefilearray != null)
                {
                    orignaldatapath = orignaldatapath.YXHPathReplace();
                    savedatapath = savedatapath.YXHPathReplace();
                    Tools_Excute_CSVCombine.YXHExcuteCombination(orignaldatapath, savedatapath, selectdatefilearray, "1");
                }
                else
                {
                    Console.WriteLine("配置文件填写有误，请检查！");
                }
            }
            else
            {
                Console.WriteLine("配置文件填写有误，请检查！");
            }
        }
        public static void excuteThird()
        {
            var orignaldatapath = XMLConfigure.YXHGetXMLConfigSection("合并CSV-txt模式", "orignaldatapath");
            var savedatapath = XMLConfigure.YXHGetXMLConfigSection("合并CSV-txt模式", "savedatapath");
            var selectdatefile = XMLConfigure.YXHGetXMLConfigSection("合并CSV-txt模式", "selectdatefile");
            if (selectdatefile != null)
            {
                var selectdatefilearray = selectdatefile.Split('t');
                if (orignaldatapath != null && savedatapath != null && selectdatefilearray != null)
                {
                    orignaldatapath = orignaldatapath.YXHPathReplace();
                    savedatapath = savedatapath.YXHPathReplace();
                    Tools_Excute_CSVCombine.YXHExcuteCombination(orignaldatapath, savedatapath, selectdatefilearray, "0");
                }
                else
                {
                    Console.WriteLine("配置文件填写有误，请检查！");
                }
            }
            else
            {
                Console.WriteLine("配置文件填写有误，请检查！");
            }
        }
        public static  void excuteFourth()
        {
            var orignaldatapath = XMLConfigure.YXHGetXMLConfigSection("去除CSV头部信息", "orignaldatapath");
            var savedatapath = XMLConfigure.YXHGetXMLConfigSection("去除CSV头部信息", "savedatapath");
            if (orignaldatapath != null && savedatapath != null)
            {
                orignaldatapath = orignaldatapath.YXHPathReplace();
                savedatapath = savedatapath.YXHPathReplace();
                Tools_Excute_HeaderEdit_for_NcodeCSV.YXHExcuteHeaderAsync(orignaldatapath,savedatapath);
            }
            else
            {
                Console.WriteLine("配置文件填写有误，请检查！");
            }
        }

    }
}
