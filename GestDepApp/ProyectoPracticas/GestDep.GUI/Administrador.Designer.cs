namespace GestDep.GUI
{
    partial class Administrador
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
            this.addact = new System.Windows.Forms.Button();
            this.addmonitor = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addact
            // 
            this.addact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.addact.Location = new System.Drawing.Point(0, 0);
            this.addact.Name = "addact";
            this.addact.Size = new System.Drawing.Size(244, 50);
            this.addact.TabIndex = 0;
            this.addact.Text = "Añadir actividad";
            this.addact.UseVisualStyleBackColor = true;
            this.addact.Click += new System.EventHandler(this.addact_Click);
            // 
            // addmonitor
            // 
            this.addmonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.addmonitor.Location = new System.Drawing.Point(0, 98);
            this.addmonitor.Name = "addmonitor";
            this.addmonitor.Size = new System.Drawing.Size(244, 50);
            this.addmonitor.TabIndex = 1;
            this.addmonitor.Text = "Añadir monitor";
            this.addmonitor.UseVisualStyleBackColor = true;
            this.addmonitor.Click += new System.EventHandler(this.addmonitor_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "<-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.atras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(264, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Administrador";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addact);
            this.panel1.Controls.Add(this.addmonitor);
            this.panel1.Location = new System.Drawing.Point(272, 137);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 150);
            this.panel1.TabIndex = 4;
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Administrador";
            this.Text = "GestDepApp";
            this.Load += new System.EventHandler(this.Administrador_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addact;
        private System.Windows.Forms.Button addmonitor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}