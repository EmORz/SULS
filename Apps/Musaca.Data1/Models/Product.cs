using System;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Data1.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public decimal Price { get; set; }
        /*•	Id - a GUID String, Primary Key
           •	Name - a string with min length 3 and max length 10 (required)
           •	Price – a decimal with min value – 0.01.
           */

    }
}