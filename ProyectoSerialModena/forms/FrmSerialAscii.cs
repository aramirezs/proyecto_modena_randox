using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports; // No olvidar.
using System.Threading;

namespace ProyectoSerialModena.forms
{
    public partial class FrmSerialAscii : Form
    {
        // Utilizremos un string como buffer de recepción.
        private string [] Cargar;
        string Recibidos;
        string Recibidos_grd;
        //string Recibo_STX_02 = ASCIIEncoding.ASCII.GetString(new byte[] { 2 }); // Inico de texto.
        //string Recibo_ENQ_05 = ASCIIEncoding.ASCII.GetString(new byte[] { 5 }); // Enquiry, investigación.
        //string Recibo_ETX_03 = ASCIIEncoding.ASCII.GetString(new byte[] { 3 }); // Fin de texto.
        //string Recibo_ACK_06 = ASCIIEncoding.ASCII.GetString(new byte[] { 6 }); // Acknowledge, reconocer.
        //string Recibo_EOT_04 = ASCIIEncoding.ASCII.GetString(new byte[] { 4 }); // Fin de transmisión.
        string Recibo_STX_02 = "STX"; // Inico de texto.
        string Recibo_ENQ_05 = "ENQ"; // Enquiry, investigación.
        string Recibo_ETX_03 = "ETX"; // Fin de texto.
        string Recibo_ACK_06 = "ACK"; // Acknowledge, reconocer.
        string Recibo_EOT_04 = "EOT"; // Fin de transmisión.
        string Recibo_NAK_15 = "NAK"; // Fin de transmisión.
        private string Resultado;
        public FrmSerialAscii()
        {
            InitializeComponent();
            // Abrir puerto mientras se ejecute la aplicación.
            if (!serialPort1.IsOpen)
            {
                    serialPort1.BaudRate = Int32.Parse("9600");
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Handshake = Handshake.RequestToSend;
                    serialPort1.PortName = "COM1";
                try
                {      
                    //
                    serialPort1.Open();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                // Ejecutar la función Recepcion por disparo del Evento 'DataReived'.
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(Recepcion);
            }
        }
        // Al recibir datos.
        private void Recepcion(object sender, SerialDataReceivedEventArgs e)
        {
            // Acumula los caracteres recibidos a nuestro 'buffer' (string).
          //  Recibidos += serialPort1.ReadExisting(); 
            Thread.Sleep(500);
            Recibidos = serialPort1.ReadExisting();

            // Invocar o llamar al proceso de tramas.
            Invoke(new EventHandler(Actualizar));
            

          //  richTextBox_Mensajes.Text += Recibidos;

        //    listRec.Items.Add(Recibidos);
            //richTextBox_Mensajes.Text = sb_Year.ToString();
            //for (int i = 0; i <10; i++ )
            //{
            //    string[] Guardar = new string[20];
            //    Guardar[i] = Recibidos.ToString();
            //}
       
           
            //Cargar[0] = sb_Year.ToString();

        }

        private void GuardarRecibidos(object s,EventArgs e)
        { 
            
        }

          // this.Invoke(new EventHandler(Actualizar));
        
        private void Actualizar2(object s, EventArgs e)
        {
            // Asignar el valor de la trama al texbox
            richTextBox_Mensajes.Text = Recibidos;
        }

         private string getFrameCheckSum(string Frametext) 
        {
            byte [] a=Encoding.ASCII.GetBytes(Frametext);
             int checkSum=0;
             for(int i=0;i<a.Length;i++)
             {
                checkSum+=a[i];
             }
             string outi = string .Format("{0:x2}",(checkSum & 0xFF)).ToUpper();
             return outi;
        }

        // Procesar los datos recibidos en el bufer y extraer tramas completas.
         private void Actualizar(object sender, EventArgs e)
         {
             listRec.Items.Add("["+DateTime.Now + "]" + "      receive      " + Recibidos);

             //Separarar carácteres ASCII
             string Respuesta, ASCII, ASCII2, ASCII3, ASCII4, ASCII5, ASCII6, cadena;

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
                 //Sustraer la cadena y ASCII    
                 int CantidadLet = Recibidos.Length;
                 ASCII = Recibidos.Substring(0, 1);
                 ASCII2 = Recibidos.Substring(CantidadLet - 1, 1);
                 ASCII3 = Recibidos.Substring(CantidadLet - 4, 2);
                 ASCII4 = Recibidos.Substring(CantidadLet - 5, 1);
                 ASCII5 = Recibidos.Substring(CantidadLet - 6, 1);
                 cadena = Recibidos.Substring(2, CantidadLet - 8);

                 if (ASCII == "") //RECIBE ACK
                 {
                     ASCII = Recibo_ACK_06;
                 }
                 else if (ASCII == "") //RECIBE STX --
                 {
                     ASCII = Recibo_STX_02;
                 }
                 else if (ASCII == "") //RECIBE EOT --
                 {
                     ASCII = Recibo_STX_02;
                 }
                 else if (ASCII == "") //RECIBE NAK
                 {
                     
                 }

             }
             //foreach

               //  for (int i = 0; i < a.Length; i++)
                 if ((ASCII == Recibo_STX_02) || (ASCII == Recibo_ENQ_05))
                 {
                     //     byte[] mBuffer = Encoding.ASCII.GetBytes("ACK"); 
                     //string r  = Encoding.ASCII.GetString(mBuffer);
                     //serialPort1.Write(mBuffer, 0, mBuffer.Length);
        //             richTextBox_Mensajes.Text = "Enviado ACK_06.";
                     ///
                     // string s = ASCIIEncoding.ASCII.GetString(new byte[] { 4 }); //EOT
                     // string s = ASCIIEncoding.ASCII.GetString(new byte[] { 5 }); //ENQ

                     byte[] mBuffer = Encoding.ASCII.GetBytes("");
                     //Respuesta = ASCIIEncoding.ASCII.GetString(new byte[] { 6 }); //ACK
                     serialPort1.Write(mBuffer, 0, mBuffer.Length);                   

                     listRec.Items.Add("[" + DateTime.Now + "]" + "      send      " + "<ACK>");
                     

   //                  Recibidos = "";
                 }

                 else
                 {
                     // if ((Recibidos != "2") & (Recibidos != "3") & (Recibidos != "5") & (Recibidos != "6") & (Recibidos != "4")) // != si son iguales devuelve false;
                     if (ASCII == Recibo_EOT_04) //eot del equipo correcto, en ese momento envias rspta enq
                     {
                         //         this.Invoke(new EventHandler(Actualizar));

                         //se agrego
                         Respuesta = ASCIIEncoding.ASCII.GetString(new byte[] { 5 }); //ENVÍO ENQ
                         serialPort1.Write(Respuesta);
                                               
                         listRec.Items.Add("[" + DateTime.Now + "]" + "      send      " + "<ENQ>");
     //                    Recibidos = "";
                     }
                     else if (ASCII == Recibo_ACK_06) //recibo ack
                     {
                         //Envio un STX concatenado con el texto y ETX

                         //[2019/02/14 10:35:02:417] 	receive	<STX>1H|\^&|||Host|||||||||201603o10134625<ETX>08<CR><LF>
                         //[2019/02/18 14:57:03:329] 	send	<STX>1H|\^&|||Analyzer|||||||||<CR><ETX>BD<CR><LF>
                         //1H|\^&|||Analyzer|||||||||20190218121948<CR><ETX>CB<CR><LF>
                         //1H|\^&|||Analyzer|||||||||20190219103105<CR> si pones en el checksum esta cadena te debe dar 
                         //<STX>1H|\^&|||Host|||||||||20160310134628<ETX>0B<CR><LF>

                         //               byte[] mBuffer = Encoding.ASCII.GetBytes("\r");
                         //               byte[] mBufferl = Encoding.ASCII.GetBytes("\n");

                         //string respuesta2 = ASCIIEncoding.ASCII.GetString(new byte[] { 2 }) 
                         //  +  ASCIIEncoding.ASCII.GetString(new byte[] { 13 }); 1H|\^&|||Analyzer|||||||||20190219103105

                         //<STX>1H|\^&|||Host|||||||||20160310134628<ETX>0B<CR><LF> el 
                         string data = @"1H|\^&|||host|||||||||20190219103105";//que formato da eso mm 20190219103105 no ese formato no da hazlo asi que de ese formato, pero antes muestrame el host simuator estabien  / yo lo estoy concatenando con el texto aca //ok, ercuerda es sequencial cuado sea dinmico
                  //       Respuesta = (char)10 + data; //+(char)10 ;//porque el arroba? por que sin ese arroba aparrece error es po el uso de "\"ah ok


                         //char2 stx //char 3 = etx vamos al log del modena
                         //(char)13 CR // char 10 = LF 
                         //probar OK
                         //falta limpiar el buffer cuando enviamos, limpiar? log del modena ok
                         //se callo porque el buffer se acomuló los datos que recepcionaba
                         Respuesta = (char)2+ data + (char)3 + getFrameCheckSum(data) + (char)13+(char)10; //LF//CR//ETX //prueba de nuevo/ esta bien // salio Nak //checa el log del modena/ ok
                 //      + ASCIIEncoding.ASCII.GetString(new byte[] { 13 }) //CR                         
//paras un momento aqui cuando corres
                         serialPort1.Write(Respuesta);
                        
                         listRec.Items.Add("[" + DateTime.Now + "]" + "      send      " + Respuesta);


       //                  Recibidos = "";
                         byte[] STX = new byte[] { 0x02 };
                         byte[] ETX = new byte[] { 0x03 };



                         byte[] CR = new byte[] { 0x13 };
                         byte[] LF = new byte[] { 0x10 };
                  //       string rst = "1H|\\^&|||Host|||||||||20160310134625";

                         //byte[] bytess = System.Text.Encoding.ASCII.GetBytes(@"1H|\^&|||Host|||||||||20160310134625");
                         //serialPort1.Write(STX, 0, 1);
                         //serialPort1.Write("1");
                         //serialPort1.Write(bytess, 0, bytess.Length);
                         //serialPort1.Write(ETX, 0, 1);
                         //serialPort1.Write(getFrameCheckSum(rst));
                         //serialPort1.Write(ASCIIEncoding.ASCII.GetString(new byte[] { 13 }));
                         //serialPort1.Write(ASCIIEncoding.ASCII.GetString(new byte[] { 10 }));

                     }

                     else
                     {
                         if (Recibidos == "4") // EOT.
                         {
                             this.Invoke(new EventHandler(actualizarenter));
                         }
                         else
                         {
                             if (Recibidos == "3") // ETX.
                             {
                                 byte[] mBuffer = Encoding.ASCII.GetBytes("ACK");
                                 serialPort1.Write(mBuffer, 0, mBuffer.Length);
              //                   richTextBox_Mensajes.Text = "Enviado ACK_06 en Recibidos ETX_3.";
                             }
                         }
                     }
                 }
               
       //          listRec.Items.Add("[" + DateTime.Now + "]" + "      receive      " + Recibidos);
                 
             }
    
        private void actualizarenter(object s, EventArgs e)
        {
            Recibidos = richTextBox_Mensajes.Text.ToString();
        }


        private void FrmSerialAscii_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getFrameCheckSum("3O|1|01100525||^^^004\^^^039\^^^038\^^^022\^^^042\^^^006\^^^013\^^^014\^^^040\^^^012\^^^026|R|||||||||||01|||||||||||||||<CR><ETX>31<CR><LF>");
        }
    }
}
