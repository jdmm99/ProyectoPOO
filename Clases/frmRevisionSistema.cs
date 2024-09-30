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
    public class frmRevisionSistem
    {
     
        public frmRevisionSistem(int documentoPaciente, string cabeza, string cuello, string torax, string corazon, string pulmon, string abdomen, string osteoMuscular, string neurologico, string vascular, string genitoUrinario)
        {
            this.DocumentoPaciente = documentoPaciente;
            this.Cabeza = cabeza;
            this.Cuello = cuello;
            this.Torax = torax;
            this.Corazon = corazon;
            this.Pulmon = pulmon;
            this.Abdomen = abdomen;
            this.OsteoMuscular = osteoMuscular;
            this.Neurologico = neurologico;
            this.Vascular = vascular;
            this.GenitoUrinario = genitoUrinario;
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblRevisionSistema", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public int DocumentoPaciente { get; set; }
        public string Cabeza {  get; set; }
        public string Cuello {  get; set; }
        public string Torax {  get; set; }
        public string Corazon { get; set; }
        public string Pulmon { get; set; }
        public string Abdomen {  get; set; }
        public string OsteoMuscular { get; set; }
        public string Neurologico { get; set; }
        public string Vascular {  get; set; }
        public string GenitoUrinario {  get; set; }

        public void Agregar(frmRevisionSistem Nuevo)
        {
            SqlCommand cmd = new SqlCommand("insert into tblRevisionSistema values('" + Nuevo.DocumentoPaciente + "','" + Nuevo.Cabeza + "','" + Nuevo.Cuello + "','" + Nuevo.Torax + "','" + Nuevo.Corazon + "','" + Nuevo.Pulmon + "','" + Nuevo.Abdomen + "','" + Nuevo.OsteoMuscular + "','" + Nuevo.Neurologico + "','" + Nuevo.Vascular + "','" + Nuevo.GenitoUrinario + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Información guardada");
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

        public void Actualizar(int Actualizar, frmRevisionSistem Nuevesito)
        {
            SqlCommand cmd = new SqlCommand("Update tblRevisionSistema set Cabeza='" + Nuevesito.Cabeza + "',Cuello='" + Nuevesito.Cuello + "',Torax='" + Nuevesito.Torax + "',Corazon='" + Nuevesito.Corazon + "',Pulmon='" + Nuevesito.Pulmon + "',Abdomen='" + Nuevesito.Abdomen + "',OsteoMuscular='" + Nuevesito.OsteoMuscular + "',Neurologico='" + Nuevesito.Neurologico + "',Vascular='" + Nuevesito.Vascular + "',GenitoUrinario='" + Nuevesito.GenitoUrinario + "'where Paciente='" + Actualizar + "'", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Información modificada");
        }
    }
}
