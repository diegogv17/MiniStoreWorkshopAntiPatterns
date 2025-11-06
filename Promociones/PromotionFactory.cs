using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.Promociones
{
    public static class PromotionFactory
    {
        public static IPromotion Create(string? type) => type switch
        {
            "bf" => new BlackFridayPromotion(),
            "vip" => new VipPromotion(),
            "employee" => new EmployeePromotion(),
            _ => new NoPromotion(),
        };
    }

}
