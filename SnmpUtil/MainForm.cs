using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SnmpSharpNet;
using System.Text.RegularExpressions;
using System.Net;

namespace SnmpUtil
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnGet.Enabled = false;
            snmpObj = new Entity(SnmpVersion.Ver1, PduType.Get);
            comboBoxAsnType.Visible = false;
            tAsnType.Visible = false;
            lbStatus.Visible = false;
            ResultStatus.Visible = false;
        }

        private Entity snmpObj;
        private Dictionary<Oid, AsnType> result;
        private DataTable resultData;
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.comboBoxVersion.Items.Add(new DictionaryEntry("Ver1", SnmpVersion.Ver1));
            this.comboBoxVersion.Items.Add(new DictionaryEntry("Ver2", SnmpVersion.Ver2));
            this.comboBoxVersion.Items.Add(new DictionaryEntry("Ver3", SnmpVersion.Ver3));
            this.comboBoxVersion.DisplayMember = "key";
            this.comboBoxVersion.ValueMember = "value";
            this.comboBoxVersion.SelectedIndex = 0;
            this.comboBoxGetStyle.Items.Add(new DictionaryEntry("Get", PduType.Get));
            this.comboBoxGetStyle.Items.Add(new DictionaryEntry("GetNext", PduType.GetNext));
            this.comboBoxGetStyle.Items.Add(new DictionaryEntry("GetBulk", PduType.GetBulk));
            this.comboBoxGetStyle.Items.Add(new DictionaryEntry("Set", PduType.Set));
            this.comboBoxGetStyle.DisplayMember = "key";
            this.comboBoxGetStyle.ValueMember = "value";
            this.comboBoxGetStyle.SelectedIndex = 0;

            List<OidObj> objVals = Config.LoadConfigs();
            if (objVals == null || objVals.Count == 0)
            {
                objVals = Config.LoadDefaultConfigs();
                Config.SaveConfigs(objVals);
                #region #
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("主机名", "1.3.6.1.2.1.1.5.0"));
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("存储", "1.3.6.1.2.1.25.2.3.1.3.0"));
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("进程", "1.3.6.1.2.1.25.4.2.1.2.0"));
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("网卡", "1.3.6.1.2.1.2.2.1.2.0"));
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("ProbeProgram", "1.3.6.1.4.1.41083.1.1.2.1.1.0"));
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("ProbeCard", "1.3.6.1.4.1.41083.1.1.2.2.1.1.0"));
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("ProbeSocket", "1.3.6.1.4.1.41083.1.1.2.3.1.1.0"));
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("IBSPragram", "1.3.6.1.4.1.41083.1.2.2.1.1.0"));
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("IBSDecoder", "1.3.6.1.4.1.41083.1.2.2.2.1.1.0"));
                //this.comboBoxOIDList.Items.Add(new DictionaryEntry("IBSProcessor", "1.3.6.1.4.1.41083.1.2.2.3.1.1.0"));
                #endregion
            }
            foreach (OidObj val in objVals)
            {
                this.comboBoxOIDList.Items.Add(val);
            }

            this.comboBoxOIDList.DisplayMember = "key";
            this.comboBoxOIDList.ValueMember = "value";
            this.comboBoxOIDList.SelectedIndex = 0;

            this.comboBoxAsnType.Items.Add(new DictionaryEntry("OctetString", typeof(OctetString)));
            this.comboBoxAsnType.Items.Add(new DictionaryEntry("Integer32", typeof(Integer32)));
            this.comboBoxAsnType.Items.Add(new DictionaryEntry("TimeTicks", typeof(TimeTicks)));
            this.comboBoxAsnType.Items.Add(new DictionaryEntry("Oid", typeof(Oid)));
            this.comboBoxAsnType.Items.Add(new DictionaryEntry("Sequence", typeof(Sequence)));
            this.comboBoxAsnType.Items.Add(new DictionaryEntry("UInteger32", typeof(UInteger32)));
            this.comboBoxAsnType.Items.Add(new DictionaryEntry("Null", typeof(Null)));
            this.comboBoxAsnType.Items.Add(new DictionaryEntry("Counter64", typeof(Counter64)));
            this.comboBoxAsnType.DisplayMember = "key";
            this.comboBoxAsnType.ValueMember = "value";
            this.comboBoxAsnType.SelectedIndex = 0;

            resultData = new DataTable();
            resultData.Columns.Add("OID");
            resultData.Columns.Add("TYPE");
            resultData.Columns.Add("VALUE");

