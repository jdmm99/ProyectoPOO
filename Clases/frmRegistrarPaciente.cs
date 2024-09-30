using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Proyecto.Clases
{
    public class frmRegistrarPaciente : Usuario
    {
        public frmRegistrarPaciente(int documento, string tipodDocumento, string nombre, string apellido, string sexo, string fechaNacimiento, string direccion, string departamento, string ciudad, string telefono, string correo, string contraseña, string EPS) : base(documento, tipodDocumento, nombre, apellido, sexo, fechaNacimiento, direccion, departamento, ciudad, telefono, correo, contraseña)
        {
            this.EPS = EPS;
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblPaciente", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        public frmRegistrarPaciente()
        {
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblPaciente", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

        }

        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt; 

        public string EPS { get; set; }
        public string TipoSangre { get; set; }

        public void Agregar(frmRegistrarPaciente Nuevo)
        {
            SqlCommand cmd = new SqlCommand("insert into tblPaciente values('" + Nuevo.Documento + "','" + Nuevo.TipodDocumento + "','" + Nuevo.Nombre + "','" + Nuevo.Apellido + "','" + Nuevo.Sexo + "','"+ Nuevo.EPS + "','" + Nuevo.FechaNacimiento + "','" + Nuevo.Direccion + "','" + Nuevo.Departamento + "','" + Nuevo.Ciudad + "','" + Nuevo.Telefono + "','" + Nuevo.Correo + "','" + Nuevo.Contraseña + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Paciente guardado");
        }

        public void Eliminar(int Eliminar)
        {
            if (MessageBox.Show("Desea borrar el Paciente?", "Alerta!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cm = new SqlCommand("delete from tblPaciente where IdPaciente = '" + Eliminar + "'", cn.AbrirConexion());
                cm.ExecuteNonQuery();
                MessageBox.Show("Paciente Eliminado");
            }
        }

        public void Actualizar(int Actualizar,frmRegistrarPaciente Nuevesito)
        {
                SqlCommand cmd = new SqlCommand("Update tblPaciente set Nombre='" + Nuevesito.Nombre + "',Apellidos='" + Nuevesito.Apellido + "',Sexo='" + Nuevesito.Sexo + "',EPS='" + Nuevesito.EPS + "',FechaNacimiento='" + Nuevesito.FechaNacimiento + "',Direccion='" + Nuevesito.Direccion + "',Departamento='" + Nuevesito.Departamento + "',Ciudad='" + Nuevesito.Ciudad + "',Telefono='" + Nuevesito.Telefono + "',Correo='" + Nuevesito.Correo + "',Contraseña='" + Nuevesito.Contraseña + "'where IdPaciente='" + Actualizar + "'", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Paciente modificado");   
        }


    }
}
