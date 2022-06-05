using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InsurgencyServerStarter
{
    class HandleComboBoxData
    {
        public void HandleSvPlaylist(ComboBox comboBox)
        {
            StringCollection s = new StringCollection();

            try
            {
                for (int i = 0; i < Properties.Settings.Default.sv_playlist.Count; i++)
                {
                    bool Contains = comboBox.Items.Contains(Properties.Settings.Default.sv_playlist[i]);
                    if (!Contains)
                    {
                        comboBox.Items.Add(Properties.Settings.Default.sv_playlist[i]);
                    }
                }

                var uniques = Properties.Settings.Default.sv_playlist.Cast<IEnumerable>();
                var unique = uniques.Distinct();

                foreach (var x in unique)
                {
                    s.Add(x.ToString());
                }

                if (s.Count > 9)
                {
                    s.RemoveAt(8);
                }

                Properties.Settings.Default.sv_playlist = s;
            }
            catch (Exception)
            {
                Properties.Settings.Default.sv_playlist = s;
            }
        }

        public void HandleMpTheaterOverride(ComboBox comboBox)
        {
            StringCollection s = new StringCollection();

            try
            {
                for (int i = 0; i < Properties.Settings.Default.mp_theater_override.Count; i++)
                {
                    bool Contains = comboBox.Items.Contains(Properties.Settings.Default.mp_theater_override[i]);
                    if (!Contains)
                    {
                        comboBox.Items.Add(Properties.Settings.Default.mp_theater_override[i]);
                    }
                }

                var uniques = Properties.Settings.Default.mp_theater_override.Cast<IEnumerable>();
                var unique = uniques.Distinct();

                foreach (var x in unique)
                {
                    s.Add(x.ToString());
                }

                if (s.Count > 3)
                {
                    s.RemoveAt(2);
                }

                Properties.Settings.Default.mp_theater_override = s;
            }
            catch (Exception)
            {
                Properties.Settings.Default.mp_theater_override = s;
            }
        }

        public void HandleMapcycle(string mapcycleDir, ComboBox comboBox)
        {
            List<string> mapcycleFileDirs = Directory.GetFiles(mapcycleDir).Where(w => w.Contains("mapcycle_")).ToList();
            StringCollection s = new StringCollection();
            StringCollection sc = new StringCollection();

            try
            {
                foreach (var mapcycleFileDir in mapcycleFileDirs)
                {
                    var mapcycleName = mapcycleFileDir.Substring(mapcycleFileDir.LastIndexOf("/") + 1);
                    if (!comboBox.Items.Contains(mapcycleName))
                    {
                        comboBox.Items.Add(mapcycleName);
                        s.Add(mapcycleName);
                    }
                }

                Properties.Settings.Default.mapcycle = s;
            }
            catch (Exception)
            {
                Properties.Settings.Default.mapcycle = s;
            }
        }
    }
}
