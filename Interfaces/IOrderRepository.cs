using MiniStoreWorkshopAntiPatterns.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreWorkshopAntiPatterns.Interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
