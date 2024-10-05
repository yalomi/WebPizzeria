namespace WebPizzeria.Core.Dtos;

public class IngredientDto
{
    public string Name { get; set; }
    public List<string> PizzaNames { get; set; } = new List<string>();
}