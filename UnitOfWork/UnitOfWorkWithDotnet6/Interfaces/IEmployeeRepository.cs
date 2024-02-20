using static UnitOfWorkWithDotnet6.Interfaces.IGenericRepository;
using UnitOfWorkWithDotnet6.Models;

namespace UnitOfWorkWithDotnet6.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        //Here, you need to define the operations which are specific to Employee Entity
        //This method returns all the Employee entities along with Department data
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        //This method returns one the Employee along with Department data based on the Employee Id
        Task<Employee?> GetEmployeeByIdAsync(int EmployeeID);
        //This method will return Employees by Departmentid
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int Departmentid);
    }
}
