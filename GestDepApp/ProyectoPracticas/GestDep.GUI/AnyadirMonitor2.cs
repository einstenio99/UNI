using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestDep.Services;
using GestDep.Entities;


namespace GestDep.GUI
{
    public partial class AnyadirMonitor2 : Form
    {
        private IGestDepService service;
        private AnyadirMonitor AMon;
        private CityHall c;
        private Gym g;
        private Activity act;
        private Instructor iii;
        private List<Instructor> instructores = new List<Instructor>();
        public AnyadirMonitor2(IGestDepService service)
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
        private void lanzadera(String error)
        {
            DialogResult check = MessageBox.Show(this, error, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void lanzadera2(String info)
        {
            DialogResult check = MessageBox.Show(this, info, "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LoadData()
        {
            c = service.FindCityHallByName("Valencia");
            g = c.FindGymByName("Gym1");
            //String name = AnyadirMonitor.aaactscb.Text;
            //Console.WriteLine(label3.Text);
            //Activity act = g.FindActivityByName(label3.Text);
            //Console.WriteLine(act);
            //String hola = label3.Text;
            //Console.WriteLine(hola);

            /*try
            {
                ICollection<Activity> acts = service.GetAllActivities();
                actscb2.Items.Clear();
                foreach (Activity a in acts)
                {
                    actscb2.Items.Add(a.Description);
                }
            }
            catch (ServiceException) { lanzadera("No hay actividades"); }*/
        }
        private void button1_Click(object sender, EventArgs e)
        {
            act.SetInstructor(iii);
            lanzadera2("Se ha inscrito a " + iii.Name + " correctamente");
            AMon = new AnyadirMonitor(service);
            AMon.StartPosition = FormStartPosition.Manual;
            AMon.Location = this.Location;
            this.Hide();
            AMon.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AMon = new AnyadirMonitor(service);
            AMon.StartPosition = FormStartPosition.Manual;
            AMon.Location = this.Location;
            this.Hide();
            AMon.Show();
        }

        private void actscb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Instructor i in instructores) {
                if (i.Name == actscb2.Text) { iii = i; }
            }
            button1.Enabled = true;
        }

        private void monitorclick(object sender, EventArgs e)
        {
            String actividad = label3.Text;
            act = g.FindActivityByName(actividad);
            //  Console.WriteLine(hola);
            

            try
            {
                ICollection<Person> personas = c.People;
                //List<Instructor> instructores = new List<Instructor>();
                foreach (Person p in personas)
                {
                    //Console.WriteLine("hola1");
                    try
                    {
                        if (service.FindInstructorById(p.Id) != null)
                        {
                            instructores.Add(service.FindInstructorById(p.Id));
                            //Console.WriteLine("hola2");
                        }
                    }
                    catch (ServiceException) { }
                }
                if (!(instructores.Any())) { lanzadera("No hay instructores disponibles"); }

                //List<Instructor> ins = new List<Instructor>();
                try
                {
                    foreach (Instructor i in instructores)
                    {
                        if (act.Instructor != null) {
                            lanzadera("ESTA ACTIVIDAD YA TIENE UN INSTRUCTOR");
                            AMon = new AnyadirMonitor(service);
                            AMon.StartPosition = FormStartPosition.Manual;
                            AMon.Location = this.Location;
                            this.Hide();
                            AMon.Show();
                            //instructores.Remove(i);
                            /*throw new ServiceException("ESTA ACTIVIDAD YA TIENE UN INSTRUCTOR");*/
                        }
                        foreach (Activity a in i.Activities)
                        {
                            if ((act.StartDate <= a.StartDate && act.FinishDate >= a.StartDate) || (act.StartDate >= a.StartDate && act.StartDate <= a.FinishDate))
                            {
                                if ((a.ActivityDays & act.ActivityDays) == act.ActivityDays)
                                {
                                    if ((act.StartHour <= a.StartHour && (act.StartHour + act.Duration) >= a.StartHour) ||
                                        (act.StartHour >= a.StartHour && act.StartHour <= ((a.StartHour) + a.Duration)))
                                    {
                                        instructores.Remove(i);
                                        /*throw new ServiceException("NO ES POSIBLE AÑADIR A " + i.Name + " DEBIDO A QUE EL HORARIO DE LA ACTIVIDAD A LA QUE SE " +
                                            "LE QUIERE ASIGNAR ESTÁ SOLAPADO CON LA ACTIVIDAD " + a.Description);*/
                                    }
                                }
                            }
                        }

                    }
                }
                catch (InvalidOperationException) { }
                actscb2.Items.Clear();
                foreach (Instructor i in instructores)
                {
                    //foreach (Activity a in i.Activities) { Console.WriteLine(a.Description); }
                    //Console.WriteLine(i.Activities.description);
                    actscb2.Items.Add(i.Name);
                }


              
                //ICollection<Activity> acts = service.GetAllActivities();
                /*actscb2.Items.Clear();
                foreach (Instructor i in instructores)
                {
                    actscb2.Items.Add(i.Name);
                }*/
            }
            catch (ServiceException) { lanzadera("No hay instructores disponibles"); }
        }

        private void AnyadirMonitor2_Load(object sender, EventArgs e)
        {

        }
    }
}
