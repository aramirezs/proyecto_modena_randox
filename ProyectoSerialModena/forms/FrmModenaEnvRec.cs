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


namespace ProyectoSerialModena.forms
{
    public partial class FrmModenaEnvRec : Form
    {
        private delegate void DelefadoAcceso(string accion);
        private string strBufferIn;
        private string strBufferOut;

        private string md_cabecera, md_ordenes, md_servicios, md_footer;
        //ordenes//
        private string ls_hc, ls_apellidos, ls_nombres, ls_nom_emp, ls_cod_cia, ls_nom_suc, ls_cod_suc, ls_nom_med, ls_nom_cia, ls_sexo, ls_usuario,
                       ls_fnac, ls_fechahora, ls_yearorden, ls_ordnumero, ls_edad, ls_sexo_C, ls_Numcia, ls_NumPac, ls_anioPac, ls_liscodigo;

        private string ls_Numfox, ls_Numser, ls_cod_suc_Mues, ls_CItem, ls_ExaCodigo, ls_ExaNombre, ls_Comenta_fijo, ls_sec_Cod,
                       ls_sec_descrip, ls_Tiper, ls_SubTitulo, ls_SubTiper, ls_MueCodigo, ls_Resultado_defecto, ls_Desser,
                       ls_MetCodigo, ls_MetDescrip, ls_FlagPerfil, ls_rownum;

        //servicios
        private string Numoscab, Peroscab, Anooscab, MNumsuc, EnviarcadenaHL7;
        private int CountOrdenes;

        private string[] MsjOrdenes;

        //**variable recibir
        #region Variables Privadas

        private List<BEServicios_Rec> ListOrden_Result = null;
        //private List<BEServicios> ListServiciosPac = null;

        #endregion

        
    

        private string spaceNroOrden;
        private string spaceYearOrden2;
        private string Apellidos;
        private string NumeroOrden;
        private string Sexo;

        private string  md_hc, md_apellidos, md_nombres, md_nom_emp, md_cod_cia, md_nom_suc, md_cod_suc, md_nom_med, md_nom_cia, md_sexo, md_usuario,
                   md_fnac, md_fechahora, md_yearorden, md_year, md_ordnumero, md_edad, md_sexo_C, md_Numcia, md_NumPac, md_anioPac, md_liscodigo, md_ncabecera, md_proveedor, md_proveedornom;


        private string md_fechahora2, md_fechahora3, md_exacodigo, md_exacodigo_inf, md_result1, md_tipo, md_exa_nombre, md_nroorden, md_unidad_nombre,
                       md_usuarioVal, md_fuera_rango, md_TbAntibio, md_FlagCerrado, md_cantidad_dec, md_result_comenta, md_result_valor, md_ref_max, md_ref_min, md_Numfox;

        private DateTime md_fechaValidacion;


        //***private string li_year;

        private int md_li_year,  md_li_month, md_month;

