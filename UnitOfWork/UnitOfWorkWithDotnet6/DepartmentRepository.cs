using UnitOfWorkWithDotnet6.Interfaces;
using UnitOfWorkWithDotnet6.Models;

namespace UnitOfWorkWithDotnet6
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EFCoreDbContext context) : base(context) { }
    
    }
}
