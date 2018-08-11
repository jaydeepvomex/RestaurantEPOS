using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantEPOS.Model
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
