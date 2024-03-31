using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityDesignPattern
{
    public class InfoLogProcessor : LogProcessor
    {
        public InfoLogProcessor(LogProcessor loggerProcessor) : base(loggerProcessor)
        {
        }
        public new void Log(int logLevel, String message)
        {

            if (logLevel == INFO)
            {
                Console.WriteLine("INFO: " + message);
            }
            else
            {

                base.Log(logLevel, message);
            }

        }
    }
}
