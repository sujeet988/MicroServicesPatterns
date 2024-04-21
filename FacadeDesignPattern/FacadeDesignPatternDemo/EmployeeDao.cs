using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPatternDemo
{
    public class EmployeeDao
    {
        public void Insert()
        {
            // insert into employee table
        }
        public void UpdateEmployeeName()
        {
            // Update Employee Name
        }
        public Employee GetEmployeeDetails(int empid)
        {
            Employee emp=new Employee();
            emp.empId= empid;
            // get employee details based on emmailid
            return new Employee();
        }
        
    }

}
