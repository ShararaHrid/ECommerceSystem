using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }      // Primary key
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

