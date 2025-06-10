using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPatterns
{
    public class TransportFactory
    {
        public  static ITransport GetTransport(string transportType)
        {
            if (transportType.Equals("Truck", StringComparison.OrdinalIgnoreCase))
            {
                return new Truck();
            }
            else if (transportType.Equals("Car", StringComparison.OrdinalIgnoreCase))
            {
                return new Car();
            }
            else
            {
                throw new ArgumentException("Invalid transport type");
            }
        }

    }
}
