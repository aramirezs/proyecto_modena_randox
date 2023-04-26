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
//using System.Threading;

using CapaEntidades;
using CapaNegocio;
using System.Threading;

namespace ProyectoSerialC.forms
{
    public partial class frm_Modena : Form
    {

        #region Variables Privadas

        private delegate void DelefadoAcceso(string accion);
        private string strBufferIn;
        private string strBufferOut;

        string Recibidos;

       private string md_cabecera, md_ordenes, md_servicios, md_footer;
        //ordenes//
       private string ls_hc, ls_apellidos, ls_nombres, ls_nom_emp, ls_cod_cia, ls_nom_suc, ls_cod_suc, ls_nom_med, ls_nom_cia, ls_sexo, ls_usuario,
                      ls_fnac, ls_fechahora, ls_yearorden, ls_yea, ls_ordnumero, ls_edad, ls_sexo_C, ls_Numcia, ls_NumPac, ls_anioPac, ls_liscodigo, ls_CodMuestra, ls_YearMuestra;

       private string ls_Numfox, ls_Numser,ls_cod_suc_Mues,ls_CItem,ls_ExaCodigo,ls_ExaNombre,ls_Comenta_fijo,ls_sec_Cod,
                      ls_sec_descrip,ls_Tiper,ls_SubTitulo,ls_SubTiper,ls_MueCodigo,ls_Resultado_defecto,ls_Desser,
                      ls_MetCodigo, ls_MetDescrip, ls_FlagPerfil, ls_rownum,ls_Numfox_Mod,ls_Cod_Muestra;
        
        

       //servicios
       private string Numoscab, Peroscab, Anooscab, MNumsuc, EnviarcadenaHL7, ls_ref_max,ls_exacodigo, ls_exacodigo_inf, ls_unidad_nombre, ls_usuarioVal,
                      ls_result_valor, ls_ref_min, ls_fuera_rango, ls_fecha, CodMuestra, ls_FechaOrden;
       private DateTime ls_fechaValidacion;

       private string OrdenesModena = string.Empty;
       private string CodigoMuestra = string.Empty;
       
           
       private int CountOrdenes;

       private string[] MsjOrdenes;
       private string[] YearOrdenes;
       private string[] Numser;
       private string[] Cod_suc_Mue;

       private string[] NumscabA;
       private string[] PeroscabA;
       private string[] AnioscabA;
       private string[] NumsucA;
       private string[] CodMuestraA;

       private string[] Pruebas;
       private string[] DataResult;

       string[] DataConsulta;

       private string[] Resultado;
       private string TipoOrden;

       private string fechavalStr;

       

       private List<BEServicios_Rec> ListOrden_Result = null;

       string Recibo_STX_02 = "STX"; // Inico de texto.
       string Recibo_ENQ_05 = "ENQ"; // Enquiry, investigación.
       string Recibo_ETX_03 = "ETX"; // Fin de texto.
       string Recibo_ACK_06 = "ACK"; // Acknowledge, reconocer.
       string Recibo_EOT_04 = "EOT"; // Fin de transmisión.
       string Recibo_NAK_15 = "NAK"; // error de transmisión.
       #endregion       

       #region Constructor
       public frm_Modena()
        {
            InitializeComponent();
            
        }

       #endregion

       #region Eventos
       private void AccesoForm(string accion)
        {
            strBufferIn = accion;
            txtRecibirDatos.Text = strBufferIn;

        }

        private void AccesoInterrupcion(string accion)
        {
            DelefadoAcceso Var_DelegadoAcceso;
            Var_DelegadoAcceso = new DelefadoAcceso(AccesoForm);
            object[] arg = { accion };
            base.Invoke(Var_DelegadoAcceso, arg);
        }

