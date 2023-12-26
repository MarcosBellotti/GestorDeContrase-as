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

            txtNombreUsuarioCarga.KeyPress += validarLetra_KeyPress;
            txtNombreHistorial.KeyPress += validarLetra_KeyPress;
            txtNombreContrase�a.KeyPress += validarLetra_KeyPress;

            llenarLaGrilla();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

            if(!validadora.validarContrase�a(nuevaContrase�a))
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
    }
}