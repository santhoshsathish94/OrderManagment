using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Repository.QueryModel
{
    public class QueryOrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public int BillingId { get; set; }
        public int CustomerId { get; set; }
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
