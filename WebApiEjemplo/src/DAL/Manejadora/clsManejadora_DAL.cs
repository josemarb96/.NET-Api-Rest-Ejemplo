using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENT;
using DAL.Conexion;

namespace DAL.Manejadora
{
    public class clsManejadora_DAL
    {
        private clsMyConnection miConexion;

        public clsManejadora_DAL()
        {
            miConexion = new clsMyConnection();
        }

        /// <summary>
        /// Permite añadir un objeto de la clase persona a la base de datos.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int insertarPersonaDAL (clsPersona persona)
        {
            int insert = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            //Añadimos los datos al comando
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.FechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;

            try
            {
                //Realizamos la conexión e insertamos los datos
                conexion = miConexion.getConnection();

                miComando.CommandText = "INSERT INTO personas(nombre, apellidos, fechaNac, direccion, telefono) VALUES (@nombre, @apellidos, @fechaNac, @direccion, @telefono)";

                miComando.Connection = conexion;
                insert = miComando.ExecuteNonQuery();

                return insert;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                miConexion.closeConnection(ref conexion);
            }
        } //Fin insertarPersonaDAL

        /// <summary>
        /// Permite borrar un objeto de la clase persona pasando el id de dicha persona como parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int borrarPersonaDAL(int id)
        {
            int delete = 0;

            //SqlConnection conexion = new SqlConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = miConexion.getConnection();
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                miComando.CommandText = "Delete From personas where IdPersona=@id";

                miComando.Connection = conexion;
                delete = miComando.ExecuteNonQuery();

                return delete;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                miConexion.closeConnection(ref conexion);
            }

            //return delete;
        } //Fin borrarPersonaDAL

        /// <summary>
        /// Permite actualizar un objeto d ela clase persona pasando el id de dicha persona como parámetro.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Devuelve 0 si la actualización no ha sido correcta, sino otro número en caso contrario</returns>
        public int actualizarPersonaDAL(clsPersona persona)
        {
            int update = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = miConexion.getConnection();

                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.ID;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
                miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.FechaNac;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;

                miComando.CommandText = "Update personas set Nombre=@nombre, Apellidos=@apellidos," + "FechaNac=@fechaNac, Direccion=@direccion, Telefono=@telefono Where IDPersona=@id";

                miComando.Connection = conexion;
                update = miComando.ExecuteNonQuery();
                update = update + 1;
                update--;

                return update;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                miConexion.closeConnection(ref conexion);
            }
            //return update;
        } //Fin actualizarPersonaDAL

        /// <summary>
        /// Permite ver el objeto de la clase persona seleccionado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona verPersonaDAL(int id)
        {
            clsPersona persona = new clsPersona();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miCommand = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion = miConexion.getConnection();

                miCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                miCommand.CommandText = "Select nombre,apellidos,fechaNac,direccion,telefono from personas where IDPersona=@id";
                miCommand.Connection = conexion;

                lector = miCommand.ExecuteReader();

                if (lector.HasRows) //Si la persona existe se muestra, sino no
                {
                    if (lector.Read())
                    {
                        persona.ID = id;
                        persona.Nombre = (String)lector["nombre"];
                        persona.Apellidos = (String)lector["apellidos"];
                        persona.FechaNac = (DateTime)lector["fechaNac"];
                        persona.Direccion = (String)lector["direccion"];
                        persona.Telefono = (String)lector["telefono"];
                    }
                }
                else
                    persona = null;

                return persona;
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                conexion.Close();
                miConexion.closeConnection(ref conexion);
            }

            //return persona;
        } //Fin verPersonaDAL

    } //Fin class
}
