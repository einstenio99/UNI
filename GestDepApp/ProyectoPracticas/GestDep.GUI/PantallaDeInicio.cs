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

namespace GestDep.GUI
{
    public partial class PantallaDeInicio : Form
    {
        private IGestDepService service; // también podría ser protected
        private Administrador AdminForm;
        private Empleado EmpleForm;
        public PantallaDeInicio(IGestDepService service)
        {
            InitializeComponent();
            Show();
            /*AdminForm = new Administrador(service);
            EmpleForm = new Empleado(service);*/
            this.service = service;
            this.FormClosed += GestDepApp_FormClosed;

        }

        private void GestDepApp_FormClosed(object sender, FormClosedEventArgs e)
        {            
             Application.Exit();            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Empleado_Click(object sender, EventArgs e)
        {
            EmpleForm = new Empleado(service);
            EmpleForm.StartPosition = FormStartPosition.Manual;
            EmpleForm.Location = this.Location;
            this.Hide();
            
            EmpleForm.ShowDialog();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            AdminForm = new Administrador(service);
            AdminForm.StartPosition = FormStartPosition.Manual;
            AdminForm.Location = this.Location;
            this.Hide();           
            AdminForm.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void PantallaDeInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
