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

namespace ProyectoSerialC
{
    public partial class Form1 : Form
    {
        private delegate void DelefadoAcceso(string accion);
        private string strBufferIn;
        private string strBufferOut;

        public Form1()
        {
            InitializeComponent();
        }

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

        private void Form1_Load(object sender, EventArgs e)
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

     
    }
}
