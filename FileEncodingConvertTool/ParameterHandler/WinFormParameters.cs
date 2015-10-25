using System;
using System.Collections;

namespace FECT.ParameterHandler
{
    internal class WinFormParameters : IParameters
    {
        private ArrayList args;

        public WinFormParameters(string[] args)
        {
            this.args = new ArrayList(args);
        }

        string IParameters.GetDestEncode()
        {
            string dEncode = null;
            dEncode = GetParamValue("-d");
            return dEncode;
        }

        System.Collections.ArrayList IParameters.GetSrcEncodes()
        {
            string retVal = GetParamValue("-s");
            if (retVal != null)
            {
                return new ArrayList(retVal.Split(','));
            }
            return null;
        }

        System.Collections.ArrayList IParameters.GetFiles()
        {
            string retVal = GetParamValue("-f");
            if (retVal != null)
            {
                return new ArrayList(retVal.Split(','));
            }
            return null;
        }

        System.Collections.ArrayList IParameters.GetDirectorys()
        {
            throw new NotImplementedException();
        }

        System.Collections.ArrayList IParameters.GetExts()
        {
            string retVal = GetParamValue("-e");
            if (retVal != null)
            {
                return new ArrayList(retVal.Split(','));
            }
            return null;
        }

        public bool GetBackUp()
        {
            return args.Contains("-b");
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