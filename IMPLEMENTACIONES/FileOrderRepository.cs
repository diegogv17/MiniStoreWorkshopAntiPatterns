using MiniStoreWorkshopAntiPatterns.ENTIDADES;
using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.IMPLEMENTACIONES
{
    public class FileOrderRepository : IOrderRepository
    {
        public void Save(Order o)
        {
            Directory.CreateDirectory("db");
            var line = $"{o.Id};{o.CustomerId};{o.Subtotal};{o.Shipping};{o.Total};{o.PaymentType};{o.ShippingType};{o.Paid}";
            File.AppendAllLines("db/orders.csv", new[] { line });
        }
    }

}
