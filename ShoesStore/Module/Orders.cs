using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Module
{
    public class Orders
    {
        public Orders(Guid id, Guid userId, Guid productId, int quantity,
              DateTime orderDate, string status, decimal totalPrice,
              string notes, string shippingAddress, string phone)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
            OrderDate = orderDate;
            Status = status;
            TotalPrice = totalPrice;
            Notes = notes;
            ShippingAddress = shippingAddress;
            Phone = phone;
        }

        public Orders(Users user, Products product, int quantity,
              decimal totalPrice, string status = "Pending",
              string notes = null, string shippingAddress = null,
              string phone = null)
        {
            Id = Guid.NewGuid();
            UserId = user.ID;
            ProductId = product.ID;
            Quantity = quantity;
            OrderDate = DateTime.Now;
            TotalPrice = totalPrice;
            Status = status;
            Notes = notes;
            ShippingAddress = shippingAddress;
            Phone = phone;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; }
        public string ShippingAddress { get; set; }
        public string Phone { get; set; }
    }
}
