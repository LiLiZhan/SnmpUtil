using System;
using System.Collections.Generic;
using System.Text;

namespace SnmpUtil
{
    public class OidObj
    {
        public string Name { get; set; }
        public string Oid { get; set; }
        public int Port { get; set; }
        public object Tag { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", Name, Oid);
        }
    }
}
