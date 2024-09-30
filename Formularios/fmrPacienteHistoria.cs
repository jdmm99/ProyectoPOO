using Proyecto.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Formularios
{
    public partial class fmrPacienteHistoria : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i, boton;

        public fmrPacienteHistoria()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblImagenes", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fmrPacienteHistoria_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            //try
            //{
            //int Historia = Convert.ToInt32(txtCodigo.Text);
            //    DataTable tabla = new DataTable();

            //    cn.AbrirConexion();
            //    cmd.Connection = cn.Conexion;

            //    cmd.CommandText = "spmostrar_imagen";
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.Parameters.AddWithValue("@Historia", Historia);

            //    da.Fill(tabla);

            //    Byte[] Archivo = (byte[])tabla.Rows[0]["Imagen"];

            //    Stream imagenn = new MemoryStream(Archivo);

            //    ptbImagen.Image = Image.FromStream(imagenn);
            //    ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            //    cn.CerrarConexion();
            //}
            //catch (SqlException sqlEx)
            //{
            //    MessageBox.Show("Error de SQL: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Otro error ocurrió: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            try
            {
                int Historia = Convert.ToInt32(txtCodigo.Text);
                cn = new Cconexion();
                cmd = new SqlCommand("select Imagen from tblImagenes where Historia =" + Historia, cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                Byte[] Archivo = (byte[])dt.Rows[0][0];

                Stream imagenn = new MemoryStream(Archivo);

                ptbImagen.Image = Image.FromStream(imagenn);
                ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                if (dt.Rows.Count > 1)
                {
                    btnAnterior.Visible = true;
                    btnSiguiente.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese la informacióm correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Clear();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            i = i - 1;
            if (i == -1)//preguntamos si ya llego al primer registro y mostramos el mensaje
            {
                MessageBox.Show("Este es el primer registro");
                i++;
            }
            llenar(dt, i);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            i++;
            if (i == contador)
            {
                MessageBox.Show("Ya no hay mas");
                i--;
            }

            llenar(dt, i);
        }

        void llenar(DataTable dt, int i)
        {
            int Historia = Convert.ToInt32(txtCodigo.Text);
            cn = new Cconexion();
            cmd = new SqlCommand("select Imagen from tblImagenes where Historia =" + Historia, cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            Byte[] Archivo = (byte[])dt.Rows[i][0];

            Stream imagenn = new MemoryStream(Archivo);

            ptbImagen.Image = Image.FromStream(imagenn);
            ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            //almacena la cantidad de registro al consultar
            contador = dt.Rows.Count;
        }
    }
}
