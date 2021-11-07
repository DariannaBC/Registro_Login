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
using Registro_Login.Entidades;
using Registro_Login.BLL;
namespace Registro_Login.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rPermisos.xaml
    /// </summary>
    public partial class rPermisos : Window
    {
        public rPermisos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            permisoIDTextBox.Clear();
            NombreTextBox.Clear();
            DescripcionTextBox.Clear();
        }

        private void LlenarCampos(Permisos permiso)
        {
            permisoIDTextBox.Text = permiso.PermisosId.ToString();
            NombreTextBox.Text = permiso.Nombre;
            DescripcionTextBox.Text = permiso.DescripcionPermisos;
        }
        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            Permisos permiso = new Permisos();
            Limpiar();

            permiso = PermisosBLL.Buscar(Utilidades.ToInt(permisoIDTextBox.Text));

            if (permiso != null)
            {
                LlenarCampos(permiso);
            }
            else
            {
                MessageBox.Show("El permiso no ha sido encontrada o no esta registrado");
            }
        }
    }
}
