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
    public partial class fmrConsulta : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i, Consultica = 0;
        public fmrConsulta()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblConsulta", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try { 
            int Historias = frmCita.CodigoHistoria;
            cmd = new SqlCommand("select * from tblConsulta where Historia='" + Historias + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            i = 0;
            llenar(dt, i);
            }
            catch
            {
                MessageBox.Show("Ingrese la informacióm correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int Historias = frmCita.CodigoHistoria;
            frmConsulta Consulta
                = new frmConsulta(Historias, txtMotivo.Text, txtDescripcion.Text, txtRecomendaciones.Text);
            Consulta.Actualizar(Historias,Consulta);
        }

        private void fmrConsulta_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMotivo.Text = "";
            txtDescripcion.Text = "";
            txtRecomendaciones.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int Historias = frmCita.CodigoHistoria;
            frmConsulta Consulta
                = new frmConsulta(Historias, txtMotivo.Text, txtDescripcion.Text, txtRecomendaciones.Text);
            Consulta.Agregar(Consulta);
        }

        void llenar(DataTable dt, int i)
        {
            txtMotivo.Text = dt.Rows[i][1].ToString();
            txtDescripcion.Text = dt.Rows[i][2].ToString();
            txtRecomendaciones.Text = dt.Rows[i][3].ToString();
            contador = dt.Rows.Count;
        }
    }
}
