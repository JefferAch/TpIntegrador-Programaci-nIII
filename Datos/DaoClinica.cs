using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using System.Security.Policy;
using System.Runtime.InteropServices;

namespace Datos
{
    public class DaoClinica
    {
        ConexionClinica conexion = new ConexionClinica();
        public bool existeUsuario(string name, string password, byte tipo/*, ref SqlCommand sqlCommand*/)
        {
            string consulta = "SELECT * FROM Usuario WHERE Nombre_Usuario = @nombreUsuario AND Contraseña = @contrasenia AND Tipo_Usuario = @Tipo_Usuario ";
            SqlCommand sqlCommand = new SqlCommand(consulta);
            sqlCommand.Parameters.AddWithValue("@nombreUsuario", name);
            sqlCommand.Parameters.AddWithValue("@contrasenia", password);
            sqlCommand.Parameters.AddWithValue("@Tipo_Usuario", tipo);

            /*SqlParameter sqlparameter = new SqlParameter();
            sqlparameter = sqlCommand.Parameters.Add("@idUsuario", System.Data.SqlDbType.VarChar, 30);
            sqlparameter = sqlCommand.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 30);*/
            return conexion.existe(sqlCommand);
        }

        public DataTable getTablaTurno(string consultaSql)
        {
            DataTable table = conexion.getTabla(consultaSql);
            return table;
        }
        public DataTable getTablaTurnos(SqlCommand comando)
        {
            
            return conexion.getTablaConParametro(comando);
        }
        public DataTable getTablaMedico(SqlCommand comando)
        {
            DataTable table = conexion.getTablaConParametro(comando);
            return table;
        }
        public DataTable getTablaPacientes(SqlCommand comando)
        {
            DataTable table = conexion.getTablaConParametro(comando);
            return table;
        }




        private void EditarParametros(ref SqlCommand sqlCommand, Medico medico)
        {
            SqlParameter sqlParameter = new SqlParameter();

            sqlCommand.Parameters.AddWithValue("@nombreMedico", medico.NombreMedico);
            sqlCommand.Parameters.AddWithValue("@apellidoMedico", medico.ApellidoMedico);
            sqlCommand.Parameters.AddWithValue("@correo", medico.Correo);
            sqlCommand.Parameters.AddWithValue("@telefono", medico.TelefonoMedico);
            sqlCommand.Parameters.AddWithValue("@especialidad", medico.CodEspecialidad);
            sqlCommand.Parameters.AddWithValue("@horaInicial", medico.HoraInicial);
            sqlCommand.Parameters.AddWithValue("@horaFinal", medico.HoraFinal);
            sqlCommand.Parameters.AddWithValue("@dniMedico", medico.DniMedico);
            sqlCommand.Parameters.AddWithValue("@sexo", medico.Sexo);
            sqlCommand.Parameters.AddWithValue("@nacionalidadMed", medico.NacionalidadMed);
            sqlCommand.Parameters.AddWithValue("@nacimiento", medico.Birthdate);
            sqlCommand.Parameters.AddWithValue("@direccion", medico.Direccion);
            sqlCommand.Parameters.AddWithValue("@provincia", medico.IdProvincia);
            sqlCommand.Parameters.AddWithValue("@localidad", medico.IdLocalidad);
            sqlCommand.Parameters.AddWithValue("@legajoMedico", medico.LegajoMedico);
        }
        private void EditarParametrosPaciente(ref SqlCommand sqlCommand, Paciente paciente)
        {
            
            sqlCommand.Parameters.AddWithValue("@dni", paciente.DNI);
            sqlCommand.Parameters.AddWithValue("@nombre", paciente.Nombre);
            sqlCommand.Parameters.AddWithValue("@apellido", paciente.Apellido);
            sqlCommand.Parameters.AddWithValue("@correo", paciente.Correo);
            sqlCommand.Parameters.AddWithValue("@sexo", paciente.Sexo);
            sqlCommand.Parameters.AddWithValue("@nacionalidad", paciente.Nacionalidad);
            sqlCommand.Parameters.AddWithValue("@direccion", paciente.Direccion);
            sqlCommand.Parameters.AddWithValue("@telefono", paciente.Telefono);
            sqlCommand.Parameters.AddWithValue("@localidad", paciente.ID_Localidad);
            sqlCommand.Parameters.AddWithValue("@provincia", paciente.ID_Provincia);
        }
        public bool ActualizarPaciente(Paciente paciente)
        {
  
            SqlCommand sqlCommand = new SqlCommand();
            EditarParametrosPaciente(ref sqlCommand, paciente);
            ConexionClinica con = new ConexionClinica();
            string consulta = @"UPDATE Paciente 
                            SET nombre_paciente = @nombre, 
                                apellido_paciente = @apellido, 
                                sexo = @sexo,
                                nacionalidad = @nacionalidad,
                                direccion = @direccion,
                                telefono = @telefono, 
                                correo_electronico = @correo,
                                Id_Localidad = @localidad,
                                Id_Provincia = @provincia 
                            WHERE DNI_Paciente = @dni"; 

            int filas = con.ejecutarComando(sqlCommand, consulta);

            return filas == 1;
        }

