using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutLSP
{
    public class Vehicle
    {
        public virtual int GetNumberOfWheels()
        {
            return 2;
        }
        public virtual Boolean? HasEngine()
        {
            return true;
        }
    }
}
