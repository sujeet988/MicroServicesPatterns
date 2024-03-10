using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithStrategyPattern.Strategy
{
    public class NormalDriveStrategy : DriveStrategy
    {
        public void Drive()
        {
            Console.WriteLine("Normal Drive capability");
        }
    }
}
