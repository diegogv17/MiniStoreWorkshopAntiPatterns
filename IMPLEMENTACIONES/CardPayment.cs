using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.IMPLEMENTACIONES
{
    public class CardPayment : IPayment
    {
        public bool Charge(decimal amount)
        {
            Console.WriteLine($"[CARD] Pagado {amount:C}");
            return true;
        }
    }

}
