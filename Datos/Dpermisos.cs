using ORUSCURSO.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ORUSCURSO.Datos
{
    public class Dpermisos
    {
        public bool InsertarPermisos(Lpermisos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarPermisos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdModulo", parametros.IdModulos);
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void mostrarPermisos(ref DataTable dt, Lpermisos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarPermisos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@IdUsuaeio", parametros.IdUsuario);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        public bool eliminarPermisos(Lpermisos parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminarPermisos", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
    }
}
