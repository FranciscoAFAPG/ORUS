using ORUSCURSO.Datos;
using ORUSCURSO.Logica;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ORUSCURSO.Presentacion
{
    public partial class CtlUsuarios : UserControl
    {
        public CtlUsuarios()
        {
            InitializeComponent();
        }
        int idUsuario;
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Limpiar();
            habilitarPaneles();
            MostrarModulos();
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
        }
        private void habilitarPaneles()
        {
            panelRegistro.Visible = true;
            lblAnuncioIcono.Visible = true;
            panelIcono.Visible = false;
            panelRegistro.Dock = DockStyle.Fill;
            panelRegistro.BringToFront();
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

        }
        private void MostrarModulos()
        {
            Dmodulos funcion = new Dmodulos();
            DataTable dt = new DataTable();
            funcion.mostrar_modulos(ref dt);
            dataListadoModulos.DataSource = dt;
            dataListadoModulos.Columns[1].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (!string.IsNullOrEmpty(txtUsuario.Text))
                {
                    if (!string.IsNullOrEmpty(txtContraseña.Text))
                    {
                        if (lblAnuncioIcono.Visible == false)
                        {
                            insertarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un Icono");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese la Contraseña");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el Usuario");
                }
            }
            else
            {
                MessageBox.Show("Ingrese el Nombre");
            }
        }
        private void insertarUsuarios()
        {
            Lusuarios parametros = new Lusuarios();
            Dusuarios funcion = new Dusuarios();
            parametros.Nombre = txtNombre.Text;
            parametros.Login = txtUsuario.Text;
            parametros.Password = txtContraseña.Text;
            MemoryStream ms = new MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();
            if (funcion.insertarUsuarios(parametros) == true)
            {
                obtenerIdUsuario();
                insertarPermisos();
            }

        }
        private void insertarPermisos()
        {
            foreach (DataGridViewRow row in dataListadoModulos.Rows)
            {
                int IdModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                bool marcado = Convert.ToBoolean(row.Cells["Marcar"].Value);
                if (marcado == true)
                {
                    Lpermisos parametros = new Lpermisos();
                    Dpermisos funcion = new Dpermisos();
                    parametros.IdModulos = IdModulo;
                    parametros.IdUsuario = idUsuario;
                    funcion.InsertarPermisos(parametros);
                }
            }
            mostrarUsuarios();
            panelRegistro.Visible = false;
        }
        private void mostrarUsuarios()
        {
            DataTable dt = new DataTable();
            Dusuarios funcion = new Dusuarios();
            funcion.mostrarUsuarios(ref dt);
            dataListadoUsuarios.DataSource = dt;
            DiseñarDtvUsuarios();
        }
        private void DiseñarDtvUsuarios()
        {
            Bases.DiseñoDtv(ref dataListadoUsuarios);
            Bases.DiseñoDtvEliminar(ref dataListadoUsuarios);
            dataListadoUsuarios.Columns[2].Visible = false;
            dataListadoUsuarios.Columns[5].Visible = false;
            dataListadoUsuarios.Columns[6].Visible = false;
        }
        private void obtenerIdUsuario()
        {
            Dusuarios funcion = new Dusuarios();
            funcion.obtenerIdUsuario(ref idUsuario, txtUsuario.Text);
        }

        private void lblAnuncioIcono_Click(object sender, EventArgs e)
        {
            mostrarPanelIcono();
        }
        private void mostrarPanelIcono()
        {
            panelIcono.Visible = true;
            panelIcono.Dock = DockStyle.Fill;
            panelIcono.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox3.Image;
            ocultarPanelIcono();
        }
        private void ocultarPanelIcono()
        {
            panelIcono.Visible = false;
            lblAnuncioIcono.Visible = false;
            Icono.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox4.Image;
            ocultarPanelIcono();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox5.Image;
            ocultarPanelIcono();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox6.Image;
            ocultarPanelIcono();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox7.Image;
            ocultarPanelIcono();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox8.Image;
            ocultarPanelIcono();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox9.Image;
            ocultarPanelIcono();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Icono.Image = pictureBox10.Image;
            ocultarPanelIcono();
        }

        private void agregarIcono_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Pictures|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Icono.BackgroundImage = null;
                Icono.Image = new Bitmap(dlg.FileName);
                ocultarPanelIcono();
            }
        }

        private void Icono_Click(object sender, EventArgs e)
        {
            mostrarPanelIcono();
        }

        private void CtlUsuarios_Load(object sender, EventArgs e)
        {
            mostrarUsuarios();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
        }

        private void btnVolverIcono_Click(object sender, EventArgs e)
        {
            ocultarPanelIcono();
        }
    }
}
