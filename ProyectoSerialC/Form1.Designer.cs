namespace ProyectoSerialC
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnBuscarPuerto = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnEnviarDato = new System.Windows.Forms.Button();
            this.cboPuerto = new System.Windows.Forms.ComboBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.txtEnviarDatos = new System.Windows.Forms.TextBox();
            this.txtRecibirDatos = new System.Windows.Forms.TextBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.spPuertos = new System.IO.Ports.SerialPort(this.components);
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuscarPuerto
            // 
            this.btnBuscarPuerto.Location = new System.Drawing.Point(32, 38);
            this.btnBuscarPuerto.Name = "btnBuscarPuerto";
            this.btnBuscarPuerto.Size = new System.Drawing.Size(204, 23);
            this.btnBuscarPuerto.TabIndex = 0;
            this.btnBuscarPuerto.Text = "Buscar Puerto";
            this.btnBuscarPuerto.UseVisualStyleBackColor = true;
            this.btnBuscarPuerto.Click += new System.EventHandler(this.btnBuscarPuerto_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(508, 38);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(204, 23);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnEnviarDato
            // 
            this.btnEnviarDato.Location = new System.Drawing.Point(32, 174);
            this.btnEnviarDato.Name = "btnEnviarDato";
            this.btnEnviarDato.Size = new System.Drawing.Size(204, 23);
            this.btnEnviarDato.TabIndex = 2;
            this.btnEnviarDato.Text = "Enviar Datos";
            this.btnEnviarDato.UseVisualStyleBackColor = true;
            this.btnEnviarDato.Click += new System.EventHandler(this.btnEnviarDato_Click);
            // 
            // cboPuerto
            // 
            this.cboPuerto.FormattingEnabled = true;
            this.cboPuerto.Location = new System.Drawing.Point(280, 40);
            this.cboPuerto.Name = "cboPuerto";
            this.cboPuerto.Size = new System.Drawing.Size(190, 21);
            this.cboPuerto.TabIndex = 3;
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
            this.cboBaudRate.Location = new System.Drawing.Point(280, 101);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(190, 21);
            this.cboBaudRate.TabIndex = 4;
            this.cboBaudRate.Text = "9600";
            // 
            // txtEnviarDatos
            // 
            this.txtEnviarDatos.Location = new System.Drawing.Point(280, 176);
            this.txtEnviarDatos.MaxLength = 999999999;
            this.txtEnviarDatos.Multiline = true;
            this.txtEnviarDatos.Name = "txtEnviarDatos";
            this.txtEnviarDatos.Size = new System.Drawing.Size(432, 97);
            this.txtEnviarDatos.TabIndex = 5;
            // 
            // txtRecibirDatos
            // 
            this.txtRecibirDatos.Location = new System.Drawing.Point(280, 292);
            this.txtRecibirDatos.Multiline = true;
            this.txtRecibirDatos.Name = "txtRecibirDatos";
            this.txtRecibirDatos.Size = new System.Drawing.Size(432, 103);
            this.txtRecibirDatos.TabIndex = 6;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(38, 109);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
            this.lblBaudRate.TabIndex = 7;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Datos Recibidos";
            // 
            // spPuertos
            // 
            this.spPuertos.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.DatoRecibido);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(637, 468);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 539);
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
            this.Name = "Form1";
            this.Text = "Interfaz Modena";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarPuerto;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnEnviarDato;
        private System.Windows.Forms.ComboBox cboPuerto;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.TextBox txtEnviarDatos;
        private System.Windows.Forms.TextBox txtRecibirDatos;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort spPuertos;
        private System.Windows.Forms.Button btnGuardar;
    }
}

