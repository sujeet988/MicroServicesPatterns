using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WithStrategyPattern.Strategy;

namespace WithStrategyPattern
{
    public class Vehicle
    {

        DriveStrategy driveStrategyObject;

        public Vehicle(DriveStrategy driveStrategyObject)
        {
            this.driveStrategyObject = driveStrategyObject;
        }

        public void drive()
        {
            driveStrategyObject.Drive();
        }


    }
}
