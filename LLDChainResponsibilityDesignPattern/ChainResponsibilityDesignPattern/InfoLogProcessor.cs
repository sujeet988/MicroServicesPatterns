using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityDesignPattern
{
    public class InfoLogProcessor : LogProcessor
    {
        public override void Log(int logLevel, string message)
        {
            if (logLevel == INFO)
            {
                Console.WriteLine("INFO: " + message);
            }
            else
            {

                NextHandler.Log(logLevel, message);
            }
        }
    }
}
