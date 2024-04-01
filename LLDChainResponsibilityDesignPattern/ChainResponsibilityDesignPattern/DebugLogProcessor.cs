using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityDesignPattern
{
    public class DebugLogProcessor : LogProcessor
    {
        public override void Log(int logLevel, string message)
        {
            if (logLevel == DEBUG)
            {
                Console.WriteLine("DEBUG: " + message);
            }
            else
            {

                NextHandler.Log(logLevel, message);
            }
        }
    }

}
