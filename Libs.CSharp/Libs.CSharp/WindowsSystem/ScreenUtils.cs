using System.Windows;

namespace Libs.CSharp.WindowsSystem
{
    public class ScreenUtils
    {
        public static (double, double) GetPrimaryScreenSize()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            return (screenWidth, screenHeight);
        }
    }
}
