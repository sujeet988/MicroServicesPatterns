using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityDesignPattern
{
    public abstract class LogProcessor
    {
        public static int INFO = 1;
        public static int DEBUG = 2;
        public static int ERROR = 3;

        LogProcessor nextLoggerProcessor;
        public LogProcessor(LogProcessor loggerProcessor)
        {
            this.nextLoggerProcessor = loggerProcessor;
        }
        public void Log(int logLevel, String message)
        {

            if (nextLoggerProcessor != null)
            {
                nextLoggerProcessor.Log(logLevel, message);
            }
        }
    }
}
