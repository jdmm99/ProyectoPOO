using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Clases
{
    public class frmRegistrarMedico : Usuario
    {
        public frmRegistrarMedico(int documento, string tipodDocumento, string nombre, string apellido, string sexo, string fechaNacimiento, string direccion, string departamento, string ciudad, string telefono, string correo, string contraseña,string Especialidad) : base(documento, tipodDocumento, nombre, apellido, sexo, fechaNacimiento, direccion, departamento, ciudad, telefono, correo, contraseña)
        {
            this.Especialidad = Especialidad;
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblMedico", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        public int documento { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string infoCompleta => $"{documento} - {nombre} {apellido}";

        public frmRegistrarMedico()
        {
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblMedico", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public string Especialidad {  get; set; }

        public void Agregar(frmRegistrarMedico Nuevo)
        {
            SqlCommand cmd = new SqlCommand("insert into tblMedico values('" + Nuevo.Documento + "','" + Nuevo.TipodDocumento + "','" + Nuevo.Nombre + "','" + Nuevo.Apellido + "','" + Nuevo.Sexo + "','" + Nuevo.Especialidad + "','" + Nuevo.FechaNacimiento + "','" + Nuevo.Direccion + "','" + Nuevo.Departamento + "','" + Nuevo.Ciudad + "','" + Nuevo.Telefono + "','" + Nuevo.Correo + "','" + Nuevo.Contraseña + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Medico guardado");
        }

        public void Eliminar(int Eliminar)
        {
            if (MessageBox.Show("Desea borrar el Medico?", "Alerta!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cm = new SqlCommand("delete from tblMedico where IdMedico = '" + Eliminar + "'", cn.AbrirConexion());
                cm.ExecuteNonQuery();
                MessageBox.Show("Medico Eliminado");
            }
        }

        public void Actualizar(int Actualizar, frmRegistrarMedico Nuevesito)
        {
            SqlCommand cmd = new SqlCommand("Update tblMedico set Nombre='" + Nuevesito.Nombre + "',Apellidos='" + Nuevesito.Apellido + "',Sexo='" + Nuevesito.Sexo + "',Especialidad='" + Nuevesito.Especialidad + "',FechaNacimiento='" + Nuevesito.FechaNacimiento + "',Direccion='" + Nuevesito.Direccion + "',Departamento='" + Nuevesito.Departamento + "',Ciudad='" + Nuevesito.Ciudad + "',Telefono='" + Nuevesito.Telefono + "',Correo='" + Nuevesito.Correo + "',Contraseña='" + Nuevesito.Contraseña + "'where IdMedico='" + Actualizar + "'", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Medico modificado");
        }

    }
}
