using Gestor_de_contraseñas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Interfaz_grafica
{
    public partial class Form1 : Form
    {
        private readonly IValidadora validadora;
        private readonly ISerializadora serializadora;
        private readonly IEncriptadora encriptadora;
        private Controller controller;


        public Form1()
        {
            InitializeComponent();
            this.serializadora = new Serializadora();
            this.validadora = new Validadora(serializadora);
            this.encriptadora = new EncryptMD5();

            this.controller = new Controller(validadora, serializadora, encriptadora);

            //Valido que se escriban letras solamente en el nombre
            txtNombreUsuarioCarga.KeyPress += validarLetra_KeyPress;
            txtNombreHistorial.KeyPress += validarLetra_KeyPress;
            txtNombreContraseña.KeyPress += validarLetra_KeyPress;

            //hago que en los txt de contraseña aparezca *

            txtContraseñaContraseña.PasswordChar = '*';
            txtContraseñaHistorial.PasswordChar = '*';
            txtContraseñaUsuarioCarga.PasswordChar = '*';
            txtNuevaContraseña.PasswordChar = '*';


            llenarLaGrilla();
        }

        public void llenarLaGrilla()
        {
            dtgDatosUsuarios.DataSource = serializadora.obtenerUsuarios();
            dtgDatosUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreUsuarioCarga.Text;
            string email = txtEmailUsuarioCarga.Text;
            string contraseña = txtContraseñaUsuarioCarga.Text;

            if (controller.altaUsuario(nombre, email, contraseña))
            {
                txtNombreUsuarioCarga.Text = "";
                txtEmailUsuarioCarga.Text = "";
                txtContraseñaUsuarioCarga.Text = "";

                llenarLaGrilla();
            }


        }

        public List<object> ObtenerHistorial(string nombre, string contraseña)
        {
            List<string> contraseñas = controller.contraseñasDelUsuario(nombre, contraseña);

            var historialViewModel = contraseñas.Select(c => new
            {
                Contraseña = c,
            }).ToList();

            return historialViewModel.Cast<object>().ToList();
        }


        private void btnHistorial_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreHistorial.Text;
            string contraseña = txtContraseñaHistorial.Text;

            dtgDatosUsuarios.DataSource = ObtenerHistorial(nombre, contraseña);
            dtgDatosUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            txtNombreHistorial.Text = "";
            txtContraseñaHistorial.Text = "";
        }

        private void btnActualizarContraseña_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreContraseña.Text;
            string contraseña = txtContraseñaContraseña.Text;
            string nuevaContraseña = txtNuevaContraseña.Text;

            if (!validadora.validarContraseña(nuevaContraseña))
            {
                MessageBox.Show("Ingrese la contraseña correcta!\nDebe contener mayusculas, minusculas y, al menos, un caracter especial (+, -, *, _)");
            }
            else
            {
                controller.cambiarContraseña(nombre, contraseña, nuevaContraseña);

                llenarLaGrilla();

                txtNombreContraseña.Text = "";
                txtContraseñaContraseña.Text = "";
                txtNuevaContraseña.Text = "";
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            llenarLaGrilla();
        }


        //Valido que en todos los lugares que vaya un nombre, se escriban solo letras
        private void validarLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        //Los siguientes eventos de los botones son solo para ver o dejar de ver la contraseña
        private void button1_Click(object sender, EventArgs e)
        {
            verUOcultarContraseña(txtContraseñaUsuarioCarga, btnVerContraseña);
        }

        private void btnVerContraseñaContraseña_Click(object sender, EventArgs e)
        {
            verUOcultarContraseña(txtContraseñaHistorial, btnVerContraseñaContraseña);
        }

        private void btnVerContraseñaC_Click(object sender, EventArgs e)
        {
            verUOcultarContraseña(txtContraseñaContraseña, btnVerContraseñaC);
        }

        private void btnVerContraseñaCC_Click(object sender, EventArgs e)
        {
            verUOcultarContraseña(txtNuevaContraseña, btnVerContraseñaCC);
        }

        private void verUOcultarContraseña(TextBox txt, Button btn)
        {
            if (txt.PasswordChar == '*')
            {
                txt.PasswordChar = '\0';
                btn.Text = "Ocultar";
            }
            else
            {
                txt.PasswordChar = '*';
                btn.Text = "Ver";
            }
        }
    }
}