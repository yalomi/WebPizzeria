namespace WebPizzeria.Core.Entities;

public class PizzaEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Size Size { get; set; } = Size.Small;
    public decimal BasePrice { get; set; }

    //many to many relationship with ingredient
    public List<IngredientEntity> Ingredients { get; set; } = new List<IngredientEntity>();

    //many to many relationship with cart
    public List<CartEntity> Carts { get; set; } = new List<CartEntity>();

    private readonly Dictionary<Size, decimal> PriceCoefficients = new Dictionary<Size, decimal>
    {
        { Size.Small, 1.0m },
        { Size.Medium, 1.4m },
        { Size.Large, 1.7m },
    };

    public decimal FinalPrice { get => this.BasePrice *= PriceCoefficients[this.Size]; }
}

public enum Size
{
    Small,
    Medium,
    Large,
}
