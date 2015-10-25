using FECT.OutputHandler;
using FECT.ParameterHandler;
using System;
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
                //ParameterUtils paras = new ParameterUtils(argu);
                IOutput msg = new CommandOutput();
                ValidateParams vp = new ValidateParams(argu, msg);
                if (vp.InDispensableParams())
                {
                    //EncodeUtils eu = new EncodeUtils();
                    //eu.SetEncodings(EncodingType.GetEncodings(paras.SEncode()))
                    //    .SetDestEncode(EncodingType.Encode(paras.DestEncode()))
                    //   .SetExtensions(paras.Extension())
                    //   .BackupOriginFiles(paras.BackupFlag())
                    //   .SetFiles(paras.Files())
                    //   .SetDirs(paras.Dirs());
                    IParameters paras = new CommandParameters(argu);

                    ConvertLogic cl = new ConvertLogic(paras, msg);

                    cl.Convert();
                }
            }
        }
    }
}