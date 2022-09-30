namespace Checklist
{
    partial class frmDashboard
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
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnStart = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.printerFszt = new System.Windows.Forms.CheckBox();
            this.printerEm = new System.Windows.Forms.CheckBox();
            this.printerMusic = new System.Windows.Forms.CheckBox();
            this.printerGyartas = new System.Windows.Forms.CheckBox();
            this.fujitsu = new System.Windows.Forms.CheckBox();
            this.server = new System.Windows.Forms.CheckBox();
            this.vSphere = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_webadm = new System.Windows.Forms.Button();
            this.btn_linuxok = new System.Windows.Forms.Button();
            this.btn_gluCl = new System.Windows.Forms.Button();
            this.ANH = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.groupBox2.Location = new System.Drawing.Point(40, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 332);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Windows RDP";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(264, 198);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Location = new System.Drawing.Point(115, 291);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(113, -1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "select all";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Nirmala UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblDashboard.Location = new System.Drawing.Point(29, 12);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(326, 65);
            this.lblDashboard.TabIndex = 29;
            this.lblDashboard.Text = "DASHBOARD";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ANH);
            this.groupBox3.Controls.Add(this.printerFszt);
            this.groupBox3.Controls.Add(this.printerEm);
            this.groupBox3.Controls.Add(this.printerMusic);
            this.groupBox3.Controls.Add(this.printerGyartas);
            this.groupBox3.Controls.Add(this.fujitsu);
            this.groupBox3.Controls.Add(this.server);
            this.groupBox3.Controls.Add(this.vSphere);
            this.groupBox3.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.groupBox3.Location = new System.Drawing.Point(376, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 206);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Browser and PS";
            // 
            // printerFszt
            // 
            this.printerFszt.AutoSize = true;
            this.printerFszt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.printerFszt.Location = new System.Drawing.Point(6, 19);
            this.printerFszt.Name = "printerFszt";
            this.printerFszt.Size = new System.Drawing.Size(109, 17);
            this.printerFszt.TabIndex = 3;
            this.printerFszt.Text = "Printer földszint";
            this.printerFszt.UseVisualStyleBackColor = true;
            // 
            // printerEm
            // 
            this.printerEm.AutoSize = true;
            this.printerEm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.printerEm.Location = new System.Drawing.Point(6, 42);
            this.printerEm.Name = "printerEm";
            this.printerEm.Size = new System.Drawing.Size(99, 17);
            this.printerEm.TabIndex = 4;
            this.printerEm.Text = "Printer emelet";
            this.printerEm.UseVisualStyleBackColor = true;
            // 
            // printerMusic
            // 
            this.printerMusic.AutoSize = true;
            this.printerMusic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.printerMusic.Location = new System.Drawing.Point(6, 65);
            this.printerMusic.Name = "printerMusic";
            this.printerMusic.Size = new System.Drawing.Size(94, 17);
            this.printerMusic.TabIndex = 5;
            this.printerMusic.Text = "Printer music";
            this.printerMusic.UseVisualStyleBackColor = true;
            // 
            // printerGyartas
            // 
            this.printerGyartas.AutoSize = true;
            this.printerGyartas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.printerGyartas.Location = new System.Drawing.Point(6, 88);
            this.printerGyartas.Name = "printerGyartas";
            this.printerGyartas.Size = new System.Drawing.Size(102, 17);
            this.printerGyartas.TabIndex = 6;
            this.printerGyartas.Text = "Printer gyártás";
            this.printerGyartas.UseVisualStyleBackColor = true;
            // 
            // fujitsu
            // 
            this.fujitsu.AutoSize = true;
            this.fujitsu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.fujitsu.Location = new System.Drawing.Point(6, 157);
            this.fujitsu.Name = "fujitsu";
            this.fujitsu.Size = new System.Drawing.Size(112, 17);
            this.fujitsu.TabIndex = 10;
            this.fujitsu.Text = "Fujitsu ETERNUS";
            this.fujitsu.UseVisualStyleBackColor = true;
            // 
            // server
            // 
            this.server.AutoSize = true;
            this.server.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.server.Location = new System.Drawing.Point(6, 111);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(78, 17);
            this.server.TabIndex = 7;
            this.server.Text = "Server.ps1";
            this.server.UseVisualStyleBackColor = true;
            // 
            // vSphere
            // 
            this.vSphere.AutoSize = true;
            this.vSphere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.vSphere.Location = new System.Drawing.Point(6, 134);
            this.vSphere.Name = "vSphere";
            this.vSphere.Size = new System.Drawing.Size(128, 17);
            this.vSphere.TabIndex = 9;
            this.vSphere.Text = "vSphere Web Client";
            this.vSphere.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_webadm);
            this.groupBox1.Controls.Add(this.btn_linuxok);
            this.groupBox1.Controls.Add(this.btn_gluCl);
            this.groupBox1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.groupBox1.Location = new System.Drawing.Point(376, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 120);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Putty";
            // 
            // btn_webadm
            // 
            this.btn_webadm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_webadm.Location = new System.Drawing.Point(38, 48);
            this.btn_webadm.Name = "btn_webadm";
            this.btn_webadm.Size = new System.Drawing.Size(75, 22);
            this.btn_webadm.TabIndex = 13;
            this.btn_webadm.Text = "webadm";
            this.btn_webadm.UseVisualStyleBackColor = true;
            this.btn_webadm.Click += new System.EventHandler(this.btn_webadm_Click);
            // 
            // btn_linuxok
            // 
            this.btn_linuxok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_linuxok.Location = new System.Drawing.Point(38, 19);
            this.btn_linuxok.Name = "btn_linuxok";
            this.btn_linuxok.Size = new System.Drawing.Size(75, 22);
            this.btn_linuxok.TabIndex = 15;
            this.btn_linuxok.Text = "linuxok";
            this.btn_linuxok.UseVisualStyleBackColor = true;
            this.btn_linuxok.Click += new System.EventHandler(this.btn_linuxok_Click);
            // 
            // btn_gluCl
            // 
            this.btn_gluCl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_gluCl.Location = new System.Drawing.Point(38, 78);
            this.btn_gluCl.Name = "btn_gluCl";
            this.btn_gluCl.Size = new System.Drawing.Size(75, 22);
            this.btn_gluCl.TabIndex = 14;
            this.btn_gluCl.Text = "gluCl";
            this.btn_gluCl.UseVisualStyleBackColor = true;
            this.btn_gluCl.Click += new System.EventHandler(this.btn_gluCl_Click);
            // 
            // ANH
            // 
            this.ANH.AutoSize = true;
            this.ANH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.ANH.Location = new System.Drawing.Point(6, 180);
            this.ANH.Name = "ANH";
            this.ANH.Size = new System.Drawing.Size(51, 17);
            this.ANH.TabIndex = 12;
            this.ANH.Text = "ANH";
            this.ANH.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(851, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox printerFszt;
        private System.Windows.Forms.CheckBox printerEm;
        private System.Windows.Forms.CheckBox printerMusic;
        private System.Windows.Forms.CheckBox printerGyartas;
        private System.Windows.Forms.CheckBox fujitsu;
        private System.Windows.Forms.CheckBox server;
        private System.Windows.Forms.CheckBox vSphere;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_webadm;
        private System.Windows.Forms.Button btn_linuxok;
        private System.Windows.Forms.Button btn_gluCl;
        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox ANH;
    }
}