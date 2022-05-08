using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PrimerExamenHospital
{
    internal class Conecxion
    {
        
        static private string conecxionBD = ConfigurationManager.ConnectionStrings["PrimerExamenHospital.Properties.Settings.HospitalConnectionString"].ConnectionString;

        private SqlConnection conect = new SqlConnection(conecxionBD);

        public SqlConnection AbrirConnecxion()
        {
            if(conect.State == ConnectionState.Closed)
                conect.Open();
            return conect;
        }

        public SqlConnection cerrarConecxion()
        {
            if(conect.State == ConnectionState.Open)
                conect.Close();
            return conect;
        }
        


    }
}
