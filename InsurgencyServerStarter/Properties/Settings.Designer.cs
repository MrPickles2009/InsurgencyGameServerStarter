﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsurgencyServerStarter.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>nwi/comp</string>
  <string>nwi/coop</string>
  <string>nwi/coop_elite</string>
  <string>nwi/coop_hardcore</string>
  <string>nwi/pvp_sustained</string>
  <string>nwi/pvp_tactical</string>
  <string>nwi/conquer</string>
  <string>nwi/training</string>
  <string>custom</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection sv_playlist {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["sv_playlist"]));
            }
            set {
                this["sv_playlist"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>35ab_expansion</string>
  <string>sandstormsource_insgamer</string>
  <string>theater_35angrybots8p_default</string>
  <string>theater_35angrybots8p_medic_default</string>
  <string>theater_thearmory8pnocost_default</string>
  <string>armory_pvp_default</string>
  <string>doi</string>
  <string>theater_default_training</string>
  <string>default</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection mp_theater_override {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["mp_theater_override"]));
            }
            set {
                this["mp_theater_override"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>mapcycle.txt</string>
  <string>mapcycle_all.txt</string>
  <string>mapcycle_ambush.txt</string>
  <string>mapcycle_attackdefend.txt</string>
  <string>mapcycle_checkpoint.txt</string>
  <string>mapcycle_comp.txt</string>
  <string>mapcycle_conquer.txt</string>
  <string>mapcycle_cooperative.txt</string>
  <string>mapcycle_doi.txt</string>
  <string>mapcycle_firefight.txt</string>
  <string>mapcycle_flashpoint.txt</string>
  <string>mapcycle_hunt.txt</string>
  <string>mapcycle_infiltrate.txt</string>
  <string>mapcycle_objrespawn.txt</string>
  <string>mapcycle_occupy.txt</string>
  <string>mapcycle_practice.txt</string>
  <string>mapcycle_push.txt</string>
  <string>mapcycle_singlelife.txt</string>
  <string>mapcycle_skirmish.txt</string>
  <string>mapcycle_strike.txt</string>
  <string>mapcycle_survival.txt</string>
  <string>mapcycle_sustained_combat.txt</string>
  <string>mapcycle_tactical_operations.txt</string>
  <string>mapcycle_training.txt</string>
  <string>mapcycle_workshop.txt</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection mapcycle {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["mapcycle"]));
            }
            set {
                this["mapcycle"] = value;
            }
        }
    }
}
