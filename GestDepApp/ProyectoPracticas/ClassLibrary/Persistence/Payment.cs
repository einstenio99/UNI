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
        public Payment(DateTime date, string description, int id, double quantity)
        {
            Date = date;
            Description = description;
            Id = id;
            Quantity = quantity;
        }
    }
}