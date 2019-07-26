using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVet.Producto;
using AppVet.Facturacion;

namespace AppVet.Inicio
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void pRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto Producto = new frmProducto();
            Producto.ShowDialog();
        }

        private void fACTURACIÓNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturacion Facturacion = new frmFacturacion();
            Facturacion.ShowDialog();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
