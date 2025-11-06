using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.IMPLEMENTACIONES
{
    public class CryptoPayment : IPayment
    {
        public bool Charge(decimal amount)
        {
            if (amount != Math.Truncate(amount))
                throw new InvalidOperationException("Crypto solo admite montos enteros.");
            Console.WriteLine($"[CRYPTO] Hash ok por {amount:C}");
            return true;
        }
    }

}
