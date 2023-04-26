namespace ProyectoSerialC
{
    partial class FrmModena
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.txtRecibirDatos = new System.Windows.Forms.TextBox();
            this.txtEnviarDatos = new System.Windows.Forms.TextBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.cboPuerto = new System.Windows.Forms.ComboBox();
            this.btnEnviarDato = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnBuscarPuerto = new System.Windows.Forms.Button();
            this.spPuertos = new System.IO.Ports.SerialPort(this.components);
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnSelecDest = new System.Windows.Forms.Button();
            this.btnMover = new System.Windows.Forms.Button();
            this.btnArchivo = new System.Windows.Forms.Button();
            this.btnCarpeta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.rbtArchivo = new System.Windows.Forms.RadioButton();
            this.rbtCarpeta = new System.Windows.Forms.RadioButton();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(404, 382);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Datos Recibidos";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(44, 81);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
            this.lblBaudRate.TabIndex = 17;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // txtRecibirDatos
            // 
            this.txtRecibirDatos.Location = new System.Drawing.Point(47, 262);
            this.txtRecibirDatos.Multiline = true;
            this.txtRecibirDatos.Name = "txtRecibirDatos";
            this.txtRecibirDatos.Size = new System.Drawing.Size(429, 103);
            this.txtRecibirDatos.TabIndex = 16;
            // 
            // txtEnviarDatos
            // 
            this.txtEnviarDatos.Location = new System.Drawing.Point(47, 112);
            this.txtEnviarDatos.MaxLength = 999999999;
            this.txtEnviarDatos.Multiline = true;
            this.txtEnviarDatos.Name = "txtEnviarDatos";
            this.txtEnviarDatos.Size = new System.Drawing.Size(432, 97);
            this.txtEnviarDatos.TabIndex = 15;
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "115200"});
            this.cboBaudRate.Location = new System.Drawing.Point(286, 73);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(190, 21);
            this.cboBaudRate.TabIndex = 14;
            this.cboBaudRate.Text = "9600";
            // 
            // cboPuerto
            // 
            this.cboPuerto.FormattingEnabled = true;
            this.cboPuerto.Location = new System.Drawing.Point(286, 32);
            this.cboPuerto.Name = "cboPuerto";
            this.cboPuerto.Size = new System.Drawing.Size(190, 21);
            this.cboPuerto.TabIndex = 13;
            // 
            // btnEnviarDato
            // 
            this.btnEnviarDato.Location = new System.Drawing.Point(372, 221);
            this.btnEnviarDato.Name = "btnEnviarDato";
            this.btnEnviarDato.Size = new System.Drawing.Size(104, 29);
            this.btnEnviarDato.TabIndex = 12;
            this.btnEnviarDato.Text = "Enviar Datos";
            this.btnEnviarDato.UseVisualStyleBackColor = true;
            this.btnEnviarDato.Click += new System.EventHandler(this.btnEnviarDato_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(144, 30);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(127, 23);
            this.btnConectar.TabIndex = 11;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnBuscarPuerto
            // 
            this.btnBuscarPuerto.Location = new System.Drawing.Point(34, 30);
            this.btnBuscarPuerto.Name = "btnBuscarPuerto";
            this.btnBuscarPuerto.Size = new System.Drawing.Size(104, 23);
            this.btnBuscarPuerto.TabIndex = 10;
            this.btnBuscarPuerto.Text = "Buscar Puerto";
            this.btnBuscarPuerto.UseVisualStyleBackColor = true;
            this.btnBuscarPuerto.Click += new System.EventHandler(this.btnBuscarPuerto_Click);
            // 
            // spPuertos
            // 
            this.spPuertos.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.DatoRecibido);
            // 
            // btnCopiar
            // 
            this.btnCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.Location = new System.Drawing.Point(504, 170);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(413, 70);
            this.btnCopiar.TabIndex = 30;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Visible = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnSelecDest
            // 
            this.btnSelecDest.Location = new System.Drawing.Point(851, 113);
            this.btnSelecDest.Name = "btnSelecDest";
            this.btnSelecDest.Size = new System.Drawing.Size(452, 39);
            this.btnSelecDest.TabIndex = 29;
            this.btnSelecDest.Text = "Seleccionar carpeta de destino";
            this.btnSelecDest.UseVisualStyleBackColor = true;
            this.btnSelecDest.Click += new System.EventHandler(this.btnSelecDest_Click);
            // 
            // btnMover
            // 
            this.btnMover.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMover.Location = new System.Drawing.Point(923, 170);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(409, 70);
            this.btnMover.TabIndex = 28;
            this.btnMover.Text = "Mover";
            this.btnMover.UseVisualStyleBackColor = true;
            this.btnMover.Visible = false;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // btnArchivo
            // 
            this.btnArchivo.Enabled = false;
            this.btnArchivo.Location = new System.Drawing.Point(1080, 54);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Size = new System.Drawing.Size(223, 39);
            this.btnArchivo.TabIndex = 27;
            this.btnArchivo.Text = "Seleccionar archivo";
            this.btnArchivo.UseVisualStyleBackColor = true;
            this.btnArchivo.Click += new System.EventHandler(this.btnArchivo_Click);
            // 
            // btnCarpeta
            // 
            this.btnCarpeta.Location = new System.Drawing.Point(851, 54);
            this.btnCarpeta.Name = "btnCarpeta";
            this.btnCarpeta.Size = new System.Drawing.Size(223, 39);
            this.btnCarpeta.TabIndex = 26;
            this.btnCarpeta.Text = "Seleccionar carpeta";
            this.btnCarpeta.UseVisualStyleBackColor = true;
            this.btnCarpeta.Click += new System.EventHandler(this.btnCarpeta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Origen";
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(504, 121);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(333, 20);
            this.txtDestino.TabIndex = 23;
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(504, 62);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(333, 20);
            this.txtOrigen.TabIndex = 22;
            // 
            // rbtArchivo
            // 
            this.rbtArchivo.AutoSize = true;
            this.rbtArchivo.Location = new System.Drawing.Point(1331, 99);
            this.rbtArchivo.Name = "rbtArchivo";
            this.rbtArchivo.Size = new System.Drawing.Size(61, 17);
            this.rbtArchivo.TabIndex = 21;
            this.rbtArchivo.Text = "Archivo";
            this.rbtArchivo.UseVisualStyleBackColor = true;
            // 
            // rbtCarpeta
            // 
            this.rbtCarpeta.AutoSize = true;
            this.rbtCarpeta.Checked = true;
            this.rbtCarpeta.Location = new System.Drawing.Point(1331, 65);
            this.rbtCarpeta.Name = "rbtCarpeta";
            this.rbtCarpeta.Size = new System.Drawing.Size(62, 17);
            this.rbtCarpeta.TabIndex = 20;
            this.rbtCarpeta.TabStop = true;
            this.rbtCarpeta.Text = "Carpeta";
            this.rbtCarpeta.UseVisualStyleBackColor = true;
            this.rbtCarpeta.CheckedChanged += new System.EventHandler(this.rbtCarpeta_CheckedChanged);
            // 
            // ofd1
            // 
            this.ofd1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(504, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(413, 70);
            this.button1.TabIndex = 31;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmModena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 439);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.btnSelecDest);
            this.Controls.Add(this.btnMover);
            this.Controls.Add(this.btnArchivo);
            this.Controls.Add(this.btnCarpeta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.rbtArchivo);
            this.Controls.Add(this.rbtCarpeta);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.txtRecibirDatos);
            this.Controls.Add(this.txtEnviarDatos);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.cboPuerto);
            this.Controls.Add(this.btnEnviarDato);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.btnBuscarPuerto);
            this.Name = "FrmModena";
            this.Text = "FrmModena";
            this.Load += new System.EventHandler(this.FrmModena_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.TextBox txtRecibirDatos;
        private System.Windows.Forms.TextBox txtEnviarDatos;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.ComboBox cboPuerto;
        private System.Windows.Forms.Button btnEnviarDato;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnBuscarPuerto;
        private System.IO.Ports.SerialPort spPuertos;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnSelecDest;
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.Button btnArchivo;
        private System.Windows.Forms.Button btnCarpeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.RadioButton rbtArchivo;
        private System.Windows.Forms.RadioButton rbtCarpeta;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.Button button1;
    }
}