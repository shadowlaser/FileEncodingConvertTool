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
        public string[] GetSEncode()
        {
            string retVal = GetParamValue("-s");
            if (retVal != null)
            {
                return retVal.Split(',');
            }
            return null;
        }

        //-f ： 文件集合
        public string[] GetFiles()
        {
            string retVal = GetParamValue("-f");
            if (retVal != null)
            {
                return retVal.Split(',');
            }
            return null;
        }

        //-e : 扩展名集合
        public string[] GetExtension()
        {
            string retVal = GetParamValue("-e");
            if (retVal != null)
            {
                return retVal.Split(',');
            }
            return null;
        }

        //-d : 转换后的编码格式
        public string GetDestEncode()
        {
            string dEncode = null;
            dEncode = GetParamValue("-d");
            return dEncode;
        }

        //-dir ： 目录集合
        public string GetDir()
        {
            string retVal = null;

            retVal = GetParamValue("-dir");
            return retVal;
        }

        //-b : 备份标记
        public bool GetBackupFlag()
        {
            return pars.Contains("-b");
        }

        private string GetParamValue(string par)
        {
            string retVal = null;
            if (pars.Contains(par))
            {
                if (pars[pars.IndexOf(par) + 1].ToString().IndexOf("-") != -1)
                {
                    retVal = pars[pars.IndexOf(par) + 1].ToString();
                }
            }
            return retVal;
        }
    }
}