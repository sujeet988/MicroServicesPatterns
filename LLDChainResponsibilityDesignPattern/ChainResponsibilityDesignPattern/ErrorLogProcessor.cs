using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityDesignPattern
{
    public class ErrorLogProcessor : LogProcessor
    {
        public override void Log(int logLevel, string message)
        {
            if (logLevel == ERROR)
            {
                Console.WriteLine("Error: " + message);
            }
            else
            {
                if (NextHandler != null)
                {
                    NextHandler.Log(logLevel, message);
                }
            }
        }
    }
}

