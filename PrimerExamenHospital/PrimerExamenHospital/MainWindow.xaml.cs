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
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conecxion;
        public MainWindow()
        {
            InitializeComponent();
            //string conct = ConfigurationManager.ConnectionStrings["PrimerExamenHospital.Properties.Settings.HospitalConnectionString"].ConnectionString;
            conecxion = new SqlConnection("Data Source=DESKTOP-5ATPOUI;Initial Catalog=Hospital;User ID=sa;Password=123456789");



        }

        /*
        public void login()
        {
            
            try
            {
                string peticion = "SELECT nombreDeUsuario, contrasenia FROM usuario WHERE='" + NombreUsuario.Text + "' AND  contrasenia='" + contrasenia.Text + "'";

                conecxion.Open();

                //using (conecxion)
                //{
                    using (SqlCommand cmd = new SqlCommand(peticion, conecxion))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            MessageBox.Show("conecxion correcta");
                        }
                        else
                        {
                            MessageBox.Show("ERROR EN LA CONECXION");
                        }
                    }
                //}
                conecxion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conecxion.Close();
            }
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string peticion = "SELECT nombreDeUsuario, contrasenia FROM usuario WHERE='" + NombreUsuario.Text + "' AND  contrasenia='" + contrasenia.Text + "'";

                conecxion.Open();

                using (conecxion)
                {
                using (SqlCommand cmd = new SqlCommand(peticion, conecxion))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("conecxion correcta");
                    }
                    else
                    {
                        MessageBox.Show("ERROR EN LA CONECXION");
                    }
                }
                }
                conecxion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                conecxion.Close();
            }
        }
    }
}
