using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsurgencyServerStarter
{
    public partial class Form1 : Form
    {
        static string dirToSearch = (@"C:\SteamCMD\steamapps\common\Insurgency Dedicated Server\insurgency\cfg\").Replace("\\", "/");
        string serverCfgFile = File.ReadAllText(dirToSearch + "server.cfg");

        public Form1()
        {
            InitializeComponent();

            try
            {
                comboBox1.Text = Properties.Settings.Default.sv_playlist[0];
                comboBox2.Text = Properties.Settings.Default.mp_theater_override[0];
                comboBox3.Text = Properties.Settings.Default.mapcycle[0];
                comboBox4.Enabled = false;
            }
            catch (Exception)
            {
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;
            }

            HandleComboBoxData handleComboBoxData = new HandleComboBoxData();
            handleComboBoxData.handleSvPlaylist(comboBox1);
            handleComboBoxData.handleMpTheaterOverride(comboBox2);
            handleComboBoxData.handleMapcycle(comboBox3);
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
            string[] selectedMapcycleDir = File.ReadAllText(mapcycleDir + comboBox3.Text).Split("\n".ToCharArray());

            comboBox4.Items.Clear();
            foreach (var item in selectedMapcycleDir)
            {
                comboBox4.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.sv_playlist.Insert(0, comboBox1.Text);
            Properties.Settings.Default.mp_theater_override.Insert(0, comboBox2.Text);
            Properties.Settings.Default.mapcycle.Insert(0, comboBox3.Text);
            Properties.Settings.Default.Save();

            string srcdsDir = @"C:\SteamCMD\steamapps\common\Insurgency Dedicated Server\srcds.exe";
            string startServerCommand = $"-console +map {comboBox4.SelectedItem} +maxplayers 32 -workshop +IP -condebug";

            var proc = new Process();
            proc.StartInfo.FileName = srcdsDir;
            proc.StartInfo.Arguments = startServerCommand;
            proc.Start();
            proc.WaitForExit();
            var exitCode = proc.ExitCode;
            proc.Close();
        }

        private void ManipulateFiles( Regex rx, string textToReplace)
        {
            string fileInfoReplaced = Regex.Replace(serverCfgFile, rx.ToString(), textToReplace);
            serverCfgFile = fileInfoReplaced;
            File.WriteAllText(dirToSearch + "server.cfg", fileInfoReplaced);
        }
    }
}
