using System;
using System.Diagnostics;
using PCLConvert.Patterns;

namespace PCLConvert.Util
{
    public sealed class PCLConvertManager : SingletonBase<PCLConvertManager>
    {
        private PCLConvertManager()
        {
        }

        public bool ConvertPCLToPDF(string sourcePath, string destPath, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                var startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;
                startInfo.FileName = ConfigManager.Instance.GhostPCLPath;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = $"-o {destPath} -sDEVICE=pdfwrite -f {sourcePath}";

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
