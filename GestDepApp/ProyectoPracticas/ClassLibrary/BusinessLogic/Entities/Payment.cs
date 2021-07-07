using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Payment
    {
        public Payment() { }
        public Payment(DateTime date, string description, double quantity)
        {
            Date = date;
            Description = description;
            Quantity = quantity;
        }
    }
}