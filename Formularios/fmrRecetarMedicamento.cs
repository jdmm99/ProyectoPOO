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
    public partial class fmrRecetarMedicamento : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public fmrRecetarMedicamento()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from HistoriaMedicamento", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //int Medicamento;
            int CodigoHistoria = frmCita.CodigoHistoria;
            //frmMedicamentos Medicamentos = new frmMedicamentos(cmbNombre.Text, Convert.ToInt32(txtCantidad.Text), txtDescripcion.Text);
            //Medicamento = Medicamentos.Agregar(Medicamentos);
            ////Medicamentos.Agregar(Medicamentos);
            //AsignarMedicamento(Medicamento,CodigoHistoria);
            GuardarMedicamento(CodigoHistoria);

        }

        //void AsignarMedicamento(int Medicamento,int CodigoHistoria)
        //{
        //    SqlCommand cmd = new SqlCommand("insert into HistoriaMedicamento values('" + Medicamento + "','" + CodigoHistoria + "')", cn.AbrirConexion());
        //    cmd.ExecuteNonQuery();
        //    MessageBox.Show("Medicamento asignado");
        //}

        void Limpiar()
        {
            //txtCodigo.Text = "";
            cmbNombre.Text = "";
            txtCantidad.Text = "";
            txtDescripcion.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        void GuardarMedicamento(int CodigoHistoria)
        {
            // Insertar el medicamento y obtener su código generado
            string query = "INSERT INTO tblMedicamento (Nombre, Cantidad, Descripcion) VALUES (@Nombre, @Cantidad, @Descripcion); SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, cn.AbrirConexion()))
            {
                cmd.Parameters.AddWithValue("@Nombre", cmbNombre.Text);
                cmd.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtCantidad.Text));
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);

                // Obtener el código del medicamento generado
                int codigoMedicamento = Convert.ToInt32(cmd.ExecuteScalar());

                // Asignar el medicamento a la historia
                AsignarMedicamento(codigoMedicamento, CodigoHistoria);
            }
        }

        void AsignarMedicamento(int Medicamento, int CodigoHistoria)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO HistoriaMedicamento VALUES (@Medicamento, @CodigoHistoria)", cn.AbrirConexion());
            cmd.Parameters.AddWithValue("@Medicamento", Medicamento);
            cmd.Parameters.AddWithValue("@CodigoHistoria", CodigoHistoria);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Medicamento asignado");
        }


    }
}
