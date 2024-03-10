using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WithStrategyPattern.Strategy;

namespace WithStrategyPattern
{
    public class OffRoadVehicle : Vehicle
    {
        public OffRoadVehicle(DriveStrategy driveStrategyObject) : base(driveStrategyObject)
        {
        }
    }
}
