using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Clases
{
    internal class frmConsulta
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public int Historia { get; set; }
        public string MotivoConsulta { get; set; }
        public string Descripcion { get; set; }
        public string Recomendaciones {  get; set; }

        public frmConsulta(int historia, string motivoConsulta, string descripcion, string recomendaciones)
        {
            this.Historia = historia;
            this.MotivoConsulta = motivoConsulta;
            this.Descripcion = descripcion;
            this.Recomendaciones = recomendaciones;
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblConsulta", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        public void Agregar(frmConsulta Nuevo)
        {
            SqlCommand cmd = new SqlCommand("insert into tblConsulta values('" + Nuevo.Historia + "','" + Nuevo.MotivoConsulta + "','" + Nuevo.Descripcion + "','" + Nuevo.Recomendaciones + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Consulta guardada");
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

        public void Actualizar(int Actualizar, frmConsulta Nuevesito)
        {
            SqlCommand cmd = new SqlCommand("Update tblConsulta set MotivoConsulta='" + Nuevesito.MotivoConsulta + "',Descripcion='" + Nuevesito.Descripcion + "',Recomendaciones='" + Nuevesito.Recomendaciones + "'where Historia='" + Actualizar + "'", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Consulta modificada");
        }


    }
}
