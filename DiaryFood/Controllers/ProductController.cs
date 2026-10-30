using DiaryFood.DTOs;
using DiaryFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryFood.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    public static readonly List<Product> _productOfList = new List<Product>();
    public static int _count = 0;

    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetAllProduct() { 
        var productsDto = _productOfList.Select(p=> new ProductDto { 
                        Id = p.Id,
                        Name = p.Name,
                        Calories = p.Calories,
                        Protein = p.Protein,
                        Fat = p.Fat,
                        Carbs = p.Carbs }).ToList();
        return Ok(productsDto);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetIdProduct(int id)
    {
        var product = _productOfList.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Calories = product.Calories,
                Protein = product.Protein,
                Fat = product.Fat,
                Carbs = product.Carbs
            };
            return Ok(productDto);       
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] CreateProductDto createProductDto) {
        var product = new Product
        {
            Id = ++_count,
            Name = createProductDto.Name,
            Calories = createProductDto.Calories,
            Protein = createProductDto.Protein,
            Fat = createProductDto.Fat,
            Carbs= createProductDto.Carbs,
            UserId = createProductDto.UserId
        };

        _productOfList.Add(product);

        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Calories = product.Calories,
            Protein = product.Protein,
            Fat = product.Fat,
            Carbs = product.Carbs
        };        
        return CreatedAtAction(nameof(GetIdProduct), new { id = productDto.Id }, productDto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _productOfList.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound($"Продукт с {id} не найден");

        _productOfList.Remove(product);

        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct([FromBody] CreateProductDto  product, int id)
    {
        var productUp = _productOfList.FirstOrDefault(p => p.Id == id);
        if (productUp == null) return NotFound($"Продукт с {id} не найден");

        productUp.Name = product.Name;
        productUp.Calories = product.Calories;
        productUp.Protein = product.Protein;
        productUp.Fat = product.Fat;
        productUp.Carbs = product.Carbs;

        return NoContent();
    }
}
