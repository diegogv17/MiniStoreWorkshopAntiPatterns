using System;
using MiniStoreWorkshopAntiPatterns.ENTIDADES;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.Interfaces
{
    public interface IPayment
    {
        bool Charge(decimal amount);
    }
}
