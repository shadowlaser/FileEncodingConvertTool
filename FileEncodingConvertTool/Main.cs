using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FECT
{
    internal static class MainEntry
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main(string[] argu)
        {
            if (argu.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ConvertForm());
            }
            else
            {
                EncodeUtils eu = new EncodeUtils();
                eu.SetDestEncode(Encoding.UTF8).ConvertFiles(new FileInfo[] { new FileInfo("d:/BugReport.txt") });
            }
        }
    }
}