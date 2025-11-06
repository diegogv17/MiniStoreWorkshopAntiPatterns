using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.IMPLEMENTACIONES
{
    public class ExpressShipping : IShipping
    {
        public decimal CostFor(decimal totalWeightKg, decimal subtotal) => 60;

        public void Ship(string address, decimal totalWeightKg)
            => Console.WriteLine($"[SHIP] Express a {address} ({totalWeightKg}kg)");
    }

}
