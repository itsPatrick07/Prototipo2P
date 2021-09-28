using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;

namespace CapaVista.Mantenimientos
{
    public partial class mantenimientoProveedores : Form
    {
        Controlador cn = new Controlador();

        public mantenimientoProveedores()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var frmM = new mantenimiento();
            frmM.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DataTable data = cn.llenarTblProveedores("");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = data;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string codigo_proveedor = txtCodPro.Text;
            string nombre_proveedor = txtNomPro.Text;
            string direccion_proveedor = txtDirPro.Text;
            string telefono_proveedor = txtTefPro.Text;
            string nit_proveedor = txtNitPro.Text;
            string estatus_proveedor = txtEstPro.Text;



            if (cn.ingresoProveedores(codigo_proveedor, nombre_proveedor, direccion_proveedor, telefono_proveedor, nit_proveedor, estatus_proveedor))
            {
                MessageBox.Show("Ingreso exitoso");
            }
            else
            {
                MessageBox.Show("Error de ingreso");
            }
            txtCodPro.Text = "";
            txtNomPro.Text = "";
            txtDirPro.Text = "";
            txtTefPro.Text = "";
            txtNitPro.Text = "";
            txtEstPro.Text = "";
        }
    }
}
