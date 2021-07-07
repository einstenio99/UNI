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
    public partial class AnyadirMonitor : Form
    {
        private IGestDepService service;
        private Administrador admin;
        private AnyadirMonitor2 AMon2;
        String name;
        public AnyadirMonitor(IGestDepService service)
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
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            CityHall c = service.FindCityHallByName("Valencia");
            Gym g = c.FindGymByName("Gym1");
            try
            {
                ICollection<Activity> acts = service.GetAllActivities();
                aaactscb.Items.Clear();
                foreach (Activity a in acts)
                {
                    aaactscb.Items.Add(a.Description);
                }
            }
            catch (ServiceException) { lanzadera("No hay actividades"); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AMon2 = new AnyadirMonitor2(service);
            AMon2.StartPosition = FormStartPosition.Manual;
            AMon2.Location = this.Location;
            this.Hide();
            AMon2.label3.Text = name;
            AMon2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin = new Administrador(service);
            admin.StartPosition = FormStartPosition.Manual;
            admin.Location = this.Location;
            this.Hide();
            admin.Show();
        }

        private void actscb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("test");
            CityHall c = service.FindCityHallByName("Valencia");
            Gym g = c.FindGymByName("Gym1");
            name = aaactscb.Text;
            
            

            try
            {
                richTextBox1.Clear();
                Activity act = g.FindActivityByName(name);
                string temp = act.StartHour.ToShortTimeString();
                string temp2 = act.StartDate.ToShortDateString();
                string temp3 = act.FinishDate.ToShortDateString();
                richTextBox1.Text += "Actividad: " + name + "\n";
                richTextBox1.Text += "Duracion: " + act.Duration + "\n";
                richTextBox1.Text += "Dias: " + act.ActivityDays + "\n";
                richTextBox1.Text += "Hora inicio: " + temp + "\n";
                richTextBox1.Text += "Fecha inicio: " + temp2 + "\n";
                richTextBox1.Text += "Fecha fin: " + temp3 + "\n";
                richTextBox1.Text += "Inscripciones minimas: " + act.MinimumEnrollments + "\n";
                richTextBox1.Text += "Inscripciones maximas: " + act.MaximumEnrollments + "\n";
                richTextBox1.Text += "Precio: " + act.Price + "\n";
                richTextBox1.Text += "Descripcion: " + act.Description + "\n";
                button1.Enabled = true;
            }
            catch (ServiceException){ }
            }
        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
