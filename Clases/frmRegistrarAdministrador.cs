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
    public class frmRegistrarAdministrador : Usuario
    {
        public frmRegistrarAdministrador(int documento, string tipodDocumento, string nombre, string apellido, string sexo, string fechaNacimiento, string direccion, string departamento, string ciudad, string telefono, string correo, string contraseña) : base(documento, tipodDocumento, nombre, apellido, sexo, fechaNacimiento, direccion, departamento, ciudad, telefono, correo, contraseña)
        {
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblAdministrador", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        public frmRegistrarAdministrador()
        {
            cn = new Cconexion();
            cmd = new SqlCommand("select * from tblAdministrador", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        Cconexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public void Agregar(frmRegistrarAdministrador Nuevo)
        {
            SqlCommand cmd = new SqlCommand("insert into tblAdministrador values('" + Nuevo.Documento + "','" + Nuevo.TipodDocumento + "','" + Nuevo.Nombre + "','" + Nuevo.Apellido + "','" + Nuevo.Sexo + "','" + Nuevo.FechaNacimiento + "','" + Nuevo.Direccion + "','" + Nuevo.Departamento + "','" + Nuevo.Ciudad + "','" + Nuevo.Telefono + "','" + Nuevo.Correo + "','" + Nuevo.Contraseña + "')", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Administador guardado");
        }

        public void Eliminar(int Eliminar)
        {
            if (MessageBox.Show("Desea borrar el Administrador?", "Alerta!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cm = new SqlCommand("delete from tblAdministrador where IdAdmin = '" + Eliminar + "'", cn.AbrirConexion());
                cm.ExecuteNonQuery();
               MessageBox.Show("Administrador Eliminado");
            }
        }

        public void Actualizar(int Actualizar, frmRegistrarAdministrador Nuevesito)
        {
            SqlCommand cmd = new SqlCommand("Update tblAdministrador set Nombre='" + Nuevesito.Nombre + "',Apellidos='" + Nuevesito.Apellido + "',Sexo='" + Nuevesito.Sexo + "',FechaNacimiento='" + Nuevesito.FechaNacimiento + "',Direccion='" + Nuevesito.Direccion + "',Departamento='" + Nuevesito.Departamento + "',Ciudad='" + Nuevesito.Ciudad + "',Telefono='" + Nuevesito.Telefono + "',Correo='" + Nuevesito.Correo + "',Contraseña='" + Nuevesito.Contraseña + "'where IdAdmin='" + Actualizar + "'", cn.AbrirConexion());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Administrador modificado");

        }

    }
}
