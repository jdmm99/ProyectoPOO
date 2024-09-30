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
    public partial class fmrInicio : Form
    {
        public fmrInicio()
        {
            InitializeComponent();
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblPaciente", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        public static string Cedula;
        public static int CedulaMedico { get; set; }
        public static int CedulaPaciente { get; set; }
        public static int CedulaAdmon { get; set; }
        public static int Conta { get; set; }

        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        

        private void fmrInicio_Load(object sender, EventArgs e)
        {
            lblIniciar.Parent = pictureBox1;
            lblIniciar.BackColor = Color.Transparent;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            switch (cmbTipo.Text)
            {
                case "Administrador":
                    fmrRegistroAdministrador CambioA = new fmrRegistroAdministrador();
                    CambioA.Show();
                    this.Hide();
                break;

                case "Paciente":
                    fmrRegistroPaciente CambioP = new fmrRegistroPaciente();
                    CambioP.Show();
                    this.Hide();
                break;

                case "Medico":
                    fmrRegistroMedico CamvioM = new fmrRegistroMedico();
                    CamvioM.Show();
                    this.Hide();
                break;
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            switch(cmbTipo.Text) 
            {
                case "Administrador":
                    cn = new Cconexion();
                    cmd = new SqlCommand();
                    da = new SqlDataAdapter();
                    dt = new DataTable();
                    CedulaAdmon = Convert.ToInt32(txtUsuario.Text);
                    Conta = 1;

                    string cedula = txtUsuario.Text;
                    string clave = txtContraseña.Text;

                    // consulta SQL para verificar la información de inicio de sesión
                    string query = "SELECT COUNT(*) FROM tblAdministrador WHERE IdAdmin = @cedula AND Contraseña = @clave";

                    try
                    {
                        // establecer la conexión a la base de datos
                        cn.AbrirConexion();

                        // configurar el comando y los parámetros de la consulta SQL
                        cmd.Connection = cn.Conexion;
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        cmd.Parameters.AddWithValue("@clave", clave);

                        // ejecutar la consulta SQL y guardar el resultado en un DataTable
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        // verificar si la consulta SQL devolvió algún resultado
                        int count = Convert.ToInt32(dt.Rows[0][0]);
                        if (count == 1)
                        {
                            // el usuario proporcionó información de inicio de sesión válida, asignar la cédula a la variable global
                            Cedula = cedula;

                            //comprobar si los datos ingresados son de un administrador
                            cmd = new SqlCommand("SELECT COUNT(*) FROM tblAdministrador WHERE IdAdmin = @cedula", cn.Conexion);
                            cmd.Parameters.AddWithValue("@cedula", cedula);
                            da = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);
                            //Si cedula es igual a 1, entonces es un administrador
                            if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                            {
                                // mostrar el formulario del menú
                                this.Hide();
                                fmrWelcome welcome = new fmrWelcome();
                                welcome.ShowDialog();
                                fmrAdministrador Adm = new fmrAdministrador();
                                Adm.Show();
                                //this.Hide();
                                return;
                            }
                        }
                        else
                        {
                            // el usuario proporcionó información de inicio de sesión incorrecta, mostrar un mensaje de alerta
                            MessageBox.Show("Usuario y/o contraseña incorrectos");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        // cerrar la conexión a la base de datos
                        cn.CerrarConexion();
                    }
                    break;

                case "Paciente":
                    cn = new Cconexion();
                    cmd = new SqlCommand();
                    da = new SqlDataAdapter();
                    dt = new DataTable();
                    CedulaPaciente = Convert.ToInt32(txtUsuario.Text);
                    Conta = 2;

                    string Documento = txtUsuario.Text;
                    string Contraseña = txtContraseña.Text;

                    // consulta SQL para verificar la información de inicio de sesión
                    string consulta = "SELECT COUNT(*) FROM tblPaciente WHERE IdPaciente = @Documento AND Contraseña = @Contraseña";

                    try
                    {
                        // establecer la conexión a la base de datos
                        cn.AbrirConexion();

                        // configurar el comando y los parámetros de la consulta SQL
                        cmd.Connection = cn.Conexion;
                        cmd.CommandText = consulta;
                        cmd.Parameters.AddWithValue("@Documento", Documento);
                        cmd.Parameters.AddWithValue("@Contraseña", Contraseña);

                        // ejecutar la consulta SQL y guardar el resultado en un DataTable
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        // verificar si la consulta SQL devolvió algún resultado
                        int count = Convert.ToInt32(dt.Rows[0][0]);
                        if (count == 1)
                        {
                            // el usuario proporcionó información de inicio de sesión válida, asignar la cédula a la variable global
                            Cedula = Documento;

                            //comprobar si los datos ingresados son de un administrador
                            cmd = new SqlCommand("SELECT COUNT(*) FROM tblPaciente WHERE IdPaciente = @Documento", cn.Conexion);
                            cmd.Parameters.AddWithValue("@Documento", Documento);
                            da = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);
                            //Si cedula es igual a 1, entonces es un administrador
                            if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                            {
                                // mostrar el formulario del menú
                                this.Hide();
                                fmrWelcome welcome = new fmrWelcome();
                                welcome.ShowDialog();
                                fmrPacientes Pac = new fmrPacientes();
                                Pac.Show();
                                //this.Hide();
                                return;
                            }
                        }
                        else
                        {
                            // el usuario proporcionó información de inicio de sesión incorrecta, mostrar un mensaje de alerta
                            MessageBox.Show("Usuario y/o contraseña incorrectos");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        // cerrar la conexión a la base de datos
                        cn.CerrarConexion();
                    }
                    break;

                case "Medico":
                    cn = new Cconexion();
                    cmd = new SqlCommand();
                    da = new SqlDataAdapter();
                    dt = new DataTable();
                    CedulaMedico = Convert.ToInt32(txtUsuario.Text);
                    Conta = 3;

                    string CC = txtUsuario.Text;
                    string Clave = txtContraseña.Text;

                    // consulta SQL para verificar la información de inicio de sesión
                    string Consulta = "SELECT COUNT(*) FROM tblMedico WHERE IdMedico = @CC AND Contraseña = @Clave";

                    try
                    {
                        // establecer la conexión a la base de datos
                        cn.AbrirConexion();

                        // configurar el comando y los parámetros de la consulta SQL
                        cmd.Connection = cn.Conexion;
                        cmd.CommandText = Consulta;
                        cmd.Parameters.AddWithValue("@CC", CC);
                        cmd.Parameters.AddWithValue("@Clave", Clave);

                        // ejecutar la consulta SQL y guardar el resultado en un DataTable
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        // verificar si la consulta SQL devolvió algún resultado
                        int count = Convert.ToInt32(dt.Rows[0][0]);
                        if (count == 1)
                        {
                            // el usuario proporcionó información de inicio de sesión válida, asignar la cédula a la variable global
                            Cedula = CC;

                            //comprobar si los datos ingresados son de un administrador
                            cmd = new SqlCommand("SELECT COUNT(*) FROM tblMedico WHERE IdMedico = @CC", cn.Conexion);
                            cmd.Parameters.AddWithValue("@CC", CC);
                            da = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);
                            //Si cedula es igual a 1, entonces es un administrador
                            if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                            {
                                // mostrar el formulario del menú
                                this.Hide();
                                fmrWelcome welcome = new fmrWelcome();
                                welcome.ShowDialog();
                                frmCita Cita = new frmCita();
                                Cita.Show();
                                //this.Hide();
                                return;
                            }
                        }
                        else
                        {
                            // el usuario proporcionó información de inicio de sesión incorrecta, mostrar un mensaje de alerta
                            MessageBox.Show("Usuario y/o contraseña incorrectos");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        // cerrar la conexión a la base de datos
                        cn.CerrarConexion();
                    }
                    
                break;
            }
        }

    }
}
