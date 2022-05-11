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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PrimerExamenHospital
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Conecxion conectar = new Conecxion();
            MostrandoRegistros MisRegistros = new MostrandoRegistros();

            try
            {
                string peticion = String.Format("select * from usuario where nombreDeUsuario='" + NombreUsuario.Text + "' and contrasenia='" + contrasenia.Text + "'");

                
                conectar.AbrirConnecxion();

                SqlCommand cmd = new SqlCommand(peticion, conectar.AbrirConnecxion());
               
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string ban = reader["nombreDeUsuario"].ToString();
                    reader.Close();
                    cmd.Dispose();
                    conectar.cerrarConecxion();

                    MessageBox.Show("DATOS VALIDOS");
                    this.Close();
                    MisRegistros.Show();

                } 
                else
                {
                    MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {               
                conectar.cerrarConecxion();
                NombreUsuario.Clear();
                contrasenia.Clear();               
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mostrando registrar = new Mostrando();
            registrar.Show();
            this.Close();
        }
    }
}
