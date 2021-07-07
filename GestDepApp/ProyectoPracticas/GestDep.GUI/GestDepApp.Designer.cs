namespace GestDep.GUI
{
    partial class GestDepApp
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
            this.nombre_tb = new System.Windows.Forms.TextBox();
            this.apellidos_tb = new System.Windows.Forms.TextBox();
            this.dni_tb = new System.Windows.Forms.TextBox();
            this.cp_tb = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.Label();
            this.dni = new System.Windows.Forms.Label();
            this.cp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.IBAN_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.jubilado_c_b = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dir_tb = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Direccion = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nombre_tb
            // 
            this.nombre_tb.Location = new System.Drawing.Point(129, 36);
            this.nombre_tb.Name = "nombre_tb";
            this.nombre_tb.Size = new System.Drawing.Size(100, 20);
            this.nombre_tb.TabIndex = 0;
            this.nombre_tb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // apellidos_tb
            // 
            this.apellidos_tb.Location = new System.Drawing.Point(129, 79);
            this.apellidos_tb.Name = "apellidos_tb";
            this.apellidos_tb.Size = new System.Drawing.Size(101, 20);
            this.apellidos_tb.TabIndex = 1;
            this.apellidos_tb.TextChanged += new System.EventHandler(this.apellidos_tb_TextChanged);
            // 
            // dni_tb
            // 
            this.dni_tb.Location = new System.Drawing.Point(130, 121);
            this.dni_tb.Name = "dni_tb";
            this.dni_tb.Size = new System.Drawing.Size(100, 20);
            this.dni_tb.TabIndex = 2;
            this.dni_tb.TextChanged += new System.EventHandler(this.dni_tb_TextChanged);
            // 
            // cp_tb
            // 
            this.cp_tb.Location = new System.Drawing.Point(417, 36);
            this.cp_tb.Name = "cp_tb";
            this.cp_tb.Size = new System.Drawing.Size(61, 20);
            this.cp_tb.TabIndex = 3;
            this.cp_tb.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Location = new System.Drawing.Point(52, 39);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(44, 13);
            this.nombre.TabIndex = 4;
            this.nombre.Text = "Nombre";
            this.nombre.Click += new System.EventHandler(this.label1_Click);
            // 
            // apellido
            // 
            this.apellido.AutoSize = true;
            this.apellido.Location = new System.Drawing.Point(47, 82);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(49, 13);
            this.apellido.TabIndex = 5;
            this.apellido.Text = "Apellidos";
            // 
            // dni
            // 
            this.dni.AutoSize = true;
            this.dni.Location = new System.Drawing.Point(63, 124);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(26, 13);
            this.dni.TabIndex = 6;
            this.dni.Text = "DNI";
            // 
            // cp
            // 
            this.cp.AutoSize = true;
            this.cp.Location = new System.Drawing.Point(319, 39);
            this.cp.Name = "cp";
            this.cp.Size = new System.Drawing.Size(71, 13);
            this.cp.TabIndex = 7;
            this.cp.Text = "Código postal";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IBAN_tb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.jubilado_c_b);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dir_tb);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Direccion);
            this.panel1.Controls.Add(this.nombre_tb);
            this.panel1.Controls.Add(this.cp);
            this.panel1.Controls.Add(this.apellidos_tb);
            this.panel1.Controls.Add(this.dni);
            this.panel1.Controls.Add(this.dni_tb);
            this.panel1.Controls.Add(this.apellido);
            this.panel1.Controls.Add(this.cp_tb);
            this.panel1.Controls.Add(this.nombre);
            this.panel1.Location = new System.Drawing.Point(42, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 302);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // IBAN_tb
            // 
            this.IBAN_tb.Location = new System.Drawing.Point(129, 217);
            this.IBAN_tb.Name = "IBAN_tb";
            this.IBAN_tb.Size = new System.Drawing.Size(125, 20);
            this.IBAN_tb.TabIndex = 16;
            this.IBAN_tb.TextChanged += new System.EventHandler(this.IBAN_tb_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "IBAN";
            // 
            // jubilado_c_b
            // 
            this.jubilado_c_b.AutoSize = true;
            this.jubilado_c_b.Location = new System.Drawing.Point(130, 258);
            this.jubilado_c_b.Name = "jubilado_c_b";
            this.jubilado_c_b.Size = new System.Drawing.Size(15, 14);
            this.jubilado_c_b.TabIndex = 14;
            this.jubilado_c_b.UseVisualStyleBackColor = true;
            this.jubilado_c_b.CheckedChanged += new System.EventHandler(this.jubilado_c_b_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Jubilado";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dir_tb
            // 
            this.dir_tb.Location = new System.Drawing.Point(417, 82);
            this.dir_tb.Name = "dir_tb";
            this.dir_tb.Size = new System.Drawing.Size(157, 39);
            this.dir_tb.TabIndex = 12;
            this.dir_tb.Text = "";
            this.dir_tb.TextChanged += new System.EventHandler(this.dir_tb_TextChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(129, 167);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 11;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fecha de \r\nNacimiento";
            // 
            // Direccion
            // 
            this.Direccion.AutoSize = true;
            this.Direccion.Location = new System.Drawing.Point(338, 82);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(52, 13);
            this.Direccion.TabIndex = 8;
            this.Direccion.Text = "Dirección";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(544, 400);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 9;
            this.confirmButton.Text = "Confirmar";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirm_click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(42, 26);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(34, 23);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "<-";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(230, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "Añadir Usuario";
            // 
            // GestDepApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 465);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GestDepApp";
            this.Text = "GestDepApp";
            this.Load += new System.EventHandler(this.GestDepApp_Load);
            this.Click += new System.EventHandler(this.exitButton_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombre_tb;
        private System.Windows.Forms.TextBox apellidos_tb;
        private System.Windows.Forms.TextBox cp_tb;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.Label apellido;
        private System.Windows.Forms.Label dni;
        private System.Windows.Forms.Label cp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label Direccion;
        private System.Windows.Forms.RichTextBox dir_tb;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IBAN_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox jubilado_c_b;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox dni_tb;
    }
}