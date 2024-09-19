namespace WebPizzeria.Core.Entities;

public class OrderEntity
{
    public Guid Id { get; set; }
    public int Number {  get; set; }

    //one to one relationship with cart
    public Guid CartId { get; set; }
    public CartEntity Cart { get; set; }

    //many to one relationship with user
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}
