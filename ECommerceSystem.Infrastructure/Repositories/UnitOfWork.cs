using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.Data;

namespace ECommerceSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;

        public IProductRepository Products { get; private set; }

        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
