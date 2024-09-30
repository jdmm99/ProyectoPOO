using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Clases
{
    public class frmMedicamentos
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public frmMedicamentos(string nombreMedicamento, int cantidad, string descripcion)
        {
            this.NombreMedicamento = nombreMedicamento;
            this.Cantidad = cantidad;
            this.Descripcion = descripcion;
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblMedicamento", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        public string NombreMedicamento {  get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }

        public int Agregar(frmMedicamentos Nuevo)
        {
            SqlCommand cmd = new SqlCommand("insert into tblMedicamento values('" + Nuevo.NombreMedicamento + "','" + Nuevo.Cantidad + "','" + Nuevo.Descripcion + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Medicamento guardada");

            int codigoMedicamento = Convert.ToInt32(cmd.ExecuteScalar());
            return codigoMedicamento;
        }
    }
}
