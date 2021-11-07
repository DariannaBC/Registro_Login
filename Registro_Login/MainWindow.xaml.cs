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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Registro_Login.UI.Registros;

namespace Registro_Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuario u= new rUsuario();
            u.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            rRoles r = new rRoles();
            r.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            rPermisos p = new rPermisos();
            p.Show();
        }
    }
}
