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
    public partial class mantenimientoCompra : Form
    {
        Controlador cn = new Controlador();

        public mantenimientoCompra()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var frmM = new mantenimiento();
            frmM.Show();
            this.Hide();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DataTable data = cn.llenarTblCompras("");
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.DataSource = data;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string documento_compraenca = txtDocCom.Text;
            string codigo_proveedor = txtCodCom.Text;
            string fecha_compraenca = txtFecCom.Text;
            string total_compraenca = txtTotCom.Text;



            if (cn.ingresoCompras(documento_compraenca, codigo_proveedor, fecha_compraenca, total_compraenca))
            {
                MessageBox.Show("Ingreso exitoso");
            }
            else
            {
                MessageBox.Show("Error de ingreso");
            }
            txtDocCom.Text = "";
            txtCodCom.Text = "";
            txtFecCom.Text = "";
            txtTotCom.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
