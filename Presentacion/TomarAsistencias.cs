using ORUSCURSO.Datos;
using ORUSCURSO.Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ORUSCURSO.Presentacion
{
    public partial class TomarAsistencias : Form
    {
        public TomarAsistencias()
        {
            InitializeComponent();
        }

        string identificacion;
        int Idpersonal;
        int Contador;
        DateTime fechaReg;
        private void TomarAsistencias_Load(object sender, EventArgs e)
        {

        }
        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
            BuscarPersonalIdent();
            if (identificacion == txtIdentificacion.Text)
            {
                buscarAsistenciasId();
                if (Contador == 0)
                {
                    DialogResult resultado = MessageBox.Show("¿Agregar una Observacion?", "Observaciones", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (resultado == DialogResult.OK)
                    {
                        panelObservacion.Visible = true;
                        panelObservacion.Location = new Point(panel5.Location.X, panel5.Location.Y);
                        panelObservacion.Size = new Size(panel5.Width, panel5.Height);
                        panelObservacion.BringToFront();
                        txtObservacion.Clear();
                        txtObservacion.Focus();
                    }
                    else
                    {
                        insertarAsistencias();
                    }
                }
                else
                {
                    confirmarSalida();
                }
            }
        }
        private void confirmarSalida()
        {
            Lasistencias parametros = new Lasistencias();
            Dasistencias funcion = new Dasistencias();
            parametros.Id_personal = Idpersonal;
            parametros.Fecha_salida = DateTime.Now;
            parametros.Horas = Bases.DateDiff(Bases.DateInterval.Hour, fechaReg, DateTime.Now);
            if (funcion.confirmarSalida(parametros) == true)
            {
                txtAviso.Text = "SALIDA REGISTRADA";
                txtIdentificacion.Clear();
                txtIdentificacion.Focus();
            }

        }
        private void insertarAsistencias()
        {
            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                txtObservacion.Text = "-";
            }
            Lasistencias parametros = new Lasistencias();
            Dasistencias funcion = new Dasistencias();
            parametros.Id_personal = Idpersonal;
            parametros.Fecha_entrada = DateTime.Now;
            parametros.Fecha_salida = DateTime.Now;
            parametros.Estado = "ENTRADA";
            parametros.Horas = 0;
            parametros.Observacion = txtObservacion.Text;
            if (funcion.InsertarAsistencias(parametros) == true)
            {
                txtAviso.Text = "ENTRADA REGISTRADA";
                txtIdentificacion.Clear();
                txtIdentificacion.Focus();
                panelObservacion.Visible = false;
            }
        }
        private void buscarAsistenciasId()
        {
            DataTable dt = new DataTable();
            Dasistencias funcion = new Dasistencias();
            funcion.buscarAsistenciasId(ref dt, Idpersonal);
            Contador = dt.Rows.Count;
            if (Contador > 0)
            {
                fechaReg = Convert.ToDateTime(dt.Rows[0]["Fecha_entrada"]);

            }
        }
        private void BuscarPersonalIdent()
        {
            DataTable dt = new DataTable();
            Dpersonal funcion = new Dpersonal();
            funcion.buscarPersonalIdentidad(ref dt, txtIdentificacion.Text);
            if (dt.Rows.Count > 0)
            {
                identificacion = dt.Rows[0]["Identificacion"].ToString();
                Idpersonal = Convert.ToInt32(dt.Rows[0]["Id_personal"]);
                txtNombre.Text = dt.Rows[0]["Nombres"].ToString();

            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            insertarAsistencias();
        }
    }

}
