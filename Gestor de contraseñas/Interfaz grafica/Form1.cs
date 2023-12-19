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
        }
    }
}