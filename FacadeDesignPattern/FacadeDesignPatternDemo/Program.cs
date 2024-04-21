namespace FacadeDesignPatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Facade Design Pattern Demo");
            EmployeeFacade employeeFacade=new EmployeeFacade();
            employeeFacade.GetEmployeeDetails(10); // passsing empid
            
            Console.ReadLine();
        }
    }
}