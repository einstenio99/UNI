using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Instructor : Person
    {
        public Instructor(){
            Activities = new List<Activity>();
        } 
        public Instructor(string address, string iban, string id, string name, int zipCode,
            string ssn) 
            :base(address, iban, id, name, zipCode){
                    Ssn = ssn;
            Activities = new List<Activity>();

        }
                   
    }
}