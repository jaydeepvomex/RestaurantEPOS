using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEPOS.Model.Entities
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public int Pin { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
    }
}
