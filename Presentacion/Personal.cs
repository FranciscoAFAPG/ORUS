using ORUSCURSO.Datos;
using ORUSCURSO.Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ORUSCURSO.Presentacion
{
    public partial class Personal : UserControl
    {
        public Personal()
        {
            InitializeComponent();
        }
        int IdCargo = 0;
        int desde = 1;
        int hasta = 10;
        int contador;
        int Idpersonal;
        private int items_por_pagina = 10;
        string estado;
        int totalpaginas;

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LocalizarDtvCargos();
            PanelCargos.Visible = false;
            PanelPaginado.Visible = false;
            PanelRegistros.Visible = true;
            PanelRegistros.Dock = DockStyle.Fill;
            BtnGuardarPersonal.Visible = true;
            BtnGuardarCambiosPersonal.Visible = false;
            limpiar();
        }
        private void LocalizarDtvCargos()
        {
            dataListadoCargos.Location = new Point(txtSueldoPorHora.Location.X, txtSueldoPorHora.Location.Y);
            dataListadoCargos.Size = new Size(469, 141);
            dataListadoCargos.Visible = true;
            LblSueldo.Visible = false;
            PanelBtnGuardarPersonal.Visible = false;
        }

        private void limpiar()
        {
            txtNombres.Clear();
            txtIdentificacion.Clear();
            txtCargo.Clear();
            txtSueldoPorHora.Clear();
            BuscarCargos();
        }

        private void BtnGuardarPersonal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombres.Text))
            {
                if (!string.IsNullOrEmpty(txtIdentificacion.Text))
                {
                    if (!string.IsNullOrEmpty(cbxPais.Text))
                    {
                        if (IdCargo > 0)
                        {
                            if (!string.IsNullOrEmpty(txtSueldoPorHora.Text))
                            {
                                insertarPersonal();
                            }
                        }
                    }
                }
            }
        }

        private void insertarPersonal()
        {
            Lpersonal parametros = new Lpersonal();
            Dpersonal funcion = new Dpersonal();
            parametros.Nombres = txtNombres.Text;
            parametros.Identificacion = txtIdentificacion.Text;
            parametros.Pais = cbxPais.Text;
            parametros.Id_cargo = IdCargo;
            parametros.SueldoPorHora = Convert.ToDouble(txtSueldoPorHora.Text);
            if (funcion.insertarPersonal(parametros) == true)
            {
                reiniciarPaginado();
                MostrarPersonal();
                PanelRegistros.Visible = false;
            }

        }
        private void MostrarPersonal()
        {
            DataTable dt = new DataTable();
            Dpersonal funcion = new Dpersonal();
            funcion.mostrarPersonal(ref dt, desde, hasta);
            dataListadoPersonal.DataSource = dt;
            DiseñarDataGridViewPersonal();
        }
        private void DiseñarDataGridViewPersonal()
        {
            Bases.DiseñoDtv(ref dataListadoPersonal);
            Bases.DiseñoDtvEliminar(ref dataListadoPersonal);
            PanelPaginado.Visible = true;
            dataListadoPersonal.Columns[2].Visible = false;
            dataListadoPersonal.Columns[7].Visible = false;
        }

        private void insertarCargos()
        {
            if (!string.IsNullOrEmpty(txtCargoG.Text))
            {
                if (!string.IsNullOrEmpty(txtSueldoG.Text))
                {
                    Lcargos parametros = new Lcargos();
                    Dcargos funcion = new Dcargos();
                    parametros.Cargo = txtCargoG.Text;
                    parametros.SueldoPorHora = Convert.ToDouble(txtSueldoG.Text);
                    if (funcion.insertarCargo(parametros) == true)
                    {
                        txtCargo.Clear();
                        BuscarCargos();
                        PanelCargos.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Agregue el sueldo", "Falta el sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Agregue el cargo", "Falta el cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BuscarCargos()
        {
            DataTable dt = new DataTable();
            Dcargos funcion = new Dcargos();
            funcion.buscarCargos(ref dt, txtCargo.Text);
            dataListadoCargos.DataSource = dt;
            Bases.DiseñoDtv(ref dataListadoCargos);
            dataListadoCargos.Columns[1].Visible = false;
            dataListadoCargos.Columns[3].Visible = false;
            dataListadoCargos.Visible = true;
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            BuscarCargos();
        }

        private void BtnAgregarCargo_Click(object sender, EventArgs e)
        {
            PanelCargos.Visible = true;
            PanelCargos.Dock = DockStyle.Fill;
            PanelCargos.BringToFront();
            btnGuardarC.Visible = true;
            btnGuardarCambiosC.Visible = false;
            txtCargoG.Clear();
            txtSueldoG.Clear();
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            insertarCargos();
        }

        private void txtSueldoG_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtSueldoG, e);
        }

        private void txtSueldoPorHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtSueldoPorHora, e);
        }

        private void dataListadoCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoCargos.Columns["EditarC"].Index)
            {
                ObtenerCargosEditar();
            }
            if (e.ColumnIndex == dataListadoCargos.Columns["Cargo"].Index)
            {
                ObtenerDatosCargos();
            }
        }
        private void ObtenerDatosCargos()
        {
            IdCargo = Convert.ToInt32(dataListadoCargos.SelectedCells[1].Value);
            txtCargo.Text = dataListadoCargos.SelectedCells[2].Value.ToString();
            txtSueldoPorHora.Text = dataListadoCargos.SelectedCells[3].Value.ToString();
            dataListadoCargos.Visible = false;
            PanelBtnGuardarPersonal.Visible = true;
            LblSueldo.Visible = true;
        }

        private void ObtenerCargosEditar()
        {
            IdCargo = Convert.ToInt32(dataListadoCargos.SelectedCells[1].Value);
            txtCargoG.Text = dataListadoCargos.SelectedCells[2].Value.ToString();
            txtSueldoG.Text = dataListadoCargos.SelectedCells[3].Value.ToString();

            btnGuardarCambiosC.Visible = true;
            btnGuardarC.Visible = false;
            txtCargoG.Focus();
            txtCargoG.SelectAll();
            PanelCargos.Visible = true;
            PanelCargos.Dock = DockStyle.Fill;
            PanelCargos.BringToFront();
        }

        private void btnVolverCargos_Click(object sender, EventArgs e)
        {
            PanelCargos.Visible = false;
        }

        private void btnVolverPersonal_Click(object sender, EventArgs e)
        {
            PanelRegistros.Visible = false;
            PanelPaginado.Visible = true;
        }

        private void btnGuardarCambiosC_Click(object sender, EventArgs e)
        {
            EditarCargos();
        }

        private void EditarCargos()
        {
            Lcargos parametros = new Lcargos();
            Dcargos funcion = new Dcargos();
            parametros.Id_cargo = IdCargo;
            parametros.Cargo = txtCargoG.Text;
            parametros.SueldoPorHora = Convert.ToDouble(txtSueldoG.Text);
            if (funcion.editarCargo(parametros) == true)
            {
                txtCargo.Clear();
                BuscarCargos();
                PanelCargos.Visible = false;
            }
        }

        private void Personal_Load(object sender, EventArgs e)
        {
            reiniciarPaginado();
            MostrarPersonal();
        }
        private void reiniciarPaginado()
        {
            desde = 1;
            hasta = 10;
            Contar();
            if (contador > hasta)
            {
                btn_sig.Visible = true;
                btn_ant.Visible = false;
                btn_ultima.Visible = true;
                btn_primera.Visible = true;
            }
            else
            {
                btn_sig.Visible = false;
                btn_ant.Visible = false;
                btn_ultima.Visible = false;
                btn_primera.Visible = false;
            }
            Paginar();
        }
        private void dataListadoPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoPersonal.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("Solo se cambiara el estado para que no pueda acceder, Desea Continuar?", "Eliminar registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarPersonal();
                }
            }
            if (e.ColumnIndex == dataListadoPersonal.Columns["Editar"].Index)
            {
                ObtenerDatos();
            }
        }
        private void ObtenerDatos()
        {
            Idpersonal = Convert.ToInt32(dataListadoPersonal.SelectedCells[2].Value);
            estado = dataListadoPersonal.SelectedCells[8].Value.ToString();
            if (estado == "ELIMINADO")
            {
                RestaurarPersonal();
            }
            else
            {
                LocalizarDtvCargos();
                txtNombres.Text = dataListadoPersonal.SelectedCells[3].Value.ToString();
                txtIdentificacion.Text = dataListadoPersonal.SelectedCells[4].Value.ToString();
                cbxPais.Text = dataListadoPersonal.SelectedCells[10].Value.ToString();
                txtCargo.Text = dataListadoPersonal.SelectedCells[6].Value.ToString();
                IdCargo = Convert.ToInt32(dataListadoPersonal.SelectedCells[7].Value);
                txtSueldoPorHora.Text = dataListadoPersonal.SelectedCells[5].Value.ToString();
                PanelPaginado.Visible = false;
                PanelRegistros.Visible = true;
                PanelRegistros.Dock = DockStyle.Fill;
                PanelCargos.Visible = false;
                dataListadoCargos.Visible = false;
                LblSueldo.Visible = true;
                PanelBtnGuardarPersonal.Visible = true;
                BtnGuardarPersonal.Visible = false;
                BtnGuardarCambiosPersonal.Visible = true;
            }
        }
        private void RestaurarPersonal()
        {
            DialogResult result = MessageBox.Show("Este personal se Elimino. ¿Desea Volver a Habilitarlo?", "Restauracion de registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                HabilitarPersonal();
            }
        }
        private void HabilitarPersonal()
        {
            Lpersonal parametros = new Lpersonal();
            Dpersonal funcion = new Dpersonal();
            parametros.Id_personal = Idpersonal;
            if (funcion.restaurarPersonal(parametros) == true)
            {
                MostrarPersonal();
            }
        }
        private void EliminarPersonal()
        {
            Idpersonal = Convert.ToInt32(dataListadoPersonal.SelectedCells[2].Value);
            Lpersonal parametros = new Lpersonal();
            Dpersonal funcion = new Dpersonal();
            parametros.Id_personal = Idpersonal;
            if (funcion.eliminarPersonal(parametros) == true)
            {
                MostrarPersonal();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DiseñarDataGridViewPersonal();
            timer1.Stop();
        }

        private void dataListadoPersonal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnGuardarCambiosPersonal_Click(object sender, EventArgs e)
        {
            EditarPersonal();
        }
        private void EditarPersonal()
        {
            Lpersonal parametros = new Lpersonal();
            Dpersonal funcion = new Dpersonal();
            parametros.Id_personal = Idpersonal;
            parametros.Nombres = txtNombres.Text;
            parametros.Identificacion = txtIdentificacion.Text;
            parametros.Pais = cbxPais.Text;
            parametros.Id_cargo = IdCargo;
            parametros.SueldoPorHora = Convert.ToDouble(txtSueldoPorHora.Text);
            if (funcion.editarPersonal(parametros) == true)
            {
                MostrarPersonal();
                PanelRegistros.Visible = false;
            }

        }

        private void btn_sig_Click(object sender, EventArgs e)
        {
            desde += 10;
            hasta += 10;
            MostrarPersonal();
            Contar();
            if (contador > hasta)
            {
                btn_sig.Visible = true;
                btn_ant.Visible = true;
            }
            else
            {
                btn_sig.Visible = false;
                btn_ant.Visible = true;
            }
            Paginar();
        }
        private void Paginar()
        {
            try
            {
                lbl_pagina.Text = (hasta / 10).ToString();
                lbl_totalPaginas.Text = Math.Ceiling(Convert.ToSingle(contador) / items_por_pagina).ToString();
                totalpaginas = Convert.ToInt32(lbl_totalPaginas.Text);
            }
            catch (Exception)
            {

            }
        }
        private void Contar()
        {
            Dpersonal funcion = new Dpersonal();
            funcion.contarPersonal(ref contador);
        }

        private void btn_ant_Click(object sender, EventArgs e)
        {
            desde -= 10;
            hasta -= 10;
            MostrarPersonal();
            Contar();
            if (contador > hasta)
            {
                btn_sig.Visible = true;
                btn_ant.Visible = true;
            }
            else
            {
                btn_sig.Visible = false;
                btn_ant.Visible = true;
            }
            if (desde == 1)
            {
                reiniciarPaginado();
            }
            Paginar();
        }

        private void btn_ultima_Click(object sender, EventArgs e)
        {
            hasta = totalpaginas * items_por_pagina;
            desde = hasta - 9;
            MostrarPersonal();
            Contar();
            if (contador > hasta)
            {
                btn_sig.Visible = true;
                btn_ant.Visible = true;
            }
            else
            {
                btn_sig.Visible = false;
                btn_ant.Visible = true;
            }
            if (desde == 1)
            {
                reiniciarPaginado();
            }
            Paginar();
        }

        private void btn_primera_Click(object sender, EventArgs e)
        {
            reiniciarPaginado();
            MostrarPersonal();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarPersonal();
        }
        private void BuscarPersonal()
        {
            DataTable dt = new DataTable();
            Dpersonal funcion = new Dpersonal();
            funcion.buscarPersonal(ref dt, desde, hasta, txtBuscador.Text);
            dataListadoPersonal.DataSource = dt;
            DiseñarDataGridViewPersonal();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            reiniciarPaginado();
            MostrarPersonal();
            txtBuscador.Clear();
        }
    }
}
