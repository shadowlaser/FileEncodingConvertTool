using System;

namespace FECT
{
    internal class ValidateParams
    {
        private ParameterUtils pu = null;

        public ValidateParams(ParameterUtils pu)
        {
            this.pu = pu;
        }

        public bool InDispensableParams()
        {
            bool retVal = true;
            if ((pu.Files() == null && pu.Dirs() == null)
                || pu.DestEncode() == null
                )
            {
                Console.Write("参数不符合规范");
                retVal = false;
            }
            return retVal;
        }
    }
}