#if !IS200
            tHostIP.Text = "192.168.1.200";
            tPort.Text = "161";
            tCommunityName.Text = "public";
            tTimeout.Text = "2000";
            btnGet.Enabled = true;
#endif
        }

        private void comboBoxOIDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OidObj val = comboBoxOIDList.SelectedItem as OidObj;
            if (val != null)
            {
                tPort.Text = val.Port.ToString();
                string oid = val.Oid;
                if (!string.IsNullOrEmpty(oid))
                {
                    snmpObj.OID = new Oid(oid);
                    btnGet.Enabled = snmpObj.IsOK;
                }
            }
            else
                MessageBox.Show("信息出现错误", "提示");
        }

        private void tHostIP_TextChanged(object sender, EventArgs e)
        {
            bool isRight = Regex.IsMatch(tHostIP.Text, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
            if (isRight)
            {
                snmpObj.IP = tHostIP.Text;
                btnGet.Enabled = snmpObj.IsOK;
            }
        }

        private void tPort_TextChanged(object sender, EventArgs e)
        {
            int port = 0;
            if (int.TryParse(tPort.Text, out port))
            {
                snmpObj.Port = port;
                btnGet.Enabled = snmpObj.IsOK;
            }
        }

        private void tTimeout_TextChanged(object sender, EventArgs e)
        {
            int timeout = 0;
            if (int.TryParse(tTimeout.Text, out timeout))
            {
                snmpObj.Timeout = timeout;
                btnGet.Enabled = snmpObj.IsOK;
            }
        }

        private void tCommunityName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tCommunityName.Text))
            {
                snmpObj.CommunityName = tCommunityName.Text;
                btnGet.Enabled = snmpObj.IsOK;
            }
        }

        private void comboBoxVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            SnmpVersion version = (SnmpVersion)((DictionaryEntry)comboBoxVersion.SelectedItem).Value;
            if (version == SnmpVersion.Ver1 && comboBoxGetStyle.SelectedIndex == 2)
            {
                MessageBox.Show("Ver1不支持Bulk...", "提示");
                comboBoxVersion.SelectedIndex = 1;
            }
            else if (version == SnmpVersion.Ver3 && comboBoxGetStyle.SelectedIndex == 3)
            {
                MessageBox.Show("后续版本增加Ver3版本SET支持...", "提示");
                comboBoxVersion.SelectedIndex = 0;
            }
            else
                snmpObj.Version = version;
        }

        private void comboBoxGetStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            PduType pduType = (PduType)((DictionaryEntry)comboBoxGetStyle.SelectedItem).Value;
            if (pduType == PduType.GetBulk && snmpObj.Version == SnmpVersion.Ver1)
            {
                MessageBox.Show("Ver1不支持Bulk...", "提示");
                comboBoxGetStyle.SelectedIndex = 0;
                pduType = (PduType)((DictionaryEntry)comboBoxGetStyle.SelectedItem).Value;
            }
            else if (pduType == PduType.Set && snmpObj.Version == SnmpVersion.Ver3)
            {
                MessageBox.Show("后续版本增加Ver3版本SET支持...", "提示");
                comboBoxGetStyle.SelectedIndex = 0;
                pduType = (PduType)((DictionaryEntry)comboBoxGetStyle.SelectedItem).Value;
            }
            snmpObj.PduType = pduType;
            comboBoxAsnType.Visible = snmpObj.PduType == PduType.Set;
            tAsnType.Visible = snmpObj.PduType == PduType.Set;
        }

        private void tAsnType_TextChanged(object sender, EventArgs e)
        {
            string asnType = tAsnType.Text;
            switch (comboBoxAsnType.SelectedIndex)
            {
                case 0:
                    snmpObj.AsnType = new OctetString(asnType);
                    break;
                case 1:
                    snmpObj.AsnType = new TimeTicks(asnType);
                    break;
                case 2:
                    snmpObj.AsnType = new Oid(asnType);
                    break;
                case 3:
                    snmpObj.AsnType = new UInteger32(asnType);
                    break;
                case 4:
                    snmpObj.AsnType = new Counter64(asnType);
                    break;
            }
        }

        private bool running = false;
        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxContinued.Checked)
                {
                    if (!running)
                    {
                        btnGet.Text = "停止";
                        timerGet.Enabled = true;
                        running = true;
                        checkBoxContinued.Enabled = false;
                        comboBoxOIDList.Enabled = false;
                        Update("启动查询...", running);
                        UpdateResult("", running);
                        return;
                    }
                    else
                    {
                        btnGet.Text = "确定";
                        timerGet.Enabled = false;
                        checkBoxContinued.Enabled = true;
                        comboBoxOIDList.Enabled = true;
                        running = false;
                        Update("取消查询...", running);
                        return;
                    }
                }
                LoadMainData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void LoadMainData()
        {
            Update("开始查询...", true);
            if (snmpObj.IsOK && snmpObj.CheckOid(comboBoxOIDList.SelectedIndex == -1 ? comboBoxOIDList.Text : ((OidObj)comboBoxOIDList.SelectedItem).Oid))
            {
#if !V3
                if (snmpObj.Version == SnmpVersion.Ver3)
                {
                    MessageBox.Show("后续版本将增加对Ver3版本支持...", "提示");
                    return;
                }
#endif
                if (!backgroundWorkerMain.IsBusy)
                {
                    result = new Dictionary<Oid, AsnType>();
                    if (checkBoxClearHistory.Checked)
                    {
                        dataGridViewMain.DataSource = null;
                        resultData.Clear();
                    }
                    Utils.RunBackgroundWorker(backgroundWorkerMain, backgroundWorkerMain_DoWork, backgroundWorkerMain_RunWorkerCompleted);
                }
            }
            else
                MessageBox.Show("所输入内容存在错误...", "提示");
        }

        private void backgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = null;
                if (snmpObj.Version != SnmpVersion.Ver3)
                {
                    SimpleSnmp simpleSnmp = new SimpleSnmp(snmpObj.IP, snmpObj.Port, snmpObj.CommunityName, snmpObj.Timeout, 1);
                    if (snmpObj.PduType == PduType.Get)
                        result = simpleSnmp.Get(snmpObj.Version, snmpObj.Pdu);
                    else if (snmpObj.PduType == PduType.GetNext)
                        result = simpleSnmp.GetNext(snmpObj.Version, snmpObj.Pdu);
                    else if (snmpObj.PduType == PduType.GetBulk && snmpObj.Version == SnmpVersion.Ver2)
                    {
                        result = simpleSnmp.GetBulk(snmpObj.Pdu);
                    }
                    else if (snmpObj.PduType == PduType.Set)
                    {
                        result = simpleSnmp.Set(snmpObj.Version, snmpObj.Pdu);
                    }
                }
                else
                {
                    UdpTarget target = new UdpTarget(IPAddress.Parse(snmpObj.IP), snmpObj.Port, snmpObj.Timeout, 0);
                    SnmpV3Packet packet = (SnmpV3Packet)target.Request(snmpObj.Pdu, snmpObj.Parameters);
                    e.Result = packet;
                }
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private void backgroundWorkerMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                MessageBox.Show(e.Result.ToString(), "提示");
                return;
            }
            if (result != null)
            {
                int count = 0;
                foreach (KeyValuePair<Oid, AsnType> val in result)
                {
                    DataRow dr = resultData.NewRow();
                    dr["OID"] = val.Key.ToString();
                    dr["TYPE"] = val.Value.GetType().Name;// val.GetType();
                    dr["VALUE"] = Utils.ConvertTo(val.Value);
                    count++;
                    resultData.Rows.Add(dr);
                }
                dataGridViewMain.DataSource = resultData;
                UpdateResult(string.Format("新增{0}条(共{1}条)", count, resultData.Rows.Count), false);
            }
            else
            {
                MessageBox.Show("未查询到结果...", "提示");
                UpdateResult("", true);
            }
            Update("查询结束...", true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridViewMain.DataSource = null;
            resultData.Clear();
            Update("清空完成...", true);
            UpdateResult("", true);
        }

        private void timerGet_Tick(object sender, EventArgs e)
        {
            LoadMainData();
        }

        private void Update(string status, bool running)
        {
            lbStatus.Visible = running;
            lbStatus.Text = status;
        }

        private void UpdateResult(string status, bool running)
        {
            ResultStatus.Visible = !running;
            ResultStatus.Text = status;
        }
    }
}
