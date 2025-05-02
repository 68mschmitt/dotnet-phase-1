namespace CqrsMediatRDemo.Domain;

public class Order
{
    public Guid Id { get; set; }

    public required string ProductId { get; set; }

    public int Quantity { get; set; }
}
