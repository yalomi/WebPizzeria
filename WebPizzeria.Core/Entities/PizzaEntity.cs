namespace WebPizzeria.Core.Entities;

public class PizzaEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Size Size { get; set; } = Size.Small;
    public decimal BasePrice { get; set; }
    public List<IngredientEntity> Ingredients { get; set; }

    private readonly Dictionary<Size, decimal> PriceCoefficients = new Dictionary<Size, decimal>
    {
        { Size.Small, 1.0m },
        { Size.Medium, 1.4m },
        { Size.Large, 1.7m },
    };

    public decimal CalculatePrice { get => this.BasePrice *= PriceCoefficients[this.Size]; }

    public PizzaEntity()
    {
    }
}

public enum Size
{
    Small,
    Medium,
    Large,
}
