using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Medico
    {

        public int LegajoMedico { get; set; }
        public int IdUsuario { get; set; }
        public int IdProvincia { get; set; }
        public int IdLocalidad { get; set; }
        public string TelefonoMedico { get; set; }

        private int Especialidad {  get; set; }
        public string Correo { get; set; }
        public int CodEspecialidad { get; set; }
        public TimeSpan HoraInicial { get; set; }
        public TimeSpan HoraFinal { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoMedico { get; set; }
        public int DniMedico { get; set; }
        public char Sexo { get; set; }
        public string NacionalidadMed { get; set; }
        public DateTime Birthdate { get; set; }
        public string Direccion { get; set; }


        public Medico(int legajoMed, string nombreMed, string apellMed, string correo, string TelefonoMed, int especialidad, TimeSpan horaInicio, TimeSpan horaFinal, int DniMed, char sexo, string nacionalidadMed, DateTime nacimiento, string direccion, int provincia, int localidad)
        {

            LegajoMedico = legajoMed;
            NombreMedico = nombreMed;
            ApellidoMedico = apellMed;
            Correo = correo;
            TelefonoMedico = TelefonoMed;
            Especialidad = especialidad;
            HoraInicial = horaInicio;
            HoraFinal = horaFinal;
            DniMedico = DniMed;
            Sexo = sexo;
            NacionalidadMed = nacionalidadMed;
            Birthdate = nacimiento;
            Direccion = direccion;
            IdProvincia = provincia;
            IdLocalidad = localidad;

        }

        public Medico() { }
    }
}
