using System.Diagnostics;

namespace Libs.CSharp.WindowsSystem
{
    public class PowerStates
    {
        public static void Shutdown()
        {
            Process.Start("shutdown", "/s /t 0");
        }

        public static void ShutdownAnyway()
        {
            Process.Start("shutdown", "/s /f /t 0");
        }
    }
}
