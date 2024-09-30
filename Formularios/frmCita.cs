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
using System.Drawing.Imaging;
using System.IO;

namespace Proyecto.Formularios
{
    public partial class frmCita : Form
    {
        public static int CodigoHistoria { get; set; }
        frmHistoriaMedica Historia;
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i,Consultica = 0;
        public static int Cedula {  get; set; }

        public frmCita()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblPaciente", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHoras.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private Form activeForm = null;

        private void AbrirenPanel(Form fmrHijo)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = fmrHijo;
            fmrHijo.TopLevel = false;
            fmrHijo.FormBorderStyle = FormBorderStyle.None;
            fmrHijo.Dock = DockStyle.Fill;
            pnlCentral.Controls.Add(fmrHijo);
            pnlCentral.Tag = fmrHijo;
            fmrHijo.BringToFront();
            fmrHijo.BringToFront();
            fmrHijo.Show();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrConsulta());
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrRevisionSistema());
        }

        private void frmCita_Load(object sender, EventArgs e)
        {

        }

        private void btnFisica_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrExamenFisico());
        }

        private void btnAntecedentes_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrAntecedente());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            fmrCerrarSesion close = new fmrCerrarSesion();
            close.ShowDialog();
            fmrInicio Ini = new fmrInicio();
            Ini.Show();
        }

        private void btnRecetar_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrRecetarMedicamento());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * from tblPaciente where IdPaciente='" + Convert.ToInt32(txtDocumento.Text) + "'", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                i = 0;
                llenarPacienteDatos(dt, i);
                cmd = new SqlCommand("select * from tblHistoria where Paciente='" + Convert.ToInt32(txtDocumento.Text) + "'", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                i = 0;
                if (dt.Rows.Count > 0)
                {
                    llenarHistoria(dt, i);
                }
                Cedula = Convert.ToInt32(txtDocumento.Text);
                CodigoHistoria = Convert.ToInt32(txtHistoria.Text);
            }
            catch
            {
                MessageBox.Show("Ingrese la informacióm correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void llenarPacienteDatos(DataTable dt, int i)
        {
            txtDocumento.Text = dt.Rows[i][0].ToString();
            txtNombre.Text = dt.Rows[i][2].ToString();
            txtApellido.Text = dt.Rows[i][3].ToString();
            cmbSexo.Text = dt.Rows[i][4].ToString();
            txtEPS.Text = dt.Rows[i][5].ToString();
            txtDireccion.Text = dt.Rows[i][7].ToString();
            contador = dt.Rows.Count;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Historia = new frmHistoriaMedica(Convert.ToInt32(txtHistoria.Text), Convert.ToInt32(txtDocumento.Text), cmbTipoSangre.Text, txtAcompañante.Text, txtParentesco.Text, txtResponsable.Text);
            Historia.Agregar(Historia);
            CodigoHistoria = Convert.ToInt32(txtHistoria.Text);
        }

        private void btnImagenes_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrImagenesMedico());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtHistoria.Text = "";
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEPS.Text = "";
            cmbSexo.Text = "";
            cmbTipoSangre.SelectedIndex = -1;
            txtDireccion.Text = "";
            txtAcompañante.Text = "";
            txtParentesco.Text = "";
            txtResponsable.Text = "";
        }

        void llenarHistoria(DataTable dt, int i)
        {
            txtHistoria.Text= dt.Rows[i][0].ToString();
            cmbTipoSangre.Text = dt.Rows[i][2].ToString();
            txtAcompañante.Text = dt.Rows[i][3].ToString();
            txtParentesco.Text = dt.Rows[i][4].ToString();
            txtResponsable.Text = dt.Rows[i][5].ToString();
            contador = dt.Rows.Count;
        }
    }
}
