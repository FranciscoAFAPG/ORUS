using ORUSCURSO.Datos;
using ORUSCURSO.Presentacion.AsistenteInstalacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORUSCURSO.Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        string Usuario;
        int IdUsuario;
        int Contador;
        string Indicador;
        private void Login_Load(object sender, EventArgs e)
        {
            validarConexion();
        }
        private void validarConexion()
        {
            verificarConexion();
            if (Indicador == "Correcto")
            {
                dibujarUsuarios();
            }
            else
            {
                Dispose();
                EleccionServidor frm = new EleccionServidor();
                frm.ShowDialog();
            }
        }

        private void verificarConexion()
        {
            Dusuarios funcion = new Dusuarios();
            funcion.verificarUsuario(ref Indicador);
        }
        public void dibujarUsuarios()
        {
            try
            {
                PanelUsuarios.Visible = true;
                PanelUsuarios.Dock = DockStyle.Fill;
                PanelUsuarios.BringToFront();
                DataTable dt = new DataTable();
                Dusuarios funcion = new Dusuarios();
                funcion.mostrarUsuarios(ref dt);
                foreach (DataRow rdr in dt.Rows)
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    PictureBox I1 = new PictureBox();
                    b.Text = rdr["Login"].ToString();
                    b.Name = rdr["IdUsuario"].ToString();
                    b.Size = new Size(175, 25);
                    b.Font = new Font("Microsoft Scan Serif", 13);
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Bottom;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new Size(155, 167);
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(20, 20, 20);
                    
                    I1.Size = new Size(175, 162);
                    I1.Dock = DockStyle.Top;
                    I1.BackgroundImage = null;
                    byte[] bi = (Byte[])rdr["Icono"];
                    MemoryStream ms = new MemoryStream(bi);
                    I1.Image = Image.FromStream(ms);
                    I1.SizeMode = PictureBoxSizeMode.Zoom;
                    I1.Tag = rdr["Login"].ToString();
                    I1.Cursor = Cursors.Hand;

                    p1.Controls.Add(b);
                    p1.Controls.Add(I1);
                    b.BringToFront();

                    flowLayoutPanel1.Controls.Add(p1);

                }
            }catch (Exception)
            {

            }
        }
    }
}
