using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using CapaDatos;
using CapaNegocio;

namespace ProyectoSerialC_Recibir
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Modena();
          //  Extraer();13/25
        }
        string text = @"H|\^&|471082||cobas infinity ^Roche Diagnostics|||||||||20190119190405.
                        P|1|1190457|01101910701||ROJAS ORE^SANDRA ANGELICA||19900210|F|||||||||||||||20190119112549||03^LOS OLIVOS.
                        O|1|1190457-3^G||^^^  4100\^^^4105\^^^4106\^^^4107\^^^4108\^^^4109\^^^4112\^^^4113\^^^4114\^^^4115\^^^4116\^^^4117\^^^4119\^^^4120\^^^4121\^^^4122\^^^4123\^^^4124|R|20190119112549|||||A||||SANGRE||||||||||O
                        R|1|4100^RECUENTO DE HEMATIES NUCLEADOS^^  4100|0.00|10^6xmm³||||F||||20190119182150|709||20190119190345^AVIDARTE|2
                        R|2|4005^HB CORPUSCULAR MEDIA^^4105||pg|26.00^38.00|||F||||18401231000000|709||18401231000000|1
                        R|3|4006^CONCENTRACION HB CORPUSCULAR MEDIA^^4106||g/dL|31.00^37.00|||F||||18401231000000|709||18401231000000|1
                        R|4|4007^DISTRIBUCION ERITROCITARIA (RDW)^^4107|17.8|%|11.00^16.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
                        R|5|4008^RECUENTO DE PLAQUETAS^^4108|233|10³/mm³|150.00^450.00|||F||||20190119182150|709||20190119190345^AVIDARTE|0
                        R|6|4009^VOLUMEN PLAQUETARIO MEDIO^^4109|----|fL|9.00^13.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
                        R|7|4012^SEGMENTADOS %^^4112|49.2|%|50.00^70.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
                        R|8|4013^LINFOCITOS %^^4113|41.5|%|25.00^40.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
                        R|9|4014^MONOCITOS %^^4114|7.8|%|2.00^10.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
                        R|10|4015^EOSINOFILOS %^^4115|1.2|%|0.00^5.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
                        R|11|4016^BASOFILOS %^^4116|0.3|%|0.00^1.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
                        R|12|4117^GRANULOCITOS INMADUROS %^^4117|0.3|%|0.00^0.50|||F||||20190119182150|709||20190119190345^AVIDARTE|1
                        R|13|4018^SEGMENTADOS^^4119|2.98|10^3xmm³|2.00^7.00|||F||||20190119182150|709||20190119190345^AVIDARTE|2
                        R|14|4019^LINFOCITOS^^4120|2.51|10^3xmm³|1.50^4.00|||F||||20190119182150|709||20190119190345^AVIDARTE|2
                        R|15|4020^MONOCITOS^^4121|0.47|10^3xmm³|0.00^1.10|||F||||20190119182150|709||20190119190345^AVIDARTE|2
                        R|16|4021^EOSINOFILOS^^4122|0.07|10^3xmm³|0.00^0.40|||F||||20190119182150|709||20190119190345^AVIDARTE|2
                        R|17|4022^BASOFILOS^^4123|0.02|10^3xmm³|0.00^0.20|||F||||20190119182150|709||20190119190345^AVIDARTE|2
                        R|18|4124^GRANULOCITOS INMADUROS^^4124|0.02|10^3xmm³|0.00^0.00|||F||||20190119182150|709||20190119190346^AVIDARTE|2
                        L|1|N";

        private string[] Resultado;
        private string[] Resultado_final;

        private string[] Ordenes;
        public void Modena()
        {
            var sb = new System.Text.StringBuilder();

            string[] separatingChars = { "\r\n" };
            string[] words = text.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            //    System.Console.WriteLine("{0} substrings in text:", words.Length);
            int i = 0;

            Resultado = new string[]{};
            Resultado_final = new string[4];
         //   Ordenes = new string[50];
                
            Resultado = new string[words.Count()];

            foreach (var word in words)
            {
                System.Console.WriteLine(word);
                i++;                
                Resultado[i-1] = ReducirEspaciado(word).ToString();

                string cadena = Resultado[i-1].ToString();
                ReducirEspaciado(cadena);

                if (i -1 == 0)
                {
                    //--Cabecera
                    string[] Inicial = { @"H|\^&|", "||", "|||||||||" };
                    string[] final = { "||", "|||||||||", "." };                   

                    string[] ResultadoC = ExtraerCaracter(cadena,Inicial,final);

                    //almacenar
                }
                else if (i-1 == 1)
                {
                    //--Paciente
                    string[] Inicial = { @"P|1|", "|", "||", "^", "||", "|", "|||||||||||||||", "||", "^" };
                    string[] final = { "|", "||", "^", "||", "|", "|||||||||||||||", "||", "^", "." };
                    string[] ResultadoP = ExtraerCaracter(cadena,Inicial, final);

                }
                else if (i-1 == 2)
                {

                    string[] Inicial = { "||" };
                    string[] final = { "|R|" };
                    string[] ResultadoO = ExtraerCaracter(cadena, Inicial, final);

                    string[] separatingChars_Ord = { "^^^", @"\" };
                    string[] Result_Ord = Resultado[0].Split(separatingChars_Ord, System.StringSplitOptions.RemoveEmptyEntries);

                    //var u = 0;
                    //foreach (var Word_ord in Result_Ord)
                    //{
                    //    u++;
                    //    //Ordenes[u-1] = Word_ord.ToString();
                    //   string[]ordenehs= Word_ord.ToString();
                    //}
                    //Envio de ExaCodigos

                }
                else if (i-1 >= 3)
                {
                    if (cadena.StartsWith("R")) 
                    {
                        string[] ResultadoR;
                        
                        string[] Inicial = { "R|", "|", "^", "^^", "|", "|", "|||", "||", "||", "|", "||" };
                        string[] final = { "|", "^", "^^", "|", "|", "|||", "||", "||", "|", "||", "|" };
                      ResultadoR = ExtraerCaracter(cadena, Inicial, final);                    
                    }
                    else if (cadena.StartsWith("C"))
                    {
                        string[] ResultadoC;
                        string[] Inicial = { "C|", "|", "|", "|"  , "|" };
                        string[] final   = { "|" , "|", "|", "|"  , "|" };
                        ResultadoC = ExtraerCaracter(cadena, Inicial, final); 
                    }   
                }
             }
          }

        //public void ExtraerCaracter(string cadena,string []Inicial,string [] final)
        public string[] ExtraerCaracter(string cadena, string[] Inicial, string[] final)
        {
            string[] NuevoTexto;

            //1er parametro Nro de Orden
            var Separadores = Inicial.Zip(final, (i, f) => new { Inicial = i, final = f });

            NuevoTexto = new string[20];
            Resultado = new string[50];
            NuevoTexto[0] = cadena.ToString();
            string nuevoString_a;
            int CantidadLet;
            int o = -1;
            foreach (var sp in Separadores)
            {
                o++;
                int offset_a = (sp.Inicial).Length;
                int terminastring_a;
                if (o == 0)
                {
                    terminastring_a = cadena.IndexOf(sp.final, offset_a);
                    nuevoString_a = cadena.Substring(0, terminastring_a);
                    CantidadLet = cadena.Length - terminastring_a;
                    NuevoTexto[o + 1] = cadena.Substring(terminastring_a, CantidadLet);           
                }
                else
                {
                    terminastring_a = NuevoTexto[o].IndexOf(sp.final, offset_a);
                    nuevoString_a = NuevoTexto[o].Substring(0, terminastring_a);
                    CantidadLet = NuevoTexto[o].Length - terminastring_a;
                    NuevoTexto[o + 1] = NuevoTexto[o].Substring(terminastring_a, CantidadLet);
                }

                int iniciaString_a = nuevoString_a.LastIndexOf(sp.Inicial) + offset_a;
                int cortar_a = nuevoString_a.Length - iniciaString_a;
                nuevoString_a = nuevoString_a.Substring(iniciaString_a, cortar_a);
                Resultado[o] = nuevoString_a;

              }
            return Resultado;
          }

        public static string ReducirEspaciado(string Cadena)
        {
            while (Cadena.Contains("  "))
            {
                Cadena = Cadena.Replace("  ", "");
            }

            return Cadena;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modena();
        }
    }
}
