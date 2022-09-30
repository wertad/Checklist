using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Management;

namespace Checklist
{
    internal class Functions
    {
        #region SetProcessDisplay
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;

        #endregion

        //
        // Elindítja a megkapott fájlt
        //
        public static void startProcess(string targetFile)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = targetFile;
                    myProcess.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        // Megadható az is, hogy melyik kijelzőre küldje a process-t
        //
        // TODO: Az mstsc process-ek nem mozognak át a kijelölt monitorra, mert cmd-ből vannak indítva
        // 
        public static void startProcess(string targetFile, int preferredMonitor)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = targetFile;
                    myProcess.Start();

                    // Maximum 5mp-es várakozás hogy a process aktív legyen
                    myProcess.WaitForInputIdle(5000);
                    Thread.Sleep(500);

                    if (Screen.AllScreens.Length >= preferredMonitor)
                    {
                        SetWindowPos(myProcess.MainWindowHandle,
                            IntPtr.Zero,
                            Screen.AllScreens[preferredMonitor].WorkingArea.Left,
                            Screen.AllScreens[preferredMonitor].WorkingArea.Top,
                            0, 0, SWP_NOSIZE | SWP_NOZORDER);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void startProcess(string targetFile, int preferredMonitor, string processName)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    // Kilövi a megadott processt, különben nem kapnánk meg a MainWindowHandle-t a SetWindowPos metódusban
                    List<Process> existingProcesses = Process.GetProcessesByName(processName).ToList();

                    if(existingProcesses.Count > 0)
                    {
                        MessageBox.Show("Save all data and close all paint.net applications before continue...");

                        foreach (var existingProcess in existingProcesses)
                        {
                            existingProcess.Kill();
                        }
                    }

                    myProcess.StartInfo.FileName = targetFile;
                    myProcess.Start();

                    // Maximum 5mp-es várakozás hogy a process aktív legyen
                    myProcess.WaitForInputIdle(5000);
                    Thread.Sleep(500);

                    if (Screen.AllScreens.Length >= preferredMonitor)
                    {
                        SetWindowPos(myProcess.MainWindowHandle,
                            IntPtr.Zero,
                            Screen.AllScreens[preferredMonitor].WorkingArea.Left,
                            Screen.AllScreens[preferredMonitor].WorkingArea.Top,
                            0, 0, SWP_NOSIZE | SWP_NOZORDER);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void startPutty(string user, string server, string port)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.Arguments = "-ssh " + user + "@" + server + " -P " + port;
                    myProcess.StartInfo.FileName = Form1.puttyPath;
                    myProcess.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void startPainNet()
        {
            string paintInstallLocation = FindInRegistry();

            if (paintInstallLocation != null)
            {
                startProcess(paintInstallLocation + @"\PaintDotNet.exe");
            }
            else
            {
                MessageBox.Show("A paint.net elérési útja nem található, kérlek indítsd kézzel!");
            }
        }
        //TODO: display kiszedése innen (elég csak az RDP-nek megadni, hogy melyik képernyőn nyíljon meg)
        public static void startPainNet(int display, string processName)
        {
            string paintInstallLocation = FindInRegistry();

            if (paintInstallLocation != null)
            {
                startProcess(paintInstallLocation + @"\PaintDotNet.exe", display, processName);
            }
            else
            {
                //TODO: fordítás - "A paint.net elérési útja nem található, kérlek indítsd kézzel!"
                MessageBox.Show("A paint.net elérési útja nem található, kérlek indítsd kézzel!");
            }
        }

        public static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                return "Error";
            }
        }
        //
        // App.Config fájlba írás
        //
        public static void WriteSetting(string key, string value)
        {
            try
            {
                //Ahhoz, hogy használni tujda a ConfigurationManagert a következőket kell tenni:
                //
                //You have also to add the reference to the assembly System.Configuration.dll , by
                //1. - Right - click on the References / Dependencies
                //2. - Choose Add Reference
                //3. - Find and add System.Configuration.

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public static string FindInRegistry()
        {
            // Registryből kikeresi a paint.net telepítési helyét, és visszaadja

            try
            {
                RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64); // <--- ha 32 bit-es akkor elvileg RegistryView.Registry32
                localKey = localKey.OpenSubKey(@"SOFTWARE\paint.net\");
                string match = Convert.ToString(localKey.GetValue("TARGETDIR"));
                return match;
            }
            catch
            {

            }
            return null;
        }

        public static void createChecklistFolders()
        {
            DateTime time = DateTime.Now;
            string dateString;
            dateString = time.ToString("yyyy.MM.dd");
            if (!Directory.Exists(Form1.checklistPath +  @"\" + dateString))
            {
                string strCmdText = $"/c start Powershell -NoExit -ExecutionPolicy Bypass cd \\\\noname\\noname\\Checklist; .\\check-konyvtarak.ps1";
                Process.Start("CMD.exe", strCmdText);
            }

            // Ellenőrzi, hogy a check-konyvtarak.ps1 fájl legvégén gyártott ~\Checklist\{mai.datum}\done.tmp jelzőfájl létezik-e, ha nem, akkor 3mp-ig várakozik.
            // A done.tmp fájlra azért van szükség, mert a program jelenleg kiakad, ha nem készül el időben a check-konyvtarak.ps1 a mappákkal és png fájlokkal
            // A program gyorsabban lefut, mint a vele párhuzamosan dolgozó check-konyvtarak.ps1
            // Ezt azért majd jó lenne átírni máshogy...
            int sleeptime = 0;
            while (!File.Exists(Form1.checklistPath + @"\" + dateString + @"\done.tmp"))
            {
                Thread.Sleep(100);
                sleeptime += 100;
                if (sleeptime > 3000)
                {
                    break;
                }
            }
            if (File.Exists(Form1.checklistPath + @"\" + dateString + @"\done.tmp"))
            {
                File.SetAttributes(Form1.checklistPath + @"\" + dateString + @"\done.tmp", FileAttributes.Hidden);
            }
        }

        public static List<string> LoadSoundPacks()
        {
            var sp = new Root();
            sp.soundpacks = new List<SoundPack> { };

            List<string> soundpacks = new List<string>();
            try
            {
                // Beolvassa a sounds mappa almappáit, és amelyikben van A és Q almappa, és azokban mp3 fájl, azt hozzáadja a comboboxhoz
                // Majd ezeket kiírja egy soundpacks.json fájlba
                // Végül visszaad egy listát, hogy fel lehessen tölteni a comboboxot
                int aq = 0;
                DirectoryInfo soundsDir = new DirectoryInfo(@".\sounds\");
                DirectoryInfo[] dirs = soundsDir.GetDirectories();

                foreach (DirectoryInfo item in dirs)
                {
                    DirectoryInfo soundsSubdir = new DirectoryInfo(item.FullName);
                    DirectoryInfo[] subDirs = soundsSubdir.GetDirectories();

                    string[] mp3sA = { };
                    string[] mp3sQ = { };

                    foreach (DirectoryInfo subItem in subDirs)
                    {
                        if (subItem.Name == "A")
                        {
                            mp3sA = Directory.GetFiles(subItem.FullName, "*.mp3");
                            if (mp3sA.Length > 0)
                                aq++;
                        }
                        else if (subItem.Name == "Q")
                        {
                            mp3sQ = Directory.GetFiles(subItem.FullName, "*.mp3");
                            if (mp3sQ.Length > 0)
                                aq++;
                        }
                    }

                    if (aq == 2)
                    {
                        sp.soundpacks.Add(new SoundPack { name = item.Name, A = mp3sA, Q = mp3sQ });

                        string JSONresult = JsonConvert.SerializeObject(sp, Formatting.Indented);
                        string path = (AppDomain.CurrentDomain.BaseDirectory + "soundpacks.json");

                        using (var tw = new StreamWriter(path, false))
                        {
                            tw.WriteLine(JSONresult.ToString());
                            tw.Close();
                        }

                        soundpacks.Add(item.Name);
                    }
                    //else
                        //MessageBox.Show(item.FullName + " is dosen't contain A and/or Q folder(s)!");
                    aq = 0;
                }

                return soundpacks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static SoundPack GetVoicePack(string selectedVoicePackName)
        {
            SoundPack voicePack = null;
            string voicePackJsonFile = (AppDomain.CurrentDomain.BaseDirectory + "soundpacks.json");

            using(StreamReader sr = new StreamReader(voicePackJsonFile))
            {
                string jsonData = sr.ReadToEnd();
                dynamic data = JObject.Parse(jsonData);

                voicePack = new SoundPack();

                for (int i = 0; i < data.soundpacks.Count; i++)
                {
                    if (data.soundpacks[i].name == selectedVoicePackName)
                    {
                        voicePack.name = data.soundpacks[i].name;
                        voicePack.A = (data.soundpacks[i].A).ToObject<string[]>();
                        voicePack.Q = (data.soundpacks[i].Q).ToObject<string[]>();
                    }
                    else
                    {
                        voicePack.name = data.soundpacks[0].name;
                        voicePack.A = (data.soundpacks[0].A).ToObject<string[]>();
                        voicePack.Q = (data.soundpacks[0].Q).ToObject<string[]>();
                    }
                }
            }
            return voicePack;
        }

        public static void InitSettings()
        {
            if (Functions.ReadSetting("ChklistFolderLocation") == "Not Found")
            {
                Functions.WriteSetting("ChklistFolderLocation", @"\\noname\noname\Checklist");
                Form1.checklistPath = @"\\noname\noname\Checklist";
            }

            if (Functions.ReadSetting("RDP_Display") == "Not Found")
            {
                Functions.WriteSetting("RDP_Display", "0");
            }
        }

        public static List<string> GetMonitorsFriendlyNames()
        {
            List<string> monitors = new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "select * from WMIMonitorID");

            string data = string.Empty;
            int idx = 0;

            foreach (ManagementObject managementObject in searcher.Get())
            {
                foreach (PropertyData property in managementObject.Properties)
                {
                    if (property.Value != null)
                        if (property.Name != "UserFriendlyName")
                            data += string.Format("{0}: {1}{2}", property.Name, property.Value.ToString(), System.Environment.NewLine);
                        else
                        {
                            idx++;
                            data += string.Format("{0}: {1}{2}", property.Name, property.Value.ToString(), System.Environment.NewLine);
                            object tempObj = (object)property.Value;
                            UInt16[] ushortArray = ((System.Collections.IEnumerable)tempObj).Cast<object>().Select(x => Convert.ToUInt16(x)).ToArray();

                            byte[] buf = new byte[Buffer.ByteLength(ushortArray)]; // 2 bytes per short
                            Buffer.BlockCopy(ushortArray, 0, buf, 0, Buffer.ByteLength(ushortArray));

                            monitors.Add(idx + " - " + System.Text.Encoding.ASCII.GetString(buf).Replace("\0", String.Empty));
                        }
                }
            }
            return monitors;
        }
    }
}
