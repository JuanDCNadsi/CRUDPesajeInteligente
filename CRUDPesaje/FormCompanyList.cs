using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDPesaje.BL;

namespace CRUDPesaje
{
    public partial class FormCompanyList : Form
    {

        DatabaseContext db = new DatabaseContext();
        public FormCompanyList()
        {
            InitializeComponent();
        }

        private void FormCompanyList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= db.Empresa.ToList();
            this.dataGridView1.Columns["EmpresaID"].Visible = false;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FormCompanyEditor Frm= new FormCompanyEditor();
            Frm.AgregarOEditar = 1;
            Frm.LblTitle.Text = "AGREGAR EMPRESA";
            Frm.ShowDialog();

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            var id =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var empresa = db.Empresa.Find(id);
            FormCompanyEditor  Frm = new FormCompanyEditor();
            Frm.LblTitle.Text = "EDITAR EMPRESA";
            Frm.BtnAgregarEmpresa.Text = "Editar";
            Frm.IDempresa = id;
            Frm.AgregarOEditar = 2;
            Frm.TxtNombre.Text = empresa.Nombre;
            Frm.NudCodigo.Value = empresa.Codigo;
            Frm.TxtDireccion.Text = empresa.Direccion;
            Frm.TxtCuidad.Text = empresa.Cuidad;
            Frm.TxtDepartamento.Text = empresa.Departamento;
            Frm.TxtPais.Text = empresa.Pais;
            Frm.TxtTelefono.Text = empresa.Telefono;
            Frm.ShowDialog();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Desea eliminar? " + id, "Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    var empresa = db.Empresa.Find(id);
                    db.Empresa.Remove(empresa);
                    db.SaveChanges();
                    MessageBox.Show("Eliminado Correctamente");
                    dataGridView1.DataSource = db.Empresa.ToList();
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var listado = (from a in db.Empresa
                               where a.Nombre.Contains(textBox1.Text)
                               select new
                               {
                                   empresaID = a.EmpresaID,
                                   nombre = a.Nombre,
                                   codigo = a.Codigo,
                                   direccion = a.Direccion,
                                   telefono = a.Telefono,
                                   cuidad = a.Cuidad,
                                   departamento = a.Departamento,
                                   pais = a.Pais,
                                   fechaAdd = a.FechaAdd,
                                   fechaEdit = a.FechaEdit

                               }).ToList();

                dataGridView1.DataSource = listado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
