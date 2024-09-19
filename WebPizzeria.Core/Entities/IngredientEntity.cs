namespace WebPizzeria.Core.Entities;

public class IngredientEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    //many to many relationship with pizzas
    public List<PizzaEntity> Pizzas{ get; set; } = new List<PizzaEntity>();
}