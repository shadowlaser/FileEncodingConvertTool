using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

//-e : 扩展名集合
//-f ： 文件集合
//-dir ： 目录集合
//-s : 需要处理的文件的编码格式
//-d : 转换后的编码格式
//-b : 备份标记

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