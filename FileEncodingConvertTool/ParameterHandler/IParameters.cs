using System.Collections;
using System.Text;

namespace FECT.ParameterHandler
{
    internal interface IParameters
    {
        ArrayList GetFiles();

        ArrayList GetDirectorys();

        ArrayList GetExts();

        string GetDestEncode();

        ArrayList GetSrcEncodes();

        bool GetBackUp();
    }
}