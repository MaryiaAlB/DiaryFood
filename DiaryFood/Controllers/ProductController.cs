using DiaryFood.DTOs;
using DiaryFood.Models;
using DiaryFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiaryFood.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context) {
        _context = context;
    }



    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProduct()
    { 
        var productsDto = await _context.Products
            .Select(p=> new ProductDto 
            { 
                        Id = p.Id,
                        Name = p.Name,
                        Calories = p.Calories,
                        Protein = p.Protein,
                        Fat = p.Fat,
                        Carbs = p.Carbs })
            .ToListAsync();
        return Ok(productsDto);
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetIdProduct(int id)
    {
        var productDto = await _context.Products.Where(p => p.Id == id)
           .Select(p => new ProductDto
           {
               Id = p.Id,
               Name = p.Name,
               Calories = p.Calories,
               Protein = p.Protein,
               Fat = p.Fat,
               Carbs = p.Carbs
           })
        .FirstOrDefaultAsync(); // Асинхронно!

        if (productDto == null) return NotFound();

        return Ok(productDto);
    }


    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductDto createProductDto)
    {
        var product = new Product
        {
            Name = createProductDto.Name,
            Calories = createProductDto.Calories,
            Protein = createProductDto.Protein,
            Fat = createProductDto.Fat,
            Carbs = createProductDto.Carbs,
            UserId = createProductDto.UserId
            
        };

        _context.Products.Add(product); // Добавляем в контекст
        await _context.SaveChangesAsync(); // СОХРАНЯЕМ в базу!

        // После SaveChangesAsync у product.Id уже есть сгенерированное значение
        var productDto = new ProductDto { 
            Id = product.Id, 
            Name = product.Name, 
            Calories = product.Calories,
        Protein = product.Protein,
        Fat = product.Fat,
        Carbs = product.Carbs};

        return CreatedAtAction(nameof(GetIdProduct), new { id = product.Id }, productDto);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound($"Продукт с {id} не найден");

        _context.Products.Remove(product); // Помечаем на удаление
        await _context.SaveChangesAsync(); // Выполняем DELETE

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromBody] CreateProductDto productDto, int id)
    {
        var productUp = await _context.Products.FindAsync(id); // Ищем в базе
        if (productUp == null) return NotFound($"Продукт с {id} не найден");

        // Обновляем поля
        productUp.Name = productDto.Name;
        productUp.Calories = productDto.Calories;
        productUp.Protein = productDto.Protein;
        productUp.Fat = productDto.Fat;
        productUp.Carbs = productDto.Carbs;

        await _context.SaveChangesAsync(); // EF Core сам поймет, что мы изменили объект, и сделает UPDATE

        return NoContent();
    }
}
