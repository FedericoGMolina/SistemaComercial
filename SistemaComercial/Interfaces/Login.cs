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
using System.Text.RegularExpressions;

namespace SistemaComercial
{
    public partial class Login : Form
    {
        //Implementación de cue text
        [DllImport("user32.dll", CharSet = CharSet.Auto)] 
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public Login()
        {
            InitializeComponent();
            SendMessage(txtUsuarioLogin.Handle, 0x1501, 0, "Username");            //Implementación de cue text
            SendMessage(txtContraseñaLogin.Handle, 0x1501, 0, "Password");
            
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
        private void txtUsuarioLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"\W");
            if (!char.IsControl(e.KeyChar) && regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                panelUsuarioLogin.BackColor = Color.Red;
                lblErrorUsuarioLogin.Text = "Solo se admiten caracteres Alfa Numericos";
            }
            else
            {
                lblErrorUsuarioLogin.Text = "";
                panelUsuarioLogin.BackColor = Color.White;
            }

            if (e.KeyChar != '\b' && e.KeyChar == ' ' && regex.IsMatch(e.KeyChar.ToString()))
                e.Handled = true;
        }
        private void txtUsuarioLogin_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"\W");
            if (regex.IsMatch(txtUsuarioLogin.Text))
            {
                txtUsuarioLogin.Text = "";
                panelUsuarioLogin.BackColor = Color.Red;
                lblErrorUsuarioLogin.Text = "Solo se admiten caracteres Alfa Numericos";
            }
        }
        private void txtContraseñaLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"\W");
            if (!char.IsControl(e.KeyChar) && regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                panelContraseñaLogin.BackColor = Color.Red;
                lblErrorContraseñaLogin.Text = "Solo se admiten caracteres Alfa Numericos";
            }
            else
            {
                lblErrorContraseñaLogin.Text = "";
                panelContraseñaLogin.BackColor = Color.White;
            }

            if (e.KeyChar != '\b' && e.KeyChar == ' ' && regex.IsMatch(e.KeyChar.ToString()))
                e.Handled = true;
        }
        private void txtContraseñaLogin_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"\W");
            if (regex.IsMatch(txtContraseñaLogin.Text))
            {
                txtContraseñaLogin.Text = "";
                panelContraseñaLogin.BackColor = Color.Red;
                lblErrorContraseñaLogin.Text = "Solo se admiten caracteres Alfa Numericos";
            }
        }
    }
}
