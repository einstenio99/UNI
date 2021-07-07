using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Gym
    {
        public Gym()
        {
            Offers = new List<Activity>();
            Has = new List<Room>();
        }
        public Gym(DateTime closingHour, int discountLocal, int discountRetired, double freeUserPrice, int id,
            string name, DateTime openingHour, int zipCode)
        {
            ClosingHour = closingHour;
            DiscountLocal = discountLocal;
            DiscountRetired = discountRetired;
            FreeUserPrice = freeUserPrice;
            Id = id;
            Name = name;
            OpeningHour = openingHour;
            ZipCode = zipCode;
            Offers = new List<Activity>();
            Has = new List<Room>();
        }
    }
}