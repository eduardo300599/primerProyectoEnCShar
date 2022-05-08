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
using System.Configuration;

namespace PrimerExamenHospital
{
    /// <summary>
    /// Lógica de interacción para MostrandoRegistros.xaml
    /// </summary>
    public partial class MostrandoRegistros : Window
    {
        public MostrandoRegistros()
        {

            InitializeComponent();
            mostrar();
            mostrarPacientes();
        }

        private void mostrarRegistros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        public void mostrar()
        {
            Conecxion conectando = new Conecxion();

            string consulta = "SELECT *, CONCAT(numeroDeExpedinte, NombreDeCreador) as mostrarTodo FROM registroDeExpediente";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conectando.AbrirConnecxion());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            /*
            mostrarRegistros.DisplayMemberPath = "mostrarTodo";
            mostrarRegistros.SelectedValuePath = "idExpediente";
            mostrarRegistros.ItemsSource = dt.DefaultView;
            conectando.cerrarConecxion();*/
        }

        public void mostrarPacientes()
        {
            Conecxion conectando = new Conecxion();
            string consul = "SELECT * FROM pacientes";
            //string consulta = "SELECT *, CONCAT(nombre,' ',apellido, ' ', edad, ' ', enfermedadQuePadece, ' ', numeroDeExpediente) as mostrarTodo FROM pacientes";
            SqlDataAdapter adaptador = new SqlDataAdapter(consul, conectando.AbrirConnecxion());
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            mostrarPaciente.DisplayMemberPath = "nombre";
            mostrarPaciente.SelectedValuePath = "idPacientes";
            mostrarPaciente.ItemsSource = dt.DefaultView;
            conectando.cerrarConecxion();
        }

        public void registrar()
        {
            Conecxion conectando = new Conecxion();
            string consulta = "INSERT INTO pacientes(nombre, apellido, edad, enfermedadQuePadece, numeroDeExpediente) VALUES (@nombre, @apellido, @edad, @enfermedad, @expediente)";

            SqlCommand command = new SqlCommand(consulta, conectando.AbrirConnecxion());
            conectando.AbrirConnecxion();
            command.Parameters.AddWithValue("@nombre", nombre.Text);
            command.Parameters.AddWithValue("@apellido", apellido.Text);
            command.Parameters.AddWithValue("@edad", edad.Text);
            command.Parameters.AddWithValue("@enfermedad", enfermedad.Text);
            command.Parameters.AddWithValue("@expediente", expediente.Text);
            
            command.ExecuteNonQuery();
            conectando.cerrarConecxion();

            mostrarPacientes();
            nombre.Text = "";
            apellido.Text = "";
            edad.Text = "";
            enfermedad.Text = "";
            expediente.Text = "";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registrar();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Conecxion conectando = new Conecxion();

            string peticion = "DELETE FROM pacientes WHERE idPacientes=@IDBORRAR";
            SqlCommand command = new SqlCommand(peticion, conectando.AbrirConnecxion());
            conectando.AbrirConnecxion();

            command.Parameters.AddWithValue("@IDBORRAR", mostrarPaciente.SelectedValue);
            command.ExecuteNonQuery();
            conectando.cerrarConecxion();

            mostrarPacientes();
        }

        public void actualizar()
        {

        }

        //actualizar
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Actualizar actualizar = new Actualizar();
            actualizar.Show();
            Conecxion conectar = new Conecxion();

            try
            {
                string peticion = "SELECT nombre, apellido, edad, enfermedadQuePadece, numeroDeExpediente FROM pacientes WHERE id=@IDPACIENTE";
                
                SqlCommand cmd = new SqlCommand(peticion, conectar.AbrirConnecxion());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                using(adapter)
                {
                    cmd.Parameters.AddWithValue("@IDPACIENTE", mostrarPaciente.SelectedValue);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    

                    actualizar.nombre.Text = tabla.Rows[1]["nombre"].ToString();
                    actualizar.apellido.Text = tabla.Rows[2]["apellido"].ToString();
                    actualizar.edad.Text = tabla.Rows[3]["edad"].ToString();
                    actualizar.enfermedad.Text = tabla.Rows[4]["enfermedadQuePadece"].ToString();
                    actualizar.expediente.Text = tabla.Rows[5]["numeroDeExpediente"].ToString();

                }


            }catch (Exception ex)
            {

            }finally
            {
                conectar.cerrarConecxion();
                this.Close();
            }


        }

        public DataTable Buscar(string nombre)
        {
            string consulta = string.Format("SELECT * FROM pacientes WHERE nombre LIKE '%{0}%'", nombre);
            Conecxion conectar = new Conecxion();
            conectar.AbrirConnecxion();
            DataSet ds;
            SqlCommand cmd = new SqlCommand(consulta,conectar.AbrirConnecxion());
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            ds= new DataSet();

            adaptador.Fill(ds, "tabla");
            conectar.cerrarConecxion();
            return ds.Tables["tabla"];           
        }


        private void mostrarPaciente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (buscar.Text != "")
            {
                mostrarPaciente.DisplayMemberPath = Buscar(buscar.Text).ToString();
            }
            else
                mostrarPacientes();
        }
    }
}
