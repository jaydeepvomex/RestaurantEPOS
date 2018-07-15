using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEPOS.UI
{
    public class ListItems
    {
        public static ObservableCollection<Item> Items;

        public ListItems()
        {
            Items = new ObservableCollection<Item>();
        }
    }
}
