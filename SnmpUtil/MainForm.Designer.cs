namespace SnmpUtil
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbHostIP = new System.Windows.Forms.Label();
            this.tHostIP = new System.Windows.Forms.TextBox();
            this.tCommunityName = new System.Windows.Forms.TextBox();
            this.lbCommunityName = new System.Windows.Forms.Label();
            this.tPort = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbGetStyle = new System.Windows.Forms.Label();
            this.comboBoxGetStyle = new System.Windows.Forms.ComboBox();
            this.lbVersion = new System.Windows.Forms.Label();
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.lbOID = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.OID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerMain = new System.ComponentModel.BackgroundWorker();
            this.lbTimeOut = new System.Windows.Forms.Label();
            this.comboBoxOIDList = new System.Windows.Forms.ComboBox();
            this.checkBoxClearHistory = new System.Windows.Forms.CheckBox();
            this.tTimeout = new System.Windows.Forms.TextBox();
            this.comboBoxAsnType = new System.Windows.Forms.ComboBox();
            this.tAsnType = new System.Windows.Forms.TextBox();
            this.checkBoxContinued = new System.Windows.Forms.CheckBox();
            this.timerGet = new System.Windows.Forms.Timer(this.components);
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ResultStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.contextMenuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHostIP
            // 
            this.lbHostIP.AutoSize = true;
            this.lbHostIP.Location = new System.Drawing.Point(13, 13);
            this.lbHostIP.Name = "lbHostIP";
            this.lbHostIP.Size = new System.Drawing.Size(65, 12);
            this.lbHostIP.TabIndex = 0;
            this.lbHostIP.Text = "服务器IP：";
            // 
            // tHostIP
            // 
            this.tHostIP.Location = new System.Drawing.Point(72, 10);
            this.tHostIP.Name = "tHostIP";
            this.tHostIP.Size = new System.Drawing.Size(124, 21);
            this.tHostIP.TabIndex = 1;
            this.tHostIP.TextChanged += new System.EventHandler(this.tHostIP_TextChanged);
            // 
            // tCommunityName
            // 
            this.tCommunityName.Location = new System.Drawing.Point(72, 54);
            this.tCommunityName.Name = "tCommunityName";
            this.tCommunityName.Size = new System.Drawing.Size(124, 21);
            this.tCommunityName.TabIndex = 5;
            this.tCommunityName.TextChanged += new System.EventHandler(this.tCommunityName_TextChanged);
            // 
            // lbCommunityName
            // 
            this.lbCommunityName.AutoSize = true;
            this.lbCommunityName.Location = new System.Drawing.Point(13, 57);
            this.lbCommunityName.Name = "lbCommunityName";
            this.lbCommunityName.Size = new System.Drawing.Size(65, 12);
            this.lbCommunityName.TabIndex = 2;
            this.lbCommunityName.Text = "社区名称：";
            // 
            // tPort
            // 
            this.tPort.Location = new System.Drawing.Point(262, 8);
            this.tPort.Name = "tPort";
            this.tPort.Size = new System.Drawing.Size(83, 21);
            this.tPort.TabIndex = 2;
            this.tPort.TextChanged += new System.EventHandler(this.tPort_TextChanged);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(227, 13);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(41, 12);
            this.lbPort.TabIndex = 4;
            this.lbPort.Text = "端口：";
            // 
            // lbGetStyle
            // 
            this.lbGetStyle.AutoSize = true;
            this.lbGetStyle.Location = new System.Drawing.Point(203, 37);
            this.lbGetStyle.Name = "lbGetStyle";
            this.lbGetStyle.Size = new System.Drawing.Size(65, 12);
            this.lbGetStyle.TabIndex = 6;
            this.lbGetStyle.Text = "操作方式：";
            // 
            // comboBoxGetStyle
            // 
            this.comboBoxGetStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGetStyle.FormattingEnabled = true;
            this.comboBoxGetStyle.Location = new System.Drawing.Point(262, 32);
            this.comboBoxGetStyle.Name = "comboBoxGetStyle";
            this.comboBoxGetStyle.Size = new System.Drawing.Size(83, 20);
            this.comboBoxGetStyle.TabIndex = 4;
            this.comboBoxGetStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxGetStyle_SelectedIndexChanged);
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(13, 36);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(65, 12);
            this.lbVersion.TabIndex = 8;
            this.lbVersion.Text = "SNMP版本：";
            // 
            // comboBoxVersion
            // 
            this.comboBoxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVersion.FormattingEnabled = true;
            this.comboBoxVersion.Location = new System.Drawing.Point(72, 33);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(124, 20);
            this.comboBoxVersion.TabIndex = 3;
            this.comboBoxVersion.SelectedIndexChanged += new System.EventHandler(this.comboBoxVersion_SelectedIndexChanged);
            // 
            // lbOID
            // 
            this.lbOID.AutoSize = true;
            this.lbOID.Location = new System.Drawing.Point(43, 81);
            this.lbOID.Name = "lbOID";
            this.lbOID.Size = new System.Drawing.Size(35, 12);
            this.lbOID.TabIndex = 10;
            this.lbOID.Text = "OID：";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(398, 6);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(56, 23);
            this.btnGet.TabIndex = 8;
            this.btnGet.Text = "确定";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMain.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OID,
            this.TYPE,
            this.VALUE});
            this.dataGridViewMain.ContextMenuStrip = this.contextMenuStripMain;
            this.dataGridViewMain.Location = new System.Drawing.Point(2, 104);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.RowHeadersWidth = 20;
            this.dataGridViewMain.RowTemplate.Height = 23;
            this.dataGridViewMain.Size = new System.Drawing.Size(499, 190);
            this.dataGridViewMain.TabIndex = 13;
            // 
            // OID
            // 
            this.OID.DataPropertyName = "OID";
            this.OID.HeaderText = "OID";
            this.OID.Name = "OID";
            this.OID.ReadOnly = true;
            // 
            // TYPE
            // 
            this.TYPE.DataPropertyName = "TYPE";
            this.TYPE.HeaderText = "TYPE";
            this.TYPE.Name = "TYPE";
            this.TYPE.ReadOnly = true;
            // 
            // VALUE
            // 
            this.VALUE.DataPropertyName = "VALUE";
            this.VALUE.HeaderText = "VALUE";
            this.VALUE.Name = "VALUE";
            this.VALUE.ReadOnly = true;
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClear});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(99, 26);
            // 
            // btnClear
            // 
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 22);
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // backgroundWorkerMain
            // 
            this.backgroundWorkerMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMain_DoWork);
            this.backgroundWorkerMain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMain_RunWorkerCompleted);
            // 
            // lbTimeOut
            // 
            this.lbTimeOut.AutoSize = true;
            this.lbTimeOut.Location = new System.Drawing.Point(202, 57);
            this.lbTimeOut.Name = "lbTimeOut";
            this.lbTimeOut.Size = new System.Drawing.Size(65, 12);
            this.lbTimeOut.TabIndex = 14;
            this.lbTimeOut.Text = "超时(ms)：";
            // 
            // comboBoxOIDList
            // 
            this.comboBoxOIDList.FormattingEnabled = true;
            this.comboBoxOIDList.Location = new System.Drawing.Point(73, 78);
            this.comboBoxOIDList.Name = "comboBoxOIDList";
            this.comboBoxOIDList.Size = new System.Drawing.Size(235, 20);
            this.comboBoxOIDList.TabIndex = 15;
            this.comboBoxOIDList.SelectedIndexChanged += new System.EventHandler(this.comboBoxOIDList_SelectedIndexChanged);
            // 
            // checkBoxClearHistory
            // 
            this.checkBoxClearHistory.AutoSize = true;
            this.checkBoxClearHistory.Checked = true;
            this.checkBoxClearHistory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClearHistory.Location = new System.Drawing.Point(355, 80);
            this.checkBoxClearHistory.Name = "checkBoxClearHistory";
            this.checkBoxClearHistory.Size = new System.Drawing.Size(72, 16);
            this.checkBoxClearHistory.TabIndex = 16;
            this.checkBoxClearHistory.Text = "清除历史";
            this.checkBoxClearHistory.UseVisualStyleBackColor = true;
            // 
            // tTimeout
            // 
            this.tTimeout.Location = new System.Drawing.Point(262, 54);
            this.tTimeout.Name = "tTimeout";
            this.tTimeout.Size = new System.Drawing.Size(83, 21);
            this.tTimeout.TabIndex = 17;
            this.tTimeout.Text = "200";
            this.tTimeout.TextChanged += new System.EventHandler(this.tTimeout_TextChanged);
            // 
            // comboBoxAsnType
            // 
            this.comboBoxAsnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAsnType.FormattingEnabled = true;
            this.comboBoxAsnType.Location = new System.Drawing.Point(351, 32);
            this.comboBoxAsnType.Name = "comboBoxAsnType";
            this.comboBoxAsnType.Size = new System.Drawing.Size(103, 20);
            this.comboBoxAsnType.TabIndex = 18;
            // 
            // tAsnType
            // 
            this.tAsnType.Location = new System.Drawing.Point(351, 53);
            this.tAsnType.Name = "tAsnType";
            this.tAsnType.Size = new System.Drawing.Size(103, 21);
            this.tAsnType.TabIndex = 19;
            this.tAsnType.TextChanged += new System.EventHandler(this.tAsnType_TextChanged);
            // 
            // checkBoxContinued
            // 
            this.checkBoxContinued.AutoSize = true;
            this.checkBoxContinued.Location = new System.Drawing.Point(351, 10);
            this.checkBoxContinued.Name = "checkBoxContinued";
            this.checkBoxContinued.Size = new System.Drawing.Size(48, 16);
            this.checkBoxContinued.TabIndex = 20;
            this.checkBoxContinued.Text = "持续";
            this.checkBoxContinued.UseVisualStyleBackColor = true;
            // 
            // timerGet
            // 
            this.timerGet.Interval = 2000;
            this.timerGet.Tick += new System.EventHandler(this.timerGet_Tick);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus,
            this.ResultStatus});
            this.statusStripMain.Location = new System.Drawing.Point(0, 297);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(501, 22);
            this.statusStripMain.TabIndex = 21;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(16, 17);
            this.lbStatus.Text = "...";
            // 
            // ResultStatus
            // 
            this.ResultStatus.Name = "ResultStatus";
            this.ResultStatus.Size = new System.Drawing.Size(16, 17);
            this.ResultStatus.Text = "...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 319);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.checkBoxContinued);
            this.Controls.Add(this.tAsnType);
            this.Controls.Add(this.comboBoxAsnType);
            this.Controls.Add(this.tTimeout);
            this.Controls.Add(this.comboBoxOIDList);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.lbOID);
            this.Controls.Add(this.checkBoxClearHistory);
            this.Controls.Add(this.lbTimeOut);
            this.Controls.Add(this.comboBoxVersion);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.comboBoxGetStyle);
            this.Controls.Add(this.lbGetStyle);
            this.Controls.Add(this.tPort);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.tCommunityName);
            this.Controls.Add(this.lbCommunityName);
            this.Controls.Add(this.tHostIP);
            this.Controls.Add(this.lbHostIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SNMP工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.contextMenuStripMain.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHostIP;
        private System.Windows.Forms.TextBox tHostIP;
        private System.Windows.Forms.TextBox tCommunityName;
        private System.Windows.Forms.Label lbCommunityName;
        private System.Windows.Forms.TextBox tPort;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbGetStyle;
        private System.Windows.Forms.ComboBox comboBoxGetStyle;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.ComboBox comboBoxVersion;
        private System.Windows.Forms.Label lbOID;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMain;
        private System.Windows.Forms.Label lbTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn OID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALUE;
        private System.Windows.Forms.ComboBox comboBoxOIDList;
        private System.Windows.Forms.CheckBox checkBoxClearHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        private System.Windows.Forms.TextBox tTimeout;
        private System.Windows.Forms.ComboBox comboBoxAsnType;
        private System.Windows.Forms.TextBox tAsnType;
        private System.Windows.Forms.CheckBox checkBoxContinued;
        private System.Windows.Forms.Timer timerGet;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripStatusLabel ResultStatus;
    }
}

