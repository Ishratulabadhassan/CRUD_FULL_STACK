using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
