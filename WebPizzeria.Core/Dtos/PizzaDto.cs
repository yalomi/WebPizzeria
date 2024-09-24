using WebPizzeria.Core.Entities;

namespace WebPizzeria.Core.Dtos;

public class PizzaDto
{
    public string Name { get; set; } = string.Empty;
    public Size Size { get; set; } = Size.Small;
    public decimal BasePrice { get; set; }
    public List<Guid> IngredientsIds { get; set; } = new List<Guid>();
}
