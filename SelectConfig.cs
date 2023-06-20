using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CSV文件操作集合程序
{
    public static class SelectConfig
    {
        public static XmlDocument SelectConfigfile(int whoconfig)
        {
            XmlDocument xml = new XmlDocument();
            switch (whoconfig)
            {
                case 1:
                    {
                        xml.Load("俞晓辉.config");
                    }
                    break;
                case 2:
                    {
                        xml.Load("邱宇.config");
                    }
                    break;
                case 3:
                    {
                        xml.Load("陈海江.config");
                    }
                    break;
                case 4:
                    {
                        xml.Load("李文魁.config");
                    }
                    break;
                case 5:
                    {
                        xml.Load("施之暄.config");
                    }
                    break;
                case 6:
                    {
                        xml.Load("刘粟涛.config");
                    }
                    break;
                default:
                    xml.Load("俞晓辉.config");
                    break;
            }
            return xml;
        }
    }
}
