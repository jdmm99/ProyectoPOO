using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Clases
{
    public class Usuario
    {
        public Usuario(int documento, string tipodDocumento, string nombre, string apellido, string sexo, string fechaNacimiento, string direccion, string departamento, string ciudad, string telefono, string correo, string contraseña)
        {
            this.Documento = documento;
            this.TipodDocumento = tipodDocumento;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.FechaNacimiento = fechaNacimiento;
            this.Direccion = direccion;
            this.Departamento = departamento;
            this.Ciudad = ciudad;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Contraseña = contraseña;
        }

        public Usuario()
        {

        }

        public int Documento { get; set; }
        public string TipodDocumento { get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; } 
        public string Departamento { get; set;}
        public string Ciudad { get; set; }
        public string Telefono { get; set;}
        public string Correo { get; set;}
        public string Contraseña { get; set; }


    }
}
