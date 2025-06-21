using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System;

namespace Libs.CSharp.WindowsSystem
{
    public class FileFolderSecurity
    {
        public static string SetAccessControl(string path, string userAccount = "Everyone")
        {
            try
            {
                if (File.Exists(path))
                {
                    FileSecurity security = new FileSecurity();
                    security.AddAccessRule(new FileSystemAccessRule(userAccount, FileSystemRights.Modify, AccessControlType.Allow));
                    new FileInfo(path).SetAccessControl(security);
                }
                else if (Directory.Exists(path))
                {
                    DirectorySecurity security = new DirectorySecurity(path, AccessControlSections.Owner);
                    security.SetOwner(new NTAccount(userAccount));
                    new DirectoryInfo(path).SetAccessControl(security);
                }
            }
            catch (Exception ex) { return ex.Message; }
            return "";
        }

        public static string SetHiddenAttribute(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                }
                else if (Directory.Exists(path))
                {
                    new DirectoryInfo(path).Attributes |= FileAttributes.Hidden;
                }
            }
            catch (Exception ex) { return ex.Message; }
            return "";
        }
    }
}
