using System;
using System.IO;
using System.Windows.Forms;
using PCLConvert.Patterns;
using PCLConvert.Properties;

namespace PCLConvert.Util
{
    public sealed class ConfigManager : SingletonBase<ConfigManager>
    {
        public static readonly string LangEnglish = "en-US";
        public static readonly string LangSimplifiedChinese = "zh-CN";
        public static readonly string LangTraditionalChinese = "zh-TW";

        private ConfigManager()
        {
            string rootPath = Path.GetDirectoryName(Application.ExecutablePath);
            if (Environment.Is64BitOperatingSystem)
            {
                GhostPCLPath = $"{rootPath}\\ghostpcl-win64\\gpcl6win64.exe";
                GhostXPSPath = $"{rootPath}\\ghostxps-win64\\gxpswin64.exe";
            }
            else
            {
                GhostPCLPath = $"{rootPath}\\ghostpcl-win32\\gpcl6win32.exe";
                GhostXPSPath = $"{rootPath}\\ghostxps-win32\\gxpswin32.exe";
            }
            ReloadSettings();
        }

        public void ReloadSettings()
        {
            IsOpenAfterConvert = Settings.Default.OpenAfterConvert;
            Language = (string)Settings.Default.Lang;
        }

        public void SaveOpenAfterConvert(bool value)
        {
            Settings.Default.OpenAfterConvert = value;
            Settings.Default.Save();
            ReloadSettings();
        }

        public void SaveLange(string value)
        {
            if (value != LangEnglish && value != LangSimplifiedChinese && value != LangTraditionalChinese)
            {
                throw new ArgumentOutOfRangeException("Invalid language");
            }

            Settings.Default.Lang = value;
            Settings.Default.Save();
            ReloadSettings();
        }

        public string GhostPCLPath { get; private set; }

        public string GhostXPSPath { get; private set; }

        public bool IsOpenAfterConvert { get; private set; }

        public string Language { get; private set; }
    }
}
