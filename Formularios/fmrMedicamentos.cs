using Proyecto.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Formularios
{
    public partial class fmrMedicamentos : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public fmrMedicamentos()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblMedicamento", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

        }

        private void fmrMedicamentos_Load(object sender, EventArgs e)
        {
            llenarMedicamento();
            Recomendaciones();
            ProximoControl();
        }

        void llenarMedicamento()
        {
            int n = 0;
            int Paciente = fmrInicio.CedulaPaciente;
            SqlCommand cmd = new SqlCommand("select tblMedicamento.CodigoMedicamento,tblMedicamento.Nombre,tblMedicamento.Cantidad,tblMedicamento.Descripcion from tblMedicamento join HistoriaMedicamento on tblMedicamento.CodigoMedicamento= HistoriaMedicamento.Medicamento join tblHistoria on HistoriaMedicamento.HistoriaClinica = tblHistoria.CodigoHistoria where tblHistoria.Paciente='" + Paciente + "'", cn.AbrirConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                n = dt.Rows.Count;
                if (n>1)
                {
                    dgvMedicamentos.Rows.Add(n - 1);
                }     
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvMedicamentos.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dgvMedicamentos.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dgvMedicamentos.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dgvMedicamentos.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                }
            }
        }

        void Recomendaciones()
        {
            int Paciente = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select tblConsulta.Recomendaciones from tblConsulta join tblHistoria on tblConsulta.Historia = tblHistoria.CodigoHistoria join tblPaciente on tblPaciente.IdPaciente = tblHistoria.Paciente where tblPaciente.IdPaciente ='" + Paciente + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            txtRecomendaciones.Text = dt.Rows[0][0].ToString();
            
        }

        void ProximoControl()
        {
            int Paciente = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Dias from tblCita where Paciente ='" + Paciente + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtProximo.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                txtProximo.Text = "No tienes proximo control";
            }
            
        }
    }
}
