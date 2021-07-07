using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestDep.Services;

namespace GestDep.Entities
{
    public partial class Gym
    {
        public Gym()
        {
            Activities = new List<Activity>();
            Rooms = new List<Room>();
            allrooms = new List<Room>();
        }
        public Gym(DateTime closingHour, int discountLocal,
            int discountRetired, double freeUserPrice,
            string name, DateTime openingHour, int zipCode)
        {
            ClosingHour = closingHour;
            DiscountLocal = discountLocal;
            DiscountRetired = discountRetired;
            FreeUserPrice = freeUserPrice;
            Name = name;
            OpeningHour = openingHour;
            ZipCode = zipCode;
            Activities = new List<Activity>();
            Rooms = new List<Room>();
        }
        public void AddActivity(Activity a)
        {
            try
            {
                Activities.Add(a);
            }
            catch (Exception) { throw new ServiceException("NO HA SIDO POSIBLE INSERTAR LA ACTIVIDAD "+ a.Description); }
        }

        public void AddRoom(Room r)
        {            
            foreach (Room rum in Rooms)
                {
                    if (rum.Number == r.Number) 
                    {
                    throw new ServiceException("LA SALA ("+ r.Number +") QUE SE PRETENDE AÑADIR YA EXISTE EN EL GYM");
                    }
                    
            }
        this.Rooms.Add(r);    
        }

        public Room FindRoom(int v)
        {
            foreach (Room r in Rooms)
            {
                if (r.Number == v)
                {
                    return r;
                }
            }
            throw new ServiceException("NO SE HA ENCONTRADO LA SALA " + v);
        }
        public List<Room> FindAllRooms()
        { 
            foreach (Room r in Rooms)
            {
                allrooms.Add(r); 
            }
            return allrooms;
        }



        public Activity FindActivityByName(string d)
        {
                foreach (Activity a in Activities)
                {
                    if (a.Description == d)
                    {
                        return a;
                    }
                }
            throw new ServiceException("NO SE HA ENCONTRADO LA ACTIVIDAD " + d);
        }

        public int GetFreeRooms(DateTime dateTime, Days day)
        {
            try
            {
                /* LA PARTE COMENTADA ES LA FORMA NO OPTIMA DE CONSEGUIR UN DATE TIME CON SOLO LAS HORAS
                 * int hh = dateTime.Hour;
                 int mm = dateTime.Minute;
                 int ss = dateTime.Second;
                 string h = hh.ToString();
                 string m = mm.ToString();
                 string s = ss.ToString();
                 DateTime thisH =  Convert.ToDateTime(hh + ":" + mm + ":" + ss);
                 LAS 2 LÍNEAS DE ABAJO ES LA FORMA ÓPTIMA                
                 */
                string temp = dateTime.ToShortTimeString();
                DateTime thisH = Convert.ToDateTime(temp);
                int cont = 0;
                foreach (Room r in Rooms)
                {
                    foreach (Activity a in r.Activities)
                    {
                        if(dateTime <= a.FinishDate && dateTime >= a.StartDate)
                        {
                            if ((day & a.ActivityDays) == day) 
                            {
                                if(thisH >= a.StartHour && thisH <= (a.StartHour + a.Duration))
                                {
                                    cont++;
                                }
                            }
                        }      
                    }
                }
                return Rooms.Count - cont;
            }catch (Exception){ throw new ServiceException("ERROR AL INTENTAR OBTENER LAS SALAS LIBRES"); }   
        }
    } 
}