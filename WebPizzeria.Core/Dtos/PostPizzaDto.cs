namespace WebPizzeria.Core.Dtos;

public class PostPizzaDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public List<string>? IngredientNames { get; set; }
}