namespace ProyectoSerialModena.forms
{
    partial class FrmSerialAscii
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtRecibidos = new System.Windows.Forms.TextBox();
            this.listRec = new System.Windows.Forms.ListBox();
            this.richTextBox_Mensajes = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRecibidos
            // 
            this.txtRecibidos.Location = new System.Drawing.Point(28, 30);
            this.txtRecibidos.Multiline = true;
            this.txtRecibidos.Name = "txtRecibidos";
            this.txtRecibidos.Size = new System.Drawing.Size(237, 116);
            this.txtRecibidos.TabIndex = 1;
            // 
            // listRec
            // 
            this.listRec.FormattingEnabled = true;
            this.listRec.Location = new System.Drawing.Point(28, 152);
            this.listRec.Name = "listRec";
            this.listRec.Size = new System.Drawing.Size(542, 290);
            this.listRec.TabIndex = 2;
            // 
            // richTextBox_Mensajes
            // 
            this.richTextBox_Mensajes.Location = new System.Drawing.Point(307, 30);
            this.richTextBox_Mensajes.Multiline = true;
            this.richTextBox_Mensajes.Name = "richTextBox_Mensajes";
            this.richTextBox_Mensajes.Size = new System.Drawing.Size(155, 39);
            this.richTextBox_Mensajes.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(515, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "chechSum";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmSerialAscii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 477);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listRec);
            this.Controls.Add(this.txtRecibidos);
            this.Controls.Add(this.richTextBox_Mensajes);
            this.Name = "FrmSerialAscii";
            this.Text = "FrmSerialAscii";
            this.Load += new System.EventHandler(this.FrmSerialAscii_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtRecibidos;
        private System.Windows.Forms.ListBox listRec;
        private System.Windows.Forms.TextBox richTextBox_Mensajes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}