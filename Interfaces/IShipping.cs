using System;
using MiniStoreWorkshopAntiPatterns.ENTIDADES;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.Interfaces
{
    public interface IShipping
    {
        decimal CostFor(decimal totalWeightKg, decimal subtotal);
        void Ship(string address, decimal totalWeightKg);

    }
}
