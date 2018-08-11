using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEPOS.Model.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public string TableNumber { get; set; }
        public int MaxSeatings { get; set; }
    }
}
