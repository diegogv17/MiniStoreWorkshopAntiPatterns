using MiniStoreWorkshopAntiPatterns.Interfaces;
using MiniStoreWorkshopAntiPatterns.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.IMPLEMENTACIONES
{
    public class ConsoleNotifier : INotifier
    {
        public void SendEmail(string to, string subject, string body)
            => Console.WriteLine($"[EMAIL] To:{to} Subj:{subject} Body:{body}");

        public void SendSms(string phone, string message)
            => Console.WriteLine($"[SMS] To:{phone} Msg:{message}");
    }

}
