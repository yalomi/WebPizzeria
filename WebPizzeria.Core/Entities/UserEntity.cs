namespace WebPizzeria.Core.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.None;

    //one to many relationship with cart
    public List<CartEntity> Carts { get; set; } = new List<CartEntity>();
    //one to many relationship with order
    public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}

public enum Gender
{
    Male,
    Female,
    None
}
