using Proyecto.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Formularios
{
    public partial class fmrImagenesMedico : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int contador, i, boton;

        public fmrImagenesMedico()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblImagenes", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            DialogResult resultado = dialogo.ShowDialog();
            if(resultado == DialogResult.OK)
            {
                ptbImagen.Image = Image.FromFile(dialogo.FileName);
                ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int Historia = frmCita.CodigoHistoria;
            MemoryStream archivoMemoria = new MemoryStream();
            string rpt;

            cn.AbrirConexion();
            cmd.Connection = cn.Conexion;

            ptbImagen.Image.Save(archivoMemoria,ImageFormat.Bmp);

            cmd.CommandText = "spininsertar_imagen";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Historia", Historia);
            cmd.Parameters.AddWithValue("@NumeroImagen", Convert.ToInt32(txtCodigo.Text));
            cmd.Parameters.AddWithValue("@Imagen", archivoMemoria.GetBuffer());

            rpt = cmd.ExecuteNonQuery() > 0 ? "Se guardo la imagen" : "No se guardo la imagen";
            MessageBox.Show(rpt);
            cn.CerrarConexion();
            txtCodigo.Clear();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                int Historia = frmCita.CodigoHistoria;
                //DataTable tabla = new DataTable();

                //cn.AbrirConexion();
                //cmd.Connection = cn.Conexion;

                //cmd.CommandText = "spmostrar_imagen";
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@Historia", Historia);

                //da.Fill(tabla);

                //Byte[] Archivo = (byte[])tabla.Rows[0]["Imagen"];

                //Stream imagenn = new MemoryStream(Archivo);

                //ptbImagen.Image = Image.FromStream(imagenn);
                //ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                //cn.CerrarConexion();
                //int Historia = Convert.ToInt32(txtCodigo.Text);
                cn = new Cconexion();
                cmd = new SqlCommand("select Imagen from tblImagenes where Historia =" + Historia, cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                Byte[] Archivo = (byte[])dt.Rows[0][0];

                Stream imagenn = new MemoryStream(Archivo);

                ptbImagen.Image = Image.FromStream(imagenn);
                ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                Label();
                if (dt.Rows.Count > 1)
                {
                    btnAnterior.Visible = true;
                    btnSiguiente.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese la informacióm correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void llenar(DataTable dt, int i)
        {
            int Historia = frmCita.CodigoHistoria;
            cn = new Cconexion();
            cmd = new SqlCommand("select Imagen from tblImagenes where Historia =" + Historia, cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            Byte[] Archivo = (byte[])dt.Rows[i][0];

            Stream imagenn = new MemoryStream(Archivo);
            
            ptbImagen.Image = Image.FromStream(imagenn);
            ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            Label();
            //almacena la cantidad de registro al consultar
            contador = dt.Rows.Count;
        }

        void Label()
        {
            int Historia = frmCita.CodigoHistoria;
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblImagenes where Historia =" + Historia, cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            txtCodigo.Text = dt.Rows[i][1].ToString();
        }
    }
}
