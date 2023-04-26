using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;


  using System;
    using System.Globalization;
using System.Threading;


namespace ProyectoSerialC_Recibir
{
    public partial class Form3 : Form
    {
        private string ls_hc, ls_apellidos, ls_nombres, ls_nom_emp, ls_cod_cia, ls_nom_suc, ls_cod_suc, ls_nom_med, ls_nom_cia, ls_sexo, ls_usuario,
           ls_fnac, ls_fechahora, ls_yearorden, ls_ordnumero, ls_edad, ls_sexo_C, ls_Numcia, ls_NumPac, ls_anioPac, ls_liscodigo, ls_ncabecera, ls_proveedor, ls_proveedornom;


        private string ls_fechahora2, ls_fechahora3, ls_usuarioVal, ls_exacodigo, ls_result1, ls_tipo, ls_exa_nombre, ls_nroorden;

        public Form3()
        {
            InitializeComponent();
        }
        private int[] sueldos;
        public void Cargar()
        {
            sueldos = new int[5];
            for (int f = 0; f < 5; f++)
            {
                Console.Write("Ingrese valor de la componente:");
                String linea;
                //linea = Console.ReadLine();
                linea = "30";
                sueldos[f] = int.Parse(linea);

                Console.WriteLine(sueldos[f]);
                //             textBox1.Text = sueldos[f].ToString(); 
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ArrayList palabras = new ArrayList();
            string frase = "reakdkdkd dkkd";
            Console.WriteLine(" Ingrese Numero de palabras: ");
            int limite = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < limite; i++)
            {
                Console.WriteLine(" Ingrese palabra: ");
                palabras.Add(Console.ReadLine());
            }

            for (int i = 0; i < palabras.Count; i++)
            {
                frase += palabras[i].ToString() + " ";
            }
            Console.WriteLine("Frase Completa: " + frase);
            Console.ReadKey();
        }

        static void MainArray(string[] args)
        {
            ArrayList palabras = new ArrayList();
            string frase = "";
            Console.WriteLine(" Ingrese Numero de palabras: ");
            int limite = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < limite; i++)
            {
                Console.WriteLine(" Ingrese palabra: ");
                palabras.Add(Console.ReadLine());
            }

            for (int i = 0; i < palabras.Count; i++)
            {
                frase += palabras[i].ToString() + " ";
            }
            Console.WriteLine("Frase Completa: " + frase);
            Console.ReadKey();
        }

        private void UnionForeach()
        {
            var numbers = new[] { 1, 2, 3, 4 };
            var words = new[] { "one", "two", "three", "four" };

            var numbersAndWords = numbers.Zip(words, (n, w) => new { Number = n, Word = w });
            foreach (var nw in numbersAndWords)
            {
                Console.WriteLine(nw.Number + nw.Word);
            }
        }
        private String extraerValorIni(String cadena, String stringInicial, String stringFinal)
        {
            int terminaString = cadena.LastIndexOf(stringFinal);
            String nuevoString = cadena.Substring(0, terminaString);
            int offset = stringInicial.Length;
            int iniciaString = nuevoString.LastIndexOf(stringInicial) + offset;

            int cortar = nuevoString.Length - iniciaString;
            nuevoString = nuevoString.Substring(iniciaString, cortar);
            return nuevoString;

        }
        private void SplitModena()
        {
            var sb = new System.Text.StringBuilder();
            // ls_hc
            /*string text =   @"H|\^&|410177||cobas infinity ^Roche Diagnostics|||||||||20181228110327" +
                            "P|1|12270227|01858521801||VERGARAY TORRES^VICTORIA||19421223|F|||||||||||||||20181227091410||02^MIRAFLORES" +
                            "O|1|12270227^G||^^^4055|R|20181227091410|||||A||||OTRO||||||||||O" +
                            "R|1|4055^FRAGILIDAD CAPILAR^^4055|NEGATIVO|||||F||||20181228110305|||20181228110305^LUISROJAS" +
                            "L|1|N";
            */
            string text = @"H|\^&|471082||cobas infinity ^Roche Diagnostics|||||||||20190119190405
                        P|1|1190457|01101910701||ROJAS ORE^SANDRA ANGELICA||19900210|F|||||||||||||||20190119112549||03^LOS OLIVOS
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
            //string[] separatingChars = { "<<", "..." };
            string[] separatingChars = {@"H|","|","^" ,"|||||||||",    
                                        "P|", "|", "||", "^", "||", "|", "|||||||||||||||", "||", "^" ,
                                        "O|","^G||^^^","|R|","|||||A||||","||||||||||",
                                        "R|","^","^^","|","|||||","||||","|||","^"
                                       };
            //    string text = "one<<two......three<<four";
            //  System.Console.WriteLine("Original text: '{0}'", text);
            string[] words = text.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            //    System.Console.WriteLine("{0} substrings in text:", words.Length);
            int i = 0;
            foreach (var word in words)
            {

                System.Console.WriteLine(word);
 //               txtRecibir2.Text = word;

                sb.AppendLine(word + "&&");

                //txtRecibir2.Text = sb.ToString();
                i++;

                if (i == 1) { ls_ncabecera = word; }
                else if (i == 2) { ls_proveedor = word; }
                else if (i == 3) { ls_proveedornom = word; }
                else if (i == 4) { ls_fechahora = word; }
                else if (i == 5) { ls_ordnumero = word; }
                else if (i == 6) { ls_hc = word; }
                else if (i == 7) { ls_apellidos = word; }
                else if (i == 8) { ls_nombres = word; }
                else if (i == 9) { ls_fnac = word; }
                else if (i == 10) { ls_sexo = word; }
                else if (i == 11) { ls_fechahora2 = word; }
                else if (i == 12) { ls_cod_suc = word; }
                else if (i == 13) { ls_nom_cia = word; }
                else if (i == 14) { ls_ordnumero = word; }
                else if (i == 15) { ls_exacodigo = word; }
                else if (i == 16) { ls_fechahora = word; }
                else if (i == 17) { ls_tipo = word; }
                else if (i == 18) { ls_exacodigo = word; }
                else if (i == 19) { ls_exa_nombre = word; }
                else if (i == 20) { ls_result1 = word; }
                else if (i == 21) { ls_sexo = word; }
                else if (i == 22) { ls_fechahora3 = word; }
                else if (i == 23) { ls_fechahora3 = word; }
                else if (i == 24) { ls_usuarioVal = word; }

                else
                {
                    // ls_proveedornom = word;
                }

                //year orden -- ini
                //li_year = DateTime.Today.Year;
                //li_month = DateTime.Today.Month;
                //ls_nroorden = ("00" + ls_nroorden);
                //ls_yearorden = li_year + ls_nroorden;


                //ls_nroorden =Right( "00" + dw_trama_cab.object.nroorden[1]  , 8)


                //year orden -- fin


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            sleep();
          
        }
        //public static void Sleep(TimeSpan timeout);
        private void sleep()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Sleep for 2 seconds.");
                Thread.Sleep(10000);
            }

            Console.WriteLine("Main thread exits.");
        }


    }
}


