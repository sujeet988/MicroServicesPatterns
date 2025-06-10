namespace FactoryDesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory Design Patterns ");
            Console.WriteLine("=====================================");
            string transportType = "Car"; // This can be changed to "Ship" or "Airplane"
            ITransport transport = TransportFactory.GetTransport(transportType);
            transport.Deliver();
            Console.WriteLine("=====================================");
            Console.ReadLine();

        }
    }
}
