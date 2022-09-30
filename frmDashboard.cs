using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace Checklist
{
    public partial class frmDashboard : Form
    {
        public static SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public bool chk = false;
        public bool chkSwitch = false;

        public frmDashboard()
        {
            InitializeComponent();

            Functions.createChecklistFolders();

            // csak az első indításkor fusson le 
            if (Form1.rDPServers == null)
            {
                Form1.rDPServers = new List<RDPServer>();
                readMstscFolder();
            }
            else 
            {
                int idx = 0;
                foreach (var rdpItem in Form1.rDPServers)
                {
                    listView1.Items.Add(rdpItem.name);
                    listView1.Items[idx].ForeColor = Color.FromArgb(153, 180, 209);
                    idx++;
                }
            }

            initRDPItemsColor();
        }

        #region Functions
        public void initRDPItemsColor()
        {
            int i = 0;
            foreach (var rdpItem in Form1.rDPServers)
            {
                if (rdpItem.done)
                    changeColor(i);
                i++;
            }
        }

        public void changeColor(int index)
        {
            //listView1.Items[index].BackColor = Color.SeaGreen;
            listView1.Invoke(new Action(() => { listView1.Items[index].BackColor = Color.SeaGreen; }));
        }

        public void readMstscFolder()
        {
            try
            {
                // .rdp fájlok beolvasása az mstsc folderből
                DirectoryInfo d = new DirectoryInfo(Functions.ReadSetting("ChklistFolderLocation") + @"\mstsc");
                FileInfo[] Files = d.GetFiles("*.rdp");
                int idx = 0;
                List<string> files = new List<string>();

                foreach (FileInfo file in Files)
                {
                    string folder = file.Name.Substring(0, file.Name.Length - 4);
                    // rDPServers globális lista feltöltése: .rdp fájl neve kiterjesztés nélkül lesz a name prop. a full path az rdpFile
                    //Form1.rDPServers.Add(new RDPServer((file.Name).Substring(0, file.Name.Length - 4), file.FullName, folder, GetPngFiles(folder)));

                    Form1.rDPServers.Add(new RDPServer(folder, file.FullName, folder, GetPngFiles(folder)));

                    // listview1 feltöltése ugyanúgy mint az rDPServers
                    listView1.Items.Add((file.Name).Substring(0, file.Name.Length - 4));
                    listView1.Items[idx].ForeColor = Color.FromArgb(153, 180, 209);
                    idx++;
                }
            }
            catch (IOException ex)
            {
                btnStart.Enabled = false;
                MessageBox.Show(".rdp files are missing!\n\n" + ex.Message);
            }
        }

        private List<string> GetPngFiles(string folder)
        {
            List<string> pngFiles = new List<string>();

            DirectoryInfo d = new DirectoryInfo(Form1.checklistPath + @"\" + Form1.dateString + @"\" + folder);
            FileInfo[] Files = d.GetFiles("*.png");

            // Ha több png fájl van a mappában, azokat is felveszi így egy listába, amit azután visszaad
            foreach (var pngItem in Files)
            {
                pngFiles.Add(pngItem.FullName);
            }

            return pngFiles;
        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Form1.LoadQuestionVoice();

            int x = 0;
            switch (e.Result.Text)
            {
                case "start first ten":
                    if (listView1.Items.Count > 0)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (listView1.Items[i].Checked == false)
                            {
                                listView1.Items[i].Checked = true;
                            }
                        }
                        foreach (ListViewItem s in listView1.CheckedItems)
                        {
                            //Thread.CurrentThread.Suspend();
                            if (x == 0)
                            {
                                //Thread.CurrentThread.Join(2000);
                                Thread secondThread = new Thread(Form1.LoadQuestionVoice);
                                secondThread.Name = "Secondary";
                                secondThread.Start();
                            }
                            //Functions.startProcess(@"\\noname\noname\Checklist\mstsc\" + s.Text);
                            Console.WriteLine(@"\\noname\noname\Checklist\mstsc\" + s.Text);
                            Thread.Sleep(800);
                            x++;
                        }
                        Form1.mic = false;
                        Form1.btnVoiceControl.ForeColor = Color.FromArgb(0, 126, 249);
                        recEngine.RecognizeAsyncStop();
                    }
                    else
                    {
                        MessageBox.Show("RDP list is empty!");
                    }

                    break;
                case "start last ten":

                    break;
                case "start all":

                    break;
            }
        }
        #endregion

        #region Events
        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listview_item in listView1.CheckedItems)
            {
                Functions.startProcess(Form1.checklistPath + @"\mstsc\"+ listview_item.Text + ".rdp");
                Thread.Sleep(800);
            }

            if (printerFszt.Checked == true)
            {
                string strCmdText = $"/c start explorer http://192.168.169.236/wcd/top.xml";
                Process.Start("CMD.exe", strCmdText);
            }

            if (printerEm.Checked == true)
            {
                string strCmdText = $"/c start explorer http://192.168.169.252/wcd/top.xml";
                Process.Start("CMD.exe", strCmdText);
            }

            if (printerMusic.Checked == true)
            {
                string strCmdText = $"/c start explorer http://192.168.169.41/";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }

            if (printerGyartas.Checked == true)
            {
                string strCmdText = $"/c start explorer http://192.168.169.238/";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }

            if (server.Checked == true)
            {
                string strCmdText = $"/c start Powershell -NoExit \\\\noname\\noname\\Checklist\\server.ps1";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }

            if (vSphere.Checked == true)
            {
                string strCmdText = $"/c start explorer https://bigbaby2019.digisport.hu/ui";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }

            if (fujitsu.Checked == true)
            {
                string strCmdText = $"/c start explorer http://fujitsu.digisport.hu/";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }

            if (ANH.Checked == true)
            {
                string strCmdText = $"/c start explorer https://anaphose.digisport.hu/";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }
        }
        //TODO: Thread kezelés, hogy az 'A' hangfájlokat is egyidőben játsza le az RDP megnyitással
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "start first ten", "start last ten", "start all" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            try
            {
                recEngine.SetInputToDefaultAudioDevice();
            }
            catch (Exception)
            {
                //MessageBox.Show("Please check your microphone!\n\nVoice Control is unavaible.");
                Form1.btnVoiceControl.Enabled = false;
            }
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (chk == false)
                {
                    listView1.Items[i].Checked = true;
                    chkSwitch = true;
                }
                else
                {
                    listView1.Items[i].Checked = false;
                    chkSwitch = false;
                }
            }

            if (chkSwitch == true)
            {
                chk = true;
            }
            else
            {
                chk = false;
            }
        }
        #endregion

        private void btn_linuxok_Click(object sender, EventArgs e)
        {
            Functions.startPutty(Form1.puttyUser, "server", "22");
            Functions.startPutty(Form1.puttyUser, "bobafett", "22");
            Functions.startPutty(Form1.puttyUser, "game2020", "22");
            Functions.startPutty(Form1.puttyUser, "bolka", "22");
            Functions.startPutty(Form1.puttyUser, "share", "22");
            //Functions.startPutty(Form1.puttyUser, "openvpn", "22");
            Functions.startPutty(Form1.puttyUser, "192.168.169.99", "22"); //sharefirewall2020
        }

        private void btn_webadm_Click(object sender, EventArgs e)
        {
            Functions.startPutty(Form1.puttyUser, "webadm", "22");
            Functions.startPutty(Form1.puttyUser, "webadm", "22");
            Functions.startPutty(Form1.puttyUser, "webadm", "22");
        }

        private void btn_gluCl_Click(object sender, EventArgs e)
        {
            Functions.startPutty(Form1.puttyUser, "glucl1", "22");
            Functions.startPutty(Form1.puttyUser, "glucl2", "22");
            Functions.startPutty(Form1.puttyUser, "glucl3", "22");
            Functions.startPutty(Form1.puttyUser, "glucl4", "22");
            Functions.startPutty(Form1.puttyUser, "glucl5", "22");
            Functions.startPutty(Form1.puttyUser, "forgatottuj", "22");
        }
    }
}
