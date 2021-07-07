using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Instructor
    {
        public Instructor(){
            Manages = new List<Activity>();
        } 
        public Instructor(string address, string iban, string id, string name, int zipCode,
            string ssn) 
            :base(address, iban, id, name, zipCode){
                    Ssn = ssn;
                    Manages = new List<Activity>();
        }
                   
    }
}