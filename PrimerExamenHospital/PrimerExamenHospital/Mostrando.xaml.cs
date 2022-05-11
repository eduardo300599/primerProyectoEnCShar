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
using System.Data.SqlClient;
using System.Data;

namespace PrimerExamenHospital
{
    /// <summary>
    /// Lógica de interacción para Mostrando.xaml
    /// </summary>
    public partial class Mostrando : Window
    {
        public Mostrando()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Conecxion conectar = new Conecxion();
            MainWindow login = new MainWindow();

            try
            {
                
                string peticion = "INSERT INTO usuario(nombre, nombreDeUsuario, contrasenia) VALUES (@nombre ,@usuario, @contrasenia)";
                SqlCommand command = new SqlCommand(peticion, conectar.AbrirConnecxion());

                conectar.AbrirConnecxion();

                command.Parameters.AddWithValue("@nombre", nombre.Text);
                command.Parameters.AddWithValue("@usuario", usuario.Text);
                command.Parameters.AddWithValue("@contrasenia", contrasenia.Text);
                command.ExecuteNonQuery();

                login.Show();
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                conectar.cerrarConecxion();
            }

            
        }
    }
}
