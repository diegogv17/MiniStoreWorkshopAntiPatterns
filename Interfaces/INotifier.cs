using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniStoreWorkshopAntiPatterns.ENTIDADES;

namespace MiniStoreWorkshopAntiPatterns.Interfaces
{
    public interface INotifier
    {
        void SendEmail(string to, string subject, string body);
        void SendSms(string phone, string message);
    }
}
