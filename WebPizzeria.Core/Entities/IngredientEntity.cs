namespace WebPizzeria.Core.Entities;

public class IngredientEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid PizzaId { get; set; }
    public PizzaEntity Pizza { get; set; }
    public IngredientEntity()
    {   
    }
}