using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSettingApps.yankzsoe {
    class Settings {
        public static string ConfigFilePath { get; set; }
        public static Tuple<bool, string> GetTupleMainAppSetting(string settingKey) {
            try {
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                if (config.HasFile) {
                    AppSettingsSection appSettings = config.AppSettings;
                    KeyValueConfigurationElement element = appSettings.Settings[settingKey];
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

        public static string GetStringMainAppSetting(string settingKey) {
            try {
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                if (config.HasFile) {
                    AppSettingsSection appSettings = config.AppSettings;
                    KeyValueConfigurationElement element = appSettings.Settings[settingKey];
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

        public static bool UpdateMainAppSetting(string settingKey, string newValue) {
            try {
                bool result = false;
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                if (config.HasFile) {
                    config.AppSettings.Settings[settingKey].Value = newValue;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    result = true;
                } else {
                    result = false;
                }
                return result;
            } catch (Exception es) {
                throw es;
            }
        }

        public static bool UpdateMainConnectionString(string connectionStringName, string newValue) {
            try {
                bool result = false;
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                if (config.HasFile) {
                    config.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = newValue;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    result = true;
                } else {
                    result = false;
                }
                return result;
            } catch (Exception es) {
                throw es;
            }
        }
    }
}
