using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSerialModena
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                sb.AppendLine(i.ToString());
            }
            System.Console.WriteLine(sb.ToString());

            textBox1.Text = sb.ToString();
        }
    }
}
