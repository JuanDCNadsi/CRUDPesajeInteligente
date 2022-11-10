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
    public partial class FormCompanyEditor : Form
    {
        public int AgregarOEditar = 0;
        public int IDempresa = 0;
        public DateTime Fecha = DateTime.Now;

        private DatabaseContext db = new DatabaseContext();
        public FormCompanyEditor()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregarEmpresa_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text.Length == 0 || TxtCuidad.Text.Length == 0 || TxtDepartamento.Text.Length == 0 || TxtDireccion.Text.Length == 0 || TxtPais.Text.Length == 0 || TxtTelefono.Text.Length == 0 || NudCodigo.Value == 0)
            {
                MessageBox.Show("Llenar todos los campos");
            }
            else
            {
                if (AgregarOEditar == 1)
                {
                    try
                    {
                        DateTime Fecha = DateTime.Now;
                        var empresa = new Empresa
                        {
                            Nombre = TxtNombre.Text,
                            Codigo = Convert.ToInt32(NudCodigo.Value.ToString()),
                            Direccion = TxtDireccion.Text,
                            Telefono = TxtTelefono.Text,
                            Cuidad = TxtCuidad.Text,
                            Departamento = TxtDepartamento.Text,
                            Pais = TxtPais.Text,
                            FechaAdd = Fecha,
                            FechaEdit = Fecha,
                        };
                        db.Empresa.Add(empresa);
                        db.SaveChanges();
                        MessageBox.Show("Agregado Correctamente");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error");
                        throw;
                    }
                }
                else if (AgregarOEditar == 2)
                {
                    try
                    {
                        var empresa = db.Empresa.Find(Convert.ToInt32(IDempresa));
                        empresa.Nombre = TxtNombre.Text;
                        empresa.Codigo = Convert.ToInt32(NudCodigo.Value.ToString());
                        empresa.Direccion = TxtDireccion.Text;
                        empresa.Telefono = TxtTelefono.Text;
                        empresa.Cuidad = TxtCuidad.Text;
                        empresa.Departamento = TxtDepartamento.Text;
                        empresa.Pais = TxtPais.Text;
                        empresa.FechaEdit = Fecha;
                        db.SaveChanges();
                        MessageBox.Show("Editado Correctamente");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error");
                        throw;
                    }
                }
            }
        }

    }
}
