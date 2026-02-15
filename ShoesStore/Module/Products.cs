using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Module
{
    public class Products
    {
        public Products(Guid Id, string name, string description, string category,
                      decimal price, int stockQuantity, DateTime createdDate,
                      int? size = null, string color = null, string brand = null)
        {
            ID = Id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
            Size = size;
            Color = color;
            Brand = brand;
            CreatedDate = createdDate;
        }

        public Products(string name, string description, string category,
                      decimal price, int stockQuantity, int? size = null,
                      string color = null, string brand = null)
        {
            ID = Guid.NewGuid();
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
            Size = size;
            Color = color;
            Brand = brand;
            CreatedDate = DateTime.Now;
        }

        // Добавляем конструктор без параметров
        public Products()
        {
            ID = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int? Size { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
