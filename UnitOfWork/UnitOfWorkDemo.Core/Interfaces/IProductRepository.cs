using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnitOfWorkDemo.Core.Interfaces.IGenericRepository;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<ProductDetails>
    {

    }
}
