using MiniStoreWorkshopAntiPatterns.IMPLEMENTACIONES;
using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.Factorias
{
    public static class ShippingFactory
    {
        public static IShipping Create(string? type) => type switch
        {
            "express" => new ExpressShipping(),
            "drone" => new DroneShipping(),
            _ => new StandardShipping(),
        };
    }

}
