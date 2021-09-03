using System;
using System.Collections.Generic;
using System.Text;
using First.Entities.enums;

namespace First.Entities
{
    public class Order
    {   
        public DateTime Moment { get; private set; }
        public OrderStatus Status { get; set; }        
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }        
        
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Summary: ");
            sb.AppendLine($"Order Moment: {Moment}");
            sb.AppendLine($"Order Status: {Status}");
            sb.AppendLine($"Client: {Client.Name} ({Client.BirthDate}) - {Client.Email}");
            sb.AppendLine("Order items: ");
            foreach(OrderItem i in Items)
            {
                sb.AppendLine($"{i.Product.Name}, ${i.Product.Price}, Quantity: {i.Quantity}, SubTotal: ${i.SubTotal()}");
            }
            sb.AppendLine($"Total Price: ${Total()}");
            return sb.ToString();
        }
    }
}