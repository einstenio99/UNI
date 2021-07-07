using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestDep.Services;

namespace GestDep.Entities
{
    public partial class CityHall
    {
        public CityHall() { 
        People = new List<Person>();
        Payments = new List<Payment>();
        Gyms = new List<Gym>();
        }
        public CityHall(string name) :this() {
            Name = name;
        }
        public void AddPayment(Payment p)
        {
            try
            {
                this.Payments.Add(p);
            } catch (Exception) { throw new ServiceException("FALLO EN EN EL PAGO"); }
        }
        public void AddGym(Gym g) 
        {
        foreach(Gym gg in this.Gyms)
            {
                if(gg.Name == g.Name && gg.ZipCode == g.ZipCode)
                {
                    throw new ServiceException(g.Name + " YA EXISTE EN EL SISTEMA");
                }
            }
            this.Gyms.Add(g);
        }
        public Gym FindGymByName(string name)
        {
           
            foreach (Gym g in Gyms)
            {
                if (g.Name == name)
                {
                    return g;
                }
            }
            throw new ServiceException("NO SE HA ENCONTRADO EL GIMNASIO " + name);
        }
        public void AddPerson(Person p)
        {
            try
            {
                foreach(Person pp in this.People)
                {
                    if(pp.Id == p.Id) { throw new ServiceException(p.Name +  " YA EXISTE EN EL SISTEMA"); }
                }
                this.People.Add(p);
            } catch (Exception) { throw new ServiceException("FALLO AL AÑADIR LA PERSONA " + p.Name); }
        }
    } 
}