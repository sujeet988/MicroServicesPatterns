using WithStrategyPattern.Strategy;

namespace WithStrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strategy Pattern Demo");
            SportsDriveStrategy obj=new SportsDriveStrategy();
            Vehicle vehicle = new Sportsvehicle(obj);
            vehicle.drive();
            Console.ReadLine();

        }
    }
}