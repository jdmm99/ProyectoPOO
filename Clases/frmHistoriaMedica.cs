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
    public class frmHistoriaMedica
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public frmHistoriaMedica(int codigoHistoria, int paciente, string tipoSangre, string nombreAcompañante, string parentesco, string numeroResponsable)
        {
            this.CodigoHistoria = codigoHistoria;
            this.Paciente = paciente;
            this.TipoSangre = tipoSangre;
            this.NombreAcompañante = nombreAcompañante;
            this.Parentesco = parentesco;
            this.NumeroResponsable = numeroResponsable;
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblHistoria", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        public int CodigoHistoria {  get; set; }
        public int Paciente { get; set; }  
        public string TipoSangre { get; set; }
        public string NombreAcompañante { get; set; }
        public string Parentesco {  get; set; }
        public string NumeroResponsable {  get; set; }

        public void Agregar(frmHistoriaMedica Nuevo)
        {
            SqlCommand cmd = new SqlCommand("insert into tblHistoria values('" + Nuevo.CodigoHistoria + "','" + Nuevo.Paciente + "','" + Nuevo.TipoSangre + "','" + Nuevo.NombreAcompañante + "','" + Nuevo.Parentesco + "','" + Nuevo.NumeroResponsable + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Historia guardada");
        }

        //public void Eliminar(int Eliminar)
        //{
        //    if (MessageBox.Show("Desea borrar el Paciente?", "Alerta!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        SqlCommand cm = new SqlCommand("delete from tblPaciente where IdPaciente = '" + Eliminar + "'", cn.AbrirConexion());
        //        cm.ExecuteNonQuery();
        //        MessageBox.Show("Paciente Eliminado");
        //    }
        //}

        public void Actualizar(int Actualizar, frmHistoriaMedica Nuevesito)
        {
            SqlCommand cmd = new SqlCommand("Update tblHistoria set TipoSangre='" + Nuevesito.TipoSangre + "',Acompañante='" + Nuevesito.NombreAcompañante + "',Parentesco='" + Nuevesito.Parentesco + "',NumeroResponsable='" + Nuevesito.NumeroResponsable + "'where Paciente='" + Actualizar + "'", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Historia modificada");
        }
    }
}
