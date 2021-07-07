namespace GestDep.GUI
{
    partial class Empleado
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.freerooms = new System.Windows.Forms.Button();
            this.adduser = new System.Windows.Forms.Button();
            this.adduseractivity = new System.Windows.Forms.Button();
            this.menuempleado = new System.Windows.Forms.Label();
            this.backbutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.freerooms);
            this.panel1.Controls.Add(this.adduser);
            this.panel1.Controls.Add(this.adduseractivity);
            this.panel1.Location = new System.Drawing.Point(267, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 206);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // freerooms
            // 
            this.freerooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.freerooms.Location = new System.Drawing.Point(0, 158);
            this.freerooms.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.freerooms.Name = "freerooms";
            this.freerooms.Size = new System.Drawing.Size(248, 46);
            this.freerooms.TabIndex = 2;
            this.freerooms.Text = "Ver salas libres";
            this.freerooms.UseVisualStyleBackColor = true;
            this.freerooms.Click += new System.EventHandler(this.button3_Click);
            // 
            // adduser
            // 
            this.adduser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.adduser.Location = new System.Drawing.Point(-1, 80);
            this.adduser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.adduser.Name = "adduser";
            this.adduser.Size = new System.Drawing.Size(249, 46);
            this.adduser.TabIndex = 1;
            this.adduser.Text = "Añadir usuario";
            this.adduser.UseVisualStyleBackColor = true;
            this.adduser.Click += new System.EventHandler(this.button2_Click);
            // 
            // adduseractivity
            // 
            this.adduseractivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.adduseractivity.Location = new System.Drawing.Point(-1, 0);
            this.adduseractivity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.adduseractivity.Name = "adduseractivity";
            this.adduseractivity.Size = new System.Drawing.Size(249, 46);
            this.adduseractivity.TabIndex = 0;
            this.adduseractivity.Text = "Inscribir usuario a actividad";
            this.adduseractivity.UseVisualStyleBackColor = true;
            this.adduseractivity.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuempleado
            // 
            this.menuempleado.AutoSize = true;
            this.menuempleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.menuempleado.Location = new System.Drawing.Point(262, 25);
            this.menuempleado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.menuempleado.Name = "menuempleado";
            this.menuempleado.Size = new System.Drawing.Size(268, 36);
            this.menuempleado.TabIndex = 1;
            this.menuempleado.Text = "Menú de empleado";
            this.menuempleado.Click += new System.EventHandler(this.label1_Click);
            // 
            // backbutton
            // 
            this.backbutton.Location = new System.Drawing.Point(12, 12);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(31, 23);
            this.backbutton.TabIndex = 2;
            this.backbutton.Text = "<-";
            this.backbutton.UseVisualStyleBackColor = true;
            this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
            // 
            // Empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.backbutton);
            this.Controls.Add(this.menuempleado);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Empleado";
            this.Text = "GestDepApp";
            this.Load += new System.EventHandler(this.Empleado_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label menuempleado;
        private System.Windows.Forms.Button freerooms;
        private System.Windows.Forms.Button adduser;
        private System.Windows.Forms.Button adduseractivity;
        private System.Windows.Forms.Button backbutton;
    }
}