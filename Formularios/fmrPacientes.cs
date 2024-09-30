using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml.html.table;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Element;
using iText.Layout.Properties;
using iTextSharp.tool.xml.html.table;
using Proyecto.Clases;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Proyecto.Formularios
{
    public partial class fmrPacientes : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int i = 0;

        public fmrPacientes()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblPaciente", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        
        private void fmrPacientes_Load(object sender, EventArgs e)
        {
            
        }

        private void tmrHoraFecha_Tick(object sender, EventArgs e)
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

        private string consultafamiliares()
        {
            string familiares = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Familiar from tblAntecedentes where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Familiar"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                familiares = sb.ToString().TrimEnd(' ', ',');
            }
            return familiares;
        }

        private string consultaginecologicos()
        {
            string ginecologicos = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Ginecologicos from tblAntecedentes where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Ginecologicos"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                ginecologicos = sb.ToString().TrimEnd(' ', ',');
            }
            return ginecologicos;
        }

        private string consultaobstetricos()
        {
            string obstetricos = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Obstetricos from tblAntecedentes where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Obstetricos"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                obstetricos = sb.ToString().TrimEnd(' ', ',');
            }
            return obstetricos;
        }

        private string consultatoxicologicos()
        {
            string toxicologicos = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Toxicologicos from tblAntecedentes where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Toxicologicos"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                toxicologicos = sb.ToString().TrimEnd(' ', ',');
            }
            return toxicologicos;
        }

        private string consultafarmacologicos()
        {
            string farmacologicos = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Farmacologicos from tblAntecedentes where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Farmacologicos"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                farmacologicos = sb.ToString().TrimEnd(' ', ',');
            }
            return farmacologicos;
        }

        private string cosultapatologicos()
        {
            string patologicos = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Patologicos from tblAntecedentes where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Patologicos"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                patologicos = sb.ToString().TrimEnd(' ', ',');
            }
            return patologicos;
        }

        private string consultaquirurgicos()
        {
            string quirurgicos = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Quirurgicos from tblAntecedentes where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Quirurgicos"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                quirurgicos = sb.ToString().TrimEnd(' ', ',');
            }
            return quirurgicos;
        }

        private string consultatraumaticos()
        {
            string traumaticos = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Traumaticos from tblAntecedentes where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Traumaticos"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                traumaticos = sb.ToString().TrimEnd(' ', ',');
            }
            return traumaticos;
        }

        private string consultaestadogeneral()
        {
            string estadogeneral = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select EstadoGeneral from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["EstadoGeneral"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                estadogeneral = sb.ToString().TrimEnd(' ', ',');
            }
            return estadogeneral;
        }

        private string consultasignosvitales()
        {
            string signosvitales = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select SignosVitales from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["SignosVitales"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                signosvitales = sb.ToString().TrimEnd(' ', ',');
            }
            return signosvitales;
        }

        private string consultapresionarterial()
        {
            string presionarterial = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select PresionArterial from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["PresionArterial"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                presionarterial = sb.ToString().TrimEnd(' ', ',');
            }
            return presionarterial;
        }

        private string consultafrecuenciacardiaca()
        {
            string frecuenciacardiaca = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select FrecuenciaCardiaca from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["FrecuenciaCardiaca"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                frecuenciacardiaca = sb.ToString().TrimEnd(' ', ',');
            }
            return frecuenciacardiaca;
        }

        private string conusltafrecuenciarespiratoria()
        {
            string frecuenciarespiratoria = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select FrecuenciaRespiratoria from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["FrecuenciaRespiratoria"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                frecuenciarespiratoria = sb.ToString().TrimEnd(' ', ',');
            }
            return frecuenciarespiratoria;
        }

        private string consultasaturacionoxigeno()
        {
            string saturacionoxigeno = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select SaturacionOxigeno from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["SaturacionOxigeno"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                saturacionoxigeno = sb.ToString().TrimEnd(' ', ',');
            }
            return saturacionoxigeno;
        }

        private string consultatemperatura()
        {
            string temperatura = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Temperatura from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Temperatura"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                temperatura = sb.ToString().TrimEnd(' ', ',');
            }
            return temperatura;
        }

        private string conusultatalla()
        {
            string talla = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Talla from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Talla"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                talla = sb.ToString().TrimEnd(' ', ',');
            }
            return talla;
        }

        private string consultapeso()
        {
            string peso = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Peso from tblExamenFisico where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Peso"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                peso = sb.ToString().TrimEnd(' ', ',');
            }
            return peso;
        }

        private string consultacabeza()
        {
            string cabeza = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Cabeza from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Cabeza"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                cabeza = sb.ToString().TrimEnd(' ', ',');
            }
            return cabeza;
        }

        private string consultacuello()
        {
            string cuello = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Cuello from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Cuello"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                cuello = sb.ToString().TrimEnd(' ', ',');
            }
            return cuello;
        }

        private string conusultatorax()
        {
            string torax = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Torax from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Torax"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                torax = sb.ToString().TrimEnd(' ', ',');
            }
            return torax;
        }

        private string conusltacorazon()
        {
            string corazon = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Corazon from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Corazon"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                corazon = sb.ToString().TrimEnd(' ', ',');
            }
            return corazon;
        }

        private string consultapulmon()
        {
            string pulmon = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Pulmon from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Pulmon"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                pulmon = sb.ToString().TrimEnd(' ', ',');
            }
            return pulmon;
        }

        private string consultarabdomen()
        {
            string abdomen = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Abdomen from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Abdomen"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                abdomen = sb.ToString().TrimEnd(' ', ',');
            }
            return abdomen;
        }

        private string consultaosteomuscular()
        {
            string osteomuscular = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select OsteoMuscular from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["OsteoMuscular"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                osteomuscular = sb.ToString().TrimEnd(' ', ',');
            }
            return osteomuscular;
        }

        private string consultaNeurologico()
        {
            string neurologico = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Neurologico from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Neurologico"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                neurologico = sb.ToString().TrimEnd(' ', ',');
            }
            return neurologico;
        }

        private string consultavascular()
        {
            string vascular = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Vascular from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Vascular"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                vascular = sb.ToString().TrimEnd(' ', ',');
            }
            return vascular;
        }

        private string consultargenitourinario()
        {
            string genito = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select GenitoUrinario from tblRevisionSistema where Paciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["GenitoUrinario"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                genito = sb.ToString().TrimEnd(' ', ',');
            }
            return genito;
        }

        private string consultarecomendaciones()
        {
            string recomendaciones = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select tblConsulta.Recomendaciones from tblConsulta join tblHistoria on tblConsulta.Historia = tblHistoria.CodigoHistoria where tblHistoria.Paciente ='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Recomendaciones"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                recomendaciones = sb.ToString().TrimEnd(' ', ',');
            }
            return recomendaciones;
        }

        private string consultanombre()
        {
            string nombre = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Nombre from tblPaciente where IdPaciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Nombre"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                nombre = sb.ToString().TrimEnd(' ', ',');
            }
            return nombre;
        }

        private string consultaapellido()
        {
            string apellido = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Apellidos from tblPaciente where IdPaciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Apellidos"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                apellido = sb.ToString().TrimEnd(' ', ',');
            }
            return apellido;
        }

        private string consultasexo()
        {
            string sexo = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Sexo from tblPaciente where IdPaciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Sexo"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                sexo = sb.ToString().TrimEnd(' ', ',');
            }
            return sexo;
        }

        private string consultadocumento()
        {
            string id = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select IDPaciente from tblPaciente where IdPaciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["IdPaciente"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                id = sb.ToString().TrimEnd(' ', ',');
            }
            return id;
        }

        private string consultatelefono()
        {
            string telefono = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Telefono from tblPaciente where IdPaciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Telefono"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                telefono = sb.ToString().TrimEnd(' ', ',');
            }
            return telefono;
        }

        private string consultacorreo()
        {
            string correo = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Correo from tblPaciente where IdPaciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Correo"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                correo = sb.ToString().TrimEnd(' ', ',');
            }
            return correo;
        }

        private string consultadireccion()
        {
            string direccion = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select Direccion from tblPaciente where IdPaciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["Direccion"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                direccion = sb.ToString().TrimEnd(' ', ',');
            }
            return direccion;
        }

        private string consultaexpediente()
        {
            string expediente = "";
            int Consultar = fmrInicio.CedulaPaciente;
            cmd = new SqlCommand("select tblHistoria.CodigoHistoria from tblHistoria inner join tblPaciente on tblHistoria.Paciente=tblPaciente.IdPaciente where IdPaciente='" + Consultar + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Assuming you want to concatenate multiple family member names if there are multiple rows.
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row["CodigoHistoria"].ToString()).Append(", ");
                }

                // Remove the trailing comma and space
                expediente = sb.ToString().TrimEnd(' ', ',');
            }
            return expediente;
        }

        private void btnHistoria_Click_1(object sender, EventArgs e)
        {

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = ("HistoriaClinica.pdf") + ".pdf";


            string paginahtml_text = Properties.Resources.diseñopedf.ToString();

            paginahtml_text = paginahtml_text.Replace("@nombre", consultanombre());
            paginahtml_text = paginahtml_text.Replace("@apellido", consultaapellido());
            paginahtml_text = paginahtml_text.Replace("@sexo", consultasexo());
            paginahtml_text = paginahtml_text.Replace("@direccion", consultadireccion());
            paginahtml_text = paginahtml_text.Replace("@telefono", consultatelefono());
            paginahtml_text = paginahtml_text.Replace("@talla", conusultatalla());
            paginahtml_text = paginahtml_text.Replace("@peso", consultapeso());
            paginahtml_text = paginahtml_text.Replace("@correo", consultacorreo());
            paginahtml_text = paginahtml_text.Replace("@documento", consultadocumento());
            paginahtml_text = paginahtml_text.Replace("@noexpediente", consultaexpediente());


            paginahtml_text = paginahtml_text.Replace("@familiares", consultafamiliares());
            paginahtml_text = paginahtml_text.Replace("@ginecologicos", consultaginecologicos());
            paginahtml_text = paginahtml_text.Replace("@obstetricos", consultaobstetricos());
            paginahtml_text = paginahtml_text.Replace("@toxicologicos", consultatoxicologicos());
            paginahtml_text = paginahtml_text.Replace("@farmacologicos", consultafarmacologicos());
            paginahtml_text = paginahtml_text.Replace("@patologicos", cosultapatologicos());
            paginahtml_text = paginahtml_text.Replace("@quirurgicos", consultaquirurgicos());
            paginahtml_text = paginahtml_text.Replace("@traumaticos", consultatraumaticos());
            paginahtml_text = paginahtml_text.Replace("@estadogeneral", consultaestadogeneral());
            paginahtml_text = paginahtml_text.Replace("@signosvitales", consultasignosvitales());
            paginahtml_text = paginahtml_text.Replace("@presionarterial", consultapresionarterial());
            paginahtml_text = paginahtml_text.Replace("@frecuenciacardiaca", consultafrecuenciacardiaca());
            paginahtml_text = paginahtml_text.Replace("@frecienciarespiratoria", conusltafrecuenciarespiratoria());
            paginahtml_text = paginahtml_text.Replace("@saturacionoxigeno", consultasaturacionoxigeno());
            paginahtml_text = paginahtml_text.Replace("@temperatura", consultatemperatura());
            paginahtml_text = paginahtml_text.Replace("@talla", conusultatalla());
            paginahtml_text = paginahtml_text.Replace("@peso", consultapeso());
            paginahtml_text = paginahtml_text.Replace("@cabeza", consultacabeza());
            paginahtml_text = paginahtml_text.Replace("@cuello", consultacuello());
            paginahtml_text = paginahtml_text.Replace("@torax", conusultatorax());
            paginahtml_text = paginahtml_text.Replace("@corazon", conusltacorazon());
            paginahtml_text = paginahtml_text.Replace("@pulmon", consultapulmon());
            paginahtml_text = paginahtml_text.Replace("@abdomen", consultarabdomen());
            paginahtml_text = paginahtml_text.Replace("@osteomuscular", consultaosteomuscular());
            paginahtml_text = paginahtml_text.Replace("@neurologico", consultaNeurologico());
            paginahtml_text = paginahtml_text.Replace("@vascular", consultavascular());
            paginahtml_text = paginahtml_text.Replace("@genitourinario", consultargenitourinario());
            paginahtml_text = paginahtml_text.Replace("@recomendaciones", consultarecomendaciones());
            //asi mismo para todos los campos que se necesiten llenar


            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Properties.Resources.Holi, System.Drawing.Imaging.ImageFormat.Png);

                    logo.ScaleToFit(250, 180);
                    logo.Alignment = iTextSharp.text.Image.UNDERLYING;
                    //logo.SetAbsolutePosition(pdfDoc.TopMargin,pdfDoc.RightMargin);
                    logo.SetAbsolutePosition(460, 600);
                    pdfDoc.Add(logo);

                    using (StringReader sr = new StringReader(paginahtml_text))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    //iText.Kernel.Font.PdfFont fontcolumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    //iText.Kernel.Font.PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    float[] tamano = { 2, 4 };
                    string[] Columnas = { "Medicamento", "Descripcion" };

                    PdfPTable tabla_medicamentos = new PdfPTable(2); // 2 columnas
                    tabla_medicamentos.TotalWidth = 100f; // Ancho total de la tabla (100%)
                    float[] columnWidths = new float[] { 2f, 4f }; // Ancho relativo de las columnas

                    tabla_medicamentos.SetWidths(columnWidths);

                    foreach (string columna in Columnas)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(columna));
                        tabla_medicamentos.AddCell(cell);
                    }



                    int Consultar = fmrInicio.CedulaPaciente;
                    cmd = new SqlCommand("select tblMedicamento.Nombre,tblMedicamento.Descripcion from tblMedicamento inner join HistoriaMedicamento on tblMedicamento.CodigoMedicamento=HistoriaMedicamento.Medicamento inner join tblHistoria on HistoriaMedicamento.HistoriaClinica=tblHistoria.CodigoHistoria where tblHistoria.Paciente='" + Consultar + "'", cn.AbrirConexion());
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);


                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nombre = reader["Nombre"].ToString();
                        string descripcion = reader["Descripcion"].ToString();

                        PdfPCell cellNombre = new PdfPCell(new Phrase(nombre));
                        PdfPCell cellDescripcion = new PdfPCell(new Phrase(descripcion));

                        tabla_medicamentos.AddCell(cellNombre);
                        tabla_medicamentos.AddCell(cellDescripcion);
                    }

                    // Ahora debes agregar filas de datos a la tabla utilizando tabla_medicamentos.AddCell().

                    pdfDoc.Add(tabla_medicamentos);


                    pdfDoc.Close();
                    stream.Close();
                }



            }
        }

        private void btnMedicamento_Click_1(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrMedicamentos());
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGraficos_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrPacienteHistoria());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            fmrCerrarSesion close = new fmrCerrarSesion();
            close.ShowDialog();
            fmrInicio Ini = new fmrInicio();
            Ini.Show();
            //this.Hide();
        }
    }
}
