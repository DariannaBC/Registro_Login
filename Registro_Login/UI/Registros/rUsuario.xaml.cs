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
using Registro_Login.Entidades;
namespace Registro_Login.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rUsuario.xaml
    /// </summary>
    public partial class rUsuario : Window
    {
        private Usuarios usuarios = new Usuarios();
        public rUsuario()
        {
            InitializeComponent();
            this.DataContext = usuarios;
            rolComboBox.ItemsSource = RolesBLL.GetRoles();
            rolComboBox.SelectedValuePath = "RolID";
            rolComboBox.DisplayMemberPath = "DescripcionRol";
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var usuario = UsuariosBLL.Buscar(Utilidades.ToInt(idTextBox.Text));

            if (usuario != null)
                this.usuarios = usuario;
            else
                this.usuarios = new Usuarios();

            this.DataContext = this.usuarios;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuariosBLL.Guardar(usuarios);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardo exitosamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No guardo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            if (UsuariosBLL.Eliminar(Utilidades.ToInt(idTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Usuario eliminado correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ID no existente", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Limpiar()
        {
            this.usuarios = new Usuarios();
            this.DataContext = usuarios;
        }

        private bool Validar()
        {
            bool paso = true;

            if (nombreTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo nombre no puede estar vacio");
                nombreTextBox.Focus();
                paso = false;
            }


            if (string.IsNullOrWhiteSpace(rolComboBox.Text))
            {
                MessageBox.Show("Debe agregar un rol especifico");
                rolComboBox.Focus();
                paso = false;
            }

            if (aliasTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo de alias no puede estar vacio");
                aliasTextBox.Focus();
                paso = false;
            }

            if (claveTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo de clave no puede estar vacio");
                claveTextBox.Focus();
                paso = false;
            }

            if (confirmarclaveTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo de confirmar clave no puede estar vacio");
                confirmarclaveTextBox.Focus();
                paso = false;
            }
            if (emailTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo de email no puede estar vacio");
                emailTextBox.Focus();
                paso = false;
            }
            return paso;
        }
    }
}
