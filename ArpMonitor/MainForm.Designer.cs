namespace ArpMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonSendArp = new System.Windows.Forms.Button();
            this.dataGridAddresses = new System.Windows.Forms.DataGridView();
            this.Img = new System.Windows.Forms.DataGridViewImageColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelForDataGrid = new System.Windows.Forms.Label();
            this.dataGridDevices = new System.Windows.Forms.DataGridView();
            this.deviceIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceMac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUIStatus = new System.Windows.Forms.Label();
            this.pictureLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAddresses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSendArp
            // 
            this.buttonSendArp.Enabled = false;
            this.buttonSendArp.Location = new System.Drawing.Point(418, 347);
            this.buttonSendArp.Name = "buttonSendArp";
            this.buttonSendArp.Size = new System.Drawing.Size(162, 33);
            this.buttonSendArp.TabIndex = 1;
            this.buttonSendArp.Text = "Обновить";
            this.buttonSendArp.UseVisualStyleBackColor = true;
            this.buttonSendArp.Click += new System.EventHandler(this.buttonSendArp_Click);
            // 
            // dataGridAddresses
            // 
            this.dataGridAddresses.AllowUserToAddRows = false;
            this.dataGridAddresses.AllowUserToDeleteRows = false;
            this.dataGridAddresses.AllowUserToResizeRows = false;
            this.dataGridAddresses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAddresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Img,
            this.IP,
            this.Mac,
            this.Type});
            this.dataGridAddresses.Location = new System.Drawing.Point(12, 27);
            this.dataGridAddresses.Name = "dataGridAddresses";
            this.dataGridAddresses.ReadOnly = true;
            this.dataGridAddresses.Size = new System.Drawing.Size(568, 304);
            this.dataGridAddresses.TabIndex = 2;
            // 
            // Img
            // 
            this.Img.HeaderText = "";
            this.Img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Img.Name = "Img";
            this.Img.ReadOnly = true;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IP.HeaderText = "IP-адрес";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Mac
            // 
            this.Mac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mac.HeaderText = "MAC-адрес";
            this.Mac.Name = "Mac";
            this.Mac.ReadOnly = true;
            this.Mac.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.HeaderText = "Тип адреса";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // labelForDataGrid
            // 
            this.labelForDataGrid.AutoSize = true;
            this.labelForDataGrid.Location = new System.Drawing.Point(12, 11);
            this.labelForDataGrid.Name = "labelForDataGrid";
            this.labelForDataGrid.Size = new System.Drawing.Size(145, 13);
            this.labelForDataGrid.TabIndex = 3;
            this.labelForDataGrid.Text = "Список доступных адресов";
            // 
            // dataGridDevices
            // 
            this.dataGridDevices.AllowUserToAddRows = false;
            this.dataGridDevices.AllowUserToDeleteRows = false;
            this.dataGridDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceIP,
            this.deviceMac,
            this.deviceVendor});
            this.dataGridDevices.Location = new System.Drawing.Point(12, 392);
            this.dataGridDevices.Name = "dataGridDevices";
            this.dataGridDevices.Size = new System.Drawing.Size(568, 112);
            this.dataGridDevices.TabIndex = 4;
            // 
            // deviceIP
            // 
            this.deviceIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deviceIP.HeaderText = "IP-адрес";
            this.deviceIP.Name = "deviceIP";
            this.deviceIP.ReadOnly = true;
            // 
            // deviceMac
            // 
            this.deviceMac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deviceMac.HeaderText = "MAC-адрес";
            this.deviceMac.Name = "deviceMac";
            this.deviceMac.ReadOnly = true;
            // 
            // deviceVendor
            // 
            this.deviceVendor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deviceVendor.HeaderText = "Производитель";
            this.deviceVendor.Name = "deviceVendor";
            this.deviceVendor.ReadOnly = true;
            // 
            // OUIStatus
            // 
            this.OUIStatus.AutoSize = true;
            this.OUIStatus.Location = new System.Drawing.Point(83, 367);
            this.OUIStatus.Name = "OUIStatus";
            this.OUIStatus.Size = new System.Drawing.Size(214, 13);
            this.OUIStatus.TabIndex = 5;
            this.OUIStatus.Text = "Загрузка списка вендоров, подождите...";
            // 
            // pictureLoading
            // 
            this.pictureLoading.Image = ((System.Drawing.Image)(resources.GetObject("pictureLoading.Image")));
            this.pictureLoading.Location = new System.Drawing.Point(103, 347);
            this.pictureLoading.Name = "pictureLoading";
            this.pictureLoading.Size = new System.Drawing.Size(165, 18);
            this.pictureLoading.TabIndex = 6;
            this.pictureLoading.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(592, 517);
            this.Controls.Add(this.pictureLoading);
            this.Controls.Add(this.OUIStatus);
            this.Controls.Add(this.dataGridDevices);
            this.Controls.Add(this.labelForDataGrid);
            this.Controls.Add(this.dataGridAddresses);
            this.Controls.Add(this.buttonSendArp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Arp Monitor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAddresses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSendArp;
        private System.Windows.Forms.DataGridView dataGridAddresses;
        private System.Windows.Forms.Label labelForDataGrid;
        private System.Windows.Forms.DataGridViewImageColumn Img;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridView dataGridDevices;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceMac;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceVendor;
        private System.Windows.Forms.Label OUIStatus;
        private System.Windows.Forms.PictureBox pictureLoading;
    }
}

