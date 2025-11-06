using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.Promociones
{
    public class BlackFridayPromotion : IPromotion
    {
        public decimal Apply(decimal subtotal) => subtotal * 0.7m;
    }

}
