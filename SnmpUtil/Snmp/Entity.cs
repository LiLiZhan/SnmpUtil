using System;
using System.Collections.Generic;
using System.Text;
using SnmpSharpNet;

namespace SnmpUtil
{
    public class Entity
    {
        public Entity(string ip, SnmpVersion version, string communityName, int port, PduType pduType, string oid)
        {
            this.IP = ip;
            this.Version = version;
            this.CommunityName = communityName;
            this.Port = port;
            this.PduType = pduType;
            this.OID = new Oid(oid);
        }

        public Entity(SnmpVersion version, PduType pduType)
        {
            this.Version = version;
            this.PduType = pduType;
        }

        public Entity()
        { }

        public string IP { get; set; }

        public SnmpVersion Version { get; set; }

        public string CommunityName { get; set; }

        public int Port { get; set; }

        public PduType PduType { get; set; }

        public Pdu Pdu
        {
            get
            {
                Pdu pdu = new Pdu(PduType);
                if (PduType != PduType.Set)
                    pdu.VbList.Add(OID);
                else
                    pdu.VbList.Add(OID, AsnType);
                return pdu;
            }
        }

        public AsnType AsnType { get; set; }

        public Oid OID { get; set; }

        public bool CheckOid(string oid)
        {
            if (!string.IsNullOrEmpty(oid))
            {
                OID = new Oid(oid);
                return true;
            }
            else
                return false;
        }

        public int Timeout { get; set; }

        public IAgentParameters Parameters
        {
            get
            {
                if (!string.IsNullOrEmpty(CommunityName))
                {
                    if (Version != SnmpVersion.Ver3)
                        return new AgentParameters(Version, new OctetString(CommunityName));
                    else
                        return new SecureAgentParameters();
                }
                else
                    return null;
            }
        }

        public bool IsOK
        {
            get
            {
                if (!string.IsNullOrEmpty(IP) && Version != null && !string.IsNullOrEmpty(CommunityName) && Port > 0 && PduType != null && OID != null && Timeout > 0)
                    return true;
                else return false;
            }
        }
    }
}
