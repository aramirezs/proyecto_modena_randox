namespace ProyectoSerialC_Recibir.forms
{
    partial class ProyectoSerialC_Recibir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProyectoSerialC_Recibir));
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
            this.btnVer = new System.Windows.Forms.Button();
            this.txtRecibir2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtinfo = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecibido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Datos Recibidos";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(13, 44);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
            this.lblBaudRate.TabIndex = 36;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // txtRecibirDatos
            // 
            this.txtRecibirDatos.Location = new System.Drawing.Point(16, 206);
            this.txtRecibirDatos.MaxLength = 999999999;
            this.txtRecibirDatos.Multiline = true;
            this.txtRecibirDatos.Name = "txtRecibirDatos";
            this.txtRecibirDatos.Size = new System.Drawing.Size(432, 126);
            this.txtRecibirDatos.TabIndex = 35;
            // 
            // txtEnviarDatos
            // 
            this.txtEnviarDatos.Location = new System.Drawing.Point(16, 68);
            this.txtEnviarDatos.MaxLength = 999999999;
            this.txtEnviarDatos.Multiline = true;
            this.txtEnviarDatos.Name = "txtEnviarDatos";
            this.txtEnviarDatos.Size = new System.Drawing.Size(432, 97);
            this.txtEnviarDatos.TabIndex = 34;
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
            this.cboBaudRate.Location = new System.Drawing.Point(268, 41);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(180, 21);
            this.cboBaudRate.TabIndex = 33;
            this.cboBaudRate.Text = "9600";
            // 
            // cboPuerto
            // 
            this.cboPuerto.FormattingEnabled = true;
            this.cboPuerto.Location = new System.Drawing.Point(268, 12);
            this.cboPuerto.Name = "cboPuerto";
            this.cboPuerto.Size = new System.Drawing.Size(180, 21);
            this.cboPuerto.TabIndex = 32;
            // 
            // btnEnviarDato
            // 
            this.btnEnviarDato.Location = new System.Drawing.Point(344, 171);
            this.btnEnviarDato.Name = "btnEnviarDato";
            this.btnEnviarDato.Size = new System.Drawing.Size(104, 29);
            this.btnEnviarDato.TabIndex = 31;
            this.btnEnviarDato.Text = "Enviar Datos";
            this.btnEnviarDato.UseVisualStyleBackColor = true;
            this.btnEnviarDato.Click += new System.EventHandler(this.btnEnviarDato_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(126, 10);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(127, 23);
            this.btnConectar.TabIndex = 30;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnBuscarPuerto
            // 
            this.btnBuscarPuerto.Location = new System.Drawing.Point(16, 10);
            this.btnBuscarPuerto.Name = "btnBuscarPuerto";
            this.btnBuscarPuerto.Size = new System.Drawing.Size(104, 23);
            this.btnBuscarPuerto.TabIndex = 29;
            this.btnBuscarPuerto.Text = "Buscar Puerto";
            this.btnBuscarPuerto.UseVisualStyleBackColor = true;
            this.btnBuscarPuerto.Click += new System.EventHandler(this.btnBuscarPuerto_Click);
            // 
            // spPuertos
            // 
            this.spPuertos.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.DatoRecibido);
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(178, 177);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(75, 23);
            this.btnVer.TabIndex = 38;
            this.btnVer.Text = "ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // txtRecibir2
            // 
            this.txtRecibir2.Location = new System.Drawing.Point(466, 12);
            this.txtRecibir2.MaxLength = 999999999;
            this.txtRecibir2.Multiline = true;
            this.txtRecibir2.Name = "txtRecibir2";
            this.txtRecibir2.Size = new System.Drawing.Size(82, 336);
            this.txtRecibir2.TabIndex = 39;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 385);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // txtinfo
            // 
            this.txtinfo.Location = new System.Drawing.Point(16, 339);
            this.txtinfo.Multiline = true;
            this.txtinfo.Name = "txtinfo";
            this.txtinfo.Size = new System.Drawing.Size(426, 41);
            this.txtinfo.TabIndex = 41;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(246, 402);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(35, 13);
            this.lblEstado.TabIndex = 43;
            this.lblEstado.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Copyright © 2019.  Derechos reservados";
            // 
            // lblRecibido
            // 
            this.lblRecibido.AutoSize = true;
            this.lblRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecibido.Location = new System.Drawing.Point(13, 168);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Size = new System.Drawing.Size(45, 16);
            this.lblRecibido.TabIndex = 44;
            this.lblRecibido.Text = "label3";
            // 
            // ProyectoSerialC_Recibir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 443);
            this.Controls.Add(this.lblRecibido);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtinfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtRecibir2);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.txtRecibirDatos);
            this.Controls.Add(this.txtEnviarDatos);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.cboPuerto);
            this.Controls.Add(this.btnEnviarDato);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.btnBuscarPuerto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProyectoSerialC_Recibir";
            this.Text = "MODENA >> SUIZA RESULT";
            this.Load += new System.EventHandler(this.ProyectoSerialC_Recibir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.TextBox txtRecibir2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtinfo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecibido;
    }
}