        private void frm_Modena_Load(object sender, EventArgs e)
        {
            lblEstado.Text = "Desconectado";
            lblRecibido.Text = "Esperando Exámenes Escaneados.";
       //     InitTimer();
       //     EjecutarHilo();

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
                    spPuertos.BaudRate = Int32.Parse(cboBaudRate.Text);
                    spPuertos.DataBits = 8;
                    //spPuertos.Parity = Parity.None;
                    spPuertos.Parity = Parity.Even;
                    spPuertos.StopBits = StopBits.One;
                    spPuertos.Handshake = Handshake.RequestToSend;
                    spPuertos.PortName = cboPuerto.Text;
                    lblEstado.Text = "Conectado";

                    spPuertos.DataReceived += new SerialDataReceivedEventHandler(Recepcion);

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
                    lblRecibido.Text = "Esperando Ordenes.";

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnEnviarDato_Click(object sender, EventArgs e)
        {
            EnviarHL7();
        }
        //
        private void EnviarHL7()
        {
            try
            {
                lblRecibido.Text = "Enviando Ordenes...";
                var sb_Year = new System.Text.StringBuilder();
          //    ListarServicioModena();
                spPuertos.DiscardOutBuffer();
                // strBufferOut = txtEnviarDatos.Text;
 //               strBufferOut = txtEnviarDatos.Text;
                strBufferOut = EnviarcadenaHL7;
                spPuertos.Write(strBufferOut);
                sb_Year.AppendLine("Orden: "+ ls_yearorden+ ": N° Servicio: "+ ls_Numfox + "...Envio Correcto");              
            }
            catch (Exception)
            {
                var sb_Year = new System.Text.StringBuilder();
                if (btnConectar.Text == "Desconectar")
                {
                    sb_Year.AppendLine("Orden: " + ls_yearorden + ": N° Servicio: " + ls_Numfox + "...Envio Incorrecto");
                    //textBox1.Text = sb_Year.ToString();
                }
                //throw;                
            }
        }
        //
        public int contador = 0;
        public int NOrdenes = 0;
        public int contadorQ = 0;
        string exacodigo_R;
        string YearOrden_R;
        
        private void Recepcion(object sender, SerialDataReceivedEventArgs e)
        {
            //AccesoInterrupcion(spPuertos.ReadExisting());

            Thread.Sleep(500);
            Recibidos = spPuertos.ReadExisting();

            // Invocar o llamar al proceso de tramas.
            Invoke(new EventHandler(ProcesarTrama));

        }
        private string getFrameCheckSum(string Frametext)
        {
            byte[] a = Encoding.ASCII.GetBytes(Frametext);
            int checkSum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                checkSum += a[i];
            }
            string outi = string.Format("{0:x2}", (checkSum & 0xFF)).ToUpper();
            return outi;
        }
        private void ProcesarTrama(object sender, EventArgs e)
        {
            listRec.Items.Add("[" + DateTime.Now + "]" + "      receive      " + Recibidos);

            Utilitarios.Seguridad.LogServiceEnvioAutomatico("      receive      " + Recibidos.ToString()); // log

            //Separarar carácteres ASCII
            string Respuesta, ASCII, ASCII2, ASCII3, ASCII4, ASCII5, cadena, proceso;

            if (Recibidos == "")       //RECIBE ENQ
            {
                ASCII = Recibo_ENQ_05;
            }
            else if (Recibidos == "") //RECIBE EOT
            {
                ASCII = Recibo_EOT_04;
            }
            else if (Recibidos == "") // RECIBE ACK
            {
                ASCII = Recibo_ACK_06;
            }
            else if (Recibidos == "") // RECIBE NAK
            {
                ASCII = Recibo_ACK_06;
            }

            else
            {
                //CUANDO SE RECIBE UN STX PASA POR AQUÍ
                //Sustraer la cadena y ASCII    
                int CantidadLet = Recibidos.Length;
                ASCII = Recibidos.Substring(0, 1);
                ASCII2 = Recibidos.Substring(CantidadLet - 1, 1);
                ASCII3 = Recibidos.Substring(CantidadLet - 4, 2);
                ASCII4 = Recibidos.Substring(CantidadLet - 5, 1);
                ASCII5 = Recibidos.Substring(CantidadLet - 6, 1);
                cadena = Recibidos.Substring(2, CantidadLet - 8);
                

                //2P|1|2503|||PAPUCHO|||U|||||||0||||||||||^^^|||||||||<CR><ETX>B4<CR><LF>
                //2Q|1|ALL||||||||||N<CR><ETX>BB<CR><LF>
                //L|1|

                if (ASCII == "") //RECIBE ACK
                {
                    ASCII = Recibo_ACK_06;
                }
                else if (ASCII == "") //RECIBE STX --
                {
                    ASCII = Recibo_STX_02;
                    //
                    if (cadena.StartsWith("L") || cadena.StartsWith("C"))
                    {

                    }
                    else
                    {
                        string[] Inicial = { "|", "|", "|"   , "|", "|"    , "|", "|", "|" };
                        string[] final = { "|", "|", "|"     , "|", "|"    , "|", "|", "|" };

                        string[] ResultadoC = ExtraerCaracter("|" + cadena, Inicial, final);

                        TipoOrden = ResultadoC[0];

                        //string[] dataQ = new string[ResultadoC.Length];
                        string[] dataH = new string[ResultadoC.Length];
                        string[] dataP= new string [ResultadoC.Length];
                        string[] dataO = new string[ResultadoC.Length];
                        string[] dataR = new string[ResultadoC.Length];

                        if (TipoOrden == "H")
                        {
                            string[] InicialH = { "|", "|", "|", "|", "|", "|", "|", "|", "|", "|", "|", "|"  , "|" , "|"  };
                            string[] finalH = { "|", "|", "|", "|", "|", "|", "|", "|"   , "|", "|", "|", "|" , "|" , "|" };

                            string[] ResultadoH = ExtraerCaracter(("|" + cadena + "|"), InicialH, finalH);

                            dataH = ResultadoH;
                            ls_FechaOrden = dataH[13].Substring(0,4);
                            

                            //   ls_ordnumero = dataP[2];
                        }                       

                        if (TipoOrden == "Q")
                        {
                            string[] InicialQ = { "|", "|", "|", "|", "|", "|", "|", "|" };
                            string[] finalQ = { "|", "|", "-", "|", "-", "|", "|", "|" };

                            string[] dataQ = ExtraerCaracter("|" + cadena + "|", Inicial, final);

                            //string cadenaQ = dataQ[2];

                            string[] separatingChars_Q = { "-" };
                            string[] Result_Ord = dataQ[2].Split(separatingChars_Q, System.StringSplitOptions.RemoveEmptyEntries);

                            //string OrdModena = string.Empty;
                            OrdenesModena = string.Empty;
                            CodigoMuestra = string.Empty;

                           // dataQ = ResultadoC;
                            if (Result_Ord[0].Count() < 8)
                            {
                                OrdenesModena = "0" + Result_Ord[0];
                            }
                            else
                            {
                                OrdenesModena = Result_Ord[0];
                            }

                            if (Result_Ord.Length > 1 )
                            {
                                CodigoMuestra = Result_Ord[1];
                            }
                            else
                            {
                                CodigoMuestra = null;
                            }
                            
                                
                        }

                        if (TipoOrden == "P")
                        { 
                             dataP = ResultadoC;
                             ls_yearorden = "2018" + dataP[2];
                             ls_ordnumero = dataP[2];
                            
                          //   ls_ordnumero = dataP[2];
                        }
                        else if (TipoOrden == "O")
                        { 
                            dataO= ResultadoC;
                            string[] separatingChars_Ord = { "^^^", @"\" };
                            string[] Result_Ord = dataO[4].Split(separatingChars_Ord, System.StringSplitOptions.RemoveEmptyEntries);
                            //exacodigo_R = Result_Ord[0];
                            ls_exacodigo = Result_Ord[0];
                            ls_fecha =  dataO[7].Substring(0,4);

                            //if (dataO[2].Length < 8)
                            //{
                            //    ls_yearorden = ls_fecha + "0" +dataO[2];
                            //}
                           // else
                           // {
                            //YearOrden_R = ls_fecha + ls_ordnumero; 
                            ls_yearorden = ls_fecha + ls_ordnumero; 
                            //}
                        }
                        else if (TipoOrden == "R")
                        {
                            string[] InicialR = { "|", "|", "|", "|", "|", "|", "|", "|", "|", "|", "|", "|", "|" };
                            string[] finalR = { "|", "|", "|", "|", "|", "|", "|", "|"  , "|", "|", "|", "|", "|" };

                            string[] ResultadoR = ExtraerCaracter("|" + cadena, InicialR, finalR);
                            

                             dataR = ResultadoR;
                             ls_result_valor = dataR[3];
                             fechavalStr = dataR[12];
                             Grabar_Resultados_Update();
                        }

                        ///
                        //if (TipoOrden == "R")
                        //{
                        //    //ls_yearorden = "2019" + dataP[2];
                        //    //ls_ordnumero = dataP[2];
                        //    //ls_result_valor = dataR[3];

                        //    if (ls_result_valor.Length > 0)
                        //    {
                        //        Grabar_Resultados_Update();
                        //        ls_result_valor = "";
                        //    }
                        //}
                        //
                        //var Numos = NumscabA.Zip(PeroscabA, (n, p) => new { n, p }).Zip(AnioscabA, (t, a) => new {  NumscabA = t.n, PeroscabA = t.p, AnioscabA = a }).
                        //      Zip(NumsucA, (z, s) => new { NumscabA = z.NumscabA, PeroscabA = z.PeroscabA, AnioscabA = z.AnioscabA, Numsuc=s });

                        //var Result = dataP.Zip(dataO, (p, o) => new { p, o }).Zip(dataR, (t, r) => new { DataP = t.p, DataO = t.o, dataR = r });

                        //foreach (var parametros in Result)
                        //{
                        //    ls_apellidos= parametros.DataP;

                        //    Grabar_Orden_Result();
                        //}
                       // string[] countP = new string[50];
                       // countP[contador] = TipoOrden;                         
                       
                    }
                }
                else if (ASCII == "") //RECIBE EOT --
                {
                    ASCII = Recibo_STX_02;
                }
                else if (ASCII == "") //RECIBE NAK
                {

                }

            }
            //  for (int i = 0; i < a.Length; i++)
            //Respuesta del host--
            if ((ASCII == Recibo_STX_02) || (ASCII == Recibo_ENQ_05))
            {
             
                byte[] mBuffer = Encoding.ASCII.GetBytes("");
                //Respuesta = ASCIIEncoding.ASCII.GetString(new byte[] { 6 }); //ACK
                spPuertos.Write(mBuffer, 0, mBuffer.Length);
                listRec.Items.Add("[" + DateTime.Now + "]" + "      send      " + "<ACK>");

                Utilitarios.Seguridad.LogServiceEnvioAutomatico("      send      " + "<ACK>"); // log
            }

            else
            {
                // if ((Recibidos != "2") & (Recibidos != "3") & (Recibidos != "5") & (Recibidos != "6") & (Recibidos != "4")) // != si son iguales devuelve false;
                
               
                if (ASCII == Recibo_EOT_04) //eot del equipo correcto, en ese momento envias rspta enq
                {
                    //         this.Invoke(new EventHandler(Actualizar));

                    //se agrego
                     
                  
                    if (TipoOrden == "Q")     // Si es Q,  significa que Modena esta solicitando Ordenes
                    {

                        Respuesta = ASCIIEncoding.ASCII.GetString(new byte[] { 5 }); //ENVÍO ENQ
                        spPuertos.Write(Respuesta);
                        listRec.Items.Add("[" + DateTime.Now + "]" + "      send      " + "<ENQ>");

                        Utilitarios.Seguridad.LogServiceEnvioAutomatico("      send      " + "<ENQ>"); // log

                       // string[] Rpt = null;
                     //   ListarServicioModena(ref Trama);
                        //Rpt = new string[8];
                        //if (contador == 0)
                        //{
                        //    ListarServicioModena(ref Rpt);
                        //}

                    }
                    else // NO hay necesidad de enviar ENQ debido a que
                    {
                       // listRec.Items.Add("[" + DateTime.Now + "]" + "      send      " + "<ENQ>");
                    }
                    //                    Recibidos = "";
                }
                
                
                else if (ASCII == Recibo_ACK_06) //recibo ack
                {
                    //if (contador==0)
                    //{
                        
                        
                    //}
                    //OrdModena

                    //string [] Rpt = null;
                    //ListarServicioModena(ref Rpt);
                    //string rs = OrdenesModena;

                    //string CMuestra = "1";
         
                    string CMuestra = "1";

                    string YearOrden = string.Empty;
                    YearOrden = ls_FechaOrden + OrdenesModena;

                    //2150875-17

                    string[] ResultadoHost = ListarServicioModena(YearOrden, CodigoMuestra);
                    // Add bob to the last element of the array                
                  //  string data2;
                    int i = 0;
                    //foreach (string s in Rpt)
                    //{
                        i++;

                        int TotalEnvio = ResultadoHost.Length - 1;
                        if (contador > TotalEnvio)
                        {
                            Respuesta = ASCIIEncoding.ASCII.GetString(new byte[] { 4 }); //ENVÍO EOT
                            spPuertos.Write(Respuesta);
                            listRec.Items.Add("[" + DateTime.Now + "]" + "      send      " + "<EOT>");

                            Utilitarios.Seguridad.LogServiceEnvioAutomatico("      send      " + "<EOT>"); // log
                            
                            GrabarData();  //Graba Data

                            contador = 0;
                            NOrdenes = 0;
                        }
                        else
                        {
                            //si Cont es =7 se reinicia el contador a 0 según el manual del Modena
                            //int Cont = 0;
                            if (NOrdenes + 1 > 7)
                            {
                               // Cont = 0;
                                //Cont = 0;

                                //
                                string data = ("0" + ResultadoHost[contador]);
                                Respuesta = (char)2 + data + (char)3 + getFrameCheckSum(data + (char)3) + (char)13 + (char)10;
                                //      Respuesta = (char)2 + data + (char)3 + getFrameCheckSum(data + (char)3) + (char)13 + (char)10;    //FUNCIONÓ                        

                                spPuertos.Write(Respuesta);
                                listRec.Items.Add("[" + DateTime.Now + "]" + "      send      " + Respuesta);

                                Utilitarios.Seguridad.LogServiceEnvioAutomatico("      send      " + Respuesta); // log

                                NOrdenes = 0;

                            }
                            else
                            {
                               // Cont=contador+1;
                                string data = ((NOrdenes + 1) + ResultadoHost[contador]);
                                Respuesta = (char)2 + data + (char)3 + getFrameCheckSum(data + (char)3) + (char)13 + (char)10;
                                //      Respuesta = (char)2 + data + (char)3 + getFrameCheckSum(data + (char)3) + (char)13 + (char)10;    //FUNCIONÓ                        

                                spPuertos.Write(Respuesta);
                                listRec.Items.Add("[" + DateTime.Now + "]" + "      send      " + Respuesta);

                                Utilitarios.Seguridad.LogServiceEnvioAutomatico("      send      " + Respuesta); // log

                            }

                                NOrdenes++;
                                contador++; 
                        }
             //       }
                        
                }

                //else
                //{
                //    if (Recibidos == "4") // EOT.
                //    {
                //       // this.Invoke(new EventHandler(actualizarenter));
                //    }
                //    else
                //    {
                //        if (Recibidos == "3") // ETX.
                //        {
                //            byte[] mBuffer = Encoding.ASCII.GetBytes("ACK");
                //            spPuertos.Write(mBuffer, 0, mBuffer.Length);
                //            //                   richTextBox_Mensajes.Text = "Enviado ACK_06 en Recibidos ETX_3.";
                //        }
                //    }
                //}
            }
            //Fin de Respuesta del host--
            //          listRec.Items.Add("[" + DateTime.Now + "]" + "      receive      " + Recibidos);

        }
              
        #region Variables Privadas

        private List<BEServicios> ListServicios_Ord_Pac = null;
        private List<BEServicios> ListServiciosPac = null;

        #endregion


        #region Métodos Privados

        //INTERNO
        public void GrabarData()
        {
            string[] YearCount = YearOrdenes;
            foreach(var YOrdenes in YearCount)            
            {
                GrabarDatosOrden_Cab(YOrdenes);
                ls_yearorden = YOrdenes;

            }
                var Numos = NumscabA.Zip(PeroscabA, (n, p) => new { n, p }).Zip(AnioscabA, (t, a) => new {  NumscabA = t.n, PeroscabA = t.p, AnioscabA = a }).
                              Zip(NumsucA, (z, s) => new { NumscabA = z.NumscabA, PeroscabA = z.PeroscabA, AnioscabA = z.AnioscabA, NumsucA=s }).
                              Zip(CodMuestraA, (cm, l) => new { NumscabA = cm.NumscabA, PeroscabA = cm.PeroscabA, AnioscabA = cm.AnioscabA, NumsucA = cm.NumsucA, CodMuestra = l });

                foreach (var Ord in Numos)
                {
                    string NumoscabD = Ord.NumscabA;
                    string PeroscabD = Ord.PeroscabA;
                    string AnioscabD = Ord.AnioscabA;
                    string NumsucD = Ord.NumsucA;
                    string CodMuestra = Ord.CodMuestra;
                    ListServiciosPac = BLServicios.ServiciosLab_EnvioPen_Modena_det(NumoscabD, PeroscabD, AnioscabD, NumsucD, CodMuestra);

                    foreach (var servicios in ListServiciosPac)
                    {
                        {
                          //  s++;
                            ls_Numfox = servicios.Numfox;
                            ls_Numser = servicios.Numser;
                            ls_cod_suc_Mues = servicios.Codigo_Sucur_Mues;
                            ls_Numfox_Mod = servicios.Lcm_Numfox_Mod;
                            ls_Cod_Muestra = servicios.Cod_Muestra;
                            //Year y Ord
                            ls_yearorden = servicios.YearOrden;
                            ls_ordnumero = servicios.OrdNumero;

                        }
                        ListarServicioLisModena("3", ls_Numser, ls_cod_suc_Mues);   //  Result, ResultTexto y Orden Servicio.

                    }
                }
                LimpiarVariables();         

            //foreach (var YOrdenes in YearCount)
            //{
            //   Servicio_Cab_flagEnvMig_Update();
            //}
            
        }
        public void LimpiarVariables()
        { 
            md_cabecera=""; md_ordenes=""; md_servicios=""; md_footer="";ls_hc=""; ls_apellidos=""; ls_nombres=""; ls_nom_emp=""; ls_cod_cia=""; ls_nom_suc="";
            ls_cod_suc=""; ls_nom_med=""; ls_nom_cia=""; ls_sexo=""; ls_usuario="";ls_fnac=""; ls_fechahora=""; ls_yearorden="";ls_yea=""; ls_ordnumero=""; ls_edad="";
            ls_sexo_C=""; ls_Numcia=""; ls_NumPac="";ls_anioPac=""; ls_liscodigo="";ls_Numfox=""; ls_Numser="";ls_cod_suc_Mues="";ls_CItem="";ls_ExaCodigo="";ls_ExaNombre="";
            ls_Comenta_fijo="";ls_sec_Cod="";ls_sec_descrip="";ls_Tiper="";ls_SubTitulo="";ls_SubTiper="";ls_MueCodigo="";ls_Resultado_defecto="";ls_Desser="";
            ls_MetCodigo=""; ls_MetDescrip=""; ls_FlagPerfil=""; ls_rownum="";ls_Numfox_Mod="";ls_Cod_Muestra="";
        
            Numoscab=""; Peroscab=""; Anooscab=""; MNumsuc=""; EnviarcadenaHL7=""; ls_ref_max="";ls_exacodigo=""; ls_exacodigo_inf=""; ls_unidad_nombre=""; ls_usuarioVal="";
            ls_result_valor = ""; ls_ref_min = ""; ls_fuera_rango = ""; ls_fecha = ""; TipoOrden = ""; OrdenesModena = ""; ls_CodMuestra = ""; ls_YearMuestra="";
                //ls_fechaValidacion;        
               ////private string[] YearOrdenes;
               //private string[] Numser;
               //private string[] Cod_suc_Mue;
               //private string[] NumscabA;
               //private string[] PeroscabA;
               //private string[] AnioscabA;
               //private string[] NumsucA;
               //string[] DataConsulta;
               //private string[] Resultado;        
      
        }
        //public void ListarServicioModena(ref string[] prue)
        public string[] ListarServicioModena(string YearOrden, string CodMuestra)
        {
            try
            {
                lblRecibido.Text = "";
                lblRecibido.Text = "Consultando Ordenes.";
                //variables


                string Numsuc = "G";
                //string Numsuc = "ALL";
                var sb = new StringBuilder();
                var sb_Year = new System.Text.StringBuilder();
                Resultado = new string[20];
                ListServicios_Ord_Pac = BLServicios.ServiciosLab_EnvioPen_Modena_cab(Numsuc, YearOrden, CodMuestra);
                //var count = ListServicios_Ord_Pac.Count(x => x != null);
                //CountOrdenes = count;
                //if (count <= 0)
                //{
                //    lblRecibido.Text = "Esperando Exámenes Escaneados.";
                //}
                //else
                //{              

                //    sb_Year.AppendLine(DateTime.Now.ToString("G") + "......." + ls_yearorden + "  NroServicio:  " + ls_Numfox + "  envio correcto...");
                //sb_Year.AppendLine(DateTime.Now.ToString("G") + "......." + "total de Ordenes: " + count.ToString());
                //string mensajeOrdenes = DateTime.Now.ToString("G") + "......." + "total de Ordenes: " + count.ToString();

                //string[] MsjEnvio = new string[] { count.ToString() };
                //MsjOrdenes = new string[] { mensajeOrdenes };

                //string data = "abc,def,ghi";
                //string[] str = data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int i = 0;

                md_cabecera = @"H|\^&|||LIS^MODENA Diagnostics|||||||||" + ls_fechahora;
                sb.AppendLine(md_cabecera);
                YearOrdenes = new string[ListServicios_Ord_Pac.Count()];
                 NumscabA  = new string [ListServicios_Ord_Pac.Count()];
                 PeroscabA = new string [ListServicios_Ord_Pac.Count()];
                 AnioscabA = new string [ListServicios_Ord_Pac.Count()];
                 NumsucA   = new string[ListServicios_Ord_Pac.Count()];
                 CodMuestraA = new string[ListServicios_Ord_Pac.Count()];
                
                foreach (BEServicios servicios_ord in ListServicios_Ord_Pac)
                {
                    {
                        i++;
                        ls_hc = servicios_ord.NumPac + servicios_ord.AnioPac + "01";
                        ls_apellidos = servicios_ord.PatPac + " " + servicios_ord.MatPac;
                        ls_nombres = servicios_ord.NomPac;
                        ls_nom_cia = servicios_ord.Ncocia;
                        ls_cod_cia = servicios_ord.Seekcia;
                        ls_nom_suc = servicios_ord.Nombre_Sucursal;
                        ls_cod_suc = servicios_ord.Codigo_Sucursal;
                        ls_nom_med = servicios_ord.NComed;
                        ls_nom_emp = servicios_ord.RazemCia;
                        ls_sexo = servicios_ord.SexPac;
                        ls_usuario = servicios_ord.Usuario;
                        ls_fnac = servicios_ord.FNacPac.ToString("yyyyMMdd");
                        ls_yearorden = servicios_ord.YearOrden;
                        ls_fechahora = ls_yearorden.Substring(0, 8) + DateTime.Now.ToString("HHmmss");
                        //ls_ordnumero = servicios_ord.OrdNumero;
                        ls_edad = servicios_ord.Edad;
                        ls_sexo_C = servicios_ord.SexPac_C;
                        ls_Numcia = servicios_ord.Numcia;
                        ls_NumPac = servicios_ord.NumPac;
                        ls_anioPac = servicios_ord.AnioPac;
                        ls_liscodigo = servicios_ord.LisCodigo;
                        ls_CodMuestra = servicios_ord.Cod_Muestra;

                        
                        ls_ordnumero = servicios_ord.OrdNumero.TrimStart(new Char[] { '0' });

                        ls_YearMuestra = ls_ordnumero; //agre // + "-"+ ls_CodMuestra;
                    
                        //md_ordenes = "P|1|" + ls_ordnumero + "|" + ls_hc + "||" + ls_apellidos + "^" + ls_nombres + "||" + ls_fnac + "|"
                        //                       + ls_sexo + "|||||||||||||||||" + ls_cod_suc + "||||" + ls_nom_cia + "|" + ls_cod_cia + "|"
                        //                       + ls_nom_suc + "|" + ls_cod_suc + "|" + ls_nom_med + "|" + ls_nom_emp + "||||";

                        
                        //Ordenes host ASTM
                        //P|1|20194||||||||||||
                        md_ordenes = "P|" + i + "|" + ls_YearMuestra + "|||" + ls_apellidos + " " + ls_nombres + "|" + " |" + ls_fnac + "|" + ls_sexo + "||||||";
                                               //+ "|"                              
                                               //+ ls_hc + "||" + ls_apellidos + "^" + ls_nombres + "||" + ls_fnac + "|"
                                               //+ ls_sexo + "|||||||||||||||||" + ls_cod_suc + "||||" + ls_nom_cia + "|" + ls_cod_cia + "|"
                                               //+ ls_nom_suc + "|" + ls_cod_suc + "|" + ls_nom_med + "|" + ls_nom_emp + "||||";
                        //fin--
                        
   //agregar            sb.AppendLine(md_cabecera);
                        sb.AppendLine(md_ordenes);
                    }
                    sb_Year.AppendLine(DateTime.Now.ToString("G") + "......." + ls_yearorden + "  envio correcto...");
                    txtRecibirDatos.Text = sb_Year.ToString();

                    listBox1.Items.Add(md_cabecera + "\r\n");

                    
                    YearOrdenes[i -1] = ls_yearorden;
  //agregar                  GrabarDatosOrden_Cab();   //1 Cabecera

                   //Parametros para buscar la Ordens del Paciente --Ini
                    Numoscab = servicios_ord.Numos;
                    Peroscab = servicios_ord.Peros;
                    Anooscab = servicios_ord.Anoos;
                    MNumsuc = servicios_ord.Numsuc;
                    CodMuestra = servicios_ord.Cod_Muestra;

                    
                    //fin

                   //almacenar Numoscab, Peroscab, Anoscab y MNumsuc para despues insertar data
                    NumscabA[i - 1] = servicios_ord.Numos;
                    PeroscabA[i - 1] = servicios_ord.Peros;
                    AnioscabA[i - 1] = servicios_ord.Anoos;
                    NumsucA[i - 1] = servicios_ord.Numsuc;
                    CodMuestraA[i - 1] = servicios_ord.Cod_Muestra;

                   
                    //

                    ListServiciosPac = BLServicios.ServiciosLab_EnvioPen_Modena_det(Numoscab, Peroscab, Anooscab, MNumsuc, CodMuestra);

                    listBox1.Items.Add(md_ordenes + "\r\n");

                    int s = 0;
                    int b = 0;

                    //Numser = new string[ListServiciosPac.Count()];
                    //Cod_suc_Mue = new string[ListServiciosPac.Count()];
                    Pruebas = new string [ListServiciosPac.Count()];
                   
                    foreach (BEServicios servicios in ListServiciosPac)
                    {
                        {
                            s++;
                            ls_Numfox = servicios.Numfox;
                            ls_Numser = servicios.Numser;
                            ls_cod_suc_Mues = servicios.Codigo_Sucur_Mues;
                            ls_Numfox_Mod = servicios.Lcm_Numfox_Mod;
                            ls_Cod_Muestra = servicios.Cod_Muestra;

 //correcto                        md_servicios = ("O|" + s + "|" + ls_ordnumero + "-"+ ls_Cod_Muestra + "||^^^" + ls_Numfox_Mod); //Numero de Orden mas el codigo de muestra //+ "^^|R|" + ls_fechahora + "|||||A||||||||||||||O");                        

                            Pruebas[s-1] = ls_Numfox_Mod;

                            //md_servicios = ("O|" + s + "|" + ls_ordnumero + "||^^^" + ls_Numfox_Mod); // con Numero de Orden /  + "^^|R|" + ls_fechahora + "|||||A||||||||||||||O");   
                            
                            //md_servicios = ("O|" + servicios.RowNum + "|" + ls_ordnumero + "||^^^" + ls_Numfox + "^^|R|" + ls_fechahora + "|||||A||||||||||||||O");
                      //      md_servicios = "O|" + s + @"|001||^^^022\^^^017";
 //correcto                           sb.AppendLine(md_servicios);
                        } 
                        listBox1.Items.Add(md_servicios + "\r\n");
                    }
                    string PruebasPaciente = string.Empty;
                    string OrdNumeroMue = string.Empty;
                    int pr = 0;
                    foreach(var row in Pruebas)
                    {
                        pr++;
                        if ((pr)==Pruebas.Length)
                        {
                            PruebasPaciente += "^^^" + row;
                        }
                        else 
                        {
                            char conc = Convert.ToChar(@"\");
                            PruebasPaciente += "^^^" + row + conc; 
                        }
                         
                    }
                    b++;
                    OrdNumeroMue = ls_ordnumero + "-" + ls_Cod_Muestra;
                    md_servicios = ("O|" + b + "|" + OrdNumeroMue + "||" + PruebasPaciente);
                    sb.AppendLine(md_servicios);
  
                }
                  md_footer = "L|1|";
                  sb.AppendLine(md_footer);
                  listBox1.Items.Add(md_footer);

                  string[] separatingChars = { "\r\n" };
                  string[] words = sb.ToString().Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
                  //prue = words;
                  DataResult = words;
   //agregar           Servicio_Cab_flagEnvMig_Update(); // Orden_Servicio_Det
                }
                
         //   }
                 
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
            //finally
            //{

            //}
            return DataResult;
        }



        //
        public void ListarServicioLisModena(string lis_codigo,string Numser, string cod_suc_mue)
        {
            try
            {

                ListServicios_Ord_Pac = BLServicios.ServiciosLab_XLis_Modena(lis_codigo, Numser, cod_suc_mue);
                foreach (BEServicios servicios_Lis in ListServicios_Ord_Pac)
                {
                    {
                        ls_rownum = servicios_Lis.RowNum;
                        ls_Numser = servicios_Lis.Numser;
                        ls_Numfox = servicios_Lis.Numfox;
                        ls_Desser = servicios_Lis.Desser;
                        ls_Tiper = servicios_Lis.Tipser;
                       // ls_flag_perfil = servicios_Lis.Flag_Perfil;
                        ls_CItem = servicios_Lis.C_Item;
                        ls_ExaCodigo = servicios_Lis.Exa_Codigo;
                        ls_Comenta_fijo = servicios_Lis.Comenta_Fijo;
                        ls_ExaNombre = servicios_Lis.Exa_Nombre;
                        ls_SubTitulo = servicios_Lis.SubTitulo;
                        ls_SubTiper = servicios_Lis.SubTiper;
                        ls_Resultado_defecto = servicios_Lis.Resultado_Defecto;
                        ls_MetCodigo = servicios_Lis.Meto_codigo;
                        ls_MetDescrip = servicios_Lis.Meto_Descrip;
                        ls_MueCodigo = servicios_Lis.MueCodigo;
                        ls_FlagPerfil = servicios_Lis.Flag_Perfil;
                        ls_sec_Cod = servicios_Lis.SecCodigo;
                        ls_sec_descrip = servicios_Lis.SecDescrip;
                    }
                      

                           Grabar_Orden_Result();

               
                }
                          Grabar_Orden_Servicio();  

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
        }
        //
        private void GrabarDatosOrden_Cab(string Yearorden)
        {
            try
            {
            //    var sb_Year = new System.Text.StringBuilder();
                BEServicios entidad = new BEServicios();
                entidad.YearOrden=Yearorden;

                    entidad = BLServicios.Lab_Orden_Cab_Insert(entidad);

                if (entidad.Resultado == 1)
                {
        //            MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //sb_Year.AppendLine(DateTime.Now.ToString("G") + "......."+ ls_yearorden + " NroServicio: "+ ls_Numfox + "envio correcto...");
                    //txtRecibirDatos.Text = sb_Year.ToString();
                }
                else if (entidad.Resultado == -1)
                {
         //           MessageBox.Show(entidad.Mensaje + "TB CONTROL.LAB_ORDEN_CAB:" + "Yearorden: " + ls_yearorden , "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //sb_Year.AppendLine(DateTime.Now.ToString("G") + "......." + ls_yearorden + " NroServicio: " + ls_Numfox + "envio correcto...");
                    //txtRecibirDatos.Text = sb_Year.ToString();
                }
                else
                {
        //            MessageBox.Show(":  los registos ya existen");

                }
        
            }
            catch (Exception ex)
            {
                // MessageBox.Show("El registro ya existe");
                Console.Write(ex.Message.ToString());
            }
        }
        //
        private void Servicio_Cab_flagEnvMig_Update()
        {
            try
            {
                BEServicios entidad = new BEServicios();
                entidad.YearOrden = ls_yearorden;

                entidad = BLServicios.Servicio_Cab_flagEnvMig_Update(entidad);

                if (entidad.Resultado == 1)
                {
         //           MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (entidad.Resultado == -1)
                {
        //            MessageBox.Show(entidad.Mensaje + "TB sigeser.sgs_orden_servicio_det:" + "Yearorden: " + ls_yearorden, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
        //            MessageBox.Show(":  los registos ya existen");

                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("El registro ya existe");
                Console.Write(ex.Message.ToString());
            }
        }
        //

        private void Grabar_Orden_Servicio()
        {
            try
            {
                BEServicios entidad = new BEServicios();
                entidad.YearOrden = ls_yearorden;
                entidad.OrdNumero = ls_ordnumero;
                entidad.Numser = ls_Numser;
                entidad.C_Item = ls_rownum; //Cantidad de exacodigos;

                entidad = BLServicios.Lab_Orden_Servicio_Insert(entidad);

                if (entidad.Resultado == 1)
                {
        //            MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (entidad.Resultado == -1)
                {
         //           MessageBox.Show(entidad.Mensaje + "TB CONTROL.LAB_ORDEN_SERVICIO:" + "Yearorden: " + ls_yearorden + " " + "Numser: " + ls_Numser ,
         //                           "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
          //          MessageBox.Show(":  los registos ya existen");

                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("El registro ya existe");
                Console.Write(ex.Message.ToString());
            }
        }

        private void Grabar_Orden_Result()
        {
            try
            {
                BEServicios entidad = new BEServicios();  
                //Resultado por defecto --ini PB
                if (entidad.Resultado_Defecto.Length > 0)
                { 
                    entidad.Result_Valor = entidad.Resultado_Defecto;
                }
                if (IsNumeric(entidad.Result_Valor))
                {
                    entidad.Result_TipoDat="N";
                }
                else{
                    entidad.Result_TipoDat="T";
                }
                //Resultado por defecto --fin PB

                entidad.Tb_Impreso = "0";
                entidad.LisCodigo = "3";                
                entidad.YearOrden = ls_yearorden;
                entidad.OrdNumero = ls_ordnumero;

                entidad.Item = ls_rownum; //Item

                entidad.MueCodigo = ls_MueCodigo;

                //OTROS PB
                entidad.Flag_Reporte = "1";
                entidad.Flag_Confide = "0";
                entidad.Exa_Codigo = ls_ExaCodigo;
                //PREG
                entidad.Exa_Nombre = ls_ExaNombre;


                //DATOS DEL SERVICIO -INI
                entidad.Numfox = ls_Numfox;
                entidad.Numser = ls_Numser;
                entidad.Flag_Perfil = ls_FlagPerfil;

                if (entidad.Flag_Perfil == "1")
                {
                    entidad.Nombre_Perfil = ls_Desser;
                }
                else
                {
                    entidad.Nombre_Perfil = "";
                }           
                entidad.Meto_codigo = "0";
                entidad.Meto_Descrip = ls_MetDescrip;

                entidad.SecCodigo = ls_sec_Cod;
                entidad.SecDescrip = ls_sec_descrip;

                entidad.SubTitulo = ls_SubTitulo;
                entidad.SubTiper = ls_SubTiper;

                if (ls_Comenta_fijo.Length > 0)
                {
                    entidad.Tb_Texto = "1";
                    Grabar_Orden_Result_Texto();
                }
                else {
                    entidad.Tb_Texto = "0";
                }

                entidad.FlagCerado = "0";               

                //if (FormState == "New")
                entidad = BLServicios.Lab_Orden_Result_Insert(entidad);

                if (entidad.Resultado == 1)
                {
       //             MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (entidad.Resultado == -1)
                {
        //            MessageBox.Show(entidad.Mensaje + "CONTROL.LAB_ORDEN_RESULT:" + "Yearorden: " + ls_yearorden + " "+ "Numser: "+ ls_Numser + " "+ "Exacodigo: "+ls_ExaCodigo, "Mensaje del Sistema",
        //                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
        //            MessageBox.Show(":  los registos ya existen");
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("El registro ya existe");
                Console.Write(ex.Message.ToString());
            }
        }
        private void Grabar_Orden_Result_Texto()
        {
            try
            {
                BEServicios entidad = new BEServicios();

                entidad.YearOrden=ls_yearorden;
                entidad.OrdNumero=ls_ordnumero;
                entidad.Numser=ls_Numser;
                entidad.Item=ls_rownum;
                entidad.Comenta_Fijo=ls_Comenta_fijo;
                entidad.LisCodigo=ls_liscodigo;

                //if (FormState == "New")
                entidad = BLServicios.Lab_Orden_Result_Texto_Insert(entidad);

                if (entidad.Resultado == 1)
                {
      //              MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (entidad.Resultado == -1)
                {
     //               MessageBox.Show(entidad.Mensaje + "CONTROL.LAB_ORDEN_RESULT_TEXTO:" + "Yearorden: " + ls_yearorden + " " + "Numser: " + ls_Numser, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
     //               MessageBox.Show(":  los registos ya existen");
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
            int result;
            return int.TryParse(valor, out result);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {            
            //string[] Rpt = null;
            //ListarServicioModena(ref Rpt);
           string CMuestra = null;
           string YearOrden = null;
            string[] ResultadoHost = ListarServicioModena(YearOrden, CMuestra);

            string res = "dd";

            string a = @"@\";
            Console.WriteLine(a);
   

           // GrabarData();
            
      //      ListarServicioModena();
        }
 

        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    //string text = System.IO.File.ReadAllText(listBox1.Text);
        //    //MessageBox.Show(text);

        //    //System.IO.File.WriteAllText(@"C:\Users\jramirez\Desktop\EscribeTexto2.txt", text);

            
        //}

    //    private Timer timer1;
        //public void InitTimer()
        //{
        //        timer1 = new Timer();
        //        timer1.Tick += new EventHandler(timer1_Tick);
        //        timer1.Interval = 5000; // in miliseconds 
        //        timer1.Start();             
            
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (btnConectar.Text == "Desconectar")
            {                
             //   txtRecibirDatos.Text = "";
                timer1.Stop();
     //           ListarServicioModena();
                if (CountOrdenes > 0)
                {
                    EnviarHL7();
                }
                else
                {
                //    lblRecibido.Text = "";
                }

  //              InitTimer(); // se agrego, a fin de que termine el proceso y cuente nuevamente los segundos
                //spPuertos.DiscardOutBuffer();
                //strBufferOut = txtEnviarDatos.Text;
                //spPuertos.Write(strBufferOut);

                //dato recibido
            }

            else
            {
              //  lblRecibido.Text = "Puerto COM Desconectado";            
            }
        }

        //private void CorrerProceso()
        //{
        //    //Hacer que se tarde 10000 milisegundos (10 segundos) 
        //    Thread.Sleep(10000);
        //   // ListarServicioModena();
        //    EnviarHL7();
        //    MessageBox.Show("Proceso finalizado");
        //}

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            listRec.Items.Clear();
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
        //Grabar REsultados
        private void Grabar_Resultados_Update()
        {
            try
            {
                BEServicios_Rec entidad = new BEServicios_Rec();
                entidad.YearOrden = ls_yearorden;
                // entidad.Numfox = ls_Numfox;
                entidad.Exa_Codigo = ls_exacodigo;     //exa del modena
               // entidad.Exa_Codigo_Inf = ls_exacodigo_inf;       
                entidad.Unidad_Nombre = ls_unidad_nombre;         //falta

                //Determinar si esta fuera del ranngo//
                ListarOrdenResult();
                //
                entidad.Valor_referencial = ls_ref_min +  " - " + ls_ref_max;
                if (IsNumeric(ls_result_valor))
                {
                    if (ls_ref_max.Length >0)
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
                }
                else ls_fuera_rango = "";

                entidad.Fuera_Rango = ls_fuera_rango;
                entidad.Tb_Antibio = "";
                entidad.FlagCerado = "1";
                entidad.Numfox = ls_Numfox;
                entidad.Exa_Codigo = ls_exacodigo;   //recuperamos exa del esquema control.
                entidad.Result_Valor = ls_result_valor;
                entidad.Flag_Reporte = "1";

                
                //// string fecha = "2019-01-19 19:03:46";
               // if (Result_UsuVal.Length > 0)
               // {
                string fechaval = (fechavalStr.Substring(0, 4)) + "/" + fechavalStr.Substring(4, 2) + "/" + fechavalStr.Substring(6, 2) + " " +
                             fechavalStr.Substring(8, 2) + ":" + fechavalStr.Substring(10, 2) + ":" + fechavalStr.Substring(12, 2);
                    ls_fechaValidacion = DateTime.ParseExact(fechaval, "yyyy/MM/dd HH:mm:ss",
                                   System.Globalization.CultureInfo.InvariantCulture);
                //}

                    entidad.FechaValidacion = ls_fechaValidacion;   
                    entidad.Usuario_Validacion = ls_usuarioVal;       //falta

                //if (FormState == "New")
                entidad = BLServicios_Rec.Lab_Mod_Sui_Result_Update(entidad);

                if (entidad.Resultado == 1)
                {
                    Validar_Servicio_Det();
              //      MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (entidad.Resultado == -1)
                {
                    //MessageBox.Show(entidad.Mensaje + "CONTROL.LAB_ORDEN_RESULT_TEXTO:" + "Yearorden: " + ls_yearorden + " " + "Numser: " + ls_Numser, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
              //      MessageBox.Show(":  los registos ya existen");
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("El registro ya existe");
                Console.Write(ex.Message.ToString());
            }
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
                        ls_Numfox = Result_Select.Numfox;
                        ls_exacodigo = Result_Select.Exa_Codigo;
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

        private void Validar_Servicio_Det()
        {
            try
            {
                BEServicios_Rec entidad = new BEServicios_Rec();
                entidad.YearOrden = ls_yearorden;
                entidad.Numfox = ls_Numfox;

                entidad = BLServicios_Rec.Validar_Servicios_Det(entidad);

                if (entidad.Resultado == 1)
                {
                   // MessageBox.Show(entidad.Mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (entidad.Resultado == -1)
                {
                    //MessageBox.Show(entidad.Mensaje + "CONTROL.LAB_ORDEN_RESULT_TEXTO:" + "Yearorden: " + ls_yearorden + " " + "Numser: " + ls_Numser, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
       //             MessageBox.Show(":  los registos ya existen");
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("El registro ya existe");
                Console.Write(ex.Message.ToString());
            }
        }
        //
        //private void EjecutarHilo()
        //{
        //    //Creamos el delegado 
        //    ThreadStart delegado = new ThreadStart(CorrerProceso);
        //    //Creamos la instancia del hilo 
        //    Thread hilo = new Thread(delegado);
        //    //Iniciamos el hilo 
        //    hilo.Start(); 
        //}



        //

        #endregion
    }
}
