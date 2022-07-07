using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Repository
{
    public class DatabaseOptions
    {
        public const string SectionName = "ConnectionStrings";
        public string OrderDatabase { get; set; } = string.Empty;
    }
}
