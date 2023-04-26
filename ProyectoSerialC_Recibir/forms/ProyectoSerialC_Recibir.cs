using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

using CapaEntidades;
using CapaNegocio;

using System.Threading;
namespace ProyectoSerialC_Recibir.forms
{public partial class ProyectoSerialC_Recibir : Form
    {
        #region Variables Privadas

        private List<BEServicios_Rec> ListOrden_Result= null;
        //private List<BEServicios> ListServiciosPac = null;

        #endregion

        private delegate void DelefadoAcceso(string accion);
        private string strBufferIn;
        private string strBufferOut;

        private string spaceNroOrden;
        private string spaceYearOrden2;
        private string Apellidos;
        private string NumeroOrden;
        private string Sexo;

        private string ls_hc, ls_apellidos, ls_nombres, ls_nom_emp, ls_cod_cia, ls_nom_suc, ls_cod_suc, ls_nom_med, ls_nom_cia, ls_sexo, ls_usuario,
                   ls_fnac, ls_fechahora, ls_yearorden,ls_year, ls_ordnumero, ls_edad, ls_sexo_C, ls_Numcia, ls_NumPac, ls_anioPac, ls_liscodigo, ls_ncabecera,ls_proveedor,ls_proveedornom;


        private string ls_fechahora2, ls_fechahora3, ls_exacodigo,ls_exacodigo_inf, ls_result1, ls_tipo, ls_exa_nombre, ls_nroorden, ls_unidad_nombre,
                       ls_usuarioVal, ls_fuera_rango, ls_TbAntibio, ls_FlagCerrado, ls_cantidad_dec, ls_result_comenta, ls_result_valor, ls_ref_max, ls_ref_min,ls_Numfox;

        private DateTime ls_fechaValidacion;


        //private string li_year;

        private int li_year, li_month, month;

        private string cadena;
        public ProyectoSerialC_Recibir()
        {
            InitializeComponent();
        }
        private void AccesoForm(string accion)
        {
            var sb = new System.Text.StringBuilder();
            strBufferIn = accion;
            
            txtRecibirDatos.Text = strBufferIn;

            long b = accion.LongCount(letra => letra.ToString() == "&");
            sb.AppendLine(DateTime.Now.ToString("G")  +"  Total de ordenes recibidas: " + b.ToString());



       //     long count = (from x in accion where x => "L" select x).LongCount();  // count: 2
            

          //  sb.AppendLine(b.ToString());

            txtinfo.Text = sb.ToString();
           // Modena(accion); //Activar cuando se resiban resultados reales
       
        }

        private void AccesoInterrupcion(string accion)
        {
            DelefadoAcceso Var_DelegadoAcceso;
            Var_DelegadoAcceso = new DelefadoAcceso(AccesoForm);
            object[] arg = { accion };
            base.Invoke(Var_DelegadoAcceso, arg);
        }
        private void ProyectoSerialC_Recibir_Load(object sender, EventArgs e)
        {
            lblEstado.Text = "Desconectado";
            lblRecibido.Text = "Esperando Resultados.";

            string[] PuertosDisponibles = SerialPort.GetPortNames();

            cboPuerto.Items.Clear();

            foreach (string puerto_simple in PuertosDisponibles)
            {
                cboPuerto.Items.Add(puerto_simple);
            }

            if (cboPuerto.Items.Count > 0)
            {
                cboPuerto.SelectedIndex = 0;
                MessageBox.Show("Seleccionar el puerto de trabajo");
                btnConectar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ningun puerto detectado");
                cboPuerto.Items.Clear();
                cboPuerto.Text = "                    ";
                strBufferIn = "";
                strBufferOut = "";
                btnConectar.Enabled = false;
                btnEnviarDato.Enabled = false;
            }

            //
            strBufferIn = "";
            strBufferOut = "";
        }
        private void btnBuscarPuerto_Click(object sender, EventArgs e)
        {
            string[] PuertosDisponibles = SerialPort.GetPortNames();

            cboPuerto.Items.Clear();

            foreach (string puerto_simple in PuertosDisponibles)
            {
                cboPuerto.Items.Add(puerto_simple);
            }

            if (cboPuerto.Items.Count > 0)
            {
                cboPuerto.SelectedIndex = 0;
                MessageBox.Show("Seleccionar el puerto de trabajo");
                btnConectar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ningun puerto detectado");
                cboPuerto.Items.Clear();
                cboPuerto.Text = "                    ";
                strBufferIn = "";
                strBufferOut = "";
                btnConectar.Enabled = false;
                btnEnviarDato.Enabled = false;
            }
        }
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnConectar.Text == "Conectar")
                {
                    //spPuertos.BaudRate = Int32.Parse(cboBaudRate.Text);
                    //spPuertos.DataBits = 8;
                    //spPuertos.Parity = Parity.None;
                    //spPuertos.StopBits = StopBits.One;
                    //spPuertos.Handshake = Handshake. None;
                    //spPuertos.PortName = cboPuerto.Text;
                    //lblEstado.Text = "Conectado";

                    //cambio modena
                    spPuertos.BaudRate = Int32.Parse(cboBaudRate.Text);
                    spPuertos.DataBits = 8;
                    spPuertos.Parity = Parity.Even;
                    spPuertos.StopBits = StopBits.One;
                    spPuertos.Handshake = Handshake.None;
                    spPuertos.PortName = cboPuerto.Text;
                    lblEstado.Text = "Conectado";


                    try
                    {
                        spPuertos.Open();
                        btnConectar.Text = "Desconectar";
                        btnEnviarDato.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        lblEstado.Text = "El Puerto COM, ya esta en uso";
                        // throw;
                    }

                }
                else if (btnConectar.Text == "Desconectar")
                {
                    spPuertos.Close();
                    btnConectar.Text = "Conectar";
                    btnEnviarDato.Enabled = false;

                    lblEstado.Text = "Desconectado";
                    lblRecibido.Text = "Esperando Resultados.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void btnEnviarDato_Click(object sender, EventArgs e)
        {
            try
            {
                spPuertos.DiscardOutBuffer();
                strBufferOut = txtEnviarDatos.Text;
                spPuertos.Write(strBufferOut);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void DatoRecibido(object sender, SerialDataReceivedEventArgs e)
        {            
   //         Thread.Sleep(500);
            AccesoInterrupcion(spPuertos.ReadExisting());
            
            /*string Data_in = spPuertos.ReadExisting();
            MessageBox.Show(Data_in);
            txtRecibirDatos.Text = Data_in;*/
        }

        public class SubStringTest
        {
            public static void Main1()
            {
                string[] info = { "Name: Felica Walker", "Title: Mz.", 
                           "Age: 47", "Location: Paris", "Gender: F"};
                int found = 0;

                Console.WriteLine("The initial values in the array are:");
                foreach (string s in info)
                    Console.WriteLine(s);                    

                Console.WriteLine("\nWe want to retrieve only the key information. That is:");
                foreach (string s in info)
                {
                    found = s.IndexOf(": ");
                    Console.WriteLine("   {0}", s.Substring(found + 2));
                }
            }
        }
        private void btnVer_Click(object sender, EventArgs e)
        {
            string text = @"H|\^&|517530||cobas infinity ^Roche Diagnostics|||||||||20190204132612
                        P|1|2040037|00184361901||ALVARADO LOPEZ^KAROLAY||19901019|F|||||||||||||||20190204072430||02^MIRAFLORES
                        O|1|2040037-3^G||^^^330722|R|20190204072430|||||A||||SANGRE||||||||||O
                        R|1|1025^HEMOGLOBINA GLUCOSILADA^^330722|5.20|%|4.80^6.00|||F||||20190204132554|||20190204132554^HGILMORI|2
                        L|1|N";
            Modena(text);

        }

        private string[] Resultado;
        private string[] Resultado_final;

       // private string[] Ordenes;
//        string text = @"H|\^&|471082||cobas infinity ^Roche Diagnostics|||||||||20190119190405.
//                        P|1|1190457|01101910701||ROJAS ORE^SANDRA ANGELICA||19900210|F|||||||||||||||20190119112549||03^LOS OLIVOS.
//                        O|1|1190457-3^G||^^^  4100\^^^4105\^^^4106\^^^4107\^^^4108\^^^4109\^^^4112\^^^4113\^^^4114\^^^4115\^^^4116\^^^4117\^^^4119\^^^4120\^^^4121\^^^4122\^^^4123\^^^4124|R|20190119112549|||||A||||SANGRE||||||||||O
//                        R|1|4100^RECUENTO DE HEMATIES NUCLEADOS^^  4100|0.00|10^6xmm³||||F||||20190119182150|709||20190119190345^AVIDARTE|2
//                        R|2|4005^HB CORPUSCULAR MEDIA^^4105||pg|26.00^38.00|||F||||18401231000000|709||18401231000000|1
//                        R|3|4006^CONCENTRACION HB CORPUSCULAR MEDIA^^4106||g/dL|31.00^37.00|||F||||18401231000000|709||18401231000000|1
//                        R|4|4007^DISTRIBUCION ERITROCITARIA (RDW)^^4107|17.8|%|11.00^16.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
//                        R|5|4008^RECUENTO DE PLAQUETAS^^4108|233|10³/mm³|150.00^450.00|||F||||20190119182150|709||20190119190345^AVIDARTE|0
//                        R|6|4009^VOLUMEN PLAQUETARIO MEDIO^^4109|----|fL|9.00^13.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
//                        R|7|4012^SEGMENTADOS %^^4112|49.2|%|50.00^70.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
//                        R|8|4013^LINFOCITOS %^^4113|41.5|%|25.00^40.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
//                        R|9|4014^MONOCITOS %^^4114|7.8|%|2.00^10.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
//                        R|10|4015^EOSINOFILOS %^^4115|1.2|%|0.00^5.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
//                        R|11|4016^BASOFILOS %^^4116|0.3|%|0.00^1.00|||F||||20190119182150|709||20190119190345^AVIDARTE|1
//                        R|12|4117^GRANULOCITOS INMADUROS %^^4117|0.3|%|0.00^0.50|||F||||20190119182150|709||20190119190345^AVIDARTE|1
//                        R|13|4018^SEGMENTADOS^^4119|2.98|10^3xmm³|2.00^7.00|||F||||20190119182150|709||20190119190345^AVIDARTE|2
//                        R|14|4019^LINFOCITOS^^4120|2.51|10^3xmm³|1.50^4.00|||F||||20190119182150|709||20190119190345^AVIDARTE|2
//                        R|15|4020^MONOCITOS^^4121|0.47|10^3xmm³|0.00^1.10|||F||||20190119182150|709||20190119190345^AVIDARTE|2
//                        R|16|4021^EOSINOFILOS^^4122|0.07|10^3xmm³|0.00^0.40|||F||||20190119182150|709||20190119190345^AVIDARTE|2
//                        R|17|4022^BASOFILOS^^4123|0.02|10^3xmm³|0.00^0.20|||F||||20190119182150|709||20190119190345^AVIDARTE|2
//                        R|18|4124^GRANULOCITOS INMADUROS^^4124|0.02|10^3xmm³|0.00^0.00|||F||||20190119182150|709||20190119190346^AVIDARTE|2
//                        L|1|N";


        public void Modena(string ResultadoModena)
        {
            var sb = new System.Text.StringBuilder();

            string[] separatingChars = { "\r\n" };
            string[] words = ResultadoModena.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            //string[] words = strBufferIn.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            //    System.Console.WriteLine("{0} substrings in text:", words.Length);
            int i = 0;

            Resultado = new string[] { };
            Resultado_final = new string[4];
            //   Ordenes = new string[50];

            Resultado = new string[words.Count()];

            foreach (var word in words)
            {
                System.Console.WriteLine(word);
                i++;
                Resultado[i - 1] = ReducirEspaciado(word).ToString();

                string cadena = Resultado[i - 1].ToString();
                ReducirEspaciado(cadena);

                if (i - 1 == 0)
                {
                    //--Cabecera
                    string[] Inicial = { @"H|\^&|", "||", "|||||||||" };
                    string[] final = { "||", "|||||||||", "|" };

                    string[] ResultadoC = ExtraerCaracter(cadena+"|", Inicial, final);

                    ls_year = ResultadoC[2].Substring(0,4);

                    //almacenar
                }
                else if (i - 1 == 1)
                {
                    //--Paciente
                    string[] Inicial = { @"P|1|", "|", "||", "^", "||", "|", "|||||||||||||||", "||", "^" };
                    string[] final = { "|", "||", "^", "||", "|", "|||||||||||||||", "||", "^", "|" };
                    string[] ResultadoP = ExtraerCaracter(cadena + "|", Inicial, final);

                    if (ResultadoP[0].Length <= 7)
                        ls_yearorden = ls_year + "0" + ResultadoP[0];
                        
                    else 
                    {
                        ls_yearorden = ls_year + ResultadoP[0];
                    }

                }
                else if (i - 1 == 2)
                {

                    string[] Inicial = { "||" };
                    string[] final = { "|R|" };
                    string[] ResultadoO = ExtraerCaracter(cadena, Inicial, final);

                    string[] separatingChars_Ord = { "^^^", @"\" };
                    string[] Result_Ord = Resultado[0].Split(separatingChars_Ord, System.StringSplitOptions.RemoveEmptyEntries);

                }
                else if (i - 1 >= 3)
                {
                    long b = cadena.LongCount(letra => letra.ToString() == "|");

                    if (b <= 16)
                    {
                        int caracterInsert = 17 - int.Parse(b.ToString());
                        
                        cadena = cadena + string.Concat(Enumerable.Repeat("|", caracterInsert));
                    }   
                    if (cadena.StartsWith("R"))
                    {
                        string[] ResultadoR;

                        string[] Inicial = { "R|", "|", "^", "^^", "|", "|", "|||", "||", "||", "|", "||","|" };
                        string[] final = { "|", "^", "^^", "|", "|", "|||", "||", "||", "|", "||", "|" ,"|"};
                        ResultadoR = ExtraerCaracter(cadena, Inicial, final);

                        ls_exacodigo = Resultado[3];
                        ls_exacodigo_inf=Resultado[1];
                        ls_unidad_nombre=Resultado[5];                        

                        //Separar fecha de validacion y usuario de validación
                        string[] separatingChars_Ord = { "^" };
                        string[] Result_UsuVal = Resultado[10].Split(separatingChars_Ord, System.StringSplitOptions.RemoveEmptyEntries);

                       // string fecha = "2019-01-19 19:03:46";
                        if (Result_UsuVal.Length > 0)
                        {
                            string fechaval = (Result_UsuVal[0].Substring(0, 4)) + "/" + Result_UsuVal[0].Substring(4, 2) + "/" + Result_UsuVal[0].Substring(6, 2) + " " +
                                     Result_UsuVal[0].Substring(8, 2) + ":" + Result_UsuVal[0].Substring(10, 2) +":" + Result_UsuVal[0].Substring(12, 2);
                        ls_fechaValidacion = DateTime.ParseExact(fechaval, "yyyy/MM/dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                        }

                        if (Result_UsuVal.Length > 1)
                        {
                            ls_usuarioVal = Result_UsuVal[1];
                        }
                        else
                        {
                            ls_usuarioVal = "";
                        }                     
                       // ls_fuera_rango   = ""; // comparar registros;              
                        
                        ls_cantidad_dec =  Resultado[11]; // contar los decimales;
                       // ls_result_comenta = "";
                        ls_result_valor = Resultado[4];
                        //if (ls_result_valor.Substring(0, 1) == ".")
                        //{
                        //    ls_result_valor = "0" + ls_result_valor;
                        //}

                        Grabar_Resultados_Update();

                    }
                    else if (cadena.StartsWith("C"))
                    {
                        string[] ResultadoC;
                        string[] Inicial = { "C|", "|", "|", "|", "|" };
                        string[] final =   { "|" , "|", "|", "|", "|" };
                        ResultadoC = ExtraerCaracter(cadena, Inicial, final);
                        ls_result_comenta = ResultadoC[2];
                        Resultado_Comentario_Update();

                    }
                    else if (cadena.StartsWith("L"))
                    {
                        Validar_Servicio_Det();
                    }
                    
                }
            }
        }
        public string[] ExtraerCaracter(string cadena, string[] Inicial, string[] final)
        {
            string[] NuevoTexto;

            //1er parametro Nro de Orden
            var Separadores = Inicial.Zip(final, (i, f) => new { Inicial = i, final = f });

            NuevoTexto = new string[20];
            Resultado = new string[20];
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

        public void ListarOrdenResult()
        {
            try
            {
                ListOrden_Result = BLServicios_Rec.Orden_Result_Select(ls_yearorden, ls_exacodigo);
                foreach (BEServicios_Rec Result_Select in ListOrden_Result)
                {
                    {
                        ls_ref_max = Result_Select.Ref_Max;
                        ls_ref_min = Result_Select.Ref_Min;
                    }
                 //   Grabar_Orden_Result();

                }
                //Grabar_Orden_Servicio();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
        }
        private void Grabar_Resultados_Update()
        {
            try
            {
                BEServicios_Rec entidad = new BEServicios_Rec();
                entidad.YearOrden = ls_yearorden;
               // entidad.Numfox = ls_Numfox;
                entidad.Exa_Codigo = ls_exacodigo;
                entidad.Exa_Codigo_Inf = ls_exacodigo_inf;
                entidad.Unidad_Nombre = ls_unidad_nombre;
                entidad.FechaValidacion = ls_fechaValidacion;
                entidad.Usuario_Validacion = ls_usuarioVal;
                //Determinar si esta fuera del ranngo//
                ListarOrdenResult();
                //
                entidad.Valor_referencial = ls_ref_min + " " + "-" + " " + ls_ref_max;
                if (IsNumeric(ls_result_valor))
                {
                    if (Convert.ToDecimal(ls_result_valor) >= Convert.ToDecimal(ls_ref_min) && Convert.ToDecimal(ls_result_valor) >= Convert.ToDecimal(ls_ref_min))
                    {
                        ls_fuera_rango = "0";
                    }
                    else
                    {
                        ls_fuera_rango = "1";
                    }
                }
                else ls_fuera_rango = "";

                entidad.Fuera_Rango = ls_fuera_rango;
                entidad.Tb_Antibio = "";
                entidad.FlagCerado = "1";
                //if (FormState == "New")
                entidad = BLServicios_Rec.Lab_Mod_Sui_Result_Update(entidad);

                if (entidad.Resultado == 1)
                {
                    MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (entidad.Resultado == -1)
                {
                    //MessageBox.Show(entidad.Mensaje + "CONTROL.LAB_ORDEN_RESULT_TEXTO:" + "Yearorden: " + ls_yearorden + " " + "Numser: " + ls_Numser, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(":  los registos ya existen");
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("El registro ya existe");
                Console.Write(ex.Message.ToString());
            }
        }
        public static Boolean IsNumeric(string valor)
        {
            double result;
            return double.TryParse(valor, out result);
        }
    //Update comentario
        private void Resultado_Comentario_Update()
        {
            try
            {
                BEServicios_Rec entidad = new BEServicios_Rec();
                entidad.YearOrden = ls_yearorden;
            //    entidad.Numfox = ls_Numfox;
                entidad.Exa_Codigo = ls_exacodigo;
                entidad.Exa_Codigo_Inf = ls_exacodigo_inf;
                entidad.Result_Comenta = ls_result_comenta;

                entidad = BLServicios_Rec.Lab_Mod_Sui_Result_Coment_Update(entidad);

                if (entidad.Resultado == 1)
                {
                    MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (entidad.Resultado == -1)
                {
                    //MessageBox.Show(entidad.Mensaje + "CONTROL.LAB_ORDEN_RESULT_TEXTO:" + "Yearorden: " + ls_yearorden + " " + "Numser: " + ls_Numser, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(":  los registos ya existen");
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("El registro ya existe");
                Console.Write(ex.Message.ToString());
            }
        }
        private void Validar_Servicio_Det()
        {
            try
            {
                BEServicios_Rec entidad = new BEServicios_Rec();
                entidad.YearOrden = ls_yearorden;
              
                entidad = BLServicios_Rec.Validar_Servicios_Det(entidad);

                if (entidad.Resultado == 1)
                {
                    MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (entidad.Resultado == -1)
                {
                    //MessageBox.Show(entidad.Mensaje + "CONTROL.LAB_ORDEN_RESULT_TEXTO:" + "Yearorden: " + ls_yearorden + " " + "Numser: " + ls_Numser, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(":  los registos ya existen");
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("El registro ya existe");
                Console.Write(ex.Message.ToString());
            }
        }


    }
}
