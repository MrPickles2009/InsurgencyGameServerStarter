using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;

namespace InsurgencyServerStarter
{
    class HandleComboBoxData
    {
        public void handleSvPlaylist(ComboBox comboBox)
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

        public void handleMpTheaterOverride(ComboBox comboBox)
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

        public void handleMapcycle(ComboBox comboBox)
        {
            StringCollection s = new StringCollection();

            try
            {
                for (int i = 0; i < Properties.Settings.Default.mapcycle.Count; i++)
                {
                    bool Contains = comboBox.Items.Contains(Properties.Settings.Default.mapcycle[i]);
                    if (!Contains)
                    {
                        comboBox.Items.Add(Properties.Settings.Default.mapcycle[i]);
                    }
                }

                var uniques = Properties.Settings.Default.mapcycle.Cast<IEnumerable>();
                var unique = uniques.Distinct();

                foreach (var x in unique)
                {
                    s.Add(x.ToString());
                }

                if (s.Count > 23)
                {
                    s.RemoveAt(22);
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
