using System.Diagnostics;

namespace Libs.CSharp.WindowsSystem
{
    public class ProcessManager
    {
        public static void Kill(int processId)
        {
            var process = Process.GetProcessById(processId);
            if (process != null)
            {
                process.Kill();
                process.WaitForExit();
            }
        }
    }
}
