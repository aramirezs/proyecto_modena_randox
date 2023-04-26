using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;



//using Microsoft.VisualBasic.Devices; // Recuerden agregar la referencia "Microsoft.VisualBasic".

namespace ProyectoSerialModena
{
    public partial class FrmLog : Form
    {
        public FrmLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombrearch = string.Format("fichero_{0:yyyyMMDD_HHmm}.txt", DateTime.Now);

            var archivo = "E:\\Log" + nombrearch;
            FileStream fs = File.Create(archivo);

            string cadena = "Hola Mundo";
            byte[] bytes = Encoding.UTF8.GetBytes(cadena.ToString());

            foreach (byte b in bytes)
            {
	            fs.WriteByte(b);
            }

            fs.Flush();
            fs.Close();
        }
    }
}
