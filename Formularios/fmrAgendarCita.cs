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
    public partial class fmrAgendarCita : Form
    {
        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DateTime hoy;
        int contador, i = 0;
        


        //Diccionario de medicos
        private Dictionary<string, int> medicosDiccionario = new Dictionary<string, int>();

        void llenarMedico()
        {
            //// Conexión a la base de datos

            //string cadConexion = Cconexion.cadenaConexion;

            //using (SqlConnection conexion = new SqlConnection(cadConexion))
            //{
            //    conexion.Open();

            //    SqlCommand cmd = new SqlCommand("select IdMedico,Nombre from tblMedico", conexion);
            //    SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        int medicoID = Convert.ToInt32(reader["IdMedico"]);
            //        string nombreMedico = reader["Nombre"].ToString();

            //        // Agrega el nombre del médico al ComboBox
            //        cmbListaDoctores.Items.Add(nombreMedico);

            //        //// Asocia el nombre del médico con su ID en el diccionario
            //        medicosDiccionario[nombreMedico] = medicoID;
            //    }
            //}
            //--------------------------------------------------------------------------//

            //Crear lista de Medicos para almacenar info
            List<frmRegistrarMedico> medicos = new List<frmRegistrarMedico>();

            //Conexion con la base de Datos 
            using (SqlConnection conexion = new SqlConnection(Cconexion.cadenaConexion))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("select IdMedico,Nombre,Apellidos from tblMedico ", conexion))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int medicoID = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);

                        medicos.Add(new frmRegistrarMedico { documento = medicoID, nombre = nombre, apellido = apellido });
                    }
                }
            }
            // Configurar el ComboBox para mostrar la concatenación de ID, nombre y apellido
            cmbListaDoctores.DataSource = medicos;
            cmbListaDoctores.DisplayMember = "infoCompleta";
        }

        public fmrAgendarCita()
        {
            InitializeComponent();
            cn = new Cconexion();
        }


        //Metodo para seleccionar el id del medico

        private void cmbListaDoctores_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Medico Seleccionado en el Combobox
            frmRegistrarMedico medicoSeleccionado = (frmRegistrarMedico)cmbListaDoctores.SelectedItem;

            // Obtener el ID del medico
            int idMedico = medicoSeleccionado.documento;
        }

        string ConfirmarcionCita = "";

        private void dtgCancelarCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Metodo para llevar las citas al dataGrid

        private void CargarCitas(int IdPaciente)
        {
            dgvCancelarCitas.Rows.Clear();

            //Conectar a la base de Datos
            using (SqlConnection conexion = new SqlConnection(Cconexion.cadenaConexion))
            {
                conexion.Open();
                //Consulta
                using (SqlCommand cmd = new SqlCommand("select IdCita, Dias, Horas from  tblCita WHERE Paciente = @IdPaciente", conexion))
                {
                    cmd.Parameters.AddWithValue("@IdPaciente", IdPaciente);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            int IdCita = lector.GetInt32(0);
                            string Fecha = lector.GetString(1);
                            string Hora = lector.GetString(2);

                            //Agregar al DataGrid
                            dgvCancelarCitas.Rows.Add(false, IdCita, Fecha, Hora);

                        }
                    }
                }
            }
        }
        private void CargarReasignar(int IdPaciente)
        {
            dgvReasignar.Rows.Clear();
            //Conectar a la base de Datos
            using (SqlConnection conexion = new SqlConnection(Cconexion.cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("select IdCita from  tblCita WHERE Paciente = @IdPaciente", conexion))
                {
                    cmd.Parameters.AddWithValue("@IdPaciente", IdPaciente);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            int IdCita = lector.GetInt32(0);
                            //Agregar al DataGrid
                            dgvReasignar.Rows.Add(false, IdCita);
                        }
                    }
                }

            }
        }
        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            dgvCancelarCitas.Visible = true;
            btnCanCita.Visible = true;
            btnTerminar.Visible = true;
            dgvReasignar.Visible = false;
            btnReasig.Visible = false;
            btnTerminar2.Visible = false;
        }

        private void dgvCancelarCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dgvReasignar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNroDocumento_Leave_1(object sender, EventArgs e)
        {
            // Obtener doc del paciente
            string documento = txtNroDocumento.Text;

            // Conexión a la base de datos

            string cadConexion = Cconexion.cadenaConexion;

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("select Nombre, Apellidos, Telefono from tblPaciente where IdPaciente = @Documento", conexion);

                cmd.Parameters.AddWithValue("@Documento", documento);

                SqlDataReader reader = cmd.ExecuteReader();

                //if (reader.Read())
                try 
                {
                    // Si se encuentra un paciente con ese número de documento, llenar los cuadros de texto correspondientes
                    reader.Read();
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtApellidos.Text = reader["Apellidos"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                }
                //else
                catch (Exception ex)
                {
                    // Si no se encuentra un paciente, limpiar los cuadros de texto de nombre, apellido y teléfono
                    txtNombre.Clear();
                    txtApellidos.Clear();
                    txtTelefono.Clear();
                    MessageBox.Show("Paciente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("Paciente no registrado");
                }
            }
            //Cargar en el datagrid las citas asiganadas
            int IdPaciente;
            if (int.TryParse(txtNroDocumento.Text, out IdPaciente))
                CargarCitas(IdPaciente);

            //Cargar en el datagrid de reasignar
            if (int.TryParse(txtNroDocumento.Text, out IdPaciente))
                CargarReasignar(IdPaciente);
        }

        private void fmrAgendarCita_Load(object sender, EventArgs e)
        {
            llenarMedico();
            mtcFecha.MinDate = DateTime.Now;

            if (string.IsNullOrEmpty(txtNroDocumento.Text))
            {
                mtcFecha.Enabled = false;
                cmbHorasAtención.Enabled = false;
            }
            mtcFecha.Enabled = true;
            cmbHorasAtención.Enabled = true;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // ID del medico seleccionado
            // Medico Seleccionado en el Combobox
            frmRegistrarMedico medicoSeleccionado = (frmRegistrarMedico)cmbListaDoctores.SelectedItem;

            // Obtener el ID del medico
            int idMedico = medicoSeleccionado.documento;

            //Obtener otro valores en el interfaz

            int IdPaciente = Convert.ToInt32(txtNroDocumento.Text);
            string motivoConsulta = txtTipodeConsulta.Text;
            string fecha = mtcFecha.SelectionStart.ToShortDateString();
            string hora = cmbHorasAtención.SelectedItem.ToString();
            string confirmar = ConfirmarcionCita;


            //Conexion a la base de datos
            string cadConexion = Cconexion.cadenaConexion;
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                conexion.Open();

                //Verificar si ya existe una cita 
                SqlCommand cmd = new SqlCommand("select count(*) from tblCita where MedicoAsignado = @Medico and Dias = @Fecha and Horas = @Hora", conexion);
                cmd.Parameters.AddWithValue("@Medico", idMedico);
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@Hora", hora);

                //Contar coincidencias
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Cita no disponible, seleccione otro dia u otra hora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("insert into tblCita(MedicoAsignado,Paciente,MotivoConsulta,ConfirmarCita,Dias,Horas)values(@Medico,@Paciente,@Motivo,@Confirmar,@Fecha,@Hora)", conexion);
                    cmd2.Parameters.AddWithValue("@Medico", idMedico);
                    cmd2.Parameters.AddWithValue("@Paciente", IdPaciente);
                    cmd2.Parameters.AddWithValue("@Motivo", motivoConsulta);
                    cmd2.Parameters.AddWithValue("@Confirmar", confirmar);
                    cmd2.Parameters.AddWithValue("@Fecha", fecha);
                    cmd2.Parameters.AddWithValue("@Hora", hora);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("insert into tblMedicoPaciente (IdMedico,IdPaciente)values(@Medico,@Paciente)", conexion);
                    cmd3.Parameters.AddWithValue("@Medico", idMedico);
                    cmd3.Parameters.AddWithValue("@Paciente", IdPaciente);
                    cmd3.ExecuteNonQuery();

                    MessageBox.Show("Cita asignada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento para el RadioButton "Sí"
        private void rdbSI_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSI.Checked)
            {
                ConfirmarcionCita = "Sí";
            }
        }

        // Evento para el RadioButton "No"
        private void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNo.Checked)
            {
                ConfirmarcionCita = "No";
            }
        }

        private void btnReasig_Click_1(object sender, EventArgs e)
        {
            //Obtener el ID de la Cita del Datagrid 
            //Recorrer las filas del datagrid
            for (int i = dgvReasignar.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewCheckBoxCell check = dgvReasignar.Rows[i].Cells["Elegirr"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(check.Value))
                {
                    // ID del medico seleccionado
                    // Medico Seleccionado en el Combobox
                    frmRegistrarMedico medicoSeleccionado = (frmRegistrarMedico)cmbListaDoctores.SelectedItem;

                    // Obtener el ID del medico
                    int idMedico = medicoSeleccionado.documento;
                    int IdCita = (int)dgvReasignar.Rows[i].Cells["IdCitaa"].Value;
                    //Obtener datos 
                    string motivoConsulta = txtTipodeConsulta.Text;
                    string fecha = mtcFecha.SelectionStart.ToShortDateString();
                    string hora = cmbHorasAtención.SelectedItem.ToString();
                    string confirmar = ConfirmarcionCita;

                    //Conexion a la base de datos
                    string cadConexion = Cconexion.cadenaConexion;
                    using (SqlConnection conexion = new SqlConnection(cadConexion))
                    {
                        conexion.Open();

                        //Verificar si ya existe una cita 
                        SqlCommand cmd1 = new SqlCommand("select count(*) from tblCita where MedicoAsignado = @Medico and Dias = @Fecha and Horas = @Hora", conexion);
                        cmd1.Parameters.AddWithValue("@Medico", idMedico);
                        cmd1.Parameters.AddWithValue("@Fecha", fecha);
                        cmd1.Parameters.AddWithValue("@Hora", hora);

                        //Contar coincidencias
                        int count = (int)cmd1.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Cita no disponible, seleccione otro dia u otra hora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("update tblCita set Dias = @NuevaFecha, Horas = @Hora, MotivoConsulta = @NuevoMotivo where IdCita = @IdCita ", conexion);
                            cmd.Parameters.AddWithValue("@NuevaFecha", fecha);
                            cmd.Parameters.AddWithValue("@Hora", hora);
                            cmd.Parameters.AddWithValue("@NuevoMotivo", motivoConsulta);
                            cmd.Parameters.AddWithValue("@Idcita", IdCita);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Cita reasignada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }

        }

        private void btnTerminar2_Click_1(object sender, EventArgs e)
        {
            invisibleReasignar();
        }
        
        private void btnReagendar_Click_1(object sender, EventArgs e)
        {

           
            try
            {
                int IdPaciente = Convert.ToInt32(txtNroDocumento.Text);
                visibleReasignar();
                invisibleCancelar();
                CargarReasignar(IdPaciente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Campo de identificación vacío, ingrese una identificación correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarCita_Click_1(object sender, EventArgs e)
        {
            try
            {
                int IdPaciente = Convert.ToInt32(txtNroDocumento.Text);
                visibleCancelar();
                invisibleReasignar();
                CargarCitas(IdPaciente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Campo de identificación vacío, ingrese una identificación correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCanCita_Click_1(object sender, EventArgs e)
        {
            //Recorrer las filas del datagrid
            for (int i = dgvCancelarCitas.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewCheckBoxCell check = dgvCancelarCitas.Rows[i].Cells["Elegir"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(check.Value))
                {
                    int IdCita = (int)dgvCancelarCitas.Rows[i].Cells["IdCita"].Value;

                    EliminarCita(IdCita);

                    dgvCancelarCitas.Rows.RemoveAt(i);

                    MessageBox.Show("Cancelación Exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnTerminar_Click_1(object sender, EventArgs e)
        {
            invisibleCancelar();
        }

        private void dgvReasignar_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Metodo para eliminar cita
        private void EliminarCita(int IdCita)
        {
            //Conectar a la base
            using (SqlConnection conexion = new SqlConnection(Cconexion.cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("delete from tblCita where IdCita = @IdCita", conexion))
                {
                    cmd.Parameters.AddWithValue("@IdCita", IdCita);
                    cmd.ExecuteNonQuery();
                    
                }
            }
        }

        //Hacer visible Cancelar Cita
        void visibleCancelar()
        {
            dgvCancelarCitas.Visible = true;
            btnCanCita.Visible = true;
            btnTerminar.Visible = true;
        }

        //Hacer visible Reasignar cita
        void visibleReasignar()
        {
            dgvReasignar.Visible = true;
            btnReasig.Visible = true;
            btnTerminar2.Visible = true;
        }

        //Hacer invisible Cancelar Cita
        void invisibleCancelar()
        {
            dgvCancelarCitas.Visible = false;
            btnCanCita.Visible = false;
            btnTerminar.Visible = false;
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        //Hacer invisible Reasignar cita
        void invisibleReasignar()
        {
            dgvReasignar.Visible = false;
            btnReasig.Visible = false;
            btnTerminar2.Visible = false;
        }


    }
}

