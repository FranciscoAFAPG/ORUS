using ORUSCURSO.Datos;
using ORUSCURSO.Logica;
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
                    b.Font = new Font("Microsoft Sans Serif", 13);
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

                    flowLayoutPanel2.Controls.Add(p1);

                    b.Click +=  eventoLabel;
                    I1.Click += eventoImagen;
                }
            }catch (Exception)
            {

            }
        }
        private void eventoImagen(object sender, EventArgs e)
        {
            Usuario = Convert.ToString(((PictureBox)sender).Tag);
            MostrarPanelPass();
        }
        private void eventoLabel(object sender, EventArgs e)
        {
            Usuario = ((Label)sender).Text;
            MostrarPanelPass();
        }
        private void MostrarPanelPass()
        {
            panelIngresoContraseña.Visible = true;
            panelIngresoContraseña.Location = new Point((Width - panelIngresoContraseña.Width) / 2, (Height - panelIngresoContraseña.Height) / 2);
            PanelUsuarios.Visible = false;
        }

        private void txtcontraseña_TextChanged(object sender, EventArgs e)
        {
            validarUsuario();
        }
        private void validarUsuario()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.Password = txtcontraseña.Text;
            parametros.Login = Usuario;
            funcion.validarUsuario(parametros, ref IdUsuario);
            if (IdUsuario > 0)
            {
                Dispose();
                MenuPrincipal frm = new MenuPrincipal();
                frm.ShowDialog();

            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña erronea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "3";

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "4";

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "5";

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "6";

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "7";

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "8";

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "9";

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtcontraseña.Text += "0";

        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            txtcontraseña.Clear();
        }

        private void btnborrarletra_Click(object sender, EventArgs e)
        {
            int contador;
            contador = txtcontraseña.Text.Count();
            if (contador > 0)
            {
                txtcontraseña.Text = txtcontraseña.Text.Substring(0,txtcontraseña.Text.Count()-1);
            }
        }
    }
}
