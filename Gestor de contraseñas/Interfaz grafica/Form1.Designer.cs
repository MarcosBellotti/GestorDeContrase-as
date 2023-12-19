namespace Interfaz_grafica
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            dtgDatosUsuarios = new DataGridView();
            btnHistorial = new Button();
            btnCargar = new Button();
            txtContraseñaHistorial = new TextBox();
            txtNombreHistorial = new TextBox();
            txtContraseñaUsuarioCarga = new TextBox();
            txtEmailUsuarioCarga = new TextBox();
            txtNombreUsuarioCarga = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgDatosUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 67);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre: ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(415, 19);
            label2.Name = "label2";
            label2.Size = new Size(193, 21);
            label2.TabIndex = 1;
            label2.Text = "Historial de contraseñas";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 106);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 149);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 3;
            label4.Text = "Contraseña:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(415, 64);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 4;
            label5.Text = "Nombre:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(27, 19);
            label6.Name = "label6";
            label6.Size = new Size(81, 25);
            label6.TabIndex = 5;
            label6.Text = "Usuario";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(415, 100);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 7;
            label8.Text = "Contraseña:";
            // 
            // dtgDatosUsuarios
            // 
            dtgDatosUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDatosUsuarios.Location = new Point(27, 258);
            dtgDatosUsuarios.Name = "dtgDatosUsuarios";
            dtgDatosUsuarios.RowTemplate.Height = 25;
            dtgDatosUsuarios.Size = new Size(732, 127);
            dtgDatosUsuarios.TabIndex = 8;
            // 
            // btnHistorial
            // 
            btnHistorial.Location = new Point(415, 149);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(75, 23);
            btnHistorial.TabIndex = 9;
            btnHistorial.Text = "Buscar";
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(27, 194);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(75, 23);
            btnCargar.TabIndex = 10;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // txtContraseñaHistorial
            // 
            txtContraseñaHistorial.Location = new Point(488, 97);
            txtContraseñaHistorial.Name = "txtContraseñaHistorial";
            txtContraseñaHistorial.Size = new Size(271, 23);
            txtContraseñaHistorial.TabIndex = 4;
            // 
            // txtNombreHistorial
            // 
            txtNombreHistorial.Location = new Point(472, 61);
            txtNombreHistorial.Name = "txtNombreHistorial";
            txtNombreHistorial.Size = new Size(287, 23);
            txtNombreHistorial.TabIndex = 3;
            // 
            // txtContraseñaUsuarioCarga
            // 
            txtContraseñaUsuarioCarga.Location = new Point(103, 146);
            txtContraseñaUsuarioCarga.Name = "txtContraseñaUsuarioCarga";
            txtContraseñaUsuarioCarga.Size = new Size(248, 23);
            txtContraseñaUsuarioCarga.TabIndex = 2;
            // 
            // txtEmailUsuarioCarga
            // 
            txtEmailUsuarioCarga.Location = new Point(90, 100);
            txtEmailUsuarioCarga.Name = "txtEmailUsuarioCarga";
            txtEmailUsuarioCarga.Size = new Size(261, 23);
            txtEmailUsuarioCarga.TabIndex = 1;
            // 
            // txtNombreUsuarioCarga
            // 
            txtNombreUsuarioCarga.Location = new Point(90, 64);
            txtNombreUsuarioCarga.Name = "txtNombreUsuarioCarga";
            txtNombreUsuarioCarga.Size = new Size(261, 23);
            txtNombreUsuarioCarga.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtNombreUsuarioCarga);
            Controls.Add(txtEmailUsuarioCarga);
            Controls.Add(txtContraseñaUsuarioCarga);
            Controls.Add(txtNombreHistorial);
            Controls.Add(txtContraseñaHistorial);
            Controls.Add(btnCargar);
            Controls.Add(btnHistorial);
            Controls.Add(dtgDatosUsuarios);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dtgDatosUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private DataGridView dtgDatosUsuarios;
        private Button btnHistorial;
        private Button btnCargar;
        private TextBox txtContraseñaHistorial;
        private TextBox txtNombreHistorial;
        private TextBox txtContraseñaUsuarioCarga;
        private TextBox txtEmailUsuarioCarga;
        private TextBox txtNombreUsuarioCarga;
    }
}