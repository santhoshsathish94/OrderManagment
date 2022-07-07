using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Repository.Entities
{
    public class Product
    {
       public int Id { get; set; }            
       public string? ProductName { get; set; }
       public int SupplierId { get; set; }
       public decimal UnitPrice { get; set; }
       public int Package { get; set; }
       public bool IsDiscontinued { get; set; }
    }
}
