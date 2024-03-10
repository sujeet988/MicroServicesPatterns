using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WithStrategyPattern.Strategy;


namespace WithStrategyPattern
{
    public class GoodsVehicle : Vehicle
    {
        public GoodsVehicle(DriveStrategy driveStrategyObject) : base(driveStrategyObject)
        {
        }
    }

}
