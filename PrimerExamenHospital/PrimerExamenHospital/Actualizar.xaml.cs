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
using System.Data;
using System.Data.SqlClient;

namespace PrimerExamenHospital
{
    /// <summary>
    /// Lógica de interacción para Actualizar.xaml
    /// </summary>
    public partial class Actualizar : Window
    {
        private int i;
        public Actualizar(int id)
        {
            InitializeComponent();
            i = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Conecxion conectar = new Conecxion();
            MostrandoRegistros mostrarR = new MostrandoRegistros();
            string consulta = "UPDATE pacientes SET nombre = @nombre, apellido=@apellido, edad=@edad, enfermedadQuePadece=@enfermedad, numeroDeExpediente=@expediente WHERE idPacientes="+ i;

            try
            {                
                SqlCommand cmd = new SqlCommand(consulta,conectar.AbrirConnecxion());
                conectar.AbrirConnecxion();

                cmd.Parameters.AddWithValue("@nombre", nombre.Text);
                cmd.Parameters.AddWithValue("@apellido", apellido.Text);
                cmd.Parameters.AddWithValue("@edad", edad.Text);
                cmd.Parameters.AddWithValue("@enfermedad", enfermedad.Text);
                cmd.Parameters.AddWithValue("@expediente", expediente.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("MODIFICADO CON EXITO");
            }
            catch (Exception ex)
            {
                MessageBox.Show("aqui "+ex.Message);
            }finally
            {
                conectar.cerrarConecxion();
                this.Close();
                //mostrarR.Show();
            }
        }
    }
}
