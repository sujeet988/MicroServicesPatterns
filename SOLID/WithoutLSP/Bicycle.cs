using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutLSP
{
    public class Bicycle : Vehicle
    {
        public override bool? HasEngine()
        {
            return null;
        }

    }
}
