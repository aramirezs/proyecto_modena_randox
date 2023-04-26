namespace ProyectoSerialC.forms
{
    partial class frm_Modena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Modena));
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblRecibido = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listRec = new System.Windows.Forms.ListBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Datos Recibidos";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(14, 50);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
            this.lblBaudRate.TabIndex = 27;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // txtRecibirDatos
            // 
            this.txtRecibirDatos.Location = new System.Drawing.Point(26, 216);
            this.txtRecibirDatos.MaxLength = 999999999;
            this.txtRecibirDatos.Multiline = true;
            this.txtRecibirDatos.Name = "txtRecibirDatos";
            this.txtRecibirDatos.Size = new System.Drawing.Size(432, 123);
            this.txtRecibirDatos.TabIndex = 26;
            // 
            // txtEnviarDatos
            // 
            this.txtEnviarDatos.Location = new System.Drawing.Point(17, 69);
            this.txtEnviarDatos.MaxLength = 999999999;
            this.txtEnviarDatos.Multiline = true;
            this.txtEnviarDatos.Name = "txtEnviarDatos";
            this.txtEnviarDatos.Size = new System.Drawing.Size(432, 78);
            this.txtEnviarDatos.TabIndex = 25;
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
            this.cboBaudRate.Location = new System.Drawing.Point(268, 42);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(181, 21);
            this.cboBaudRate.TabIndex = 24;
            this.cboBaudRate.Text = "9600";
            // 
            // cboPuerto
            // 
            this.cboPuerto.FormattingEnabled = true;
            this.cboPuerto.Location = new System.Drawing.Point(268, 15);
            this.cboPuerto.Name = "cboPuerto";
            this.cboPuerto.Size = new System.Drawing.Size(181, 21);
            this.cboPuerto.TabIndex = 23;
            // 
            // btnEnviarDato
            // 
            this.btnEnviarDato.Location = new System.Drawing.Point(352, 157);
            this.btnEnviarDato.Name = "btnEnviarDato";
            this.btnEnviarDato.Size = new System.Drawing.Size(86, 29);
            this.btnEnviarDato.TabIndex = 22;
            this.btnEnviarDato.Text = "Enviar Datos";
            this.btnEnviarDato.UseVisualStyleBackColor = true;
            this.btnEnviarDato.Click += new System.EventHandler(this.btnEnviarDato_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(127, 13);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(127, 23);
            this.btnConectar.TabIndex = 21;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnBuscarPuerto
            // 
            this.btnBuscarPuerto.Location = new System.Drawing.Point(17, 13);
            this.btnBuscarPuerto.Name = "btnBuscarPuerto";
            this.btnBuscarPuerto.Size = new System.Drawing.Size(104, 23);
            this.btnBuscarPuerto.TabIndex = 20;
            this.btnBuscarPuerto.Text = "Buscar Puerto";
            this.btnBuscarPuerto.UseVisualStyleBackColor = true;
            this.btnBuscarPuerto.Click += new System.EventHandler(this.btnBuscarPuerto_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(491, 15);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(11, 251);
            this.listBox1.TabIndex = 34;
            this.listBox1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 362);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Copyright © 2019.  Derechos reservados";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(262, 362);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(35, 13);
            this.lblEstado.TabIndex = 38;
            this.lblEstado.Text = "label3";
            // 
            // lblRecibido
            // 
            this.lblRecibido.AutoSize = true;
            this.lblRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecibido.Location = new System.Drawing.Point(26, 157);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Size = new System.Drawing.Size(45, 16);
            this.lblRecibido.TabIndex = 39;
            this.lblRecibido.Text = "label3";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 23);
            this.button2.TabIndex = 40;
            this.button2.Text = "D";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // listRec
            // 
            this.listRec.FormattingEnabled = true;
            this.listRec.Location = new System.Drawing.Point(491, 15);
            this.listRec.Name = "listRec";
            this.listRec.Size = new System.Drawing.Size(533, 381);
            this.listRec.TabIndex = 41;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(179, 160);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 24);
            this.btnLimpiar.TabIndex = 42;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frm_Modena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1058, 475);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.listRec);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblRecibido);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Modena";
            this.Text = "SUIZA SOFT >> MODENA";
            this.Load += new System.EventHandler(this.frm_Modena_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblRecibido;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listRec;
        private System.Windows.Forms.Button btnLimpiar;
    }
}