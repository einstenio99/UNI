using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestDep.Entities;
using GestDep.Services;

namespace GestDep.GUI
{
    public partial class VerSalasLibres : Form
    {
        private Empleado admin;
        private Gym g;
        private CityHall c;
        private IGestDepService service;
        int cont = 0;
        DataGridViewRow row0;
        List<int> list1;
       
        String cosa;
       String inicioplus45S;
        String inicioshortS;
        DateTime inicioplus45;
        DateTime iniciocont;
        DateTime inicio;
        DateTime fin;
        public VerSalasLibres(IGestDepService service)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            /* double a =  inicio.ToShortDateString().Split('/');
             inicio = inicio.AddDays(dateTimePicker1.Value);*/
            
            DateTime prov = dateTimePicker1.Value;
            prov = prov.AddDays(-(prov.DayOfWeek - DayOfWeek.Monday));
            string provS = prov.ToShortDateString();
            string jdr = provS + " " + g.OpeningHour.ToShortTimeString()+":00";
            Console.WriteLine(jdr);
            iniciocont = Convert.ToDateTime(jdr);

            DateTime prov2 = dateTimePicker1.Value;
            prov2 = prov2.AddDays(-(prov2.DayOfWeek - DayOfWeek.Monday));
            string prov2S = prov2.ToShortDateString();
            string jdr2 = prov2S + " " +g.ClosingHour.ToShortTimeString()+":00";
            fin = Convert.ToDateTime(jdr2);
            Console.WriteLine(jdr2);
            cont = 0;
            while (iniciocont < fin)
            {
                //HORAS           
                inicioplus45 = inicioplus45.AddMinutes(45);        
                iniciocont = inicioplus45;
                //TERMINA HORAS
                if (list1.Count == 0)
                {
                    
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Mon));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Tue));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Wed));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Thu));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Fri));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Sat));
                } else {
                    list1.Clear();
                    
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Mon));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Tue));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Wed));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Thu));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Fri));
                    list1.Add(g.GetFreeRooms(iniciocont, Days.Sat));
                }
                cont++;
            }
            Console.WriteLine(cont);
            for (int f = 0; f < 8; f++)
            {
                row0 = (DataGridViewRow)dataGridView1.Rows[f];
                for (int j = 0; j < list1.Count; j++)
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        row0.Cells[i].Value = list1[j];
                    }
                }
            }
        }
        public void LoadData()
        {
            try
            {
               //dateTimePicker1.Value = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday));
                //d = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday));
                c = service.FindCityHallByName("Valencia");
                g = c.FindGymByName("Gym1");
            }
            catch (NullReferenceException) { lanzadera("Ha habido un error"); }
            // GestDep.Entities.Days d = Days.Mon;
            list1 = new List<int>();
            inicio = g.OpeningHour;
            fin = g.ClosingHour;
            inicioplus45 = inicio;
            iniciocont = inicio;
            while (iniciocont < fin)
            {

                //HORAS
                inicioshortS = iniciocont.ToShortTimeString();
                inicioplus45 = inicioplus45.AddMinutes(45);
                inicioplus45S = inicioplus45.ToShortTimeString();
                cosa = inicioshortS + " - " + inicioplus45S;
                dataGridView1.Rows.Add(cosa);
                // dataGridView1.Rows.Insert(-1, cosa);
                iniciocont = inicioplus45;
                //TERMINA HORAS
                list1.Add(g.GetFreeRooms(iniciocont, Days.Mon));
                list1.Add(g.GetFreeRooms(iniciocont, Days.Tue));
                list1.Add(g.GetFreeRooms(iniciocont, Days.Wed));
                list1.Add(g.GetFreeRooms(iniciocont, Days.Thu));
                list1.Add(g.GetFreeRooms(iniciocont, Days.Fri));
                list1.Add(g.GetFreeRooms(iniciocont, Days.Sat));
               // cont++;
            }
           /* for (int f = 0; f < cont; f++)
            {
                row0 = (DataGridViewRow)dataGridView1.Rows[f];
                for (int j = 0; j < cont * 6; j++)
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        row0.Cells[i].Value = list1[j];
                    }
                }
            }*/
        }
       
        private void VerSalasLibres_Load(object sender, EventArgs e)
        {
           
        }

        private void back_Click(object sender, EventArgs e)
        {
            admin = new Empleado(service);
            admin.StartPosition = FormStartPosition.Manual;
            admin.Location = this.Location;
            this.Hide();
            admin.Show();
        }
    }
}
