using Microsoft.Win32;

namespace Libs.CSharp.WindowsSystem
{
    public class ContextMenuHandler
    {
        public static void AddContextMenu_SelectedFolders(string regName, string menu, string softwarePath)
        {
            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey($@"Directory\shell\{regName}"))
            {
                if (key != null)
                {
                    key.SetValue("", menu);
                    key.SetValue("Icon", softwarePath + ",0");
                    using (RegistryKey commandKey = key.CreateSubKey("command"))
                    {
                        commandKey?.SetValue("", $@"""{softwarePath}"" ""%L""");
                    }
                }
            }
        }

        public static void AddContextMenu_SelectedFiles(string regName, string menu, string softwarePath)
        {
            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey($@"*\shell\{regName}"))
            {
                if (key != null)
                {
                    key.SetValue("", menu);
                    key.SetValue("Icon", softwarePath + ",0");
                    using (RegistryKey commandKey = key.CreateSubKey("command"))
                    {
                        commandKey?.SetValue("", $@"""{softwarePath}"" ""%L""");
                    }
                }
            }
        }

        public static void AddContextMenu_Spacing(string regName, string menu, string softwarePath)
        {
            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey($@"Directory\Background\shell\{regName}"))
            {
                if (key != null)
                {
                    key.SetValue("", menu);
                    key.SetValue("Icon", softwarePath + ",0");
                    using (RegistryKey commandKey = key.CreateSubKey("command"))
                    {
                        commandKey?.SetValue("", $@"""{softwarePath}"" ""%L"" ""%V""");
                    }
                }
            }
        }

        public static void AddContextMenu_CopyMoveTo()
        {
            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers"))
            {
                key?.CreateSubKey("{C2FBB630-2971-11D1-A18C-00C04FD75D13}");
                key?.CreateSubKey("{C2FBB631-2971-11D1-A18C-00C04FD75D13}");
            }
        }

        public static void RemoveContextMenu_CopyMoveTo()
        {
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers"))
                {
                    key?.DeleteSubKey("{C2FBB630-2971-11D1-A18C-00C04FD75D13}");
                    key?.DeleteSubKey("{C2FBB631-2971-11D1-A18C-00C04FD75D13}");
                }
            }
            catch { }
        }
    }
}
