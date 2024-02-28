namespace act3_csv_json_noestructurado_contema
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProcesarArchivo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnProcesarArchivo
            // 
            this.btnProcesarArchivo.Location = new System.Drawing.Point(30, 86);
            this.btnProcesarArchivo.Name = "btnProcesarArchivo";
            this.btnProcesarArchivo.Size = new System.Drawing.Size(167, 29);
            this.btnProcesarArchivo.TabIndex = 0;
            this.btnProcesarArchivo.Text = "Procesar Archivo";
            this.btnProcesarArchivo.UseVisualStyleBackColor = true;
            this.btnProcesarArchivo.Click += new System.EventHandler(this.btnProcesarArchivo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "GESTION DE CLIENTES";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcesarArchivo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcesarArchivo;
        private System.Windows.Forms.Label label1;
    }
}

