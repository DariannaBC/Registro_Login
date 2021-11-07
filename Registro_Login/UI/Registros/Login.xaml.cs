using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Registro_Login.BLL;
using Registro_Login.UI.Registros;
namespace Registro_Login.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void IniciarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            if (usuarioTextBox.Text == "admin" && passwordTextBox.Password == "1234")
            {
                MainWindow first = new MainWindow();
                first.Show();
                this.Hide();
            }
            else if (UsuariosBLL.ExisteUsuario(usuarioTextBox.Text, passwordTextBox.Password))
            {
                MainWindow first = new MainWindow();
                first.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña ingresado es incorrecto.");
                usuarioTextBox.Clear();
                passwordTextBox.Clear();
            }
        }

        private void RegistrarseButton_Click(object sender, RoutedEventArgs e)
        {
            rUsuario usu = new rUsuario();
            usu.Show();
        }
    }
}
