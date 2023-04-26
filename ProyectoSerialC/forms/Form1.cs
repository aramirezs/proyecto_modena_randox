using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSerialC.forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("G");
            string rs="ddf";
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

        //

        static System.Timers.Timer t;
        static void Main2(string[] args)
        {
            t = new System.Timers.Timer();
            t.AutoReset = false;
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Interval = GetInterval();
            t.Start();
            Console.ReadLine();
        }

        static double GetInterval()
        {
            DateTime now = DateTime.Now;
            return ((60 - now.Second) * 1000 - now.Millisecond);
        }

        static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("o"));
            t.Interval = GetInterval();
            t.Start();
        }

         //public ActionResult Index()
         //{
         //   TempData[“nombreCompleto”] = "Pedro Pérez";
         //   return RedirectToAction("MuestraNombre");
         //}

        //
    }
}
