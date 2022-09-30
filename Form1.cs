using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using Microsoft.Win32;
using System.Diagnostics;
using System.Configuration;
using System.IO;

namespace Checklist
{
     
    //TODO: készítsen a program logfile-t is
    //TODO: listview1 színkezelése sárga = inprogress megírása
    //TODO: Indításkor jelölje be, amelyik rdp-k közül ami már kész van
    //TODO: Legyen a browser és linux lista is bővíthatő? (browsernél lehetne egy külön mappa linkekkel)
    //TODO: Linuxokat settingsből kezelhetővé tenni, pl. nem tudtuk lekezelni hogy változott az egyiknek a portja.
    //TODO: Ha kész a checklista akkor küldjön összegző emailt az IT-ra
    //TODO: szedje ki a pipát zöldeléskor (amikor kész van egy tétel)
    public partial class Form1 : Form
    {
        #region Rounded Form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        #endregion

        #region Dragable Custom Titlebar
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        #endregion

        #region Custom GroupBox
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Red, Color.Blue);
        }

        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(this.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }
        #endregion

        public static Boolean mic = false;
        public Boolean chk = false;
        public Boolean chkkapcs = false;
        public static string checklistPath = Functions.ReadSetting("ChklistFolderLocation");
        public static string puttyPath = Functions.ReadSetting("puttyLocation");
        public static string puttyUser = Functions.ReadSetting("puttyUser");

        public static List<string> soundpacks = Functions.LoadSoundPacks();
        public static List<string> monitors = Functions.GetMonitorsFriendlyNames();

        public static List<RDPServer> rDPServers;

        public static SoundPack voice = new SoundPack();
        public static Boolean voiceEnabled = false;

        public static DateTime time = DateTime.Now;
        public static string dateString = time.ToString("yyyy.MM.dd");

        public static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        frmDashboard frmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        public Form1()
        {
            InitializeComponent();

            // TODO: ezeket innen el kéne pakolni függvényekbe

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav2.Height = btnDashboard.Height;
            pnlNav2.Top = btnDashboard.Top;
            //pnlNav2.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            this.pnlFormLoader.Controls.Clear();

            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);

            frmDashboard_Vrb.Show();

            GroupBox groupBox1 = new GroupBox();
            groupBox1.Paint += groupBox1_Paint;
            groupBox1.Text = "Windows RDP:";
            groupBox1.ForeColor = Color.Orange;
            groupBox1.Location = new Point(200, 60);
            groupBox1.Size = new Size(285, 345);
            this.Controls.Add(groupBox1);

            // Ha még nem volt elindítva a program, akkor az alapbeállításokra állítja a .config fájlt
            // Benne az alap mstsc folderrel és rpd_display számmal
            Functions.InitSettings();

            if (Functions.ReadSetting("voiceEnabled") == "1")
            {
                voiceEnabled = true;
                voice = Functions.GetVoicePack(Functions.ReadSetting("selectedVoicePack"));
            }
            else
            {
                voice = Functions.GetVoicePack(Functions.ReadSetting("selectedVoicePack"));
            }

            Functions.startPainNet(Convert.ToInt32(Functions.ReadSetting("RDP_Display")), "paintdotnet");
            Watcher();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDashboard.ForeColor = Color.Coral;
        }
        #region Click_Events
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
            pnlNav2.Height = btnDashboard.Height;
            pnlNav2.Top = btnDashboard.Top;
            pnlNav2.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.ForeColor = Color.Coral;
            btnSettings.ForeColor = Color.FromArgb(0, 126, 249);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        public static void LoadQuestionVoice()
        {
            Random random = new Random();
            int idx = random.Next(0, voice.Q.Length);
            wplayer.URL = voice.Q[idx];
            wplayer.controls.play();
        }

        private void btnVoiceControl_Click(object sender, EventArgs e)
        {
            mic = !mic;
            if (mic)
            {
                if(voiceEnabled)
                    LoadQuestionVoice();
                frmDashboard.recEngine.RecognizeAsync(RecognizeMode.Multiple);
                btnVoiceControl.ForeColor = Color.Coral;
            }
            if (!mic)
            {
                frmDashboard.recEngine.RecognizeAsyncStop();
                btnVoiceControl.ForeColor = Color.FromArgb(0, 126, 249);
            }
            pnlNav2.Height = btnVoiceControl.Height;
            pnlNav2.Top = btnVoiceControl.Top;
            btnVoiceControl.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.pnlFormLoader.Controls.Clear();
            frmSettings frmDashboard_Vrb = new frmSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
            pnlNav2.Height = btnSettings.Height;
            pnlNav2.Top = btnSettings.Top;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);
            btnSettings.ForeColor = Color.Coral;
            btnDashboard.ForeColor = Color.FromArgb(0, 126, 249);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }
        #endregion

        #region Leave_Events
        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            btnDashboard.ForeColor = Color.FromArgb(0, 126, 249);
        }

        private void btnAnalytics_Leave(object sender, EventArgs e)
        {
            btnVoiceControl.BackColor = Color.FromArgb(24, 30, 54);
            btnVoiceControl.ForeColor = Color.FromArgb(0, 126, 249);
        }

        private void btnSettings_Leave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.ForeColor = Color.FromArgb(0, 126, 249);
        }
        #endregion

        private void Watcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = (checklistPath + @"\" + dateString);
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.CreationTime;
            watcher.Filter = "*.PNG";
            watcher.EnableRaisingEvents = true;
            watcher.InternalBufferSize = 24000;
            watcher.Changed += OnChanged;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            int i = 0;
            foreach (var rdpItem in rDPServers)
            {
                //TODO: jelenleg csak az első png fájlt használja, majd átírni hogy ne csak a pngFiles[0]-t figyelje
                if (e.FullPath == rdpItem.pngFiles[0])
                {
                    rdpItem.done = true;
                    ChangeColor(i);
                    break;
                }
                i++;
            }
        }

        private void ChangeColor(int index)
        {
            frmDashboard_Vrb.changeColor(index);
            //frmDashboard.listView1.Invoke(new Action(() => { listView1.Items[index].BackColor = Color.SeaGreen; })); debug, delete ha a fenti sor jó
        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::Checklist.Properties.Resources.btnClose_Inactive_verysmall3;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::Checklist.Properties.Resources.btnClose_Inactive_verysmall;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
