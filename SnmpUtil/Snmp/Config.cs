using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SnmpUtil
{
    public class Config
    {
        public static List<OidObj> LoadConfigs()
        {
            string filePath = Path.Combine(Application.StartupPath, "Config.xml");
            if (File.Exists(filePath))
            {
                string info = FileHelper.TxtReader(filePath, Encoding.UTF8);
                List<OidObj> oids = SerialiazeHelper.XmlDeserialize<List<OidObj>>(info);
                return oids;
            }
            return null;
        }

        public static List<OidObj> LoadDefaultConfigs()
        {
            List<OidObj> objVals = new List<OidObj>()
                {
                    new OidObj(){ Name = "主机名", Oid = "1.3.6.1.2.1.1.5.0", Port = 161 },
                    new OidObj(){ Name = "存储", Oid = "1.3.6.1.2.1.25.2.3.1.3.0", Port = 161 },
                    new OidObj(){ Name = "进程", Oid = "1.3.6.1.2.1.25.4.2.1.2.0", Port = 161 },
                    new OidObj(){ Name = "网卡", Oid = "1.3.6.1.2.1.2.2.1.2.0", Port = 161 },
                };
            return objVals;
        }

        public static void SaveConfigs(List<OidObj> vals)
        {
            string info = SerialiazeHelper.XmlSerialiaze<List<OidObj>>(vals, Encoding.UTF8);
            string filePath = Path.Combine(Application.StartupPath, "Config.xml");
            FileHelper.WriteToTxt(filePath, info, Encoding.UTF8, true);
        }
    }
}
