namespace GestDep.GUI
{
    partial class PantallaDeInicio
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
            this.empeadoButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.empeadoButton);
            this.panel1.Controls.Add(this.adminButton);
            this.panel1.Location = new System.Drawing.Point(300, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 150);
            this.panel1.TabIndex = 0;
            // 
            // empeadoButton
            // 
            this.empeadoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.empeadoButton.Location = new System.Drawing.Point(0, 100);
            this.empeadoButton.Name = "empeadoButton";
            this.empeadoButton.Size = new System.Drawing.Size(200, 50);
            this.empeadoButton.TabIndex = 1;
            this.empeadoButton.Text = "Empleado";
            this.empeadoButton.UseVisualStyleBackColor = true;
            this.empeadoButton.Click += new System.EventHandler(this.Empleado_Click);
            // 
            // adminButton
            // 
            this.adminButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.adminButton.Location = new System.Drawing.Point(0, 0);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(200, 50);
            this.adminButton.TabIndex = 0;
            this.adminButton.Text = "Administrador";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.Admin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Playbill", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "GestDepApp";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(671, 397);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Salir";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.Exit_Click);
            // 
            // PantallaDeInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PantallaDeInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestDepApp";
            this.Load += new System.EventHandler(this.PantallaDeInicio_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button empeadoButton;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitButton;
    }
}