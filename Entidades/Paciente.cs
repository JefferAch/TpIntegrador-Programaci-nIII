using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private string _dni;
        private string _nombre;
        private string _apellido;
        private char _sexo;
        private string _nacionalidad;
        private DateTime _fechaNacimiento;
        private string _direccion;
        private string _telefono;
        private string _correo;
        private int _idLocalidad;
        private int _idProvincia;
        private bool _estado;

        public Paciente() { }

        public Paciente(string dni, string nombre, string apellido, char sexo,
                        string nacionalidad, DateTime fechaNacimiento,
                        string direccion, string telefono, string correo,
                        int idLocalidad, int idProvincia, bool estado)
        {
            _dni = dni;
            _nombre = nombre;
            _apellido = apellido;
            _sexo = sexo;
            _nacionalidad = nacionalidad;
            _fechaNacimiento = fechaNacimiento;
            _direccion = direccion;
            _telefono = telefono;
            _correo = correo;
            _idLocalidad = idLocalidad;
            _idProvincia = idProvincia;
            _estado = estado;
        }

        public string DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public char Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        public string Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public int ID_Localidad
        {
            get { return _idLocalidad; }
            set { _idLocalidad = value; }
        }

        public int ID_Provincia
        {
            get { return _idProvincia; }
            set { _idProvincia = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}