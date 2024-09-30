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
    public partial class fmrRegistroMedico : Form
    {

        frmRegistrarMedico Medico;
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public fmrRegistroMedico()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblMedico", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void fmrRegistroMedico_Load(object sender, EventArgs e)
        {
            ptrImagendoctor.BackColor = Color.Transparent;
            ptrimagen2.BackColor = Color.Transparent;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from tblMedico where IdMedico='" + Convert.ToInt32(txtDocumento.Text) + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            i = 0;
            llenar(dt, i);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Medico = new frmRegistrarMedico(Convert.ToInt32(txtDocumento.Text), cmbTipoDocumento.Text, txtNombre.Text, txtApellidos.Text, cmbSexo.Text, txtFecha.Text, txtDireccion.Text, txtDepartamento.Text, txtCiudad.Text, txtTelefono.Text, txtCorreo.Text, txtContraseña.Text,cmbEspecialidad.Text);
            Medico.Agregar(Medico);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmRegistrarMedico Hola = new frmRegistrarMedico();
            int doc = Convert.ToInt32(txtDocumento.Text);
            Hola.Eliminar(doc);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int doc = Convert.ToInt32(txtDocumento.Text);
            Medico = new frmRegistrarMedico(Convert.ToInt32(txtDocumento.Text), cmbTipoDocumento.Text, txtNombre.Text, txtApellidos.Text, cmbSexo.Text, txtFecha.Text, txtDireccion.Text, txtDepartamento.Text, txtCiudad.Text, txtTelefono.Text, txtCorreo.Text, txtContraseña.Text, cmbEspecialidad.Text);
            Medico.Actualizar(doc, Medico);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            fmrInicio Ini = new fmrInicio();
            Ini.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void llenar(DataTable dt, int i)
        {
            txtDocumento.Text = dt.Rows[i][0].ToString();
            cmbTipoDocumento.Text = dt.Rows[i][1].ToString();
            txtNombre.Text = dt.Rows[i][2].ToString();
            txtApellidos.Text = dt.Rows[i][3].ToString();
            cmbSexo.Text = dt.Rows[i][4].ToString();
            cmbEspecialidad.Text = dt.Rows[i][5].ToString();
            txtFecha.Text = dt.Rows[i][6].ToString();
            txtDireccion.Text = dt.Rows[i][7].ToString();
            txtDepartamento.Text = dt.Rows[i][8].ToString();
            txtCiudad.Text = dt.Rows[i][9].ToString();
            txtTelefono.Text = dt.Rows[i][10].ToString();
            txtCorreo.Text = dt.Rows[i][11].ToString();
            txtContraseña.Text = dt.Rows[i][12].ToString();
            contador = dt.Rows.Count;
        }
    }
}
