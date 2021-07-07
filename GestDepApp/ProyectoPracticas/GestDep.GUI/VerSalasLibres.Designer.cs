
namespace GestDep.GUI
{
    partial class VerSalasLibres
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Martes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Miercoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jueves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Viernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sábado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.atras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Horas,
            this.Lunes,
            this.Martes,
            this.Miercoles,
            this.Jueves,
            this.Viernes,
            this.Sábado});
            this.dataGridView1.Location = new System.Drawing.Point(31, 64);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1139, 420);
            this.dataGridView1.TabIndex = 0;
            // 
            // Horas
            // 
            this.Horas.HeaderText = "Horas";
            this.Horas.MinimumWidth = 6;
            this.Horas.Name = "Horas";
            this.Horas.ReadOnly = true;
            this.Horas.Width = 125;
            // 
            // Lunes
            // 
            this.Lunes.HeaderText = "Lunes";
            this.Lunes.MinimumWidth = 6;
            this.Lunes.Name = "Lunes";
            this.Lunes.ReadOnly = true;
            this.Lunes.Width = 125;
            // 
            // Martes
            // 
            this.Martes.HeaderText = "Martes";
            this.Martes.MinimumWidth = 6;
            this.Martes.Name = "Martes";
            this.Martes.ReadOnly = true;
            this.Martes.Width = 125;
            // 
            // Miercoles
            // 
            this.Miercoles.HeaderText = "Miercoles";
            this.Miercoles.MinimumWidth = 6;
            this.Miercoles.Name = "Miercoles";
            this.Miercoles.ReadOnly = true;
            this.Miercoles.Width = 125;
            // 
            // Jueves
            // 
            this.Jueves.HeaderText = "Jueves";
            this.Jueves.MinimumWidth = 6;
            this.Jueves.Name = "Jueves";
            this.Jueves.ReadOnly = true;
            this.Jueves.Width = 125;
            // 
            // Viernes
            // 
            this.Viernes.HeaderText = "Viernes";
            this.Viernes.MinimumWidth = 6;
            this.Viernes.Name = "Viernes";
            this.Viernes.ReadOnly = true;
            this.Viernes.Width = 125;
            // 
            // Sábado
            // 
            this.Sábado.HeaderText = "Sábado";
            this.Sábado.MinimumWidth = 6;
            this.Sábado.Name = "Sábado";
            this.Sábado.ReadOnly = true;
            this.Sábado.Width = 125;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(183, 16);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(31, 16);
            this.atras.Margin = new System.Windows.Forms.Padding(4);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(33, 28);
            this.atras.TabIndex = 6;
            this.atras.Text = "<-";
            this.atras.UseVisualStyleBackColor = true;
            this.atras.Click += new System.EventHandler(this.back_Click);
            // 
            // VerSalasLibres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 554);
            this.Controls.Add(this.atras);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "VerSalasLibres";
            this.Text = "GestDepApp";
            this.Load += new System.EventHandler(this.VerSalasLibres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lunes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Martes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Miercoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jueves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Viernes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sábado;
        private System.Windows.Forms.Button atras;
    }
}