        public bool EliminarPaciente(int dni)
        {
            string consultaSQL = "UPDATE Paciente SET Estado = 0 WHERE DNI_Paciente = @dniPaciente";

            SqlCommand sqlCommand = new SqlCommand(consultaSQL);
            sqlCommand.Parameters.AddWithValue("@dniPaciente", dni);

            int filas = conexion.ejecutarComando(sqlCommand);

            if (filas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool ExisteMedico(Medico m)
        {
            string consulta = "SELECT * FROM Medico WHERE Legajo_Medico = @legajo";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@legajo", m.LegajoMedico);

            return conexion.existe(cmd);
        }

        public bool ExisteUsuario(string NombreUser)
        {
            string consultasql = "SELECT * FROM Usuario WHERE Nombre_Usuario = @nombre";
            SqlConnection con = conexion.obtenerConexion();
            SqlCommand comando = new SqlCommand(consultasql, con);
            comando.Parameters.AddWithValue("@nombre", NombreUser);
            return conexion.existe(comando);

        }

        public bool ExisteDni (int dni)
        {
            string consultasql = "SELECT * FROM Medico WHERE DNI_Medico = @dni";
            SqlConnection con = conexion.obtenerConexion();
            SqlCommand comando = new SqlCommand(consultasql, con);
            comando.Parameters.AddWithValue("@dni", dni);
            return conexion.existe(comando);
        }

        public int AgregarMedico(Medico m)
        {
            string consulta ="INSERT INTO Medico (Legajo_Medico, Id_Usuario, Id_Provincia, Id_Localidad, Telefono_Medico, Correo, Cod_Especialidad, HorarioInicio, HorarioFinal, Nombre_Medico, Apellido_Medico, DNI_Medico, Sexo, Nacionalidad_Med, Birthdate, Direccion) " + "VALUES (@legajo, @usuario, @prov, @loc, @tel, @correo, @esp, @horarioinicio, @horariofinal, @nombre, @apellido, @dni, @sexo, @nac, @birth, @dir)";
            SqlConnection con = conexion.obtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@legajo", m.LegajoMedico);
            cmd.Parameters.AddWithValue("@usuario", m.IdUsuario);
            cmd.Parameters.AddWithValue("@prov", m.IdProvincia);
            cmd.Parameters.AddWithValue("@loc", m.IdLocalidad);
            cmd.Parameters.AddWithValue("@tel", m.TelefonoMedico);
            cmd.Parameters.AddWithValue("@correo", m.Correo);
            cmd.Parameters.AddWithValue("@esp", m.CodEspecialidad);
            cmd.Parameters.AddWithValue("@horarioinicio", m.HoraInicial);
            cmd.Parameters.AddWithValue("@horariofinal", m.HoraFinal);
            cmd.Parameters.AddWithValue("@nombre", m.NombreMedico);
            cmd.Parameters.AddWithValue("@apellido", m.ApellidoMedico);
            cmd.Parameters.AddWithValue("@dni", m.DniMedico);
            cmd.Parameters.AddWithValue("@sexo", m.Sexo);
            cmd.Parameters.AddWithValue("@nac", m.NacionalidadMed);
            cmd.Parameters.AddWithValue("@birth", m.Birthdate);
            cmd.Parameters.AddWithValue("@dir", m.Direccion);
            int filas = cmd.ExecuteNonQuery();
            con.Close();
            return filas;
        }

        public int AgregarUsuario (Usuario nuevoUser)
        {
            int idUsuarioNuevo = 0;

            string consultasql = "INSERT INTO Usuario (Nombre_Usuario, Contraseña, Tipo_Usuario) " + "VALUES (@usuario, @contra, @tipo); SELECT SCOPE_IDENTITY()";
            SqlConnection con = conexion.obtenerConexion();
            SqlCommand comando = new SqlCommand(consultasql, con);
            comando.Parameters.AddWithValue("@usuario", nuevoUser.name);
            comando.Parameters.AddWithValue("@contra", nuevoUser.password);
            comando.Parameters.AddWithValue("@tipo", nuevoUser.tipoUsuario);
            object resultado = comando.ExecuteScalar();
            if (resultado != null)
            {
                idUsuarioNuevo = Convert.ToInt32(resultado);
            }
            con.Close();
            return idUsuarioNuevo;
        }

      
        public bool EliminarMedico(int legajo)
        {
            string consultaSQL = "UPDATE Medico SET Actividad = 0 WHERE Legajo_Medico = @legajo";
            SqlCommand sqlCommand = new SqlCommand(consultaSQL);
            sqlCommand.Parameters.AddWithValue("@legajo", legajo);

            int filas = conexion.ejecutarComando(sqlCommand);

            if (filas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable ObtenerEspecialidades()
        {
            string sql = "SELECT Cod_Especialidad, Descripcion_Especialidad FROM Especialidad";
            return conexion.getTabla(sql);
        }


        public DataTable getProvincias()
        {
            string consultasql = "SELECT Id_Provincia, Nombre_Provincia FROM Provincia";
            SqlConnection con = conexion.obtenerConexion();
            SqlDataAdapter da = conexion.obtenerAdapter(consultasql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close ();
            return dt;
        }

        public DataTable getLocalidades(int idProvincia)
        {
            string consultasql = "SELECT Id_Localidad, Nombre_Localidad FROM Localidad WHERE Id_Provincia = @provincia";
            SqlConnection con = conexion.obtenerConexion();
            SqlCommand comando = new SqlCommand(consultasql, con);
            comando.Parameters.AddWithValue("@provincia", idProvincia);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getEspecialidades()
        {
            string consultasql = "SELECT Cod_Especialidad, Descripcion_Especialidad FROM Especialidad";
            SqlConnection con = conexion.obtenerConexion();
            SqlDataAdapter da = conexion.obtenerAdapter(consultasql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void AgregarDias(int LegajoMedico, int idDia)
        {
            string consultasql = "INSERT INTO Medico_DiasHabiles (Legajo_Medico, Id_Dia) VALUES (@legajo, @dia)";
            SqlConnection con = conexion.obtenerConexion();
            using (SqlCommand comando = new SqlCommand(consultasql, con))
            {
                comando.Parameters.AddWithValue("@legajo", LegajoMedico);
                comando.Parameters.AddWithValue("@dia", idDia);
                comando.ExecuteNonQuery();
            }
            con.Close();
        }

        public DataTable ObtenerMedicosPorEspecialidad(int codEsp)
        {
            string sql = @"SELECT Legajo_Medico, Nombre_Medico + ' ' + Apellido_Medico AS Nombre
                   FROM Medico WHERE Cod_Especialidad = @cod AND Actividad = 1";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@cod", codEsp);

            return conexion.getTablaConParametro(cmd);
        }


        public DataTable ObtenerDiasMedico(int legajo)
        {
            string sql = @"SELECT D.ID_Dia, D.Nombre_Dia 
                   FROM Medico_DiasHabiles MDH 
                   INNER JOIN Dias D ON MDH.ID_Dia = D.ID_Dia
                   WHERE MDH.Legajo_Medico = @legajo";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@legajo", legajo);

            return conexion.getTablaConParametro(cmd);
        }

        public DataTable ObtenerHorarioMedico(int legajo)
        {
            string sql = @"SELECT HorarioInicio, HorarioFinal
                   FROM Medico
                   WHERE Legajo_Medico = @legajo AND Actividad = 1";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@legajo", legajo);

            return conexion.getTablaConParametro(cmd);
        }


        public int AgregarPaciente(Paciente p)
        {
            string consulta = "INSERT INTO Paciente (DNI_Paciente, nombre_paciente, apellido_paciente, sexo, nacionalidad, fecha_nacimiento, direccion, telefono, correo_electronico, ID_Localidad, ID_Provincia) VALUES (@dni, @nombre, @apellido, @sexo, @nacionalidad, @nacimiento, @direccion, @telefono, @correo, @localidad, @provincia)";
            SqlConnection con = conexion.obtenerConexion();
            SqlCommand comando = new SqlCommand(consulta, con);
            comando.Parameters.AddWithValue("@dni", p.DNI);
            comando.Parameters.AddWithValue("@nombre", p.Nombre);
            comando.Parameters.AddWithValue("@apellido", p.Apellido);
            comando.Parameters.AddWithValue("@sexo", p.Sexo);
            comando.Parameters.AddWithValue("@nacionalidad", p.Nacionalidad);
            comando.Parameters.AddWithValue("@nacimiento", p.FechaNacimiento);
            comando.Parameters.AddWithValue("@direccion", p.Direccion);
            comando.Parameters.AddWithValue("@telefono", p.Telefono);
            comando.Parameters.AddWithValue("@correo", p.Correo);
            comando.Parameters.AddWithValue("@localidad", p.ID_Localidad);
            comando.Parameters.AddWithValue("@provincia", p.ID_Provincia);
            int filas = comando.ExecuteNonQuery();
            con.Close();
            return filas;
        }



        public bool ExistePaciente(Paciente p)
        {
            string consulta = "SELECT * FROM Paciente WHERE DNI_Paciente = @dni";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@dni", p.DNI);

            return conexion.existe(cmd);
        }
        public DataTable ObtenerPacientes()
        {
            string sql = "SELECT DNI_Paciente, nombre_paciente + ' ' + apellido_paciente AS Nombre FROM Paciente WHERE Estado = 1";
            return conexion.getTabla(sql);
        }


        public bool ExisteTurno(int legajo, DateTime dia, TimeSpan hora)
        {
            string sql = @"SELECT * FROM Turno 
                   WHERE Legajo_Medico = @legajo AND dia = @dia AND horario = @hora";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@legajo", legajo);
            cmd.Parameters.AddWithValue("@dia", dia);
            cmd.Parameters.AddWithValue("@hora", hora);

            return conexion.existe(cmd);
        }



        public int AgregarTurno(int especialidad, DateTime dia, TimeSpan hora, string dni, int legajo)
        {
            string sql = @"INSERT INTO Turno 
                   (Cod_Especialidad, dia, horario, DNI_Paciente, Legajo_Medico, Estado_Turno)
                   VALUES (@esp, @dia, @hora, @dni, @legajo, 0)";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@esp", especialidad);
            cmd.Parameters.AddWithValue("@dia", dia);
            cmd.Parameters.AddWithValue("@hora", hora);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@legajo", legajo);

            return conexion.ejecutarComando(cmd);
        }

        public bool ActualizarMedico(Medico medico)
        {
            string consultaSQL = @"UPDATE Medico SET Nombre_Medico = @nombreMedico, Apellido_Medico = @apellidoMedico, Correo = @correo, Telefono_Medico = @telefono, Cod_Especialidad = @especialidad, HorarioInicio = @horaInicial, HorarioFinal = @horaFinal, DNI_Medico = @dniMedico, Sexo = @sexo, Nacionalidad_Med = @nacionalidadMed, Birthdate = @nacimiento, Direccion = @direccion, Id_Provincia = @provincia, Id_Localidad = @localidad WHERE Legajo_Medico = @legajoMedico";
            SqlCommand sqlCommand = new SqlCommand(consultaSQL);
            EditarParametros(ref sqlCommand, medico);
            int filas = conexion.ejecutarComando(sqlCommand);
            if (filas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable obtenerTurnosPorMedico(int legajo)
        {
            string sql = @"SELECT T.ID_Turno, T.dia, T.horario, P.nombre_paciente + ' ' + P.apellido_paciente AS Paciente, T.Estado_Turno, T.Observaciones
            FROM Turno T
            INNER JOIN Paciente P ON T.DNI_paciente = P.DNI_Paciente
            WHERE T.Legajo_Medico = @legajo";

            SqlCommand sqlCommand = new SqlCommand(sql);
            sqlCommand.Parameters.AddWithValue("@legajo", legajo);

            return conexion.getTablaConParametro(sqlCommand);
        }

        public bool ActualizarTurno(int idTurno, int estado, string observaciones)
        {
            string consultaSQL = @"UPDATE Turno SET Estado_Turno = @estado, Observaciones = @observaciones WHERE ID_Turno = @idTurno";
            SqlCommand sqlCommand = new SqlCommand(consultaSQL);
            sqlCommand.Parameters.AddWithValue("@estado", estado);
            sqlCommand.Parameters.AddWithValue("@observaciones", observaciones);
            sqlCommand.Parameters.AddWithValue("@idTurno", idTurno);
            int filas = conexion.ejecutarComando(sqlCommand);
            if (filas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable ObtenerInformeAsistencias(DateTime desde, DateTime hasta)
        {
            string sql = @"SELECT T.dia, T.horario, M.Nombre_Medico + ' ' + M.Apellido_Medico AS Medico, P.nombre_paciente + ' ' + P.apellido_paciente AS Paciente, T.Estado_Turno, T.Observaciones
            FROM Turno T
            INNER JOIN Medico M ON T.Legajo_Medico = M.Legajo_Medico
            INNER JOIN Paciente P ON T.DNI_paciente = P.DNI_Paciente
            WHERE T.dia BETWEEN @desde AND @hasta";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            return conexion.getTablaConParametro(cmd);
        }


    }
}
