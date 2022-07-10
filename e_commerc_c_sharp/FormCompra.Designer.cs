namespace e_commerc_c_sharp
{
    partial class FormCompra
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
            this.quantPizza = new System.Windows.Forms.NumericUpDown();
            this.btnFecha = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPizza = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quantPizza)).BeginInit();
            this.SuspendLayout();
            // 
            // quantPizza
            // 
            this.quantPizza.Location = new System.Drawing.Point(108, 105);
            this.quantPizza.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.quantPizza.Name = "quantPizza";
            this.quantPizza.Size = new System.Drawing.Size(75, 20);
            this.quantPizza.TabIndex = 0;
            this.quantPizza.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(93, 143);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(105, 23);
            this.btnFecha.TabIndex = 1;
            this.btnFecha.Text = "Fechar compra";
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Digite o número de pizzas de";
            // 
            // lblPizza
            // 
            this.lblPizza.AutoSize = true;
            this.lblPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPizza.Location = new System.Drawing.Point(38, 47);
            this.lblPizza.Name = "lblPizza";
            this.lblPizza.Size = new System.Drawing.Size(18, 20);
            this.lblPizza.TabIndex = 3;
            this.lblPizza.Text = "a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "a serem compradas:";
            // 
            // FormCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 193);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPizza);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.quantPizza);
            this.Name = "FormCompra";
            this.Text = "Tela de Compras";
            ((System.ComponentModel.ISupportInitialize)(this.quantPizza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown quantPizza;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPizza;
        private System.Windows.Forms.Label label3;
    }
}