namespace ArduinoUI
{
    partial class ArduinoActions
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
            this.btnLigarLed = new System.Windows.Forms.Button();
            this.btnDesligarLed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(66, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ARDUINO ACTIONS";
            // 
            // btnLigarLed
            // 
            this.btnLigarLed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLigarLed.Location = new System.Drawing.Point(32, 122);
            this.btnLigarLed.Name = "btnLigarLed";
            this.btnLigarLed.Size = new System.Drawing.Size(152, 48);
            this.btnLigarLed.TabIndex = 1;
            this.btnLigarLed.Text = "Ligar LED";
            this.btnLigarLed.UseVisualStyleBackColor = true;
            this.btnLigarLed.Click += new System.EventHandler(this.btnLigarLed_ClickAsync);
            // 
            // btnDesligarLed
            // 
            this.btnDesligarLed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesligarLed.Location = new System.Drawing.Point(228, 122);
            this.btnDesligarLed.Name = "btnDesligarLed";
            this.btnDesligarLed.Size = new System.Drawing.Size(152, 48);
            this.btnDesligarLed.TabIndex = 2;
            this.btnDesligarLed.Text = "Desligar LED";
            this.btnDesligarLed.UseVisualStyleBackColor = true;
            this.btnDesligarLed.Click += new System.EventHandler(this.btnDesligarLed_Click);
            // 
            // ArduinoActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 182);
            this.Controls.Add(this.btnDesligarLed);
            this.Controls.Add(this.btnLigarLed);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArduinoActions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArduinoActions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLigarLed;
        private System.Windows.Forms.Button btnDesligarLed;
    }
}

