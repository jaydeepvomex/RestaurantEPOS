using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEPOS.BusinessLayer.Enums
{
    public enum TableServiceStatus
    {
        Free,
        Reserved,
        BeingServed,
        Finished,
        Paid
    }
}
