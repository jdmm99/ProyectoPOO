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
    public class frmAntecedentes
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public frmAntecedentes(int paciente, string familiar, string ginecologico, string obstretico, string toxicologicos, string farmacologicos, string patologicos, string quirurgicos, string traumaticos)
        {
            this.Paciente = paciente;
            this.Familiar = familiar;
            this.Ginecologico = ginecologico;
            this.Obstretico = obstretico;
            this.Toxicologicos = toxicologicos;
            this.Farmacologicos = farmacologicos;
            this.Patologicos = patologicos;
            this.Quirurgicos = quirurgicos;
            this.Traumaticos = traumaticos;
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblAntecedentes", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
        }

        public int Paciente { get; set; }
        public string Familiar {  get; set; }
        public string Ginecologico {  get; set; }
        public string Obstretico {  get; set; }
        public string Toxicologicos {  get; set; }
        public string Farmacologicos {  get; set; }
        public string Patologicos { get; set; }
        public string Quirurgicos {  get; set; }
        public string Traumaticos {  get; set; }

        public void Agregar(frmAntecedentes Nuevo)
        {
            SqlCommand cmd = new SqlCommand("insert into tblAntecedentes values('" + Nuevo.Paciente + "','" + Nuevo.Familiar + "','" + Nuevo.Ginecologico + "','" + Nuevo.Obstretico + "','" + Nuevo.Toxicologicos + "','" + Nuevo.Farmacologicos + "','" + Nuevo.Patologicos + "','" + Nuevo.Quirurgicos + "','" + Nuevo.Traumaticos + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Antecedentes guardado");
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

        public void Actualizar(int Actualizar, frmAntecedentes Nuevesito)
        {
            SqlCommand cmd = new SqlCommand("Update tblAntecedentes set Familiar='" + Nuevesito.Familiar + "',Ginecologicos='" + Nuevesito.Ginecologico + "',Obstetricos='" + Nuevesito.Obstretico + "',Toxicologicos='" + Nuevesito.Toxicologicos + "',Farmacologicos='" + Nuevesito.Farmacologicos + "',Patologicos='" + Nuevesito.Patologicos + "',Quirurgicos='" + Nuevesito.Quirurgicos + "',Traumaticos='" + Nuevesito.Traumaticos + "'where Paciente='" + Actualizar + "'", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Antecedentes modificado");
        }
    }
}
