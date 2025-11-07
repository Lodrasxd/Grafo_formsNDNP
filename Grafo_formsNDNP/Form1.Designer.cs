namespace Grafo_formsNDNP
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_BFS = new System.Windows.Forms.TextBox();
            this.btn_eliminarVertice = new System.Windows.Forms.Button();
            this.textBox_VerticeDel = new System.Windows.Forms.TextBox();
            this.btn_eliminarArista = new System.Windows.Forms.Button();
            this.btn_crearArista = new System.Windows.Forms.Button();
            this.comboBox_V2add = new System.Windows.Forms.ComboBox();
            this.comboBox_V1add = new System.Windows.Forms.ComboBox();
            this.btn_crearVertice = new System.Windows.Forms.Button();
            this.textBox_VerticeAdd = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_matriz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_BFS = new System.Windows.Forms.Button();
            this.textBox_DFS = new System.Windows.Forms.TextBox();
            this.btn_DFS = new System.Windows.Forms.Button();
            this.grafoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_DFS);
            this.panel1.Controls.Add(this.textBox_DFS);
            this.panel1.Controls.Add(this.btn_BFS);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_BFS);
            this.panel1.Controls.Add(this.btn_eliminarVertice);
            this.panel1.Controls.Add(this.textBox_VerticeDel);
            this.panel1.Controls.Add(this.btn_eliminarArista);
            this.panel1.Controls.Add(this.btn_crearArista);
            this.panel1.Controls.Add(this.comboBox_V2add);
            this.panel1.Controls.Add(this.comboBox_V1add);
            this.panel1.Controls.Add(this.btn_crearVertice);
            this.panel1.Controls.Add(this.textBox_VerticeAdd);
            this.panel1.Location = new System.Drawing.Point(989, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 510);
            this.panel1.TabIndex = 0;
            // 
            // textBox_BFS
            // 
            this.textBox_BFS.Location = new System.Drawing.Point(14, 327);
            this.textBox_BFS.MaxLength = 1;
            this.textBox_BFS.Name = "textBox_BFS";
            this.textBox_BFS.Size = new System.Drawing.Size(57, 20);
            this.textBox_BFS.TabIndex = 10;
            // 
            // btn_eliminarVertice
            // 
            this.btn_eliminarVertice.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_eliminarVertice.Location = new System.Drawing.Point(77, 87);
            this.btn_eliminarVertice.Name = "btn_eliminarVertice";
            this.btn_eliminarVertice.Size = new System.Drawing.Size(94, 23);
            this.btn_eliminarVertice.TabIndex = 9;
            this.btn_eliminarVertice.Text = "Eliminar Vertice";
            this.btn_eliminarVertice.UseVisualStyleBackColor = true;
            this.btn_eliminarVertice.Click += new System.EventHandler(this.btn_eliminarVertice_Click);
            // 
            // textBox_VerticeDel
            // 
            this.textBox_VerticeDel.Location = new System.Drawing.Point(14, 90);
            this.textBox_VerticeDel.MaxLength = 1;
            this.textBox_VerticeDel.Name = "textBox_VerticeDel";
            this.textBox_VerticeDel.Size = new System.Drawing.Size(57, 20);
            this.textBox_VerticeDel.TabIndex = 8;
            this.textBox_VerticeDel.TextChanged += new System.EventHandler(this.textBox_VerticeDel_TextChanged);
            // 
            // btn_eliminarArista
            // 
            this.btn_eliminarArista.Location = new System.Drawing.Point(103, 223);
            this.btn_eliminarArista.Name = "btn_eliminarArista";
            this.btn_eliminarArista.Size = new System.Drawing.Size(94, 23);
            this.btn_eliminarArista.TabIndex = 7;
            this.btn_eliminarArista.Text = "Eliminar arista";
            this.btn_eliminarArista.UseVisualStyleBackColor = true;
            this.btn_eliminarArista.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_crearArista
            // 
            this.btn_crearArista.Location = new System.Drawing.Point(103, 177);
            this.btn_crearArista.Name = "btn_crearArista";
            this.btn_crearArista.Size = new System.Drawing.Size(94, 23);
            this.btn_crearArista.TabIndex = 4;
            this.btn_crearArista.Text = "Crear arista";
            this.btn_crearArista.UseVisualStyleBackColor = true;
            this.btn_crearArista.Click += new System.EventHandler(this.btn_crearArista_Click);
            // 
            // comboBox_V2add
            // 
            this.comboBox_V2add.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_V2add.FormattingEnabled = true;
            this.comboBox_V2add.Location = new System.Drawing.Point(14, 223);
            this.comboBox_V2add.Name = "comboBox_V2add";
            this.comboBox_V2add.Size = new System.Drawing.Size(57, 21);
            this.comboBox_V2add.TabIndex = 3;
            this.comboBox_V2add.SelectedIndexChanged += new System.EventHandler(this.comboBox_V2add_SelectedIndexChanged);
            // 
            // comboBox_V1add
            // 
            this.comboBox_V1add.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_V1add.FormattingEnabled = true;
            this.comboBox_V1add.Location = new System.Drawing.Point(14, 177);
            this.comboBox_V1add.Name = "comboBox_V1add";
            this.comboBox_V1add.Size = new System.Drawing.Size(57, 21);
            this.comboBox_V1add.TabIndex = 2;
            this.comboBox_V1add.SelectedIndexChanged += new System.EventHandler(this.comboBox_V1add_SelectedIndexChanged);
            // 
            // btn_crearVertice
            // 
            this.btn_crearVertice.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_crearVertice.Location = new System.Drawing.Point(77, 25);
            this.btn_crearVertice.Name = "btn_crearVertice";
            this.btn_crearVertice.Size = new System.Drawing.Size(94, 23);
            this.btn_crearVertice.TabIndex = 1;
            this.btn_crearVertice.Text = "Crear Vertice";
            this.btn_crearVertice.UseVisualStyleBackColor = true;
            this.btn_crearVertice.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_VerticeAdd
            // 
            this.textBox_VerticeAdd.Location = new System.Drawing.Point(14, 28);
            this.textBox_VerticeAdd.MaxLength = 1;
            this.textBox_VerticeAdd.Name = "textBox_VerticeAdd";
            this.textBox_VerticeAdd.Size = new System.Drawing.Size(57, 20);
            this.textBox_VerticeAdd.TabIndex = 0;
            this.textBox_VerticeAdd.TextChanged += new System.EventHandler(this.textBox_VerticeAdd_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(595, 595);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_matriz
            // 
            this.textBox_matriz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_matriz.Location = new System.Drawing.Point(642, 56);
            this.textBox_matriz.Multiline = true;
            this.textBox_matriz.Name = "textBox_matriz";
            this.textBox_matriz.ReadOnly = true;
            this.textBox_matriz.Size = new System.Drawing.Size(322, 285);
            this.textBox_matriz.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Origen";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Destino";
            // 
            // btn_BFS
            // 
            this.btn_BFS.Location = new System.Drawing.Point(77, 325);
            this.btn_BFS.Name = "btn_BFS";
            this.btn_BFS.Size = new System.Drawing.Size(75, 23);
            this.btn_BFS.TabIndex = 13;
            this.btn_BFS.Text = "Iniciar BFS";
            this.btn_BFS.UseVisualStyleBackColor = true;
            this.btn_BFS.Click += new System.EventHandler(this.btn_BFS_Click);
            // 
            // textBox_DFS
            // 
            this.textBox_DFS.Location = new System.Drawing.Point(14, 395);
            this.textBox_DFS.MaxLength = 1;
            this.textBox_DFS.Name = "textBox_DFS";
            this.textBox_DFS.Size = new System.Drawing.Size(57, 20);
            this.textBox_DFS.TabIndex = 14;
            // 
            // btn_DFS
            // 
            this.btn_DFS.Location = new System.Drawing.Point(77, 392);
            this.btn_DFS.Name = "btn_DFS";
            this.btn_DFS.Size = new System.Drawing.Size(75, 23);
            this.btn_DFS.TabIndex = 15;
            this.btn_DFS.Text = "Iniciar DFS";
            this.btn_DFS.UseVisualStyleBackColor = true;
            this.btn_DFS.Click += new System.EventHandler(this.btn_DFS_Click);
            // 
            // grafoBindingSource
            // 
            this.grafoBindingSource.DataSource = typeof(Grafo_formsNDNP.Grafo);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 619);
            this.Controls.Add(this.textBox_matriz);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_matriz;
        private System.Windows.Forms.Button btn_crearVertice;
        private System.Windows.Forms.TextBox textBox_VerticeAdd;
        private System.Windows.Forms.ComboBox comboBox_V2add;
        private System.Windows.Forms.ComboBox comboBox_V1add;
        private System.Windows.Forms.Button btn_eliminarArista;
        private System.Windows.Forms.Button btn_crearArista;
        private System.Windows.Forms.Button btn_eliminarVertice;
        private System.Windows.Forms.TextBox textBox_VerticeDel;
        private System.Windows.Forms.BindingSource grafoBindingSource;
        private System.Windows.Forms.TextBox textBox_BFS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_DFS;
        private System.Windows.Forms.TextBox textBox_DFS;
        private System.Windows.Forms.Button btn_BFS;
    }
}

