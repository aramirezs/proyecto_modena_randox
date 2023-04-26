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
using System.IO.Ports;



using Microsoft.VisualBasic.Devices; // Recuerden agregar la referencia "Microsoft.VisualBasic".


namespace ProyectoSerialC
{

    public partial class FrmModena : Form
    {
        Computer mycomputer = new Computer(); // Así accederemos al "FileSystem".
        string tipo = "carpeta"; // Para esta aplicación, para saber si copiar/mover un archivo a una carpeta.


        private delegate void DelefadoAcceso(string accion);
        private string strBufferIn;
        private string strBufferOut;
        public FrmModena()
        {
            InitializeComponent();
        }
        private void AccesoForm(string accion)
        {
            strBufferIn = accion;
            txtRecibirDatos.Text = strBufferIn;
            //

            //string text = System.IO.File.ReadAllText(@"C:\Users\jramirez\Desktop\HL7\HL7.txt");
            //MessageBox.Show(text);
            //System.IO.File.WriteAllText(@"C:\Users\jramirez\Desktop\EscribeTexto2.txt", strBufferIn);

            string nombrearch = string.Format("fichero_{0:yyyyMMDD_HHmm}.txt", DateTime.Now);

            var archivo = "C:\\Users\\jramirez\\Desktop\\HL7\\" + nombrearch;



            // eliminar el fichero si ya existe
            if (File.Exists(archivo))
                File.Delete(archivo);
            // crear el fichero                   
            

            //C:\Users\jramirez\Desktop\HL7\1030315_20190103102546_G_3.pet

            using (var fileStream = File.Create(archivo))
            {
                var texto = new UTF8Encoding(true).GetBytes(txtRecibirDatos.Text);
                fileStream.Write(texto, 0, texto.Length);
                fileStream.Flush();
            }



            

           // mycomputer.FileSystem.CopyFile(strBufferIn, txtDestino.Text); MessageBox.Show("Archivo enviado");

           // mycomputer.FileSystem.CopyFile(txtOrigen.Text, strBufferOut = txtDestino.Text); MessageBox.Show("Archivo enviado"); 

         //   C:\Users\jramirez\Desktop\HL7\1030315_20190103102546_G_3.pet
        }

        private void AccesoInterrupcion(string accion)
        {
            DelefadoAcceso Var_DelegadoAcceso;
            Var_DelegadoAcceso = new DelefadoAcceso(AccesoForm);
            object[] arg = { accion };
            base.Invoke(Var_DelegadoAcceso, arg);
        }

        private void FrmModena_Load(object sender, EventArgs e)
        {
            //BUSCAR PUERTO//
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
            // btnConectar.Enabled = false;
            //  btnEnviarDato.Enabled = false;


            //string text = System.IO.File.ReadAllText(@"C:\Users\jramirez\Desktop\formato.txt");
            //MessageBox.Show(text);

            //System.IO.File.WriteAllText(@"C:\Users\jramirez\Desktop\EscribeTexto2.txt", text);

            // string text = System.IO.File.ReadAllText(@"C:\Users\jramirez\Desktop\formato.txt");
            // MessageBox.Show(text);

            //   System.IO.File.WriteAllText(@"C:\Users\jramirez\Desktop\EscribeTexto2.txt", text);
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

                    try
                    {
                        spPuertos.Open();
                        btnConectar.Text = "Desconectar";
                        btnEnviarDato.Enabled = true;
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                }
                else if (btnConectar.Text == "Desconectar")
                {
                    spPuertos.Close();
                    btnConectar.Text = "Conectar";
                    btnEnviarDato.Enabled = false;
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
            AccesoInterrupcion(spPuertos.ReadExisting());

            /*string Data_in = spPuertos.ReadExisting();
            MessageBox.Show(Data_in);
            txtRecibirDatos.Text = Data_in;*/
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //string text = txtRecibirDatos.Text;

            //string text = System.IO.File.ReadAllText(@"C:\Users\jramirez\Desktop\formato.txt");
            string text = System.IO.File.ReadAllText(@"C:\Users\jramirez\Desktop\HL7\HL7.txt");
            MessageBox.Show(text);


            System.IO.File.WriteAllText(@"C:\Users\jramirez\Desktop\EscribeTexto2.txt", text);
        }

        private void rbtCarpeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCarpeta.Checked == true)
            {
                tipo = "carpeta"; // El tipo se cambiará a archivo.
                btnCarpeta.Enabled = true;
                btnArchivo.Enabled = false; //Para poder seleccionar un archivo y no una carpeta.
            }
            else // Si el radiobutton de la carpeta no esta seleccionado (significa lo contrario de la condición que antes hemos puesto).
            {
                tipo = "archivo"; // El tipo se cambiará a carpeta.
                btnCarpeta.Enabled = false;
                btnArchivo.Enabled = true; //Para poder seleccionar una carpeta y no un archivo.
            }
        }

        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            // El siguiente código servirá para que si hacemos un click en Ok con el selector de carpeta, el texto del TextBox1 sea la ruta seleccionada.
            var resultado = fbd1.ShowDialog();
            if (resultado == DialogResult.OK) { txtOrigen.Text = fbd1.SelectedPath; }
        }

        private void btnSelecDest_Click(object sender, EventArgs e)
        {
            // El siguiente código servirá para que el texto del textbox2 sea igual a la ruta seleccionada + desde el último índice de "\", para copiar el nombre de la carpeta.
            var resultado = fbd1.ShowDialog();
            if (resultado == DialogResult.OK) { txtDestino.Text = fbd1.SelectedPath + txtOrigen.Text.Substring(txtOrigen.Text.LastIndexOf(@"\")); }
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            // El siguiente código servirá para que si hacemos un click en Ok con el selector de archivos, el texto del TextBox1 sea el archivo seleccionado.
            var resultado = ofd1.ShowDialog();
            if (resultado == DialogResult.OK) { txtOrigen.Text = ofd1.FileName; }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (tipo == "carpeta") { mycomputer.FileSystem.CopyDirectory(txtOrigen.Text, txtDestino.Text); } // Copiamos la carpeta.
            if (tipo == "archivo") { mycomputer.FileSystem.CopyFile(txtOrigen.Text, txtDestino.Text); } // Copiamos el archivo.
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            if (tipo == "carpeta") { mycomputer.FileSystem.MoveDirectory(txtOrigen.Text, txtDestino.Text); } // Movemos la carpeta.
            if (tipo == "archivo") { mycomputer.FileSystem.MoveFile(txtOrigen.Text, txtDestino.Text); } // Movemos el archivo.
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                    //string ds = mycomputer.FileSystem.CopyFile(txtOrigen.Text, txtDestino.Text);

                    spPuertos.DiscardOutBuffer();
                   // strBufferOut = txtEnviarDatos.Text;               

                    if (tipo == "carpeta") { mycomputer.FileSystem.CopyDirectory(txtOrigen.Text, strBufferOut=txtDestino.Text); } // Copiamos la carpeta.
                    if (tipo == "archivo") { mycomputer.FileSystem.CopyFile(txtOrigen.Text, strBufferOut = txtDestino.Text); MessageBox.Show("Archivo enviado"); } // Copiamos el archivo.
                    spPuertos.Write(strBufferOut);

                    spPuertos.WriteLine(strBufferOut);


                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    }

