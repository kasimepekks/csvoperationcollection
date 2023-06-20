using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXH_Tools_Files.Tools_Configure;
using YXH_Tools_Files.Tools_DirectoryandFile;
using YXH_Tools_Files.Tools_Excute;
using YXH_Tools_Files.Tools_Spike;

namespace CSV文件操作集合程序
{
    public static class ExcuteOperation
    {
        /// <summary>
        /// 清洗程序
        /// </summary>
        public static async Task excute0(int whoconfig)
        {
            var xml=SelectConfig.SelectConfigfile(whoconfig);
            var nodes = xml.SelectNodes("//CSV清洗模式");
            var orignaldatapath = nodes?[0]?.SelectSingleNode("orignaldatapath")?.InnerText;
            var savedatapath = nodes?[0]?.SelectSingleNode("savedatapath")?.InnerText;
            var selectdatefile = nodes?[0]?.SelectSingleNode("selectdatefile")?.InnerText;
            var renamereg = nodes?[0]?.SelectSingleNode("renamereg")?.InnerText;
            var cleannumreg = nodes?[0]?.SelectSingleNode("cleannumreg")?.InnerText;
            var cleanstringreg = nodes?[0]?.SelectSingleNode("cleanstringreg")?.InnerText;

            var gpsspdindex = nodes?[0]?.SelectSingleNode("gpsspdindex")?.InnerText;
            var canspdindex = nodes?[0]?.SelectSingleNode("canspdindex")?.InnerText;

            var s1 = int.TryParse(gpsspdindex, out int st1);
            var s2 = int.TryParse(canspdindex, out int st2);
            //var orignaldatapath = XMLConfigure.YXHGetXMLConfigSection("CSV清洗模式", "orignaldatapath");
            //var savedatapath = XMLConfigure.YXHGetXMLConfigSection("CSV清洗模式", "savedatapath");
            //var selectdatefile = XMLConfigure.YXHGetXMLConfigSection("CSV清洗模式", "selectdatefile");
            //var renamereg = XMLConfigure.YXHGetXMLConfigSection("CSV清洗模式", "renamereg");
            //var cleannumreg = XMLConfigure.YXHGetXMLConfigSection("CSV清洗模式", "cleannumreg");
            //var cleanstringreg = XMLConfigure.YXHGetXMLConfigSection("CSV清洗模式", "cleanstringreg");
            if (selectdatefile != null&& cleannumreg!=null&& cleanstringreg!=null&&renamereg!=null)
            {
                selectdatefile = selectdatefile.Replace('，', ',').ToLower();
                var selectdatefilearray = selectdatefile.Split(',');
                cleannumreg = cleannumreg.Replace('，', ',');
                var cleannumreglist = cleannumreg.Split(',');
                cleanstringreg = cleanstringreg.Replace('，', ',');
                var cleanstringreglist = cleanstringreg.Split(',');
                if (orignaldatapath != null && savedatapath != null && selectdatefilearray != null)
                {
                    orignaldatapath = orignaldatapath.YXHPathReplace();
                    savedatapath = savedatapath.YXHPathReplace();
                    await Tools_Excute_CSVClean.YXHExcuteCsvClean(orignaldatapath, savedatapath, selectdatefilearray, renamereg, cleannumreglist, cleanstringreglist,st1,st2);
                    Console.WriteLine("清洗已完成");
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
        
        public static void excute1(int whoconfig)
        {
            var xml = SelectConfig.SelectConfigfile(whoconfig);
            var nodes = xml.SelectNodes("//合并CSV-时间模式");
            var orignaldatapath = nodes?[0]?.SelectSingleNode("orignaldatapath")?.InnerText;
            var savedatapath = nodes?[0]?.SelectSingleNode("savedatapath")?.InnerText;
            var selectdatefile = nodes?[0]?.SelectSingleNode("selectdatefile")?.InnerText;
            var threadsnum = nodes?[0]?.SelectSingleNode("threadsnum")?.InnerText;
           
            var s1 = int.TryParse(threadsnum, out int s);
            if (selectdatefile != null&&s1)
            {
                selectdatefile = selectdatefile.Replace('，', ',');
                var selectdatefilearray = selectdatefile.Split(',');
                if(orignaldatapath!=null && savedatapath!=null && selectdatefilearray != null)
                {
                    orignaldatapath = orignaldatapath.YXHPathReplace();
                    savedatapath = savedatapath.YXHPathReplace();
                    Tools_Excute_CSVCombine.YXHExcuteCombinationAll(orignaldatapath, savedatapath, selectdatefilearray, "1",1,1,s);
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
        public static void excute2(int whoconfig)
        {
            var xml = SelectConfig.SelectConfigfile(whoconfig);
            var nodes = xml.SelectNodes("//合并CSV-txt模式");
            var orignaldatapath = nodes?[0]?.SelectSingleNode("orignaldatapath")?.InnerText;
            var savedatapath = nodes?[0]?.SelectSingleNode("savedatapath")?.InnerText;
            var selectdatefile = nodes?[0]?.SelectSingleNode("selectdatefile")?.InnerText;
            var threadsnum = nodes?[0]?.SelectSingleNode("threadsnum")?.InnerText;
            //var orignaldatapath = XMLConfigure.YXHGetXMLConfigSection("合并CSV-txt模式", "orignaldatapath");
            //var savedatapath = XMLConfigure.YXHGetXMLConfigSection("合并CSV-txt模式", "savedatapath");
            //var selectdatefile = XMLConfigure.YXHGetXMLConfigSection("合并CSV-txt模式", "selectdatefile");
            //var threadsnum = XMLConfigure.YXHGetXMLConfigSection("合并CSV-txt模式", "threadsnum");
            var s1 = int.TryParse(threadsnum, out int s);
            if (selectdatefile != null&&s1)
            {
                selectdatefile = selectdatefile.Replace('，', ',');
                var selectdatefilearray = selectdatefile.Split(',');
                if (orignaldatapath != null && savedatapath != null && selectdatefilearray != null)
                {
                    orignaldatapath = orignaldatapath.YXHPathReplace();
                    savedatapath = savedatapath.YXHPathReplace();
                    Tools_Excute_CSVCombine.YXHExcuteCombinationAll(orignaldatapath, savedatapath, selectdatefilearray, "0",1,1, s);
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
        /// <summary>
        /// 里程模式
        /// </summary>
        public static void excute3(int whoconfig)
        {
            var xml = SelectConfig.SelectConfigfile(whoconfig);
            var nodes = xml.SelectNodes("//合并CSV-里程模式");
            var orignaldatapath = nodes?[0]?.SelectSingleNode("orignaldatapath")?.InnerText;
            var savedatapath = nodes?[0]?.SelectSingleNode("savedatapath")?.InnerText;
            var selectdatefile = nodes?[0]?.SelectSingleNode("selectdatefile")?.InnerText;
            var spdindex = nodes?[0]?.SelectSingleNode("spdindex")?.InnerText;
            var mileagebasis = nodes?[0]?.SelectSingleNode("mileagebasis")?.InnerText;
            var threadsnum = nodes?[0]?.SelectSingleNode("threadsnum")?.InnerText;
            //var orignaldatapath = XMLConfigure.YXHGetXMLConfigSection("合并CSV-里程模式", "orignaldatapath");
            //var savedatapath = XMLConfigure.YXHGetXMLConfigSection("合并CSV-里程模式", "savedatapath");
            //var selectdatefile = XMLConfigure.YXHGetXMLConfigSection("合并CSV-里程模式", "selectdatefile");
            //var spdindex = XMLConfigure.YXHGetXMLConfigSection("合并CSV-里程模式", "spdindex");
            //var mileagebasis = XMLConfigure.YXHGetXMLConfigSection("合并CSV-里程模式", "mileagebasis");
            //var threadsnum = XMLConfigure.YXHGetXMLConfigSection("合并CSV-里程模式", "threadsnum");
            var s1= int.TryParse(spdindex, out int s);
            var s2 = int.TryParse(mileagebasis, out int r);
            var s3 = int.TryParse(threadsnum, out int t);
            if (selectdatefile != null&&s1&&s2&&s3)
            {
                selectdatefile = selectdatefile.Replace('，', ',');
                var selectdatefilearray = selectdatefile.Split(',');
                if (orignaldatapath != null && savedatapath != null && selectdatefilearray != null)
                {
                    orignaldatapath = orignaldatapath.YXHPathReplace();
                    savedatapath = savedatapath.YXHPathReplace();
                    Tools_Excute_CSVCombine.YXHExcuteCombinationAll(orignaldatapath, savedatapath, selectdatefilearray, "2", r, s,t);
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


        /// <summary>
        /// 去除毛刺
        /// </summary>
        /// <param name="whoconfig"></param>
        public static async Task excute4(int whoconfig)
        {
            var xml = SelectConfig.SelectConfigfile(whoconfig);
            var nodes = xml.SelectNodes("//CSVSpike模式");
            var orignaldatapath = nodes?[0]?.SelectSingleNode("orignaldatapath")?.InnerText;
            var savedatapath = nodes?[0]?.SelectSingleNode("savedatapath")?.InnerText;
            var selectdatefile = nodes?[0]?.SelectSingleNode("selectdatefile")?.InnerText;

            var columnsname = nodes?[0]?.SelectSingleNode("columnsname")?.InnerText;
            var meanpoints = nodes?[0]?.SelectSingleNode("meanpoints")?.InnerText;
            var vairancepoints = nodes?[0]?.SelectSingleNode("vairancepoints")?.InnerText;

            var threadspercentage = nodes?[0]?.SelectSingleNode("threadspercentage")?.InnerText;
            //需要去除毛刺的列号，可以多个，也可以连续，比如1,2,3,4-10，先分割
            var s11 = columnsname?.Replace("_", "").Replace("N", "").Replace(" ", "").ToLower().Split(',');
            //List<int> indexlists=new List<int>();
            //for (int i = 0; i < s11?.Length; i++)
            //{
            //    if (int.TryParse(s11[i], out int d))
            //    {
            //        indexlists.Add(d);
            //    }
            //    else
            //    {
            //        if (s11[i].Contains('-'))
            //        {
            //            var ct = s11[i].Split('-');
            //            if (ct.Length == 2)
            //            {
            //                var bct0 = int.TryParse(ct[0], out int ct0);
            //                var bct1 = int.TryParse(ct[1], out int ct1);
            //                if (bct0 && bct1)
            //                {
                              
            //                    indexlists.AddRange(Enumerable.Range(ct0, ct1 - ct0 + 1).ToArray());
            //                }
                           
            //            }
            //            else
            //            {
            //                Console.WriteLine("列号填写错误");
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("符号'-'填写错误");
            //        }
            //    }
            //}
            ////去重数字
            //indexlists= indexlists.Distinct().ToList();
            var s2 = int.TryParse(meanpoints, out int m);
            var s3 = int.TryParse(vairancepoints, out int v);

            var s4 = double.TryParse(threadspercentage, out double p);
            if (selectdatefile != null  && s2 && s3&&s4)
            {
                selectdatefile = selectdatefile.Replace('，', ',');
                var selectdatefilearray = selectdatefile.Split(',');
                if (orignaldatapath != null && savedatapath != null && selectdatefilearray != null)
                {
                    orignaldatapath = orignaldatapath.YXHPathReplace();
                    savedatapath = savedatapath.YXHPathReplace();
                    await Tools_Excute_CSVSpikeRemoval.YXHExcuteCsvSpikeV2(orignaldatapath, savedatapath, selectdatefilearray, s11, m, v, p);
                    Console.WriteLine("去除毛刺已完成");
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
        /// <summary>
        /// 执行第一个操作
        /// </summary>
        public static void excute5(int whoconfig)
        {
            var xml = SelectConfig.SelectConfigfile(whoconfig);
            var nodes = xml.SelectNodes("//结构化数据库CSV拆分");
            var orignaldatapath = nodes?[0]?.SelectSingleNode("orignaldatapath")?.InnerText;
            var conditionmodelpath = nodes?[0]?.SelectSingleNode("conditionmodelpath")?.InnerText;
            var savedatapath = nodes?[0]?.SelectSingleNode("savedatapath")?.InnerText;
            var saveconditionpath = nodes?[0]?.SelectSingleNode("saveconditionpath")?.InnerText;
            var standard = nodes?[0]?.SelectSingleNode("standard")?.InnerText;
            var phase = nodes?[0]?.SelectSingleNode("phase")?.InnerText;
            var ballast = nodes?[0]?.SelectSingleNode("ballast")?.InnerText;
            var selectedcollumn = nodes?[0]?.SelectSingleNode("selectedcollumn")?.InnerText;

            if (standard != null && phase != null && ballast != null && selectedcollumn != null)
            {
                standard = standard.Replace('，', ',');
                phase = phase.Replace('，', ',');
                ballast = ballast.Replace('，', ',');
                selectedcollumn = selectedcollumn.Replace('，', ',');
                var standardarray = standard.Split(",");
                var phasearray = phase.Split(",");
                var ballastarray = ballast.Split(",");
                var selectedcollumnarray = selectedcollumn.Split(",");
                if (standardarray != null && phasearray != null && ballastarray != null
               && selectedcollumnarray != null && orignaldatapath != null
               && conditionmodelpath != null && savedatapath != null && saveconditionpath != null)
                {
                    orignaldatapath = orignaldatapath.YXHPathReplace();
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
        public static  async Task excute6(int whoconfig)
        {
            var xml = SelectConfig.SelectConfigfile(whoconfig);
            var nodes = xml.SelectNodes("//去除CSV头部信息");
            var orignaldatapath = nodes?[0]?.SelectSingleNode("orignaldatapath")?.InnerText;
            var savedatapath = nodes?[0]?.SelectSingleNode("savedatapath")?.InnerText;
            //var orignaldatapath = XMLConfigure.YXHGetXMLConfigSection("去除CSV头部信息", "orignaldatapath");
            //var savedatapath = XMLConfigure.YXHGetXMLConfigSection("去除CSV头部信息", "savedatapath");
            if (orignaldatapath != null && savedatapath != null)
            {
                orignaldatapath = orignaldatapath.YXHPathReplace();
                savedatapath = savedatapath.YXHPathReplace();
               await  Tools_Excute_HeaderEdit_for_NcodeCSV.YXHExcuteHeaderAsync(orignaldatapath,savedatapath);
                Console.WriteLine("去除CSV头部信息已完成");
            }
            else
            {
                Console.WriteLine("配置文件填写有误，请检查！");
            }
        }

    }
}
