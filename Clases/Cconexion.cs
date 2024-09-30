using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Proyecto.Clases
{
    internal class Cconexion
    {
        //Se define la ruta de la base de datos
        static private string CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Yoimar\Trabajos de la Uni\Quinto Semestre\Poo\Proyecto\Proyecto\HistoriaClinica.mdf"";Integrated Security=True;Connect Timeout=30";

        //Definir una variable para cargar la base de datos
        public SqlConnection Conexion = new SqlConnection(CadenaConexion);

        static public string cadenaConexion
        {
            get { return CadenaConexion; }
        }


        //Metodo para abrir la base de datos
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        //Metodo para cerrar la base de datos
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }




    }
}
