using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using PCLConvert.Patterns;

namespace PCLConvert.Util
{
    public sealed class PCLConvertManager : SingletonBase<PCLConvertManager>
    {
        private PCLConvertManager()
        {
        }

        private bool IsXPSFile(string filePath)
        {
            var firstLine = File.ReadLines(filePath).First();
            return firstLine.Contains("[Content_Types].xml");
        }

        public bool ConvertToPDF(string sourcePath, string destPath, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                var ghostFileName = ConfigManager.Instance.GhostPCLPath;
                if (IsXPSFile(sourcePath))
                {
                    ghostFileName = ConfigManager.Instance.GhostXPSPath;
                }

                var startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = false,
                    UseShellExecute = true,
                    FileName = ghostFileName,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = $"-o \"{destPath}\" -sDEVICE=pdfwrite -f \"{sourcePath}\""
                };

                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                }

                return true;
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }

        }
    }
}
