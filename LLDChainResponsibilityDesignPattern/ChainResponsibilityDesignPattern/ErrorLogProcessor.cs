using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityDesignPattern
{
    public class ErrorLogProcessor : LogProcessor
    {
        public ErrorLogProcessor(LogProcessor loggerProcessor) : base(loggerProcessor)
        {
        }
        public new void Log(int logLevel, String message)
        {

            if (logLevel == ERROR)
            {
               Console.WriteLine("ERROR: " + message);
            }
            else
            {

                base.Log(logLevel, message);
            }

        }
    }
}

