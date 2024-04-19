using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesignPatternDemo
{
    public class EmployeeDaoImpl : IEmployeeDao
    {
        public void Create(string client, EmployeeDaoModel obj)
        {
            // create a new row
            Console.WriteLine("create a new row in employee table");
        }

        public void Delete(string client, int employeeId)
        {
            // delete a row
            Console.WriteLine("Deleted a row with employee id "+ employeeId);
        }

        public EmployeeDaoModel Get(string client, int employeeId)
        {
            // fetch row

            Console.WriteLine("fetching data from db");
            return new EmployeeDaoModel();
        }
    }
}
