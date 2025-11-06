using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.IMPLEMENTACIONES
{
    public class StandardShipping : IShipping
    {
        public decimal CostFor(decimal totalWeightKg, decimal subtotal)
            => totalWeightKg <= 5 ? 25 : 50;

        public void Ship(string address, decimal totalWeightKg)
            => Console.WriteLine($"[SHIP] Standard a {address} ({totalWeightKg}kg)");
    }

}
