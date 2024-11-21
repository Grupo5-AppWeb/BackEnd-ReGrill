using ReGrill.API.Orders.Domain.Model.Commands;

namespace ReGrill.API.Orders.Domain.Model.Aggregates;

public class Order
{
    public int Id { get; private set; }
    public int Cash { get; private set; }
    public string Name { get; private set; }
    public int Table { get; private set; }
    public DateTime Time { get; private set; }
    public string Status { get; private set; }
    public int Quantity { get; private set; }

    public Order()
    {
        
    }
    public Order(CreateOrderCommand command)
    {
        Cash = command.Cash;
        Name = command.Name;
        Table = command.Table;
        Time = command.Time;
        Status = command.Status;
        Quantity = command.Quantity;
    }

    public void Update(UpdateOrderCommand command)
    {
        Cash = command.Cash;
        Name = command.Name;
        Table = command.Table;
        Time = command.Time;
        Status = command.Status;
        Quantity = command.Quantity;
    }
}