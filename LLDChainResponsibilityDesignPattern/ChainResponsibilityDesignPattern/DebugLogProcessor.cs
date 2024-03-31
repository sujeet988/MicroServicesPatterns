using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityDesignPattern
{
    public class DebugLogProcessor : LogProcessor
    {
        public DebugLogProcessor(LogProcessor loggerProcessor) : base(loggerProcessor)
        {
        }
        public new void Log(int logLevel, String message)
        {

            if (logLevel == DEBUG)
            {
                Console.WriteLine("DEBUG: " + message);
            }
            else
            {

                base.Log(logLevel, message);
            }

        }
    }

}
