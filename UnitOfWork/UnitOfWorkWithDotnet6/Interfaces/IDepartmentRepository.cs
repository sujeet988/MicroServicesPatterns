using static UnitOfWorkWithDotnet6.Interfaces.IGenericRepository;
using UnitOfWorkWithDotnet6.Models;

namespace UnitOfWorkWithDotnet6.Interfaces
{
    //Note: if you want to add some methods specific to the Department Entity, you can define here
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
    }
}
