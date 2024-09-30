using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Clases
{
    public class frmCita : frmRegistrarPaciente
    {
        public frmCita(int documento, string tipodDocumento, string nombre, string apellido, string sexo, string fechaNacimiento, string direccion, string departamento, string ciudad, string telefono, string correo, string contraseña, string EPS) : base(documento, tipodDocumento, nombre, apellido, sexo, fechaNacimiento, direccion, departamento, ciudad, telefono, correo, contraseña, EPS)
        {
            this.TipoCita = TipoCita;
            this.ConfirmarCita = ConfirmarCita;
            this.Dias = Dias;
            this.Horas = Horas;
        }

        public string TipoCita {  get; set; }
        public string ConfirmarCita {  get; set; }
        public string Dias {  get; set; }
        public string Horas { get; set; }
    }
}
