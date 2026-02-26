using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Module
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public string Unit { get; set; }
        public decimal Discount { get; set; }
        public string ImagePath { get; set; }

        // Вычисляем для цены со скидкой
        public decimal DiscountedPrice => Price * (1 - Discount / 100m);
    }
}
