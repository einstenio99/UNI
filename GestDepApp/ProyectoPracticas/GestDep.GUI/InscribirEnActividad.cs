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
    public partial class InscribirEnActividad : Form
    {
        private IGestDepService service; // también podría ser protected
        private Empleado empleado;
        private GestDepApp inscribir;
        public InscribirEnActividad(IGestDepService service)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void atras_Click(object sender, EventArgs e)
        {
            empleado = new Empleado(service);
            empleado.StartPosition = FormStartPosition.Manual;
            empleado.Location = this.Location;
            this.Hide();
            empleado.Show();
        }

        private void InscribirEnActividad_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buscar_click(object sender, EventArgs e)
        {
            CityHall c = service.FindCityHallByName("Valencia");
            Gym g = c.FindGymByName("Gym1");
            String dni = textBox1.Text;
            if (descrpag.Text == null) { descrpag.Text = ""; }
            if (textBox1.Text == null) { lanzadera("Introduzca un DNI."); }
            if (actscb.SelectedItem == null) { lanzadera("Escoja una actividad.");
                return;
            }
            try {
                richTextBox1.Clear();
                User prov = service.FindUserById(dni);
                richTextBox1.Text += "DNI: " + prov.Id + "\n";
                richTextBox1.Text += "Nombre y Apellidos: " + prov.Name +"\n";
                richTextBox1.Text += "IBAN: " + prov.IBAN + "\n";
                richTextBox1.Text += "Dirección: " + prov.Address + "\n";
                richTextBox1.Text += "Código Postal: " + prov.ZipCode + "\n";
                textBox2.Clear();
                Activity aprov = g.FindActivityByName(actscb.SelectedItem.ToString());
                textBox2.Text = aprov.GetPriceForUser(g, prov).ToString();
                button2.Enabled = true;

            }
            catch (ServiceException) 
            {
                if (dni.Length != 10 || dni.Remove(0, 9).All(char.IsDigit) || 
                    dni.Remove(dni.Length - 1, 1).Any(char.IsLetter)) {
                    lanzadera("El DNI introducido es erróneo.");
                } 
                else {
                    DialogResult check = MessageBox.Show(this, "No se ha encontrado un usuario con ese DNI. \n " +
                     "¿Desea inscribirlo?", "Usuario no encontrado",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (check == DialogResult.Yes)
                    {
                        inscribir = new GestDepApp(service);
                        inscribir.StartPosition = FormStartPosition.Manual;
                        inscribir.Location = this.Location;
                        this.Hide();
                        inscribir.dni_tb.Text = dni;
                        inscribir.Show();
                    } else { return; }
                }                  
            }
        }

        private void LoadData()
        {
            CityHall c = service.FindCityHallByName("Valencia");
            Gym g = c.FindGymByName("Gym1");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ICollection<Activity> acts = service.GetAllActivities();
                actscb.Items.Clear();
                foreach (Activity a in acts)
                {
                    if (fecha.Value >= a.StartDate && fecha.Value < a.FinishDate)
                    {
                        actscb.Items.Add(a.Description);
                    }
                }
            }
           
            catch (ServiceException) { lanzadera("No hay actividades"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String dni = textBox1.Text;
            CityHall c = service.FindCityHallByName("Valencia");
            Gym g = c.FindGymByName("Gym1");
            User prov = service.FindUserById(dni);
            Activity aprov = g.FindActivityByName(actscb.SelectedItem.ToString());
            try
            {
                if (aprov.Enrollments.Count == aprov.MaximumEnrollments) { lanzadera("esta actividad no acepta mas inscripcciones"); return; }
                Payment pe = new Payment(DateTime.Today, descrpag.Text, aprov.GetPriceForUser(g, prov));
                Enrollment enroll = new Enrollment(fecha.Value, aprov, pe, prov);
                service.AddEnrollment(enroll);
                DialogResult check = MessageBox.Show(this, "Inscripccion hecha correctamente", "Confirmación de pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (check == DialogResult.OK)
                {
                    empleado = new Empleado(service);
                    empleado.StartPosition = FormStartPosition.Manual;
                    empleado.Location = this.Location;
                    this.Hide();
                    empleado.Show();
                }
            }
            catch (ServiceException)
            {
                lanzadera("Esta inscrippción ya existe.");
                button2.Enabled = false;
                return;
            }
            catch (Exception) 
            {
                lanzadera("Ponga un valor de pago. ");
                button2.Enabled = false;
                return;
            }
        }

       
    }
}
