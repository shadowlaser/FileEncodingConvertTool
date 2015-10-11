using System.Collections;

//-e : 扩展名集合
//-f ： 文件集合
//-dir ： 目录集合
//-s : 需要处理的文件的编码格式
//-d : 转换后的编码格式
//-b : 备份标记
namespace FECT
{
    internal class ParameterUtils
    {
        private ArrayList pars;

        public ParameterUtils()
        {
        }

        public ParameterUtils(string[] pars)
        {
            Params(pars);
        }

        public ParameterUtils Params(string[] pars)
        {
            this.pars = new ArrayList(pars);
            return this;
        }

        //-s : 需要处理的文件的编码格式
        public string[] SEncode()
        {
            string retVal = GetParamValue("-s");
            if (retVal != null)
            {
                return retVal.Split(',');
            }
            return null;
        }

        //-f ： 文件集合
        public string[] Files()
        {
            string retVal = GetParamValue("-f");
            if (retVal != null)
            {
                return retVal.Split(',');
            }
            return null;
        }

        //-e : 扩展名集合
        public string[] Extension()
        {
            string retVal = GetParamValue("-e");
            if (retVal != null)
            {
                return retVal.Split(',');
            }
            return null;
        }

        //-d : 转换后的编码格式
        public string DestEncode()
        {
            string dEncode = null;
            dEncode = GetParamValue("-d");
            return dEncode;
        }

        //-dir ： 目录集合
        public string[] Dirs()
        {
            string retVal = GetParamValue("-dir");
            if (retVal != null)
            {
                return retVal.Split(',');
            }
            return null;
        }

        //-b : 备份标记
        public bool BackupFlag()
        {
            return pars.Contains("-b");
        }

        private string GetParamValue(string par)
        {
            string retVal = null;
            if (pars.Contains(par))
            {
                if (pars[pars.IndexOf(par) + 1].ToString().IndexOf("-") != 0)
                {
                    retVal = pars[pars.IndexOf(par) + 1].ToString();
                }
            }
            return retVal;
        }
    }
}