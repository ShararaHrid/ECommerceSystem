using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.Core.Entities;

namespace ECommerceSystem.Core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        // add product-specific methods later
    }
}
