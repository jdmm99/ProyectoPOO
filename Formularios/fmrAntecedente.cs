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
    public partial class fmrAntecedente : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public fmrAntecedente()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblAntecedentes", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int Consultar = frmCita.Cedula;
            frmAntecedentes Antecendentes = new frmAntecedentes(Consultar, txtFamiliar.Text, txtGinecologicos.Text, txtObstetricos.Text, txtToxicologicos.Text, txtFarmacologicos.Text, txtPatologicos.Text, txtQuirurjicos.Text, txtTraumaticos.Text);
            Antecendentes.Agregar(Antecendentes);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int Consultar = frmCita.Cedula;
                cmd = new SqlCommand("select * from tblAntecedentes where Paciente='" + Consultar + "'", cn.AbrirConexion());
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
            int Consultar = frmCita.Cedula;
            frmAntecedentes Antecendentes = new frmAntecedentes(Consultar, txtFamiliar.Text, txtGinecologicos.Text, txtObstetricos.Text, txtToxicologicos.Text, txtFarmacologicos.Text, txtPatologicos.Text, txtQuirurjicos.Text, txtTraumaticos.Text);
            Antecendentes.Actualizar(Consultar,Antecendentes);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFamiliar.Text = "";
            txtGinecologicos.Text = "";
            txtObstetricos.Text = "";
            txtToxicologicos.Text = "";
            txtFarmacologicos.Text = "";
            txtPatologicos.Text = "";
            txtQuirurjicos.Text = "";
            txtTraumaticos.Text = "";
        }

        void llenar(DataTable dt, int i)
        {
            txtFamiliar.Text = dt.Rows[i][1].ToString();
            txtGinecologicos.Text = dt.Rows[i][2].ToString();
            txtObstetricos.Text = dt.Rows[i][3].ToString();
            txtToxicologicos.Text = dt.Rows[i][4].ToString();
            txtFarmacologicos.Text = dt.Rows[i][5].ToString();
            txtPatologicos.Text = dt.Rows[i][6].ToString();
            txtQuirurjicos.Text = dt.Rows[i][7].ToString();
            txtTraumaticos.Text = dt.Rows[i][8].ToString();
            contador = dt.Rows.Count;
        }
    }
}
