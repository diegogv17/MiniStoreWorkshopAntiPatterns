using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.Promociones
{
    public class VipPromotion : IPromotion
    {
        public decimal Apply(decimal subtotal) => subtotal * 0.85m;
    }

}
