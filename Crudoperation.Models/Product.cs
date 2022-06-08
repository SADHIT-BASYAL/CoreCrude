using Crudeoperation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudoperation.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public double Price { get; set; }

        public string ImageUrl { get; set; } = default!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}