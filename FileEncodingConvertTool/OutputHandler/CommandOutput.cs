using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FECT.OutputHandler
{
    class CommandOutput : IOutput
    {
        public void WriteMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
