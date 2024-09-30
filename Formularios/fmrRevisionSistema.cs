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
    public partial class fmrRevisionSistema : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;
        
        public fmrRevisionSistema()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblRevisionSistema", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int Consultar = frmCita.Cedula;
                cmd = new SqlCommand("select * from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
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

        private void button1_Click(object sender, EventArgs e)
        {
            int Consultar = frmCita.Cedula;
            frmRevisionSistem Sistema = new frmRevisionSistem(Consultar, txtCabeza.Text, txtCuello.Text, txtTorax.Text, txtCorazon.Text, txtPulmon.Text, txtAbdomen.Text, txtOsteoMuscular.Text, txtNeurologico.Text, txtVascular.Text, txtGenitourinario.Text);
            Sistema.Agregar(Sistema);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int Consultar = frmCita.Cedula;
            frmRevisionSistem Sistema = new frmRevisionSistem(Consultar, txtCabeza.Text, txtCuello.Text, txtTorax.Text, txtCorazon.Text, txtPulmon.Text, txtAbdomen.Text, txtOsteoMuscular.Text, txtNeurologico.Text, txtVascular.Text, txtGenitourinario.Text);
            Sistema.Actualizar(Consultar,Sistema);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCabeza.Text = "";
            txtCuello.Text = "";
            txtTorax.Text = "";
            txtCorazon.Text = "";
            txtPulmon.Text = "";
            txtAbdomen.Text = "";
            txtOsteoMuscular.Text = "";
            txtNeurologico.Text = "";
            txtVascular.Text = "";
            txtGenitourinario.Text = "";
        }

        void llenar(DataTable dt, int i)
        {
            txtCabeza.Text = dt.Rows[i][1].ToString();
            txtCuello.Text = dt.Rows[i][2].ToString();
            txtTorax.Text = dt.Rows[i][3].ToString();
            txtCorazon.Text = dt.Rows[i][4].ToString();
            txtPulmon.Text = dt.Rows[i][5].ToString();
            txtAbdomen.Text = dt.Rows[i][6].ToString();
            txtOsteoMuscular.Text = dt.Rows[i][7].ToString();
            txtNeurologico.Text = dt.Rows[i][8].ToString();
            txtVascular.Text = dt.Rows[i][9].ToString();
            txtGenitourinario.Text = dt.Rows[i][10].ToString();
            contador = dt.Rows.Count;
        }
    }
}
