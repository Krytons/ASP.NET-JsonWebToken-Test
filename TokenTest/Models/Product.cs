using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TokenTest.Models
{
    public class Product
    {
        public Product(string name, string price)
        {
            Name = name;
            Price = price;
        }

        [Key]
        public long ProductId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }

    }
}
