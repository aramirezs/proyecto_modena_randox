namespace ProyectoSerialModena.forms
{
    partial class FrmModenaEnvRec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModenaEnvRec));
            this.lblRecibido = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnVer = new System.Windows.Forms.Button();
            this.txtinfo = new System.Windows.Forms.TextBox();
            this.btnTimer = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecibido
            // 
            this.lblRecibido.AutoSize = true;
            this.lblRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecibido.Location = new System.Drawing.Point(25, 157);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Size = new System.Drawing.Size(45, 16);
            this.lblRecibido.TabIndex = 53;
            this.lblRecibido.Text = "label3";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(261, 362);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(35, 13);
            this.lblEstado.TabIndex = 52;
            this.lblEstado.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Copyright © 2019.  Derechos reservados";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 362);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Datos Recibidos";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(13, 50);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
            this.lblBaudRate.TabIndex = 47;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // txtRecibirDatos
            // 
            this.txtRecibirDatos.Location = new System.Drawing.Point(25, 216);
            this.txtRecibirDatos.MaxLength = 999999999;
            this.txtRecibirDatos.Multiline = true;
            this.txtRecibirDatos.Name = "txtRecibirDatos";
            this.txtRecibirDatos.Size = new System.Drawing.Size(432, 85);
            this.txtRecibirDatos.TabIndex = 46;
            // 
            // txtEnviarDatos
            // 
            this.txtEnviarDatos.Location = new System.Drawing.Point(16, 69);
            this.txtEnviarDatos.MaxLength = 999999999;
            this.txtEnviarDatos.Multiline = true;
            this.txtEnviarDatos.Name = "txtEnviarDatos";
            this.txtEnviarDatos.Size = new System.Drawing.Size(432, 78);
            this.txtEnviarDatos.TabIndex = 45;
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
            this.cboBaudRate.Location = new System.Drawing.Point(267, 42);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(181, 21);
            this.cboBaudRate.TabIndex = 44;
            this.cboBaudRate.Text = "9600";
            // 
            // cboPuerto
            // 
            this.cboPuerto.FormattingEnabled = true;
            this.cboPuerto.Location = new System.Drawing.Point(267, 15);
            this.cboPuerto.Name = "cboPuerto";
            this.cboPuerto.Size = new System.Drawing.Size(181, 21);
            this.cboPuerto.TabIndex = 43;
            // 
            // btnEnviarDato
            // 
            this.btnEnviarDato.Location = new System.Drawing.Point(357, 157);
            this.btnEnviarDato.Name = "btnEnviarDato";
            this.btnEnviarDato.Size = new System.Drawing.Size(86, 29);
            this.btnEnviarDato.TabIndex = 42;
            this.btnEnviarDato.Text = "Enviar Datos";
            this.btnEnviarDato.UseVisualStyleBackColor = true;
            this.btnEnviarDato.Click += new System.EventHandler(this.btnEnviarDato_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(126, 13);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(127, 23);
            this.btnConectar.TabIndex = 41;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnBuscarPuerto
            // 
            this.btnBuscarPuerto.Location = new System.Drawing.Point(16, 13);
            this.btnBuscarPuerto.Name = "btnBuscarPuerto";
            this.btnBuscarPuerto.Size = new System.Drawing.Size(104, 23);
            this.btnBuscarPuerto.TabIndex = 40;
            this.btnBuscarPuerto.Text = "Buscar Puerto";
            this.btnBuscarPuerto.UseVisualStyleBackColor = true;
            // 
            // spPuertos
            // 
            this.spPuertos.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.DatoRecibido);
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(195, 157);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(75, 23);
            this.btnVer.TabIndex = 54;
            this.btnVer.Text = "ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // txtinfo
            // 
            this.txtinfo.Location = new System.Drawing.Point(25, 315);
            this.txtinfo.Multiline = true;
            this.txtinfo.Name = "txtinfo";
            this.txtinfo.Size = new System.Drawing.Size(426, 41);
            this.txtinfo.TabIndex = 55;
            // 
            // btnTimer
            // 
            this.btnTimer.Location = new System.Drawing.Point(449, 160);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(13, 23);
            this.btnTimer.TabIndex = 56;
            this.btnTimer.Text = "D";
            this.btnTimer.UseVisualStyleBackColor = true;
            this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 57;
            this.button2.Text = " checksum";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmModenaEnvRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 425);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTimer);
            this.Controls.Add(this.txtinfo);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.lblRecibido);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.txtRecibirDatos);
            this.Controls.Add(this.txtEnviarDatos);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.cboPuerto);
            this.Controls.Add(this.btnEnviarDato);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.btnBuscarPuerto);
            this.Name = "FrmModenaEnvRec";
            this.Text = "FrmModenaEnvRec";
            this.Load += new System.EventHandler(this.FrmModenaEnvRec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecibido;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.TextBox txtinfo;
        private System.Windows.Forms.Button btnTimer;
        private System.Windows.Forms.Button button2;
    }
}