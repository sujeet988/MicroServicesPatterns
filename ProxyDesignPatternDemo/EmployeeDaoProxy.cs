using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesignPatternDemo
{
    public class EmployeeDaoProxy : IEmployeeDao
    {
        private readonly IEmployeeDao employeeDaoProxy;
        public EmployeeDaoProxy() 
        {
            employeeDaoProxy=new EmployeeDaoImpl();
        }

        public void Create(string client, EmployeeDaoModel obj)
        {
            if (client.Equals("Admin"))
            {
                employeeDaoProxy.Create(client, obj);
                return;
            }

            throw new  Exception("Access Denied");
        }

        public void Delete(string client, int employeeId)
        {
            if (client.Equals("Admin"))
            {
                employeeDaoProxy.Delete(client, employeeId);
                return;
            }

            throw new Exception("Access Denied");
        }

        public EmployeeDaoModel Get(string client, int employeeId)
        {
            if(client.Equals("Admin")|| client.Equals("User"))
            {
                return employeeDaoProxy.Get(client, employeeId);
            }
            throw new Exception("Access Denied");
        }
    }
}
