using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutLSP
{
    public class Car : Vehicle
    {
        public override  int GetNumberOfWheels()
        {
            return 4;
        }
    }
}
