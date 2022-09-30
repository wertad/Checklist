namespace Checklist
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.grpboxSettings = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmboxDefaultDisplayRDP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.puttyComboBox = new System.Windows.Forms.ComboBox();
            this.puttyBrowserButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checklistBrowserButton = new System.Windows.Forms.Button();
            this.checklistTextBox = new System.Windows.Forms.TextBox();
            this.puttyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Label();
            this.grpboxVoice = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblSoundPack = new System.Windows.Forms.Label();
            this.cmboxSoundPack = new System.Windows.Forms.ComboBox();
            this.chkboxEnableSounds = new System.Windows.Forms.CheckBox();
            this.grpboxSettings.SuspendLayout();
            this.grpboxVoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpboxSettings
            // 
            this.grpboxSettings.Controls.Add(this.label4);
            this.grpboxSettings.Controls.Add(this.cmboxDefaultDisplayRDP);
            this.grpboxSettings.Controls.Add(this.label3);
            this.grpboxSettings.Controls.Add(this.puttyComboBox);
            this.grpboxSettings.Controls.Add(this.puttyBrowserButton);
            this.grpboxSettings.Controls.Add(this.label1);
            this.grpboxSettings.Controls.Add(this.checklistBrowserButton);
            this.grpboxSettings.Controls.Add(this.checklistTextBox);
            this.grpboxSettings.Controls.Add(this.puttyTextBox);
            this.grpboxSettings.Controls.Add(this.label2);
            this.grpboxSettings.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.grpboxSettings.Location = new System.Drawing.Point(40, 80);
            this.grpboxSettings.Name = "grpboxSettings";
            this.grpboxSettings.Size = new System.Drawing.Size(304, 205);
            this.grpboxSettings.TabIndex = 23;
            this.grpboxSettings.TabStop = false;
            this.grpboxSettings.Text = "Settings:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Default display for RDP: (not working yet)";
            // 
            // cmboxDefaultDisplayRDP
            // 
            this.cmboxDefaultDisplayRDP.FormattingEnabled = true;
            this.cmboxDefaultDisplayRDP.Location = new System.Drawing.Point(10, 168);
            this.cmboxDefaultDisplayRDP.Name = "cmboxDefaultDisplayRDP";
            this.cmboxDefaultDisplayRDP.Size = new System.Drawing.Size(231, 21);
            this.cmboxDefaultDisplayRDP.TabIndex = 32;
            this.cmboxDefaultDisplayRDP.SelectedIndexChanged += new System.EventHandler(this.cmboxDefaultDisplayRDP_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Username for linux:";
            // 
            // puttyComboBox
            // 
            this.puttyComboBox.FormattingEnabled = true;
            this.puttyComboBox.Items.AddRange(new object[] {
            "madi",
            "wertad"});
            this.puttyComboBox.Location = new System.Drawing.Point(11, 123);
            this.puttyComboBox.Name = "puttyComboBox";
            this.puttyComboBox.Size = new System.Drawing.Size(230, 21);
            this.puttyComboBox.TabIndex = 28;
            this.puttyComboBox.SelectedIndexChanged += new System.EventHandler(this.puttyComboBox_SelectedIndexChanged);
            // 
            // puttyBrowserButton
            // 
            this.puttyBrowserButton.Location = new System.Drawing.Point(241, 33);
            this.puttyBrowserButton.Name = "puttyBrowserButton";
            this.puttyBrowserButton.Size = new System.Drawing.Size(33, 22);
            this.puttyBrowserButton.TabIndex = 21;
            this.puttyBrowserButton.Text = "...";
            this.puttyBrowserButton.UseVisualStyleBackColor = true;
            this.puttyBrowserButton.Click += new System.EventHandler(this.puttyBrowserButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "putty.exe location:";
            // 
            // checklistBrowserButton
            // 
            this.checklistBrowserButton.Location = new System.Drawing.Point(241, 77);
            this.checklistBrowserButton.Name = "checklistBrowserButton";
            this.checklistBrowserButton.Size = new System.Drawing.Size(33, 22);
            this.checklistBrowserButton.TabIndex = 25;
            this.checklistBrowserButton.Text = "...";
            this.checklistBrowserButton.UseVisualStyleBackColor = true;
            this.checklistBrowserButton.Click += new System.EventHandler(this.checklistBrowserButton_Click);
            // 
            // checklistTextBox
            // 
            this.checklistTextBox.Location = new System.Drawing.Point(10, 78);
            this.checklistTextBox.Name = "checklistTextBox";
            this.checklistTextBox.Size = new System.Drawing.Size(231, 22);
            this.checklistTextBox.TabIndex = 23;
            this.checklistTextBox.Text = "\\\\noname\\noname\\Checklist";
            this.checklistTextBox.TextChanged += new System.EventHandler(this.checklistTextBox_TextChanged);
            // 
            // puttyTextBox
            // 
            this.puttyTextBox.Location = new System.Drawing.Point(10, 33);
            this.puttyTextBox.Name = "puttyTextBox";
            this.puttyTextBox.Size = new System.Drawing.Size(231, 22);
            this.puttyTextBox.TabIndex = 19;
            this.puttyTextBox.TextChanged += new System.EventHandler(this.puttyTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Checklist folder location:";
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Nirmala UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblSettings.Location = new System.Drawing.Point(29, 12);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(252, 65);
            this.lblSettings.TabIndex = 30;
            this.lblSettings.Text = "SETTINGS";
            // 
            // grpboxVoice
            // 
            this.grpboxVoice.Controls.Add(this.btnRefresh);
            this.grpboxVoice.Controls.Add(this.lblSoundPack);
            this.grpboxVoice.Controls.Add(this.cmboxSoundPack);
            this.grpboxVoice.Controls.Add(this.chkboxEnableSounds);
            this.grpboxVoice.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpboxVoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.grpboxVoice.Location = new System.Drawing.Point(40, 296);
            this.grpboxVoice.Name = "grpboxVoice";
            this.grpboxVoice.Size = new System.Drawing.Size(304, 104);
            this.grpboxVoice.TabIndex = 31;
            this.grpboxVoice.TabStop = false;
            this.grpboxVoice.Text = "Voice:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Location = new System.Drawing.Point(10, 68);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblSoundPack
            // 
            this.lblSoundPack.AutoSize = true;
            this.lblSoundPack.Location = new System.Drawing.Point(9, 23);
            this.lblSoundPack.Name = "lblSoundPack";
            this.lblSoundPack.Size = new System.Drawing.Size(76, 13);
            this.lblSoundPack.TabIndex = 2;
            this.lblSoundPack.Text = "Sound packs:";
            // 
            // cmboxSoundPack
            // 
            this.cmboxSoundPack.FormattingEnabled = true;
            this.cmboxSoundPack.Location = new System.Drawing.Point(12, 39);
            this.cmboxSoundPack.Name = "cmboxSoundPack";
            this.cmboxSoundPack.Size = new System.Drawing.Size(130, 21);
            this.cmboxSoundPack.TabIndex = 1;
            this.cmboxSoundPack.SelectedIndexChanged += new System.EventHandler(this.cboxSoundPack_SelectedIndexChanged);
            // 
            // chkboxEnableSounds
            // 
            this.chkboxEnableSounds.AutoSize = true;
            this.chkboxEnableSounds.Checked = true;
            this.chkboxEnableSounds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxEnableSounds.Location = new System.Drawing.Point(159, 39);
            this.chkboxEnableSounds.Name = "chkboxEnableSounds";
            this.chkboxEnableSounds.Size = new System.Drawing.Size(102, 17);
            this.chkboxEnableSounds.TabIndex = 0;
            this.chkboxEnableSounds.Text = "Enable sounds";
            this.chkboxEnableSounds.UseVisualStyleBackColor = true;
            this.chkboxEnableSounds.CheckStateChanged += new System.EventHandler(this.chkboxEnableSounds_CheckStateChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(733, 433);
            this.Controls.Add(this.grpboxVoice);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.grpboxSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpboxSettings.ResumeLayout(false);
            this.grpboxSettings.PerformLayout();
            this.grpboxVoice.ResumeLayout(false);
            this.grpboxVoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxSettings;
        private System.Windows.Forms.Button puttyBrowserButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button checklistBrowserButton;
        private System.Windows.Forms.TextBox checklistTextBox;
        private System.Windows.Forms.TextBox puttyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox puttyComboBox;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.GroupBox grpboxVoice;
        private System.Windows.Forms.Label lblSoundPack;
        private System.Windows.Forms.ComboBox cmboxSoundPack;
        private System.Windows.Forms.CheckBox chkboxEnableSounds;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmboxDefaultDisplayRDP;
    }
}