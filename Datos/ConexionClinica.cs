using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{   
    public class ConexionClinica
    {
        private const string con = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=BDClinica;Integrated Security=True";


        public SqlConnection obtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(con);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex) {
                throw new Exception("Error al conectar a la base");
            }
        }

        public bool existe(SqlCommand sqlcommand)
        {
            SqlConnection connection = obtenerConexion();
            SqlCommand sqlCommand = sqlcommand;
            sqlCommand.Connection = connection;
            //sqlCommand.
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if(reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SqlDataAdapter obtenerAdapter(string sql, SqlConnection sqlConnection)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                return sqlDataAdapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable getTabla(string sql/*, string nombreTabla*/)
        {
            SqlConnection conexion = obtenerConexion();
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = obtenerAdapter(sql, conexion);
            dataAdapter.Fill(table);
            return table;
        }

        public DataTable getTablaConParametro(SqlCommand sqlcommand)
        {
            SqlConnection connection = obtenerConexion();
            SqlCommand sqlCommand = sqlcommand;
            sqlCommand.Connection = connection;

            try
            {
                DataTable table = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(table);
                connection.Close();
                return table;
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;
            }
        }

        public int ejecutarComando(SqlCommand CommandSQL, string consultaSQL)
        {
            int filasEditadas;

            SqlConnection Conexion = obtenerConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand = CommandSQL;
            sqlCommand.Connection = Conexion;
            sqlCommand.CommandText = consultaSQL;
            filasEditadas = sqlCommand.ExecuteNonQuery();
            Conexion.Close();
            return filasEditadas;
        }

        public int ejecutarComando(SqlCommand CommandSQL)
        {
            int filasEditadas;

            SqlConnection Conexion = obtenerConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand = CommandSQL;
            sqlCommand.Connection = Conexion;
            filasEditadas = sqlCommand.ExecuteNonQuery();
            Conexion.Close();
            return filasEditadas;
        }


    }
}
