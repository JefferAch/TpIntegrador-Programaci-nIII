using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    public class ClinicaUsuario
    {
        DaoClinica dao = new DaoClinica();
        public bool verificarUsuario(string name, string password, byte tipo)
        {
            SqlCommand sqlCommand = new SqlCommand();
            
            return dao.existeUsuario(name, password, tipo/*, ref sqlCommand*/); ;
        }
       public DataTable mostrarTablaPaciente()
        {

            string tablaSQL = "SELECT P.DNI_Paciente, P.nombre_Paciente, P.apellido_Paciente, " +
                               "P.sexo, P.nacionalidad, P.fecha_nacimiento, P.direccion, " +
                               "P.correo_electronico, P.telefono, P.Estado, " +
                               "P.ID_Provincia, P.ID_Localidad, " +
                               "L.Nombre_Localidad, S.Nombre_Provincia " +
                               "FROM Paciente AS P " +
                               "INNER JOIN Localidad L ON P.ID_Localidad = L.ID_Localidad " +
                               "INNER JOIN Provincia S ON P.ID_Provincia = S.ID_Provincia " +
                               "WHERE Estado = 1";
            return dao.getTablaTurno(tablaSQL);
        }
        public DataTable FiltrarPacientes(string textoBuscar, int queFiltrar, int comoOrdenar)
        {

            string Base = @"
        SELECT 
            P.DNI_Paciente, 
            P.nombre_paciente, 
            P.apellido_paciente, 
            P.sexo, 
            P.nacionalidad, 
            P.fecha_nacimiento, 
            P.direccion, 
            P.telefono, 
            P.correo_electronico, 
            P.Estado,
        P.ID_Provincia,
        P.ID_Localidad,
            Prov.Nombre_Provincia, 
            Loc.Nombre_Localidad
        FROM Paciente P
        INNER JOIN Provincia Prov ON P.ID_Provincia = Prov.ID_Provincia
        INNER JOIN Localidad Loc ON P.ID_Localidad = Loc.ID_Localidad ";




            string where = "";
            SqlCommand cmd = new SqlCommand();


            if (!string.IsNullOrEmpty(textoBuscar))
            {
                switch (queFiltrar)
                {
                    case 0:
                        where = "WHERE P.DNI_Paciente LIKE @textoBuscar";
                        break;
                    case 1:
                        where = "WHERE P.nombre_paciente LIKE @textoBuscar";
                        break;
                    case 2:
                        where = "WHERE P.apellido_paciente LIKE @textoBuscar";
                        break;
                    case 3:
                        where = "WHERE P.nacionalidad LIKE @textoBuscar";
                        break;
                    default:
                        break;



                }


                if (!string.IsNullOrEmpty(where))
                {
                    cmd.Parameters.AddWithValue("@textoBuscar", "%" + textoBuscar + "%");
                }
            }


            string orderBy = "";
            switch (comoOrdenar)
            {
                case 0:
                    orderBy = "ORDER BY P.DNI_Paciente";
                    break;
                case 1:
                    orderBy = "ORDER BY P.nombre_paciente";
                    break;
                case 2:
                    orderBy = "ORDER BY P.apellido_paciente";
                    break;
                case 3:
                    orderBy = "ORDER BY P.nacionalidad";
                    break;
                default:
                    orderBy = "ORDER BY P.apellido_paciente ASC, P.nombre_paciente ASC";
                    break;
            }

            string consultaCompleta = Base + " " + where + " " + orderBy;

            cmd.CommandText = consultaCompleta;



            return dao.getTablaPacientes(cmd);
        }


        public DataTable mostrarTablaMedico()
        {
            string tablaSQL =
                "SELECT M.Legajo_Medico, M.Nombre_Medico, M.Apellido_Medico, M.Correo, M.Telefono_Medico, " +
                "E.Descripcion_Especialidad AS Especialidad, STRING_AGG(D.Nombre_Dia, ', ') AS Dia_Habil, " +
                "CONCAT(CONVERT(VARCHAR(5), M.HorarioInicio), ' - ', CONVERT(VARCHAR(5), M.HorarioFinal)) AS Horario_Atencion, " +
                "M.DNI_Medico, M.Sexo, M.Nacionalidad_Med, M.Birthdate, M.Direccion " +
                "FROM Medico M " +
                "INNER JOIN Medico_DiasHabiles MDH ON M.Legajo_Medico = MDH.Legajo_Medico " +
                "INNER JOIN Dias D ON MDH.ID_Dia = D.ID_Dia " +
                "INNER JOIN Especialidad E ON  M.Cod_Especialidad = E.Cod_Especialidad " +
                "WHERE Actividad = 1 " +
                "GROUP BY M.Legajo_Medico, M.Nombre_Medico, M.Apellido_Medico, M.Correo, M.Telefono_Medico, " +
                "E.Descripcion_Especialidad, M.HorarioInicio, M.HorarioFinal, M.DNI_Medico, M.Sexo, M.Nacionalidad_Med, " +
                "M.Birthdate, M.Direccion";

            return dao.getTablaTurno(tablaSQL);
        }

        public DataTable FiltrarMedicos(string textoBuscar, int queFiltrar, int comoOrdenar)
        {
         
            string Base = @"SELECT M.Legajo_Medico, M.Nombre_Medico, M.Apellido_Medico, M.Correo, M.Telefono_Medico, " +
                "E.Descripcion_Especialidad AS Especialidad, STRING_AGG(D.Nombre_Dia, ', ') AS Dia_Habil, " +
                "CONCAT(CONVERT(VARCHAR(5), M.HorarioInicio), ' - ', CONVERT(VARCHAR(5), M.HorarioFinal)) AS Horario_Atencion, " +
                "M.DNI_Medico, M.Sexo, M.Nacionalidad_Med, M.Birthdate, M.Direccion " +
                "FROM Medico M " +
                "INNER JOIN Medico_DiasHabiles MDH ON M.Legajo_Medico = MDH.Legajo_Medico " +
                "INNER JOIN Dias D ON MDH.ID_Dia = D.ID_Dia " +
                "INNER JOIN Especialidad E ON  M.Cod_Especialidad = E.Cod_Especialidad ";

            string GroupBy = @"GROUP BY M.Legajo_Medico, M.Nombre_Medico, M.Apellido_Medico, M.Correo, M.Telefono_Medico, " +
                "E.Descripcion_Especialidad, M.HorarioInicio, M.HorarioFinal, M.DNI_Medico, M.Sexo, M.Nacionalidad_Med, " +
                "M.Birthdate, M.Direccion";


            string where = "";
            SqlCommand cmd = new SqlCommand(); 

           
            if (!string.IsNullOrEmpty(textoBuscar))
            {
                switch (queFiltrar)
                {
                    case 0:
                        where = "WHERE M.Legajo_Medico LIKE @textoBuscar";
                        break;
                    case 1:
                        where = "WHERE M.Nombre_Medico LIKE @textoBuscar";
                        break;
                    case 2:
                        where = "WHERE M.Apellido_Medico LIKE @textoBuscar";
                        break;
                    case 3:
                        where = "WHERE E.Descripcion_Especialidad LIKE @textoBuscar";
                        break;


                       
                }


                if (!string.IsNullOrEmpty(where))
                {
                    cmd.Parameters.AddWithValue("@textoBuscar", "%" + textoBuscar + "%");
                }
            }

            
            string orderBy = "";
            switch (comoOrdenar)
            {
                case 0: 
                    orderBy = "ORDER BY M.Legajo_Medico";
                    break;
                case 1: 
                    orderBy = "ORDER BY M.Nombre_Medico";
                    break;
                case 2: 
                    orderBy = "ORDER BY M.Apellido_Medico";
                    break;
                case 3: 
                    orderBy = "ORDER BY E.Descripcion_Especialidad";
                    break;
                default:
                    
                    orderBy = "ORDER BY M.Legajo_Medico";
                    break;
            }

            string consultaCompleta = Base + " " + where + " " + GroupBy + " " + orderBy;
            SqlCommand cmd2 = new SqlCommand(consultaCompleta);

            cmd2.Parameters.AddWithValue("@textoBuscar", "%" + textoBuscar + "%");

          
            return dao.getTablaMedico(cmd2);
        }

       
        public bool actualizarPaciente(Paciente paciente)
        {
            return dao.ActualizarPaciente(paciente);
        }
       

        public bool existePaciente(Paciente p)
        {
            return dao.ExistePaciente(p);
        }

        public int agregarPaciente(Paciente p)
        {
            if (existePaciente(p))
            {
                return 0;
            }
            return dao.AgregarPaciente(p);
        }
        public bool eliminarPaciente(int dni)
        {
            return dao.EliminarPaciente(dni);
        }

        public bool eliminarMedico(int legajo)
        {

            return dao.EliminarMedico(legajo);
        }

        public bool existeMedico(Medico m)
        {
            return dao.ExisteMedico(m);
        }

        public int agregarMedico(Medico m)
        {
            if (existeMedico(m))
            {
                return 0; 
            }
            return dao.AgregarMedico(m);
        }

        public DataTable ObtenerEspecialidades()
        {
            return dao.ObtenerEspecialidades();
        }

        public DataTable ObtenerPacientes()
        {
            return dao.ObtenerPacientes();
        }

        public DataTable ObtenerMedicosPorEspecialidad(int codEsp)
        {
            return dao.ObtenerMedicosPorEspecialidad(codEsp);
        }

        public DataTable ObtenerDiasMedico(int legajo)
        {
            return dao.ObtenerDiasMedico(legajo);
        }

        public DataTable ObtenerHorarioMedico(int legajo)
        {
            return dao.ObtenerHorarioMedico(legajo);
        }

        public bool ExisteTurno(int legajo, DateTime dia, TimeSpan hora)
        {
            return dao.ExisteTurno(legajo, dia, hora);
        }

        public int AgregarTurno(int especialidad, DateTime dia, TimeSpan hora, string dni, int legajo)
        {
            return dao.AgregarTurno(especialidad, dia, hora, dni, legajo);
        }

        public DataTable obtenerTurnosPorMedico(int legajo)
        {
            return dao.obtenerTurnosPorMedico(legajo);
        }

        public bool ActualizarTurno(int idTurno, int estado, string observaciones)
        {
            return dao.ActualizarTurno(idTurno, estado, observaciones);
        }
    }
}
