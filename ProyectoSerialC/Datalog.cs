using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSerialC
{
    public partial class Datalog : Form
    {
        public Datalog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "HL8";
            Utilitarios.Seguridad.LogService(mensaje.ToString());
        }

    }
}
