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

       public LogProcessor NextHandler;
        public void SetNextHandler(LogProcessor NextHandler)
        {
            this.NextHandler = NextHandler;
        }
        public abstract void Log(int logLevel, String message);
    }
}
