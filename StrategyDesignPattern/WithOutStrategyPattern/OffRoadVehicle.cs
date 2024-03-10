using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithOutStrategyPattern
{
    public class OffRoadVehicle : Vehicle
    {
        public void Drive()
        {
            // some code
            Console.WriteLine("Sports Drive capability");
        }
    }
}
