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
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtNombreContraseña = new TextBox();
            txtContraseñaContraseña = new TextBox();
            txtNuevaContraseña = new TextBox();
            btnActualizarContraseña = new Button();
            btnLimpiar = new Button();
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
            label2.Location = new Point(415, 23);
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
            dtgDatosUsuarios.Location = new Point(27, 299);
            dtgDatosUsuarios.Name = "dtgDatosUsuarios";
            dtgDatosUsuarios.RowTemplate.Height = 25;
            dtgDatosUsuarios.Size = new Size(983, 127);
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
            txtContraseñaHistorial.Size = new Size(190, 23);
            txtContraseñaHistorial.TabIndex = 4;
            // 
            // txtNombreHistorial
            // 
            txtNombreHistorial.Location = new Point(472, 61);
            txtNombreHistorial.Name = "txtNombreHistorial";
            txtNombreHistorial.Size = new Size(206, 23);
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(732, 64);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 11;
            label7.Text = "Nombre:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(732, 100);
            label9.Name = "label9";
            label9.Size = new Size(70, 15);
            label9.TabIndex = 12;
            label9.Text = "Contraseña:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(732, 133);
            label10.Name = "label10";
            label10.Size = new Size(105, 15);
            label10.TabIndex = 13;
            label10.Text = "Nueva contraseña:";
            // 
            // txtNombreContraseña
            // 
            txtNombreContraseña.Location = new Point(792, 61);
            txtNombreContraseña.Name = "txtNombreContraseña";
            txtNombreContraseña.Size = new Size(218, 23);
            txtNombreContraseña.TabIndex = 5;
            // 
            // txtContraseñaContraseña
            // 
            txtContraseñaContraseña.Location = new Point(808, 97);
            txtContraseñaContraseña.Name = "txtContraseñaContraseña";
            txtContraseñaContraseña.Size = new Size(202, 23);
            txtContraseñaContraseña.TabIndex = 6;
            // 
            // txtNuevaContraseña
            // 
            txtNuevaContraseña.Location = new Point(843, 130);
            txtNuevaContraseña.Name = "txtNuevaContraseña";
            txtNuevaContraseña.Size = new Size(167, 23);
            txtNuevaContraseña.TabIndex = 7;
            // 
            // btnActualizarContraseña
            // 
            btnActualizarContraseña.Location = new Point(732, 171);
            btnActualizarContraseña.Name = "btnActualizarContraseña";
            btnActualizarContraseña.Size = new Size(75, 23);
            btnActualizarContraseña.TabIndex = 18;
            btnActualizarContraseña.Text = "Actualizar";
            btnActualizarContraseña.UseVisualStyleBackColor = true;
            btnActualizarContraseña.Click += btnActualizarContraseña_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(27, 270);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(144, 23);
            btnLimpiar.TabIndex = 19;
            btnLimpiar.Text = "Limpiar filtro";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 465);
            Controls.Add(btnLimpiar);
            Controls.Add(btnActualizarContraseña);
            Controls.Add(txtNuevaContraseña);
            Controls.Add(txtContraseñaContraseña);
            Controls.Add(txtNombreContraseña);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label7);
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
        private Label label7;
        private Label label9;
        private Label label10;
        private TextBox txtNombreContraseña;
        private TextBox txtContraseñaContraseña;
        private TextBox txtNuevaContraseña;
        private Button btnActualizarContraseña;
        private Button btnLimpiar;
    }
}