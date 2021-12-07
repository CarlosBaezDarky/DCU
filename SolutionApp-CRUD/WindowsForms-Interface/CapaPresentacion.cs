using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classLibrary_CRUD_Logic;
using Microsoft.VisualBasic;

namespace WindowsForms_Interface
{
    //Nombre: Carlos Eduardo Báez Méndez
    //Matricula: 202010160
    public partial class CapaPresentacion : Form
    {   
        CapaNegocio objetoCN = new CapaNegocio();
        private string idMerca = null;
        private bool editar = false;

        //Le otorga valores al dataGridView
        private void setDataGridDataSource() {
            //Instacanciacion y herencia de un nuevo objeto para evitar replicar datos en la tabla
            CapaNegocio objetoCN2 = new CapaNegocio();
            dataGridView1.DataSource = objetoCN2.ShowTable();
        }

        //Sobrecarga del metodo para mostrar el registro deseado
        private void setDataGridDataSource(string id)
        {
            CapaNegocio objetoCN2 = new CapaNegocio();
            dataGridView1.DataSource = objetoCN2.SearchRegister(id);
        }

        //Limpia los campos de los textBox
        private void TxtClear() {
            txtDescripcion.Clear();
            txtExistencia.Clear();
            txtComentario.Clear();
            txtEstado.Clear();
            txtNoEliminable.Clear();
        }
        public CapaPresentacion()
        {
            InitializeComponent();

        }

        private void CapaPresentacion_Load(object sender, EventArgs e)
        {
            setDataGridDataSource();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    objetoCN.InsertMerca(txtDescripcion.Text, txtExistencia.Text, txtComentario.Text, txtEstado.Text, txtNoEliminable.Text);
                    bool inserccion = CapaNegocio.getInserccionExitosa();
                    if (inserccion == true)
                    {
                        MessageBox.Show("Datos insertados correctamente.");
                        setDataGridDataSource();
                        TxtClear();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Datos no insertados correctamente, error:" + ex.Message); }
            }
            else {
                try {
                    objetoCN.UpdateMerca(txtDescripcion.Text, txtExistencia.Text, txtComentario.Text, txtEstado.Text, txtNoEliminable.Text, idMerca);
                    MessageBox.Show("Datos actulizados correctamente.");
                    setDataGridDataSource();
                    TxtClear();
                    editar = false;
                }
                catch (Exception ex){ MessageBox.Show("Datos no actulizados correctamente, error:" + ex.Message); }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtExistencia.Text = dataGridView1.CurrentRow.Cells["existencia"].Value.ToString();
                txtComentario.Text = dataGridView1.CurrentRow.Cells["comentario"].Value.ToString();
                txtEstado.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                txtNoEliminable.Text = dataGridView1.CurrentRow.Cells["noEliminable"].Value.ToString();
                idMerca = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else { MessageBox.Show("Seleccione una fila por favor."); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idMerca = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                objetoCN.DeleteMerca(idMerca);
                MessageBox.Show("Registro eliminado correctamente.");
                setDataGridDataSource();
            }
            else { MessageBox.Show("Seleccione una fila por favor."); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string id = Interaction.InputBox("Digite el id de la Mercancia.");
            try
            {
                setDataGridDataSource(id);
                MessageBox.Show("Registro encontrado correctamente.");
            }
            catch (Exception ex) { MessageBox.Show("Coloque un id valido."); }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            setDataGridDataSource();
        }
    }
}
