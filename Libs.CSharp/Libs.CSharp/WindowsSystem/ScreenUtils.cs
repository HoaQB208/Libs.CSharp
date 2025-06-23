using System.Windows;

namespace Libs.CSharp.WindowsSystem
{
    public class ScreenUtils
    {
        public static void GetPrimaryScreenSize(out double screenWidth, out double screenHeight)
        {
            screenWidth = SystemParameters.PrimaryScreenWidth;
            screenHeight = SystemParameters.PrimaryScreenHeight;
        }
    }
}
