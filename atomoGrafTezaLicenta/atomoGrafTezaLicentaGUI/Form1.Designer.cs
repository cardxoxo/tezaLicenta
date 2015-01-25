namespace atomoGrafTezaLicentaGUI
{
    partial class Form1
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
            this.genereazaButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listaAtomi = new System.Windows.Forms.TextBox();
            this.C = new System.Windows.Forms.Button();
            this.O = new System.Windows.Forms.Button();
            this.N = new System.Windows.Forms.Button();
            this.stergeUltima = new System.Windows.Forms.Button();
            this.curataTot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // genereazaButton
            // 
            this.genereazaButton.Location = new System.Drawing.Point(61, 192);
            this.genereazaButton.Name = "genereazaButton";
            this.genereazaButton.Size = new System.Drawing.Size(147, 23);
            this.genereazaButton.TabIndex = 0;
            this.genereazaButton.Text = "genereaza izomeri";
            this.genereazaButton.UseVisualStyleBackColor = true;
            this.genereazaButton.Click += new System.EventHandler(this.Genereaza_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Setati atomii:";
            // 
            // listaAtomi
            // 
            this.listaAtomi.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listaAtomi.Location = new System.Drawing.Point(27, 117);
            this.listaAtomi.Multiline = true;
            this.listaAtomi.Name = "listaAtomi";
            this.listaAtomi.ReadOnly = true;
            this.listaAtomi.Size = new System.Drawing.Size(215, 69);
            this.listaAtomi.TabIndex = 2;
            // 
            // C
            // 
            this.C.Location = new System.Drawing.Point(84, 54);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(31, 27);
            this.C.TabIndex = 3;
            this.C.Text = "C";
            this.C.UseVisualStyleBackColor = true;
            this.C.Click += new System.EventHandler(this.Carbon_Click);
            // 
            // O
            // 
            this.O.Location = new System.Drawing.Point(154, 54);
            this.O.Name = "O";
            this.O.Size = new System.Drawing.Size(31, 27);
            this.O.TabIndex = 4;
            this.O.Text = "O";
            this.O.UseVisualStyleBackColor = true;
            this.O.Click += new System.EventHandler(this.Oxigen_Click);
            // 
            // N
            // 
            this.N.Location = new System.Drawing.Point(121, 54);
            this.N.Name = "N";
            this.N.Size = new System.Drawing.Size(31, 27);
            this.N.TabIndex = 5;
            this.N.Text = "N";
            this.N.UseVisualStyleBackColor = true;
            this.N.Click += new System.EventHandler(this.Azot_Click);
            // 
            // stergeUltima
            // 
            this.stergeUltima.Location = new System.Drawing.Point(142, 87);
            this.stergeUltima.Name = "stergeUltima";
            this.stergeUltima.Size = new System.Drawing.Size(75, 23);
            this.stergeUltima.TabIndex = 6;
            this.stergeUltima.Text = "sterge ultima";
            this.stergeUltima.UseVisualStyleBackColor = true;
            this.stergeUltima.Click += new System.EventHandler(this.stergeUltima_Click);
            // 
            // curataTot
            // 
            this.curataTot.Location = new System.Drawing.Point(61, 87);
            this.curataTot.Name = "curataTot";
            this.curataTot.Size = new System.Drawing.Size(75, 23);
            this.curataTot.TabIndex = 7;
            this.curataTot.Text = "curata tot";
            this.curataTot.UseVisualStyleBackColor = true;
            this.curataTot.Click += new System.EventHandler(this.curataTot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 227);
            this.Controls.Add(this.curataTot);
            this.Controls.Add(this.stergeUltima);
            this.Controls.Add(this.N);
            this.Controls.Add(this.O);
            this.Controls.Add(this.C);
            this.Controls.Add(this.listaAtomi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genereazaButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button genereazaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox listaAtomi;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Button O;
        private System.Windows.Forms.Button N;
        private System.Windows.Forms.Button stergeUltima;
        private System.Windows.Forms.Button curataTot;
    }
}

