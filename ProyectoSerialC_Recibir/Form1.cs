using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSerialC_Recibir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            SplitModena();

        }

        //evento split
        private void Split()
        {
            string[] separatingChars = { "<<", "..." };

            string text = "one<<two......three<<four";
            System.Console.WriteLine("Original text: '{0}'", text);

            string[] words = text.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            System.Console.WriteLine("{0} substrings in text:", words.Length);

            foreach (var word in words)
            {
                System.Console.WriteLine(word);
                textBox1.Text = word;
            }        
        }

        private void SplitModena()
        {
            var sb = new System.Text.StringBuilder();
           // ls_hc
            string text = @"H|\^&|410177||cobas infinity ^Roche Diagnostics|||||||||20181228110327";
                           //"P|1|12270227|01858521801||VERGARAY TORRES^VICTORIA||19421223|F|||||||||||||||20181227091410||02^MIRAFLORES"
                           //"O|1|12270227^G||^^^4055|R|20181227091410|||||A||||OTRO||||||||||O"
                           //"R|1|4055^FRAGILIDAD CAPILAR^^4055|NEGATIVO|||||F||||20181228110305|||20181228110305^LUISROJAS"
                           //"L|1|N";

            //string[] separatingChars = { "<<", "..." };
            string[] separatingChars = { "P|1|", "|", "||", "^", "||", "|", "|||||||||||||||", "||", "^" };

        //    string text = "one<<two......three<<four";
            System.Console.WriteLine("Original text: '{0}'", text);


            string[] words = text.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            System.Console.WriteLine("{0} substrings in text:", words.Length);

            foreach (var word in words)
            {
                System.Console.WriteLine(word);
                textBox1.Text = word;

                sb.AppendLine(word + "&&");

                textBox1.Text = sb.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string[] fruits = { "apple", "banana", "mango", 
            //          "orange", "passionfruit", "grape" };

            //long count = fruits.LongCount();

            //Console.WriteLine("There are {0} fruits in the collection.", count);

                 Console.WriteLine("Ingrese una frase: ");
                 String texto = "domingo domingo";
               String[] palabras = {" " };
                int[] nro_repeticion_palabra = new int[palabras.Length];



        }

           
    }
}
