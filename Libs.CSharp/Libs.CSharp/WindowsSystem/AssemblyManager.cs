using System.IO;
using System.Reflection;

namespace Libs.CSharp.WindowsSystem
{
    public class AssemblyManager
    {
        /// <summary>
        /// Hàm này dùng để load file dll bên ngoài vào chương trình, khi mà chương trình không tự động load thông qua add file trong References
        /// </summary>
        /// <param name="assemblyPath"></param>
        public static void Load(string assemblyPath)
        {
            if (File.Exists(assemblyPath))
            {
                AssemblyName assembly = AssemblyName.GetAssemblyName(assemblyPath);
                if (assembly != null) Assembly.Load(assembly);
            }
        }
    }
}
