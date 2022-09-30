using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Management;

namespace Checklist
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            // App.config fájlból beolvassa és beállítja a mentett beállításokat.
            puttyComboBox.Text = Functions.ReadSetting("puttyUser");
            puttyTextBox.Text = Functions.ReadSetting("puttyLocation");

            // Ha nincs kitöltve vagy Not Found a Cheklist mappa elérési útja, akkor beállítja az elérést erre: \\noname\noname\Checklist
            if ((new[] { "", "Not Found", " " }).Contains(Functions.ReadSetting("ChklistFolderLocation"))) // ha minden igaz ez a megoldás a LINQ megközelítés
            {
                checklistTextBox.Text = @"\\noname\noname\Checklist";
            }
            // különben beállítja a Chekclist Folder-t az app.config-ból
            else
            {
                checklistTextBox.Text = Functions.ReadSetting("ChklistFolderLocation");
            }

            Initialize_cmboxDefaultDisplayRDP();
        }

        private void checklistTextBox_TextChanged(object sender, EventArgs e)
        {
            Functions.WriteSetting("ChklistFolderLocation", checklistTextBox.Text);
            Form1.checklistPath = checklistTextBox.Text;
        }

        private void puttyTextBox_TextChanged(object sender, EventArgs e)
        {
            Functions.WriteSetting("puttyLocation", puttyTextBox.Text);
            Form1.puttyPath = puttyTextBox.Text;
        }

        private void puttyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Functions.WriteSetting("puttyUser", puttyComboBox.Text);
            Form1.puttyUser = puttyComboBox.Text;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            Initialize_cboxSoundPack();

            string selectedVoicePack = Functions.ReadSetting("selectedVoicePack");
            if (selectedVoicePack == "" || selectedVoicePack == "Not Found")
            {
                cmboxSoundPack.SelectedIndex = 0;
            }
            else
            {
                //cboxSoundPack.Text = Functions.ReadSetting("selectedVoicePack");
                cmboxSoundPack.Text = Form1.voice.name;
                if (Functions.ReadSetting("voiceEnabled") == "1")
                {
                    cmboxSoundPack.Enabled = true;
                    chkboxEnableSounds.Checked = true;
                }
                else
                {
                    cmboxSoundPack.Enabled = false;
                    chkboxEnableSounds.Checked = false;
                }
            }
        }
        private void Initialize_cmboxDefaultDisplayRDP()
        {
            cmboxDefaultDisplayRDP.Items.Clear();

            foreach (var item in Form1.monitors)
            {
                cmboxDefaultDisplayRDP.Items.Add(item);
            }
                
            try
            {
                cmboxDefaultDisplayRDP.SelectedIndex = Convert.ToInt32(Functions.ReadSetting("RDP_Display"));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                cmboxDefaultDisplayRDP.SelectedIndex = 0;
                Functions.WriteSetting("RDP_Display", "0");
            }
            catch(FormatException ex)
            {
                cmboxDefaultDisplayRDP.SelectedIndex = 0;
                Functions.WriteSetting("RDP_Display", "0");
            }

            if ((cmboxDefaultDisplayRDP.Items.Count > 0) && (cmboxDefaultDisplayRDP.SelectedIndex == -1))
            {
                cmboxDefaultDisplayRDP.SelectedIndex = 0;
                Functions.WriteSetting("RDP_Display", "0");
            }
        }
        private void Initialize_cboxSoundPack()
        {
            // Feltölti a Functions.LoadSoundPacks() által List<string> soundpacks-ben tárolt lista alapján a comboboxot
            foreach (var item in Form1.soundpacks)
            {
                cmboxSoundPack.Items.Add(item);
            }
        }

        public void RefreshVoicePackList()
        {
            cmboxSoundPack.Items.Clear();
            Form1.soundpacks = Functions.LoadSoundPacks();
            Initialize_cboxSoundPack();
        }

        // Ha a comboboxból másik voicepackot választanak ki, beírja az appconfigba a változást,
        // beállítja a voice SoundPack objectumot.
        private void cboxSoundPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            Functions.WriteSetting("selectedVoicePack", Convert.ToString(cmboxSoundPack.Text));
            Form1.voiceEnabled = true;
            Form1.voice = Functions.GetVoicePack(Functions.ReadSetting("selectedVoicePack"));
        }

        private void chkboxEnableSounds_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkboxEnableSounds.Checked)
            {
                Functions.WriteSetting("voiceEnabled", "1");
                cmboxSoundPack.Enabled = true; 
                Form1.voiceEnabled = true;
            }
            else
            {
                Functions.WriteSetting("voiceEnabled", "0");
                cmboxSoundPack.Enabled = false;
                Form1.voiceEnabled= false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshVoicePackList();
        }

        private void cmboxDefaultDisplayRDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Functions.WriteSetting("RDP_Display", Convert.ToString(cmboxDefaultDisplayRDP.SelectedIndex));
        }

        private void puttyBrowserButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                //InitialDirectory = @"C:\",
                Title = "Browse Exe Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "exe",
                Filter = "exe files (*.exe)|*.exe",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                puttyTextBox.Text = openFileDialog1.FileName;
                Functions.WriteSetting("puttyLocation", openFileDialog1.FileName);
            }
        }

        private void checklistBrowserButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                checklistTextBox.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                Functions.WriteSetting("ChklistFolderLocation", folderDlg.SelectedPath);
            }
        }
    }
}
