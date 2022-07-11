using System.Text.Json.Serialization;

namespace OrderManagment.API.Models
{
    public class OrderItemModel
    {
        public virtual int OrderId { get; set; }
        public virtual int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderItemUpdateModel : OrderItemModel
    {
        [JsonIgnore]
        public override int OrderId { get; set; }
        [JsonIgnore]
        public override int ProductId { get; set; }

    }
}
