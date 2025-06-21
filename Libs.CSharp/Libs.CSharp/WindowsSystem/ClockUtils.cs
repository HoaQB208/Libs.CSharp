using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System;

namespace Libs.CSharp.WindowsSystem
{
    public class ClockUtils
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetSystemTime(ref SYSTEMTIME st);

        public static async Task<string> TimeSync()
        {
            try
            {
                return await Task.Run(() =>
                {
                    DateTime currentTime = GetNetworkTime();
                    SYSTEMTIME st = new SYSTEMTIME()
                    {
                        wYear = (short)currentTime.Year,
                        wMonth = (short)currentTime.Month,
                        wDay = (short)currentTime.Day,
                        wHour = (short)currentTime.Hour,
                        wMinute = (short)currentTime.Minute,
                        wSecond = (short)currentTime.Second
                    };
                    SetSystemTime(ref st);
                    return "";
                });
            }
            catch (Exception ex) { return ex.Message; }
        }


        private static DateTime GetNetworkTime()
        {
            DateTime time = new DateTime();
            TcpClient client = new TcpClient("time.nist.gov", 13);
            using (StreamReader streamReader = new StreamReader(client.GetStream()))
            {
                string response = streamReader.ReadToEnd();
                string utcDateTimeString = response.Substring(7, 17);
                time = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            }
            return time.AddHours(-7);
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }
    }
}
