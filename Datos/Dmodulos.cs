using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ORUSCURSO.Datos
{
    public class Dmodulos
    {
        public void mostrar_modulos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Modulos", CONEXIONMAESTRA.conectar);
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
    }
}
