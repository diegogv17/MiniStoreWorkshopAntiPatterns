using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.IMPLEMENTACIONES
{
    public class DroneShipping : IShipping
    {
        public decimal CostFor(decimal totalWeightKg, decimal subtotal) => 15;

        public void Ship(string address, decimal totalWeightKg)
        {
            if (totalWeightKg > 2)
                throw new NotSupportedException("Drones no soportan > 2kg.");
            Console.WriteLine($"[SHIP] Drone a {address} ({totalWeightKg}kg)");
        }
    }

}
