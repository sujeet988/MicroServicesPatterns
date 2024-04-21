namespace ProxyDesignPatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proxy Design pattern Demo");
            try
            {
                IEmployeeDao employeeDao=new EmployeeDaoProxy();
                employeeDao.Create("Admin", new EmployeeDaoModel());
                employeeDao.Get("User", 1);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}