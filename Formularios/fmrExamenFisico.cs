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
    public partial class fmrExamenFisico : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public fmrExamenFisico()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblExamenFisico", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void fmrExamenFisico_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int Consultar = frmCita.Cedula;
                cmd = new SqlCommand("select * from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int Consultar = frmCita.Cedula;
            int Talla = Convert.ToInt32(txtTalla.Text);
            int Peso = Convert.ToInt32(txtPeso.Text);
            frmExamenFisico Fisico = new frmExamenFisico(Consultar, txtGeneral.Text, txtSignos.Text, txtPresion.Text, txtFrecuencia.Text, txtRespiratoria.Text, txtSaturacion.Text, txtTemperatura.Text, Talla, Peso);
            Fisico.Agregar(Fisico);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int Consultar = frmCita.Cedula;
            int Talla = Convert.ToInt32(txtTalla.Text);
            int Peso = Convert.ToInt32(txtPeso.Text);
            frmExamenFisico Fisico = new frmExamenFisico(Consultar, txtGeneral.Text, txtSignos.Text, txtPresion.Text, txtFrecuencia.Text, txtRespiratoria.Text, txtSaturacion.Text, txtTemperatura.Text, Talla, Peso);
            Fisico.Actualizar(Consultar,Fisico);
        }

        void llenar(DataTable dt, int i)
        {
            txtGeneral.Text = dt.Rows[i][1].ToString();
            txtSignos.Text = dt.Rows[i][2].ToString();
            txtPresion.Text = dt.Rows[i][3].ToString();
            txtFrecuencia.Text = dt.Rows[i][4].ToString();
            txtRespiratoria.Text = dt.Rows[i][5].ToString();
            txtSaturacion.Text = dt.Rows[i][6].ToString();
            txtTemperatura.Text = dt.Rows[i][7].ToString();
            txtTalla.Text = dt.Rows[i][8].ToString();
            txtPeso.Text = dt.Rows[i][9].ToString();
            contador = dt.Rows.Count;
            CalcularIMC();
            
        }

        void Limpiar()
        {
            txtGeneral.Text = "";
            txtSignos.Text = "";
            txtPresion.Text = "";
            txtFrecuencia.Text = "";
            txtRespiratoria.Text = "";
            txtSaturacion.Text = "";
            txtTemperatura.Text = "";
            txtTalla.Text = "";
            txtPeso.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        void CalcularIMC()
        {
            double IMC;
            double Talla = Convert.ToDouble(txtTalla.Text);
            double Peso = Convert.ToDouble(txtPeso.Text);
            double Metros = Talla / 100;
            double cuadrado = Metros * Metros;
            IMC = Peso / cuadrado;
            txtIMC.Text = IMC.ToString();
        }
    }
}
