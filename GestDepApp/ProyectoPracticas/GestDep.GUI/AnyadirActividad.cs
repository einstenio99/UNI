using GestDep.Entities;
using GestDep.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestDep.GUI
{
    public partial class AnyadirActividad : Form
    {
        private IGestDepService service;
        private Administrador admin;
        private List<Room> lasroom;
        private Room laroom;
        // List<Days> days = new List<Days>();
        private Days l = Days.None;
        private Days m = Days.None;
        private Days mi = Days.None;
        private Days j = Days.None;
        private Days v = Days.None;
        private Days s = Days.None;
        private Days d = Days.None;
        private int maximumEnrollments;
        private int minimumEnrollments;
        private TimeSpan duration;
        private DateTime startHour;
        private DateTime finishDate;
        private DateTime startDate;
        private string description;
        private double price;
        private CityHall c;
        private Gym g;
        private List<Room> rooms;
        public AnyadirActividad(IGestDepService service)
        {
            InitializeComponent();
            this.service = service;
            LoadData();
            this.FormClosed += GestDepApp_FormClosed;
        }
        private void GestDepApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();            
        }
        public void LoadData()
        {
            
            c = service.FindCityHallByName("Valencia");
            g = c.FindGymByName("Gym1");
            // rooms = g.FindAllRooms();
            rooms = new List<Room>();
            foreach(Room r in g.Rooms)
            {
                rooms.Add(r);
            }
            //stringrooms = new List<String>();
            salas.Items.Clear();
            for (int i = 0; i < g.Rooms.Count; i++)
            {   
                salas.Items.Add("Sala " + rooms[i].Number);
            }
            //salas.Items.Clear();
            //FORMA POCO EFICIENTE, LA MEJOR ABAJO
            /*if (rooms != null)
                foreach (Room r in rooms)
                    salas.Items.Add(r);*/
            //salas.DataSource = stringrooms;
        }
        private void atras_Click(object sender, EventArgs e)
        {
            admin = new Administrador(service);
            admin.StartPosition = FormStartPosition.Manual;
            admin.Location = this.Location;
            this.Hide();
            admin.Show();
        }
        private void lanzadera(String error)
        {
            DialogResult check = MessageBox.Show(this, error, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void lanzaderaCorrecto(String correcto)
        {
            DialogResult check = MessageBox.Show(this, correcto, "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dayBox_Pick(object sender, EventArgs e)
        {
            List<int> temp = new List<int>();

            foreach (var index in dayBox.SelectedIndices)
            {
                int elem = (int)Math.Pow(2, int.Parse(index.ToString()));
                temp.Add(elem);
            }
            /* foreach (var i in temp)
             {
                 switch (i)
                 {
                     case 1: days.Add(Days.Mon); break;
                     case 2: days.Add(Days.Tue); break;
                     case 4: days.Add(Days.Wed); break;
                     case 8: days.Add(Days.Thu); break;
                     case 16: days.Add(Days.Fri); break;
                     case 32: days.Add(Days.Sat); break;
                     case 64: days.Add(Days.Sun); break;
                 }
             }*/
            foreach (var i in temp)
            {
                switch (i)
                {
                    case 1: l = Days.Mon; break;
                    case 2: m = Days.Tue; break;
                    case 4: mi = Days.Wed; break;
                    case 8: j = Days.Thu; break;
                    case 16: v = Days.Fri; break;
                    case 32: s = Days.Sat; break;
                    case 64: d = Days.Sun; break;
                }
            }
        }
        private void descripcion_TextChanged(object sender, EventArgs e)
        {
            //description = descripcion.Text;

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //startDate = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //finishDate = dateTimePicker2.Value;
        }
        private void horafin_TextChanged(object sender, EventArgs e)
        {
          /*  try {
                duration = TimeSpan.Parse(horafin.Text);
            } catch (FormatException) { }*/
        }
        private void precio_click(object sender, EventArgs e)
        {
           /* try
            {
                price = Double.Parse(precio.Text);
            }
            catch (FormatException) { }*/
        }

        private void asistentesminimos_click(object sender, EventArgs e)
        {
           /* try
            {
                minimumEnrollments = int.Parse(min0.Text);
            }
            catch (FormatException) { }*/
        }

        private void asistentesmaximos_click(object sender, EventArgs e)
        {
           /* try
            {
                maximumEnrollments = int.Parse(max1.Text);
             } catch (FormatException) { }*/
}

        private void salas_SelectedIndexChanged(object sender, EventArgs e)
        {
           // int lr = salas.SelectedIndex;
           // laroom = rooms[lr];
        }
        private void hora_inicio(object sender, EventArgs e)
        {
            /*try
            {
                startHour = Convert.ToDateTime(horainicio.Text);
            } catch (FormatException) { }*/
        }
        private void añadir_Click(object sender, EventArgs e)
        {
            try
            {
                //LAST
                /*int lr = salas.SelectedIndices;
                laroom = rooms[lr];*/
              
                    try
               {
                   maximumEnrollments = int.Parse(max1.Text);
                   minimumEnrollments = int.Parse(min0.Text);
                   startHour = Convert.ToDateTime(horainicio.Text);
                   price = Double.Parse(precio.Text);
                   duration = TimeSpan.Parse(horafin.Text);
               }
               catch (Exception) { lanzadera("Error con el formato de los elementos"); }
               finishDate = dateTimePicker2.Value;
               startDate = dateTimePicker1.Value;
               description = descripcion.Text;
               //LAST
               bool sepuede = true;
                if(salas.SelectedIndices.Count < 1) { sepuede = false;  lanzadera("Escoja alguna room"); }

                foreach (int index in salas.SelectedIndices)
                {
                    laroom = rooms[index];
                    foreach (Activity a in laroom.Activities)
                    {
                        if ((startDate <= a.StartDate && finishDate >= a.StartDate) || (startDate >= a.StartDate && startDate <= a.FinishDate))
                        {
                            if ((a.ActivityDays & (l | m | mi | j | v | s | d)) == (l | m | mi | j | v | s | d))
                            {
                                if ((startHour <= a.StartHour && (startHour + duration) >= a.StartHour) || (startHour >= a.StartHour && startHour <= ((a.StartHour) + a.Duration)))
                                {
                                    sepuede = false;
                                    lanzadera( rooms[index].Number + " ocupada en las fechas indicadas, escoja otros valores");

                                }
                            }
                        }
                    }
                }
               //cuando cierra y cuando abre el gym
               //errores con el catch y commit 
               //contar con la duracion de la actividad 

              // string temp = startDate.ToShortTimeString();
               //DateTime startDateshort = Convert.ToDateTime(temp);

               //DateTime startplusduration = startDateshort;
               // startplusduration.Add(duration);
               DateTime startplusduration = startHour + duration;
               //startplusduration.Add(duration);

               /*DateTime ahoritat = DateTime.Now;
               string temp2 = ahoritat.ToShortTimeString();
               DateTime ahorita = Convert.ToDateTime(temp2);*/

                DateTime mindate = g.OpeningHour;
                DateTime maxdate = g.ClosingHour;
               

               // string temp3 = finishDate.ToShortTimeString();
                //DateTime finishDateshort = Convert.ToDateTime(temp3);

                if(startDate >= finishDate)
                {
                    sepuede = false; lanzadera("Error, la fecha de inicio es mayor que la de fin");
                }
                //if ( startDateshort < ahorita) 
                if (startDate < DateTime.Now)
                {
                    sepuede = false; lanzadera("Error, no puedes crear actividades en el pasado, no existe la máquina del tiempo"); 
                }
                string ss = startplusduration.ToShortTimeString();
                DateTime sss = Convert.ToDateTime(ss);
                string ss2 = maxdate.ToShortTimeString();
                DateTime sss2 = Convert.ToDateTime(ss2);
                if ( sss > sss2)
                {
                    sepuede = false; lanzadera("Error, la duración de la actividad supera el horario de cierre del gimnasio");
                }
               /* if (startDateshort < mindate || finishDateshort > maxdate || startplusduration > maxdate)
                {
                    sepuede = false; lanzadera("Error con los tiempos de la creacion de la actividad");
                }*/
                TimeSpan zero= TimeSpan.Parse("00:00");              
               // DateTime maxhours = maxdate - mindate;
                string temporalmax = maxdate.ToShortTimeString();
                string temporalmin = mindate.ToShortTimeString();
                TimeSpan maxdatespan = TimeSpan.Parse(temporalmax);
                TimeSpan mindatespan = TimeSpan.Parse(temporalmin);
                TimeSpan hours = maxdatespan - mindatespan;
                if (duration > hours)
                {
                    sepuede = false; lanzadera("Error con el valor de duración introducido");
                }
                if ( duration < zero)
                {
                    sepuede = false; lanzadera("Error con el valor de duración introducido zero");
                }
                if (minimumEnrollments <= 0  || maximumEnrollments < minimumEnrollments)
                {
                    sepuede = false;
                    lanzadera("Error con la cantidad de asistentes, escoja otros valores");
                }
                if (price < 0) 
                {
                    sepuede = false;
                    lanzadera("Error con el precio indicado, escoja otro valor");
                }
               
                if (sepuede == true)
                {
                    Activity act = new Activity(l | m | mi | j | v | s | d, description, duration, finishDate, maximumEnrollments, minimumEnrollments, price, startDate, startHour);
                    foreach (int index in salas.SelectedIndices)
                    {
                        laroom = rooms[index];
                        laroom.Activities.Add(act);
                    }
                    service.AddActivity(act);
                    g.AddActivity(act);
                    lanzaderaCorrecto("La actividad se ha añadido correctamente");
                }
            }
            catch (Exception) { lanzadera("Faltan datos por rellenar"); }
        }

        private void AnyadirActividad_Load(object sender, EventArgs e)
        {

        }
    } 
}
