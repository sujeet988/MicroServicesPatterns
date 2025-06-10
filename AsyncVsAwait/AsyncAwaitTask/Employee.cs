using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitTask
{
    public class Employee
    {
        public async Task<string> GetEmployeeNameAsync()
        {
            // Simulate an asynchronous operation
            await Task.Delay(6000);
            return "John Doe";
        }
        public async Task<int> GetEmployeeId(int empid)
        {
            // Simulate an asynchronous operation
            await Task.Delay(6000);
            return empid;
        }
    }
}
