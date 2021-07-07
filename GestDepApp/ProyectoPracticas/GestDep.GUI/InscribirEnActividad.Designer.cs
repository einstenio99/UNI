namespace GestDep.GUI
{
    partial class InscribirEnActividad
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.atras = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buscar_button = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.actscb = new System.Windows.Forms.ComboBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.descrpag = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(202, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "Inscribir en actividad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 52);
            this.label2.TabIndex = 14;
            this.label2.Text = "Actividades \r\ndisponibles \r\npara esa fecha \r\nde Inscripcción.";
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(12, 12);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(25, 23);
            this.atras.TabIndex = 16;
            this.atras.Text = "<-";
            this.atras.UseVisualStyleBackColor = true;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "DNI";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 20);
            this.textBox1.TabIndex = 28;
            // 
            // buscar_button
            // 
            this.buscar_button.Location = new System.Drawing.Point(250, 240);
            this.buscar_button.Name = "buscar_button";
            this.buscar_button.Size = new System.Drawing.Size(75, 23);
            this.buscar_button.TabIndex = 29;
            this.buscar_button.Text = "Buscar";
            this.buscar_button.UseVisualStyleBackColor = true;
            this.buscar_button.Click += new System.EventHandler(this.buscar_click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(520, 100);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(253, 163);
            this.richTextBox1.TabIndex = 30;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Precio";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(520, 294);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 33;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(697, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Inscribir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // actscb
            // 
            this.actscb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actscb.FormattingEnabled = true;
            this.actscb.Location = new System.Drawing.Point(140, 193);
            this.actscb.Margin = new System.Windows.Forms.Padding(2);
            this.actscb.Name = "actscb";
            this.actscb.Size = new System.Drawing.Size(92, 21);
            this.actscb.TabIndex = 35;
            this.actscb.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(140, 146);
            this.fecha.Margin = new System.Windows.Forms.Padding(2);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(187, 20);
            this.fecha.TabIndex = 36;
            this.fecha.ValueChanged += new System.EventHandler(this.fecha_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 136);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 26);
            this.label6.TabIndex = 38;
            this.label6.Text = "Fecha de \r\nInscripcción";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 298);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Descripcción del Pago";
            // 
            // descrpag
            // 
            this.descrpag.Location = new System.Drawing.Point(140, 298);
            this.descrpag.Margin = new System.Windows.Forms.Padding(2);
            this.descrpag.Name = "descrpag";
            this.descrpag.Size = new System.Drawing.Size(187, 78);
            this.descrpag.TabIndex = 42;
            this.descrpag.Text = "";
            // 
            // InscribirEnActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.descrpag);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.actscb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buscar_button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InscribirEnActividad";
            this.Text = "GestDepApp";
            this.Load += new System.EventHandler(this.InscribirEnActividad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buscar_button;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox actscb;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox descrpag;
    }
}