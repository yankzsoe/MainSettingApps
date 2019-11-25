using MainSettingApps.yankzsoe.Tools;
using System;
using System.Configuration;

namespace MainSettingApps.yankzsoe {
    public class EncryptedSettings {
        private static string configFilePath = "Config/App.config";
        public static string ConfigFilePath {
            get => configFilePath;
            set => configFilePath = value;
        }
        private static string key = "JakartaSelatan2019";
        public static string Key {
            get => key;
            set => key = value;
        }

        public static Tuple<bool, string> GetTupleMainAppSetting(string settingKey) {
            try {
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                if (config.HasFile) {
                    AppSettingsSection appSettings = config.AppSettings;
                    KeyValueConfigurationElement element = appSettings.Settings[settingKey];
                    var result = AesEncryption.DecryptString(Key, element.Value);
                    return new Tuple<bool, string>(true, result);
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
                    var result = AesEncryption.DecryptString(Key, con.ConnectionStrings[connectionStringName].ConnectionString);
                    return new Tuple<bool, string>(true, result);
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
                    var result = AesEncryption.DecryptString(Key, element.Value);
                    return result;
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
                    var result = AesEncryption.DecryptString(Key, con.ConnectionStrings[connectionStringName].ConnectionString);
                    return result;
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
                    var cipherString = AesEncryption.EncryptString(Key, newValue);
                    config.AppSettings.Settings[settingKey].Value = cipherString;
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
                    var cipherString = AesEncryption.EncryptString(Key, newValue);
                    config.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = cipherString;
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
