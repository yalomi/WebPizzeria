using System.ComponentModel.DataAnnotations;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.Core.Dtos;

public class PostPizzaDto
{
    public string Name { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }

    public List<int> IngredientIds = new List<int>();
    public List<string>? IngredientNames { get; set; }
}