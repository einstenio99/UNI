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
using GestDep.Persistence;

namespace GestDep.GUI
{
    public partial class GestDepApp : Form
    {
        private IGestDepService service; // también podría ser protected
        private Empleado empleado;
        public GestDepApp(IGestDepService service)

        {
            InitializeComponent();
            this.service = service;
            this.FormClosed += GestDepApp_FormClosed;
        }

        private void GestDepApp_FormClosed(object sender, FormClosedEventArgs e)
        {            
             Application.Exit();            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            /*Application.Exit();*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GestDepApp_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dir_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void apellidos_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void dni_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void IBAN_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void jubilado_c_b_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void lanzadera(String error)
        {
            DialogResult check = MessageBox.Show(this, error, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void confirm_click(object sender, EventArgs e)
        {
            CityHall c = service.FindCityHallByName("Valencia");
            Gym g = c.FindGymByName("Gym1");
            String NomTotal = nombre_tb.Text + " " + apellidos_tb.Text;
            String DNI = dni_tb.Text;
            DateTime fecha_nac = dateTimePicker.Value;
            String IBAN = IBAN_tb.Text;
            Boolean Jubilado = jubilado_c_b.Checked;
            String cp1 = cp_tb.Text;
            String dir = dir_tb.Text;
            int cp = 0;

            if (nombre_tb.Text.Length == 0 || nombre_tb.Text.Any(char.IsDigit)) {
                nombre_tb.Clear();
                lanzadera("No se permiten en el campo nombre dígitos ni que el mismo esté vacío.");
                return;
            }
            if (apellidos_tb.Text.Length == 0 || apellidos_tb.Text.Any(char.IsDigit))
            {
                apellidos_tb.Clear();
                lanzadera("No se permiten en el campo apellidos dígitos ni que el mismo esté vacío.");
                return;
            }
            if (DNI.Length != 10 || DNI.Remove(0, 9).All(char.IsDigit) || DNI.Remove(DNI.Length - 1, 1).Any(char.IsLetter)) {
                dni_tb.Clear();
                lanzadera("El dni está erróneamente escrito. \n" +
                    "Ejemplo bien escrito : 123456789A");
                return;
            }
            if (cp1.Length != 5 || cp1.Any(char.IsLetter)) {
                cp_tb.Clear();
                lanzadera("El código postal debe tener una longitud de 5 dígitos y no es admitida ninguna letra.");
                return;
            }
            else {cp = int.Parse(cp_tb.Text);}
            if(IBAN.Length != 20 || IBAN.Remove(0, 2).Any(char.IsLetter) 
                || IBAN.Remove(2, IBAN.Length - 2).Any(char.IsDigit)) {
                IBAN_tb.Clear();
                lanzadera("El iban está erróneamente escrito. \n" +
                    "Ejemplo bien escrito : AB123456789123456789");
                return;
            }
            if(dir.Length == 0) { dir_tb.Clear(); lanzadera("No se permiten direcciones nulas."); return; }


            User prov = new User(dir, IBAN, DNI, NomTotal, cp, fecha_nac, Jubilado);
            
            DialogResult res = MessageBox.Show(this, "¿Desea confirmar la inscripcción?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                nombre_tb.Clear(); apellidos_tb.Clear(); dni_tb.Clear(); cp_tb.Clear(); IBAN_tb.Clear(); dir_tb.Clear();
                try
                {
                    service.AddUser(prov);
                    c.AddPerson(prov);
                    DialogResult yea = MessageBox.Show(this, "Inscripcción correctamente completada! :)", "Confirmación",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (yea == DialogResult.OK) {
                        empleado = new Empleado(service);
                        empleado.StartPosition = FormStartPosition.Manual;
                        empleado.Location = this.Location;
                        this.Hide();
                        empleado.Show();
                    }
                } catch (ServiceException) { lanzadera("Este usuario ya existe"); }
            }

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            empleado = new Empleado(service);
            empleado.StartPosition = FormStartPosition.Manual;
            empleado.Location = this.Location;
            this.Hide();
            empleado.Show();
        }

        /*private void Form1_Load(object sender, EventArgs e)
        {

        }*/
    }
}
