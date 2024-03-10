namespace WithoutLSP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Vehicle> vehiclelist = new List<Vehicle>
            {
                new MotorCycle(),
                new Car()
            };

            foreach(var vehicle in vehiclelist)
            {
                Console.WriteLine(vehicle.HasEngine().ToString());
            }

            // it will print 2 and 2 --no issues

            /*now adding new class bicycle and it will throw null pointer
             exception as Bicycle does not  engine.

            bicycle  class will break code and this is violation lsp principle as 
            bicycle does not  have engine so it will break.

            */
            List<Vehicle> vehiclelist2 = new List<Vehicle>
            {
                new MotorCycle(),
                new Car(),
                new Bicycle()
            };

            foreach (var vehicle in vehiclelist2)
            {
                Console.WriteLine(vehicle.HasEngine().ToString());
            }


            // SO solution for this put only generic method inside main class  vehicle like  number of wheels
            Console.ReadLine();

        }

    }
}