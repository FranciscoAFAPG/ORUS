using ORUSCURSO.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ORUSCURSO.Datos
{
    public class Dusuarios
    {
        public bool insertarUsuarios(Lusuarios parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarUsuario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombres", parametros.Nombre);
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                cmd.Parameters.AddWithValue("@Password", parametros.Password);
                cmd.Parameters.AddWithValue("@Icono", parametros.Icono);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void mostrarUsuarios(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("select * from Usuarios", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void obtenerIdUsuario(ref int Idusuario, string Login)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("obtenerIdUsuario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login", Login);
                Idusuario = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public bool eliminarUsuario(Lusuarios parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("eliminarUsuario", CONEXIONMAESTRA.conectar);
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
        public bool restaurarUsuario(Lusuarios parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("restaurarUsuario", CONEXIONMAESTRA.conectar);
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
        public bool editarUsuario(Lusuarios parametros)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarUsuario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
                cmd.Parameters.AddWithValue("@NombresApellidos", parametros.Nombre);
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                cmd.Parameters.AddWithValue("@Password", parametros.Password);
                cmd.Parameters.AddWithValue("@Icono", parametros.Icono);
                cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
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
        public void buscarUsuario(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarUsuario", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void verificarUsuario(ref string Indicador)
        {
            try
            {
                int Iduser;
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("select IdUsuario from Usuarios", CONEXIONMAESTRA.conectar);
                Iduser = Convert.ToInt32(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                Indicador = "Correcto";
            }
            catch (Exception)
            {
                Indicador = "Incorrecto";
            }
        }
        public void validarUsuario(Lusuarios parametros, ref int id)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("validarUsuario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Password", parametros.Password);
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                id = 0;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
    }
}
