using System.ComponentModel.DataAnnotations;

namespace DiaryFood.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; } = string.Empty;
        
        public decimal Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Fat { get; set; }
        public decimal Carbs { get; set; }

        public bool IsPublic { get; set; }
        public int UserId { get; set; }

    }
}
