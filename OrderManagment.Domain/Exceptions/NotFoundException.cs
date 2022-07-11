using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string exceptionText) : base(exceptionText)
        {

        }
    }
}
