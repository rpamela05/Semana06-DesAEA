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
using Business;
using Entity;

namespace Semana06
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            BCategoria BCategoria = null;
            try
            {
                BCategoria = new BCategoria();
                dgvCategoria.ItemsSource = BCategoria.Listar(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                BCategoria = null;
            }
        }

       

       
    }
}
