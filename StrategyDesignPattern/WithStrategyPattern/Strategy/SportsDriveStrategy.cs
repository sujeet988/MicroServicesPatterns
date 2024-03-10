using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithStrategyPattern.Strategy
{
    public class SportsDriveStrategy : DriveStrategy
    {
        public void Drive()
        {
            Console.WriteLine("Sports Drive capability");
        }

    }
}
