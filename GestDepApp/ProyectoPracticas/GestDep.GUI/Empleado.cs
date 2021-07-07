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
    public partial class Empleado : Form
    {
        private IGestDepService service;
        private PantallaDeInicio PntIni;
        private VerSalasLibres VSL;
        private GestDepApp GDA;
        private InscribirEnActividad IEA;
        public Empleado(IGestDepService service)
        {
            InitializeComponent();
            
            this.service = service;
            this.FormClosed += GestDepApp_FormClosed;
        }
        private void GestDepApp_FormClosed(object sender, FormClosedEventArgs e)
        {            
             Application.Exit();            
        }

        private void Empleado_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEA = new InscribirEnActividad(service);
            IEA.StartPosition = FormStartPosition.Manual;
            IEA.Location = this.Location;
            this.Hide();           
            IEA.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GDA = new GestDepApp(service);
            GDA.StartPosition = FormStartPosition.Manual;
            GDA.Location = this.Location;
            this.Hide();            
            GDA.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VSL = new VerSalasLibres(service);
            VSL.StartPosition = FormStartPosition.Manual;
            VSL.Location = this.Location;
            this.Hide();           
            VSL.Show();
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            PntIni = new PantallaDeInicio(service);
            PntIni.Location = this.Location;
            this.Hide();
        }
    }
}
