using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIandDOTNETCore.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Department_ID { get; set; }

        [Required]
         public string Grocery_dept { get; set; }

        [StringLength(255)]
        public string Bakery_dept { get; set; }
 public int? Total_No_Of_Products { get; set; }

          [Range(0, 100000)]
        public decimal? Price_of_Product { get; set; }

        public ICollection<Orderss> Ordersses { get; set; }
    }
}
