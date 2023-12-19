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
            controller.cambiarContraseña(nombre, contraseña, nuevaContraseña);

            llenarLaGrilla();

            txtNombreContraseña.Text = "";
            txtContraseñaContraseña.Text = "";
            txtNuevaContraseña.Text = "";

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            llenarLaGrilla();
        }
    }
}