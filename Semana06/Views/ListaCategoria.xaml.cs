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
using Business;
using Entity;
using Semana06.ViewModel;

namespace Semana06.Views
{
    /// <summary>
    /// Lógica de interacción para ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        ListaCategoriaViewModel viewModel;
        public ListaCategoria()
        {
            InitializeComponent();
            viewModel = new ListaCategoriaViewModel();
            this.DataContext = viewModel;
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
            catch (Exception ex)
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
