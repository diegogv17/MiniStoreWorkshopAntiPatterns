using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniStoreWorkshopAntiPatterns.ENTIDADES;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.Interfaces
{
    public interface IPromotion
    {
        decimal Apply(decimal subtotal);

    }
}