        //private string cadena;
        //
        public FrmModenaEnvRec()
        {
            InitializeComponent();
        }
        private void AccesoForm(string accion)
        {
            var sb = new System.Text.StringBuilder();
            strBufferIn = accion;

            txtRecibirDatos.Text = strBufferIn;

            long b = accion.LongCount(letra => letra.ToString() == "&");
            sb.AppendLine(DateTime.Now.ToString("G") + "  Total de ordenes recibidas: " + b.ToString());
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

        private void FrmModenaEnvRec_Load(object sender, EventArgs e)
        {
            lblEstado.Text = "Desconectado";
            lblRecibido.Text = "Esperando Exámenes Escaneados.";
            InitTimer();
          //   EjecutarHilo();

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
                    spPuertos.Parity = Parity.None;
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
        private void EnviarHL7()
        {
            try
            {
                lblRecibido.Text = "Enviando Ordenes...";
                var sb_Year = new System.Text.StringBuilder();
                //    ListarServicioModena();
                spPuertos.DiscardOutBuffer();
                strBufferOut = txtEnviarDatos.Text;
                //               strBufferOut = txtEnviarDatos.Text;
        //        strBufferOut = EnviarcadenaHL7;
                spPuertos.Write(strBufferOut);
                sb_Year.AppendLine("Orden: " + ls_yearorden + ": N° Servicio: " + ls_Numfox + "...Envio Correcto");
                // textBox1.Text = sb_Year.ToString();
                ////string[] MsjOrdenesf = MsjOrdenes[];

                //textBox1.Text = MsjOrdenes[0];

                //Respuesta modena

                //             AccesoInterrupcion(spPuertos.ReadExisting());


            }
            catch (Exception)
            {
                var sb_Year = new System.Text.StringBuilder();
                if (btnConectar.Text == "Desconectar")
                {
                    sb_Year.AppendLine("Orden: " + ls_yearorden + ": N° Servicio: " + ls_Numfox + "...Envio Incorrecto");
     //               textBox1.Text = sb_Year.ToString();
                }

                //throw;

            }
        }
        private void DatoRecibido(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            AccesoInterrupcion(spPuertos.ReadExisting());
            /*string Data_in = spPuertos.ReadExisting();
            MessageBox.Show(Data_in);
            txtRecibirDatos.Text = Data_in;*/
        }

        #region Variables Privadas

        private List<BEServicios> ListServicios_Ord_Pac = null;
        private List<BEServicios> ListServiciosPac = null;

        #endregion


        #region Métodos Privados

        //INTERNO
        public void ListarServicioModena()
        {
            try
            {
                lblRecibido.Text = "";
                lblRecibido.Text = "Consultando Ordenes.";
                //variables


                string Numsuc = "G";
                var sb = new System.Text.StringBuilder();
                var sb_Year = new System.Text.StringBuilder();

                ListServicios_Ord_Pac = BLServicios.ServiciosLab_EnvioPen_Modena_cab(Numsuc);
                var count = ListServicios_Ord_Pac.Count(x => x != null);
                CountOrdenes = count;
                if (count <= 0)
                {
                    lblRecibido.Text = "Esperando Exámenes Escaneados.";
                }
                else
                {

                    //    sb_Year.AppendLine(DateTime.Now.ToString("G") + "......." + ls_yearorden + "  NroServicio:  " + ls_Numfox + "  envio correcto...");
                    sb_Year.AppendLine(DateTime.Now.ToString("G") + "......." + "total de Ordenes: " + count.ToString());
                    string mensajeOrdenes = DateTime.Now.ToString("G") + "......." + "total de Ordenes: " + count.ToString();

                    string[] MsjEnvio = new string[] { count.ToString() };
                    MsjOrdenes = new string[] { mensajeOrdenes };

                    string data = "abc,def,ghi";
                    string[] str = data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (BEServicios servicios_ord in ListServicios_Ord_Pac)
                    {
                        {

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
                            ls_ordnumero = servicios_ord.OrdNumero;
                            ls_edad = servicios_ord.Edad;
                            ls_sexo_C = servicios_ord.SexPac_C;
                            ls_Numcia = servicios_ord.Numcia;
                            ls_NumPac = servicios_ord.NumPac;
                            ls_anioPac = servicios_ord.AnioPac;
                            ls_liscodigo = servicios_ord.LisCodigo;

                            md_cabecera = @"H|\^&|||LIS^MODENA Diagnostics|||||||||" + ls_fechahora;
                            md_ordenes = "P|1|" + ls_ordnumero + "|" + ls_hc + "||" + ls_apellidos + "^" + ls_nombres + "||" + ls_fnac + "|"
                                                   + ls_sexo + "|||||||||||||||||" + ls_cod_suc + "||||" + ls_nom_cia + "|" + ls_cod_cia + "|"
                                                   + ls_nom_suc + "|" + ls_cod_suc + "|" + ls_nom_med + "|" + ls_nom_emp + "||||";

                            sb.AppendLine(md_cabecera);
                            sb.AppendLine(md_ordenes);
                        }
                        sb_Year.AppendLine(DateTime.Now.ToString("G") + "......." + ls_yearorden + "  envio correcto...");
                        txtRecibirDatos.Text = sb_Year.ToString();

             //           listBox1.Items.Add(md_cabecera + "\r\n");
                        GrabarDatosOrden_Cab();   //1 Cabecera



                        //fin tmp
                        //Listar Servicios//
                        Numoscab = servicios_ord.Numos;
                        Peroscab = servicios_ord.Peros;
                        Anooscab = servicios_ord.Anoos;
                        MNumsuc = servicios_ord.Numsuc;


                        ListServiciosPac = BLServicios.ServiciosLab_EnvioPen_Modena_det(Numoscab, Peroscab, Anooscab, MNumsuc);

             //           listBox1.Items.Add(md_ordenes + "\r\n");

                        foreach (BEServicios servicios in ListServiciosPac)
                        {
                            {
                                ls_Numfox = servicios.Numfox;
                                ls_Numser = servicios.Numser;
                                ls_cod_suc_Mues = servicios.Codigo_Sucur_Mues;

                                md_servicios = ("O|" + servicios.RowNum + "|" + ls_ordnumero + "||^^^" + ls_Numfox + "^^|R|" + ls_fechahora + "|||||A||||||||||||||O");
                                sb.AppendLine(md_servicios);
                            }
                            ListarServicioLisModena();   //  Result, ResultTexto y Orden Servicio.


           //                 listBox1.Items.Add(md_servicios + "\r\n");


                        }
                        md_footer = "L|1|N";
                        sb.AppendLine(md_footer);// + "\r\n");
         //               listBox1.Items.Add(md_footer);
                        txtEnviarDatos.Text = sb.ToString();
                        EnviarcadenaHL7 = sb.ToString();

                    }

                    Servicio_Cab_flagEnvMig_Update(); // Orden_Servicio_Det
                }
            }

            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
            //finally
            //{

            //}
        }

        //
        public void ListarServicioLisModena()
        {
            try
            {

                ListServicios_Ord_Pac = BLServicios.ServiciosLab_XLis_Modena(ls_liscodigo, ls_Numser, ls_cod_suc_Mues);
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
        private void GrabarDatosOrden_Cab()
        {
            try
            {
                //    var sb_Year = new System.Text.StringBuilder();
                BEServicios entidad = new BEServicios();
                entidad.YearOrden = ls_yearorden;

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
                    entidad.Result_TipoDat = "N";
                }
                else
                {
                    entidad.Result_TipoDat = "T";
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
                    entidad.Nombre_Perfil = "";

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
                else
                {
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

                entidad.YearOrden = ls_yearorden;
                entidad.OrdNumero = ls_ordnumero;
                entidad.Numser = ls_Numser;
                entidad.Item = ls_rownum;
                entidad.Comenta_Fijo = ls_Comenta_fijo;
                entidad.LisCodigo = ls_liscodigo;

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
            ListarServicioModena();
        }

        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    //string text = System.IO.File.ReadAllText(listBox1.Text);
        //    //MessageBox.Show(text);

        //    //System.IO.File.WriteAllText(@"C:\Users\jramirez\Desktop\EscribeTexto2.txt", text);


        //}

        //    private Timer timer1;
        public void InitTimer()
        {

   //         timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 5000; // in miliseconds 
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (btnConectar.Text == "Desconectar")
            {
                //   txtRecibirDatos.Text = "";
                timer1.Stop();
                ListarServicioModena();
                if (CountOrdenes > 0)
                {
                    EnviarHL7();
                }
                else
                {
                    //    lblRecibido.Text = "";
                }

                InitTimer(); // se agrego, a fin de que termine el proceso y cuente nuevamente los segundos
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListarServicioModena();
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

                    string[] ResultadoC = ExtraerCaracter(cadena + "|", Inicial, final);

                    md_year = ResultadoC[2].Substring(0, 4);

                    //almacenar
                }
                else if (i - 1 == 1)
                {
                    //--Paciente
                    string[] Inicial = { @"P|1|", "|", "||", "^", "||", "|", "|||||||||||||||", "||", "^" };
                    string[] final = { "|", "||", "^", "||", "|", "|||||||||||||||", "||", "^", "|" };
                    string[] ResultadoP = ExtraerCaracter(cadena + "|", Inicial, final);

                    if (ResultadoP[0].Length <= 7)
                        ls_yearorden = md_year + "0" + ResultadoP[0];

                    else
                    {
                        ls_yearorden = md_year + ResultadoP[0];
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

                        string[] Inicial = { "R|", "|", "^", "^^", "|", "|", "|||", "||", "||", "|", "||", "|" };
                        string[] final = { "|", "^", "^^", "|", "|", "|||", "||", "||", "|", "||", "|", "|" };
                        ResultadoR = ExtraerCaracter(cadena, Inicial, final);

                        md_exacodigo = Resultado[3];
                        md_exacodigo_inf = Resultado[1];
                        md_unidad_nombre = Resultado[5];

                        //Separar fecha de validacion y usuario de validación
                        string[] separatingChars_Ord = { "^" };
                        string[] Result_UsuVal = Resultado[10].Split(separatingChars_Ord, System.StringSplitOptions.RemoveEmptyEntries);

                        // string fecha = "2019-01-19 19:03:46";
                        if (Result_UsuVal.Length > 0)
                        {
                            string fechaval = (Result_UsuVal[0].Substring(0, 4)) + "/" + Result_UsuVal[0].Substring(4, 2) + "/" + Result_UsuVal[0].Substring(6, 2) + " " +
                                     Result_UsuVal[0].Substring(8, 2) + ":" + Result_UsuVal[0].Substring(10, 2) + ":" + Result_UsuVal[0].Substring(12, 2);
                            md_fechaValidacion = DateTime.ParseExact(fechaval, "yyyy/MM/dd HH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture);
                        }

                        if (Result_UsuVal.Length > 1)
                        {
                            md_usuarioVal = Result_UsuVal[1];
                        }
                        else
                        {
                            md_usuarioVal = "";
                        }
                        // ls_fuera_rango   = ""; // comparar registros;              

                        md_cantidad_dec = Resultado[11]; // contar los decimales;
                        // ls_result_comenta = "";
                        md_result_valor = Resultado[4];
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
                        string[] final = { "|", "|", "|", "|", "|" };
                        ResultadoC = ExtraerCaracter(cadena, Inicial, final);
                        md_result_comenta = ResultadoC[2];
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
                ListOrden_Result = BLServicios_Rec.Orden_Result_Select(ls_yearorden, md_exacodigo, md_exacodigo_inf);
                foreach (BEServicios_Rec Result_Select in ListOrden_Result)
                {
                    {
                        md_ref_max = Result_Select.Ref_Max;
                        md_ref_min = Result_Select.Ref_Min;
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
                entidad.Exa_Codigo = md_exacodigo;
                entidad.Exa_Codigo_Inf = md_exacodigo_inf;
                entidad.Unidad_Nombre = md_unidad_nombre;
                entidad.FechaValidacion = md_fechaValidacion;
                entidad.Usuario_Validacion = md_usuarioVal;
                //Determinar si esta fuera del ranngo//
                ListarOrdenResult();
                //
                entidad.Valor_referencial = md_ref_min + " " + "-" + " " + md_ref_max;
                if (IsNumeric_double(md_result_valor))
                {
                    if (Convert.ToDecimal(md_result_valor) >= Convert.ToDecimal(md_ref_min) && Convert.ToDecimal(md_result_valor) >= Convert.ToDecimal(md_ref_min))
                    {
                        md_fuera_rango = "0";
                    }
                    else
                    {
                        md_fuera_rango = "1";
                    }
                }
                else md_fuera_rango = "";

                entidad.Fuera_Rango = md_fuera_rango;
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
        public static Boolean IsNumeric_double(string valor)
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
                entidad.Exa_Codigo = md_exacodigo;
                entidad.Exa_Codigo_Inf = md_exacodigo_inf;
                entidad.Result_Comenta = md_result_comenta;

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
        private void CorrerProceso()
        {
            //Hacer que se tarde 10000 milisegundos (10 segundos) 
            Thread.Sleep(10000);
            // ListarServicioModena();
         //   EnviarHL7();
            InitTimer();
            //
           
            //
            MessageBox.Show("Proceso finalizado");
        }
        private void DatoRecibidomod(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            AccesoInterrupcion(spPuertos.ReadExisting());
            /*string Data_in = spPuertos.ReadExisting();
            MessageBox.Show(Data_in);
            txtRecibirDatos.Text = Data_in;*/
        }
        private void EjecutarHilo()
        {
            //Creamos el delegado 
            ThreadStart delegado = new ThreadStart(CorrerProceso);
            //Creamos la instancia del hilo 
            Thread hilo = new Thread(delegado);
            //Iniciamos el hilo 
            hilo.Start();
        }

        private void btnTimer_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
