using MiniStoreWorkshopAntiPatterns.IMPLEMENTACIONES;
using MiniStoreWorkshopAntiPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.Factorias
{
    public static class PaymentFactory
    {
        public static IPayment Create(string? type) => type switch
        {
            "card" => new CardPayment(),
            "crypto" => new CryptoPayment(),
            _ => new CashPayment(),
        };
    }
}
