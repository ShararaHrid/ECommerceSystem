using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }    // Access to Product repository
        Task<int> SaveAsync();                  // Save changes in one go
    }
}