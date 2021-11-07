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
    /// Lógica de interacción para rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles roles = new Roles();
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = this.roles;
            LlenarComboPermisos();
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var roles = RolesBLL.Buscar(Utilidades.ToInt(rolIdTextBox.Text));

            if (roles != null)
                this.roles = roles;
            else
                this.roles = new Roles();
            Cargar();
        }

        private void AgregarDetalleButton_Click(object sender, RoutedEventArgs e)
        {
            roles.Detalle.Add(new RolesDetalle
            {
                RolID = roles.RolID,
                PermisosId = (int)permisoIdComboBox.SelectedValue,
                EsAsignado = (bool)activo2CheckBox.IsChecked
            });

            Cargar();
        }

        private void RemoverRol_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.SelectedIndex < 0)
                return;//Con estas 2 lineas ya no vuelve a pasar
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                roles.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = RolesBLL.Guardar(this.roles);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Roles existe = RolesBLL.Buscar(this.roles.RolID);

            if (RolesBLL.Eliminar(this.roles.RolID))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible eliminarlo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private bool Validar()
        {
            bool paso = true;

            if (descripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show("Este campo no puede quedar vacio");
                descripcionTextBox.Focus();
                paso = false;
            }

            if (RolesBLL.ExisteDescripcion(descripcionTextBox.Text))
            {
                MessageBox.Show("Esta descripcion ya existe en la base de datos");
                descripcionTextBox.Focus();
                paso = false;
            }

            if (permisoIdComboBox.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccion un Id");
                permisoIdComboBox.Focus();
                paso = false;
            }
            return paso;
        }
        private void Cargar()
        {
            this.DetalleDataGrid.ItemsSource = null;
            this.DetalleDataGrid.ItemsSource = this.roles.Detalle;
            this.DataContext = null;
            this.DataContext = this.roles;
        }
        private void Limpiar()
        {
            roles = new Roles();
            Cargar();
        }

        private void LlenarComboPermisos()
        {
            this.permisoIdComboBox.ItemsSource = PermisosBLL.GetPermisos();
            this.permisoIdComboBox.SelectedValuePath = "PermisosId";
            this.permisoIdComboBox.DisplayMemberPath = "DescripcionPermisos";
        }
    }
}