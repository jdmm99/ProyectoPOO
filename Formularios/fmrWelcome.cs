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
    public partial class fmrWelcome : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public fmrWelcome()
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
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }

        private void fmrWelcome_Load(object sender, EventArgs e)
        {
            switch (fmrInicio.Conta)
            {
                case 1:
                    int Admon = fmrInicio.CedulaAdmon;
                    cmd = new SqlCommand("select * from tblAdministrador where IdAdmin='" + Admon + "'", cn.AbrirConexion());
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    lblNombre.Text = "Bienvenid@ a nuestro sistema" + " " + dt.Rows[0][2].ToString();
                    break;
                case 2:
                    int Paciente = fmrInicio.CedulaPaciente;
                    cmd = new SqlCommand("select * from tblPaciente where IdPaciente='" + Paciente + "'", cn.AbrirConexion());
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    lblNombre.Text = "Bienvenid@ a nuestro sistema" + " " + dt.Rows[0][2].ToString();
                    break;
                case 3:
                    int Medico = fmrInicio.CedulaMedico;
                    cmd = new SqlCommand("select * from tblMedico where IdMedico='" + Medico + "'", cn.AbrirConexion());
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    lblNombre.Text = "Bienvenid@ a nuestro sistema" + " " + dt.Rows[0][2].ToString();
                    break;
            }
            this.Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            timer1.Start();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
