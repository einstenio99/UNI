using System;

namespace GestDep.GUI
{
    partial class AnyadirActividad
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
            this.atras = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.horafin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.horainicio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.añadir = new System.Windows.Forms.Button();
            this.dayBox = new System.Windows.Forms.ListBox();
            this.precio = new System.Windows.Forms.TextBox();
            this.min0 = new System.Windows.Forms.TextBox();
            this.max1 = new System.Windows.Forms.TextBox();
            this.salas = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(328, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 58);
            this.label1.TabIndex = 4;
            this.label1.Text = "Añadir actividad";
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(16, 15);
            this.atras.Margin = new System.Windows.Forms.Padding(4);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(33, 28);
            this.atras.TabIndex = 5;
            this.atras.Text = "<-";
            this.atras.UseVisualStyleBackColor = true;
            this.atras.Click += new System.EventHandler(this.atras_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(197, 140);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(197, 191);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker2.TabIndex = 11;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Fecha Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha Fin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 322);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Dias de la Semana";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 283);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Duracion";
            // 
            // horafin
            // 
            this.horafin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.horafin.Location = new System.Drawing.Point(197, 278);
            this.horafin.Margin = new System.Windows.Forms.Padding(4);
            this.horafin.Name = "horafin";
            this.horafin.Size = new System.Drawing.Size(132, 22);
            this.horafin.TabIndex = 16;
            this.horafin.TextChanged += new System.EventHandler(this.horafin_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Hora Inicio";
            // 
            // horainicio
            // 
            this.horainicio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.horainicio.Location = new System.Drawing.Point(197, 236);
            this.horainicio.Margin = new System.Windows.Forms.Padding(4);
            this.horainicio.Name = "horainicio";
            this.horainicio.Size = new System.Drawing.Size(132, 22);
            this.horainicio.TabIndex = 18;
            this.horainicio.TextChanged += new System.EventHandler(this.hora_inicio);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(576, 140);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Asistentes Minimos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(573, 181);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Asistentes Maximos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(621, 263);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Descripcion";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(712, 263);
            this.descripcion.Margin = new System.Windows.Forms.Padding(4);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(245, 125);
            this.descripcion.TabIndex = 25;
            this.descripcion.Text = "";
            this.descripcion.TextChanged += new System.EventHandler(this.descripcion_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(656, 222);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Precio";
            // 
            // añadir
            // 
            this.añadir.Location = new System.Drawing.Point(712, 411);
            this.añadir.Margin = new System.Windows.Forms.Padding(4);
            this.añadir.Name = "añadir";
            this.añadir.Size = new System.Drawing.Size(100, 28);
            this.añadir.TabIndex = 28;
            this.añadir.Text = "Añadir";
            this.añadir.UseVisualStyleBackColor = true;
            this.añadir.Click += new System.EventHandler(this.añadir_Click);
            // 
            // dayBox
            // 
            this.dayBox.FormattingEnabled = true;
            this.dayBox.ItemHeight = 16;
            this.dayBox.Items.AddRange(new object[] {
            "   Lunes",
            "   Martes",
            "   Miercoles",
            "   Jueves ",
            "   Viernes",
            "   Sábado",
            "   Domingo"});
            this.dayBox.Location = new System.Drawing.Point(197, 322);
            this.dayBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dayBox.Name = "dayBox";
            this.dayBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.dayBox.Size = new System.Drawing.Size(105, 116);
            this.dayBox.TabIndex = 29;
            this.dayBox.SelectedIndexChanged += new System.EventHandler(this.dayBox_Pick);
            // 
            // precio
            // 
            this.precio.Location = new System.Drawing.Point(715, 217);
            this.precio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(132, 22);
            this.precio.TabIndex = 30;
            this.precio.TextChanged += new System.EventHandler(this.precio_click);
            // 
            // min0
            // 
            this.min0.Location = new System.Drawing.Point(715, 137);
            this.min0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.min0.Name = "min0";
            this.min0.Size = new System.Drawing.Size(132, 22);
            this.min0.TabIndex = 31;
            this.min0.TextChanged += new System.EventHandler(this.asistentesminimos_click);
            // 
            // max1
            // 
            this.max1.Location = new System.Drawing.Point(715, 178);
            this.max1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.max1.Name = "max1";
            this.max1.Size = new System.Drawing.Size(132, 22);
            this.max1.TabIndex = 32;
            this.max1.TextChanged += new System.EventHandler(this.asistentesmaximos_click);
            // 
            // salas
            // 
            this.salas.FormattingEnabled = true;
            this.salas.ItemHeight = 16;
            this.salas.Location = new System.Drawing.Point(359, 322);
            this.salas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.salas.Name = "salas";
            this.salas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.salas.Size = new System.Drawing.Size(103, 116);
            this.salas.TabIndex = 33;
            this.salas.SelectedIndexChanged += new System.EventHandler(this.salas_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(309, 322);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Salas";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(337, 241);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "(ej. 12:00)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(337, 283);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 17);
            this.label13.TabIndex = 36;
            this.label13.Text = "(ej. 01:00)";
            // 
            // AnyadirActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 567);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.salas);
            this.Controls.Add(this.max1);
            this.Controls.Add(this.min0);
            this.Controls.Add(this.precio);
            this.Controls.Add(this.dayBox);
            this.Controls.Add(this.añadir);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.horainicio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.horafin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AnyadirActividad";
            this.Text = "GestDepApp";
            this.Load += new System.EventHandler(this.AnyadirActividad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox horafin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox horainicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox descripcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button añadir;
        private System.Windows.Forms.ListBox dayBox;
        private System.Windows.Forms.TextBox precio;
        private System.Windows.Forms.TextBox min0;
        private System.Windows.Forms.TextBox max1;
        private System.Windows.Forms.ListBox salas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}