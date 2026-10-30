using System.ComponentModel.DataAnnotations;

namespace DiaryFood.DTOs
{
    //то, что отдаем клиенту
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public decimal Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Fat { get; set; }
        public decimal Carbs { get; set; }
    }

    //то, что клиент отдает нам
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Имя продукта обязательно!")]
        [MaxLength(100, ErrorMessage = "Имя не должно превышать 100 символов")]
        public string? Name { get; set; } = string.Empty;

        [Range(0, 10000, ErrorMessage = "Калории не могут быть отрицательными")]
        public decimal Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Fat { get; set; }
        public decimal Carbs { get; set; }

        public  int UserId { get; set; }
    }
}