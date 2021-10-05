using Business;
using Entity;
using Semana06.ViewModel;
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

namespace Semana06.Views
{
    /// <summary>
    /// Lógica de interacción para ManCategoria.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {
        ManCategoriaViewModel viewModel;
        public int ID { get; set; }
        public int NewId { get; set; }

        public ManCategoria()
        {
            InitializeComponent();
            viewModel = new ManCategoriaViewModel();
            this.DataContext = viewModel;
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria Bcategoria = null;
            bool result = true;

            try
            {
                Bcategoria = new BCategoria();
                if (ID > 0)
                    result = Bcategoria.Actualizar(new Categoria { IdCategoria = ID, NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                else
                    result = Bcategoria.Insertar(new Categoria { IdCategoria = NewId, NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });

                if (!result)
                    MessageBox.Show("Comunicarse con el administrador");


                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bcategoria = null;
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
