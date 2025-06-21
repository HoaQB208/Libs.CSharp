using Microsoft.Win32;
using System;

namespace Libs.CSharp.WindowsSystem
{
    public class RunAtStartup
    {
        public static bool Set(string appName, string appPath)
        {
            try
            {
                Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true).SetValue(appName, appPath);
                return true;
            }
            catch { }
            return false;
        }

        public static bool Check(string appName, string appPath)
        {
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                string registryValue = (string)reg.GetValue(appName);
                return (registryValue != null && registryValue.Equals(appPath, StringComparison.OrdinalIgnoreCase));
            }
            catch { }
            return false;
        }

        public static bool Remove(string appName)
        {
            try
            {
                Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true).DeleteValue(appName, false);
                return true;
            }
            catch { }
            return false;
        }
    }
}
