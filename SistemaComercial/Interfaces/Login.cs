using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaComercial
{
    public partial class Login : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public Login()
        {
            InitializeComponent();
            SendMessage(txtUsuarioLogin.Handle, 0x1501, 0, "Username");     // EM_SETCUEBANNER
            SendMessage(txtContraseñaLogin.Handle, 0x1501, 0, "Password");     // EM_SETCUEBANNER
            
        }
        public class Conexion
        {
            private string servidor = "datasource=127.0.0.1";
            private string puerto = "port=3306";
            private string username = "username = root";
            private string password = "password=";
            private string bd = "database=firstbdincsharp";
            public MySqlConnection getConexion()
            {

                string cadenaConexion = servidor + ";" + puerto + ";" +
                username + ";" + password + ";" + bd;
                return new MySqlConnection(cadenaConexion);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
            register.FormClosing += register_closing;
        }
        private void register_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
    }
}
