using Gestor_de_contrase�as;
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
            txtNombreContrase�a.KeyPress += validarLetra_KeyPress;

            //hago que en los txt de contrase�a aparezca *

            txtContrase�aContrase�a.PasswordChar = '*';
            txtContrase�aHistorial.PasswordChar = '*';
            txtContrase�aUsuarioCarga.PasswordChar = '*';
            txtNuevaContrase�a.PasswordChar = '*';


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
            string contrase�a = txtContrase�aUsuarioCarga.Text;

            if (controller.altaUsuario(nombre, email, contrase�a))
            {
                txtNombreUsuarioCarga.Text = "";
                txtEmailUsuarioCarga.Text = "";
                txtContrase�aUsuarioCarga.Text = "";

                llenarLaGrilla();
            }


        }

        public List<object> ObtenerHistorial(string nombre, string contrase�a)
        {
            List<string> contrase�as = controller.contrase�asDelUsuario(nombre, contrase�a);

            var historialViewModel = contrase�as.Select(c => new
            {
                Contrase�a = c,
            }).ToList();

            return historialViewModel.Cast<object>().ToList();
        }


        private void btnHistorial_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreHistorial.Text;
            string contrase�a = txtContrase�aHistorial.Text;

            dtgDatosUsuarios.DataSource = ObtenerHistorial(nombre, contrase�a);
            dtgDatosUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            txtNombreHistorial.Text = "";
            txtContrase�aHistorial.Text = "";
        }

        private void btnActualizarContrase�a_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreContrase�a.Text;
            string contrase�a = txtContrase�aContrase�a.Text;
            string nuevaContrase�a = txtNuevaContrase�a.Text;

            if (!validadora.validarContrase�a(nuevaContrase�a))
            {
                MessageBox.Show("Ingrese la contrase�a correcta!\nDebe contener mayusculas, minusculas y, al menos, un caracter especial (+, -, *, _)");
            }
            else
            {
                controller.cambiarContrase�a(nombre, contrase�a, nuevaContrase�a);

                llenarLaGrilla();

                txtNombreContrase�a.Text = "";
                txtContrase�aContrase�a.Text = "";
                txtNuevaContrase�a.Text = "";
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


        //Los siguientes eventos de los botones son solo para ver o dejar de ver la contrase�a
        private void button1_Click(object sender, EventArgs e)
        {
            verUOcultarContrase�a(txtContrase�aUsuarioCarga, btnVerContrase�a);
        }

        private void btnVerContrase�aContrase�a_Click(object sender, EventArgs e)
        {
            verUOcultarContrase�a(txtContrase�aHistorial, btnVerContrase�aContrase�a);
        }

        private void btnVerContrase�aC_Click(object sender, EventArgs e)
        {
            verUOcultarContrase�a(txtContrase�aContrase�a, btnVerContrase�aC);
        }

        private void btnVerContrase�aCC_Click(object sender, EventArgs e)
        {
            verUOcultarContrase�a(txtNuevaContrase�a, btnVerContrase�aCC);
        }

        private void verUOcultarContrase�a(TextBox txt, Button btn)
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