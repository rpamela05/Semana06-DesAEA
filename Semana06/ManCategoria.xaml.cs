﻿using System;
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
using Entity;
using Business;

namespace Semana06
{
    /// <summary>
    /// Lógica de interacción para ManCategoria.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {
        public int ID { get; set; }
        public int NewId { get; set; }

        public ManCategoria(int Id, int newId = 0)
        {
            InitializeComponent();
            ID = Id;
            NewId = newId;
            if (ID > 0 && NewId == 0)
            {
                BCategoria bCategoria = new BCategoria();
                List<Categoria> categorias = new List<Categoria>();
                categorias = bCategoria.Listar(ID);
                if (categorias.Count > 0)
                {
                    lblId.Content = categorias[0].IdCategoria.ToString();
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion;
                }
            }
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
            catch(Exception ex)
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
