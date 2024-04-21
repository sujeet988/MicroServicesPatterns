using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesignPatternDemo
{
    public interface IEmployeeDao
    {
        public void Create(string client, EmployeeDaoModel obj);
        public void Delete(string client, int  employeeId);
        public EmployeeDaoModel Get(string client, int employeeId);

    }
}
