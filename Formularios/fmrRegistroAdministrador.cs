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
    public partial class fmrRegistroAdministrador : Form
    {
        frmRegistrarAdministrador Administrador;
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i = 0;

        public fmrRegistroAdministrador()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblAdministrador", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int doc = Convert.ToInt32(txtDocumento.Text);
            Administrador = new frmRegistrarAdministrador(Convert.ToInt32(txtDocumento.Text), cmbTipoDocumento.Text, txtNombre.Text, txtApellidos.Text, cmbSexo.Text, txtFecha.Text, txtDireccion.Text, txtDepartamento.Text, txtCiudad.Text, txtTelefono.Text, txtCorreo.Text, txtContraseña.Text);
            Administrador.Actualizar(doc, Administrador);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmRegistrarAdministrador Hola = new frmRegistrarAdministrador();
            int doc = Convert.ToInt32(txtDocumento.Text);
            Hola.Eliminar(doc);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from tblAdministrador where IdAdmin='" + Convert.ToInt32(txtDocumento.Text) + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            i = 0;
            llenar(dt, i);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Administrador = new frmRegistrarAdministrador(Convert.ToInt32(txtDocumento.Text), cmbTipoDocumento.Text, txtNombre.Text, txtApellidos.Text, cmbSexo.Text, txtFecha.Text, txtDireccion.Text, txtDepartamento.Text, txtCiudad.Text, txtTelefono.Text, txtCorreo.Text, txtContraseña.Text);
            Administrador.Agregar(Administrador);
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
            cmbSexo.Text = dt.Rows[i][4].ToString();
            txtFecha.Text = dt.Rows[i][5].ToString();
            txtDireccion.Text = dt.Rows[i][6].ToString();
            txtDepartamento.Text = dt.Rows[i][7].ToString();
            txtCiudad.Text = dt.Rows[i][8].ToString();
            txtTelefono.Text = dt.Rows[i][9].ToString();
            txtCorreo.Text = dt.Rows[i][10].ToString();
            txtContraseña.Text = dt.Rows[i][11].ToString();
            contador = dt.Rows.Count;
        }


    }
}
