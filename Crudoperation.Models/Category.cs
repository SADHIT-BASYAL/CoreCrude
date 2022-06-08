using System.ComponentModel.DataAnnotations;

namespace Crudeoperation.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}