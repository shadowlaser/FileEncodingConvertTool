using FECT.OutputHandler;
using System;
using System.Collections;
//-e : 扩展名集合 -e:cpp,c,java
//-f ： 文件集合
//-dir ： 目录集合
//-s : 需要处理的文件的编码格式
//-d : 转换后的编码格式
//-b : 备份标记
namespace FECT
{
    internal class ValidateParams
    {
        private ArrayList args = new ArrayList();
        private IOutput msglog;

        public ValidateParams(string[] args, IOutput msglog)
        {
            this.args = new ArrayList(args);
            this.msglog = msglog;
        }

        public bool InDispensableParams()
        {
            bool retVal = true;
            string msg;

            if (args.Contains("-dir") && !ValidateDirs(out msg))
            {
                msglog.WriteMsg(msg);
                retVal = false;
            }

            if (args.Contains("-f") && !ValidateFiles(out msg))
            {
                msglog.WriteMsg(msg);
                retVal = false;
            }

            if (args.Contains("-d") && !ValidateDestEncode(out msg))
            {
                msglog.WriteMsg(msg);
                retVal = false;
            }

            if (args.Contains("-s") && !ValidateSrcEncodes(out msg))
            {
                msglog.WriteMsg(msg);
                retVal = false;
            }

            return retVal;
        }

        public bool ValidateFiles(out string msg)
        {
            bool retVal = true;
            msg = "";
            if (GetParamValue("-f") == null)
            {
                msg = "-f file1[,file2][,file3][,...]";
                retVal = false;
            }
            return retVal;
        }

        public bool ValidateDirs(out string msg)
        {
            bool retVal = true;
            msg = "";
            if (GetParamValue("-dir") == null)
            {
                msg = "-dir dir1[,dir2][,dir3][,...]";
                retVal = false;
            }
            return retVal;
        }

        public bool ValidateDestEncode(out string msg)
        {
            bool retVal = true;
            msg = "";
            if (GetParamValue("-d") == null)
            {
                msg = "-d encode(converted encode)";
                retVal = false;
            }
            return retVal;
        }

        public bool ValidateSrcEncodes(out string msg)
        {
            bool retVal = true;
            msg = "";
            if (GetParamValue("-s") == null)
            {
                msg = "-s encode1[,encode2][,encode3][,...]";
                retVal = false;
            }
            return retVal;
        }

        private string GetParamValue(string par)
        {
            string retVal = null;

            if (args.Contains(par))
            {
                if (args[args.IndexOf(par) + 1].ToString().IndexOf("-") != 0)
                {
                    retVal = args[args.IndexOf(par) + 1].ToString();
                }
            }
            return retVal;
        }
    }
}