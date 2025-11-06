using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.ENTIDADES
{
    public class Product
    {
        public string Sku { get; init; } = "";
        public string Name { get; init; } = "";
        public decimal Price { get; init; }
        public decimal WeightKg { get; init; }

    }
}
