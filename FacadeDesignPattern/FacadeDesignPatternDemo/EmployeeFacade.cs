using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPatternDemo
{
    /*
     * EmployeeFacade contains only method that needed for client. not exposing all
       method as client need only two method. so it reduces complexity

     */
    public class EmployeeFacade
    {
        EmployeeDao employeeDao;
        public EmployeeFacade()
        {
            employeeDao = new EmployeeDao();
        }

        public void Insert()
        {
            employeeDao.Insert();
        }
        public void GetEmployeeDetails(int  empid)
        {
            employeeDao.GetEmployeeDetails(empid);
        }
    }
}
