using System;
using System.Windows.Forms;

namespace ORUSCURSO
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //    Presentacion.TomarAsistencias frm = new Presentacion.TomarAsistencias();
             //   Presentacion.Login frm = new Presentacion.Login();
            Presentacion.MenuPrincipal frm = new Presentacion.MenuPrincipal();
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
            Application.Run();
        }

        private static void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

    }
}
