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
    public partial class Administrador : Form
    {
        private IGestDepService service;
        private PantallaDeInicio PntIni;
        private AnyadirActividad Aact;
        private AnyadirMonitor AMon;
        public Administrador(IGestDepService service)
        {
            InitializeComponent();
            this.service = service;
            this.FormClosed += GestDepApp_FormClosed;
        }
        private void GestDepApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();            
        }
        private void Administrador_Load(object sender, EventArgs e)
        {

        }

        private void addact_Click(object sender, EventArgs e)
        {
            Aact = new AnyadirActividad(service);
            Aact.StartPosition = FormStartPosition.Manual;
            this.Hide();
            Aact.Location = this.Location;
            Aact.Show();
        }

        private void addmonitor_Click(object sender, EventArgs e)
        {
            AMon = new AnyadirMonitor(service);
            AMon.StartPosition = FormStartPosition.Manual;
            this.Hide();
            AMon.Location = this.Location;
            AMon.Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            PntIni = new PantallaDeInicio(service);
            PntIni.Location = this.Location;
            this.Hide();
        }
    }
}
