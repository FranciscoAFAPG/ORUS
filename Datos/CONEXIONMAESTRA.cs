﻿using System.Data;
using System.Data.SqlClient;

namespace ORUSCURSO.Datos
{
    public class CONEXIONMAESTRA
    {
        public static string conexion = @"Data source=LAPTOP-9KU8UPLR\SQLEXPRESS; Initial Catalog=ORUS369; Integrated Security=true";
        public static SqlConnection conectar = new SqlConnection(conexion);
        public static void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
        public static void cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }

    }
}
