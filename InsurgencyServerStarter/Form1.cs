using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace InsurgencyServerStarter
{
    public partial class Form1 : Form
    {
        static string dirToSearch = (@"C:\SteamCMD\steamapps\common\Insurgency Dedicated Server\insurgency\cfg\").Replace("\\", "/");
        string serverCfgFile = File.ReadAllText(dirToSearch + "server.cfg");
        string randomMap = "random";
        string startServerText = "Start Server";
        string stopServerText = "Stop Server";
        bool isStarted = false;

        public Form1()
        {
            InitializeComponent();

            HandleComboBoxData handleComboBoxData = new HandleComboBoxData();
            handleComboBoxData.handleSvPlaylist(comboBox1);
            handleComboBoxData.handleMpTheaterOverride(comboBox2);
            handleComboBoxData.handleMapcycle(comboBox3);

            try
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;

                comboBox4.Enabled = false;
                if (!Properties.Settings.Default.mapcycle.Contains(string.Empty))
                    comboBox4.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regex svPlaylistRx = new Regex(@"sv_playlist.\""(.{1,128})\""");
            string svPlaylist = $"sv_playlist \"{comboBox1.Text}\"";
            ManipulateFiles(svPlaylistRx, svPlaylist);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regex mpTheaterOverrideRx = new Regex(@"mp_theater_override.\""(.{1,128})\""");
            string mpTheaterOverride = $"mp_theater_override \"{comboBox2.Text}\"";
            ManipulateFiles(mpTheaterOverrideRx, mpTheaterOverride);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regex mapCycleFileRx = new Regex(@"mapcyclefile.\""(.{1,128})\""");
            string mapCycleFile = $"mapcyclefile \"{comboBox3.Text}\"";
            ManipulateFiles(mapCycleFileRx, mapCycleFile);
            comboBox4.Enabled = true;

            string mapcycleDir = (@"C:\SteamCMD\steamapps\common\Insurgency Dedicated Server\insurgency\").Replace("\\", "/");

            try
            {
                string[] selectedMapcycleDir = File.ReadAllText(mapcycleDir + comboBox3.Text).Split("\n".ToCharArray());

                comboBox4.Items.Clear();

                comboBox4.Items.Add(randomMap);
                foreach (var item in selectedMapcycleDir)
                {
                    comboBox4.Items.Add(item);
                }

                comboBox4.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show($"{comboBox3.SelectedItem} file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.sv_playlist.Insert(0, comboBox1.Text);
            Properties.Settings.Default.mp_theater_override.Insert(0, comboBox2.Text);
            Properties.Settings.Default.mapcycle.Insert(0, comboBox3.Text);
            Properties.Settings.Default.Save();

            var gameMap = comboBox4.SelectedItem;

            if (gameMap == randomMap)
                gameMap = comboBox4.Items[new Random().Next(0, comboBox4.Items.Count)];

            string srcdsDir = @"C:\SteamCMD\steamapps\common\Insurgency Dedicated Server\srcds.exe";
            string startServerCommand = $"-console +map {gameMap} +maxplayers 32 -workshop +IP -condebug";

            Process proc = new Process();
            proc.StartInfo.FileName = srcdsDir;
            proc.StartInfo.Arguments = startServerCommand;

            ThreadStart serverThreadStart = new ThreadStart(() => proc.Start());
            Thread serverThread = new Thread(serverThreadStart);

            if (isStarted)
            {
                Process[] processes = Process.GetProcessesByName("srcds");
                processes[0].Kill();
                button1.Text = startServerText;
                isStarted = false;
            }
            else
            {
                serverThread.Start();
                button1.Text = stopServerText;
                isStarted = true;
            }
        }

        private void ManipulateFiles( Regex rx, string textToReplace)
        {
            string fileInfoReplaced = Regex.Replace(serverCfgFile, rx.ToString(), textToReplace);
            serverCfgFile = fileInfoReplaced;
            File.WriteAllText(dirToSearch + "server.cfg", fileInfoReplaced);
        }
    }
}
