using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPatterns
{
    public class Car : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Delivering by Car");
        }
    }

}
