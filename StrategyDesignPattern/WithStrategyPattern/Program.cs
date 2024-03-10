using WithStrategyPattern.Strategy;

namespace WithStrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strategy Pattern Demo");
            //SportsDriveStrategy obj=new SportsDriveStrategy();
            //Vehicle vehicle = new Sportsvehicle(obj);
            //vehicle.drive();

            //NormalDriveStrategy obj = new NormalDriveStrategy();
            //Vehicle vehicle = new GoodsVehicle(obj);
            //vehicle.drive();

            SportsDriveStrategy obj = new SportsDriveStrategy();
            Vehicle vehicle = new OffRoadVehicle(obj);
            vehicle.drive();

            Console.ReadLine();

        }
    }
}