using System.ComponentModel;

namespace OrderManagment.API.Models
{
    public class PageModel
    {
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
