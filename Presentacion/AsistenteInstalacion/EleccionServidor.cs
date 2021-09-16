using System;
using System.Windows.Forms;

namespace ORUSCURSO.Presentacion.AsistenteInstalacion
{
    public partial class EleccionServidor : Form
    {
        public EleccionServidor()
        {
            InitializeComponent();
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            Dispose();
            InstalacionBd frm = new InstalacionBd();
            frm.ShowDialog();

        }

        private void btnRemoto_Click(object sender, EventArgs e)
        {
            Dispose();
            ConexionRemota frm = new ConexionRemota();
            frm.ShowDialog();

        }
    }
}
