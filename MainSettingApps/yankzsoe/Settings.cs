﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSettingApps.yankzsoe {
    class Settings {
        public static string ConfigFilePath { get; set; }
        public static Tuple<bool, string> GetTupleMainAppSetting(string settingSection) {
            try {
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                if (config.HasFile) {
                    AppSettingsSection appSettings = config.AppSettings;
                    KeyValueConfigurationElement element = appSettings.Settings[settingSection];
                    return new Tuple<bool, string>(true, element.Value);
                } else {
                    return new Tuple<bool, string>(false, null);
                }
            } catch (Exception es) {
                throw es;
            }
        }

        public static Tuple<bool, string> GetTupleMainConnectionString(string connectionStringName) {
            try {
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                if (config.HasFile) {
                    ConnectionStringsSection con = config.ConnectionStrings;
                    return new Tuple<bool, string>(true, con.ConnectionStrings[connectionStringName].ConnectionString);
                } else {
                    return new Tuple<bool, string>(false, null);
                }
            } catch (Exception es) {
                throw es;
            }
        }

        public static string GetStringMainAppSetting(string settingSection) {
            try {
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                if (config.HasFile) {
                    AppSettingsSection appSettings = config.AppSettings;
                    KeyValueConfigurationElement element = appSettings.Settings[settingSection];
                    return element.Value;
                } else {
                    return null;
                }
            } catch (Exception es) {
                throw es;
            }
        }

        public static string GetStringMainConnectionString(string connectionStringName) {
            try {
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                if (config.HasFile) {
                    ConnectionStringsSection con = config.ConnectionStrings;
                    return con.ConnectionStrings[connectionStringName].ConnectionString;
                } else {
                    return null;
                }
            } catch (Exception es) {
                throw es;
            }
        }
    }
}