using WebPizzeria.Core.Entities;

namespace WebPizzeria.Core.Dtos;

public class PizzaDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal BasePrice { get; set; }
    public List<Guid> IngredientIds { get; set; } = new();
}