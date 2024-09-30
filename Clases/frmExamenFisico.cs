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
    public class frmExamenFisico
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public frmExamenFisico(int paciente, string estadoGeneral, string signosVitales, string presionArterial, string frecuenciaCardiaca, string frecuenciaRespiratoria, string saturacionOxigeno, string temperatura, int talla, int peso)
        {
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblExamenFisico", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            this.Paciente = paciente;
            this.EstadoGeneral = estadoGeneral;
            this.SignosVitales = signosVitales;
            this.PresionArterial = presionArterial;
            this.FrecuenciaCardiaca = frecuenciaCardiaca;
            this.FrecuenciaRespiratoria = frecuenciaRespiratoria;
            this.SaturacionOxigeno = saturacionOxigeno;
            this.Temperatura = temperatura;
            this.Talla = talla;
            this.Peso = peso;
        }

        public int Paciente { get; set; }    
        public string EstadoGeneral {  get; set; } 
        public string SignosVitales {  get; set; }
        public string PresionArterial {  get; set; }
        public string FrecuenciaCardiaca { get; set; }
        public string FrecuenciaRespiratoria {  get; set; }
        public string SaturacionOxigeno {  get; set; }
        public string Temperatura {  get; set; }
        public int Talla {  get; set; }
        public int Peso {  get; set; }

        public void Agregar(frmExamenFisico Nuevo)
        {
            SqlCommand cmd = new SqlCommand("insert into tblExamenFisico values('" + Nuevo.Paciente + "','" + Nuevo.EstadoGeneral + "','" + Nuevo.SignosVitales + "','" + Nuevo.PresionArterial + "','" + Nuevo.FrecuenciaCardiaca + "','" + Nuevo.FrecuenciaRespiratoria + "','" + Nuevo.SaturacionOxigeno + "','" + Nuevo.Temperatura + "','" + Nuevo.Talla + "','" + Nuevo.Peso + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Examen guardado");
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

        public void Actualizar(int Actualizar, frmExamenFisico Nuevesito)
        {
            SqlCommand cmd = new SqlCommand("Update tblExamenFisico set EstadoGeneral='" + Nuevesito.EstadoGeneral + "',SignosVitales='" + Nuevesito.SignosVitales + "',PresionArterial='" + Nuevesito.PresionArterial + "',FrecuenciaCardiaca='" + Nuevesito.FrecuenciaCardiaca + "',FrecuenciaRespiratoria='" + Nuevesito.FrecuenciaRespiratoria + "',SaturacionOxigeno='" + Nuevesito.SaturacionOxigeno + "',Temperatura='" + Nuevesito.Temperatura + "',Talla='" + Nuevesito.Talla + "',Peso='" + Nuevesito.Peso + "'where Paciente='" + Actualizar + "'", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Examen modificado");
        }

    }
}
