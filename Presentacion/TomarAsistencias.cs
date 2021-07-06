using System;
using System.Windows.Forms;

namespace ORUSCURSO.Presentacion
{
    public partial class TomarAsistencias : Form
    {
        public TomarAsistencias()
        {
            InitializeComponent();
        }
        private void TomarAsistencias_Load(object sender, EventArgs e)
        {

        }
        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

    }
}
