namespace WebPizzeria.Core.Entities;

public class CartEntity
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public decimal TotalPrice { get; set; }

    //many to one relationship with user
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    //many to many relationship with pizza
    public List<PizzaEntity> Pizzas { get; set; } = new List<PizzaEntity>();

    //one to one relationship with order
    public Guid? OrderId { get; set; }
    public OrderEntity? Order { get; set; }
}
