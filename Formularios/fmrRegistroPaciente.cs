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
    public partial class fmrRegistroPaciente : Form
    {
        frmRegistrarPaciente Paciente;
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;


        public fmrRegistroPaciente()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblPaciente", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

        }    

        private void fmrPaciente_Load(object sender, EventArgs e)
        {
            ptrimagen1.BackColor = Color.Transparent;
            ptrimagen2.BackColor = Color.Transparent;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Paciente = new frmRegistrarPaciente(Convert.ToInt32(txtDocumento.Text), cmbTipoDocumento.Text, txtNombre.Text, txtApellidos.Text, cmbSexoPaciente.Text, txtFecha.Text, txtDireccion.Text, txtDepartamento.Text, txtCiudad.Text, txtTelefono.Text, txtCorreo.Text, txtContraseña.Text, txtEPS.Text);
            Paciente.Agregar(Paciente);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmRegistrarPaciente Hola = new frmRegistrarPaciente();
            int doc = Convert.ToInt32(txtDocumento.Text);
            Hola.Eliminar(doc);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from tblPaciente where IdPaciente='" + Convert.ToInt32(txtDocumento.Text) + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            i = 0;
            llenar(dt, i);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int doc = Convert.ToInt32(txtDocumento.Text);
            Paciente = new frmRegistrarPaciente(Convert.ToInt32(txtDocumento.Text),cmbTipoDocumento.Text, txtNombre.Text, txtApellidos.Text, cmbSexoPaciente.Text, txtFecha.Text, txtDireccion.Text, txtDepartamento.Text, txtCiudad.Text, txtTelefono.Text, txtCorreo.Text, txtContraseña.Text, txtEPS.Text);
            Paciente.Actualizar(doc,Paciente);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            fmrInicio Ini = new fmrInicio();
            Ini.Show();
            this.Hide();
        }

        void llenar(DataTable dt, int i)
        {
            txtDocumento.Text = dt.Rows[i][0].ToString();
            cmbTipoDocumento.Text = dt.Rows[i][1].ToString();
            txtNombre.Text = dt.Rows[i][2].ToString();
            txtApellidos.Text = dt.Rows[i][3].ToString();
            cmbSexoPaciente.Text = dt.Rows[i][4].ToString();
            txtEPS.Text = dt.Rows[i][5].ToString();
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
