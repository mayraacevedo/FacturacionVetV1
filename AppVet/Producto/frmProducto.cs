using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVet.Datos;

namespace AppVet.Producto
{
    public partial class frmProducto : Form
    {
        Gestion ObjGes = new Gestion();
        public frmProducto()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ObjGes.GuardarProducto(txtDescripcion.Text.Trim(),txtPrecio.Value.ToString()))
            {
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al guardar la factura");
            }
        }
        private void Limpiar()
        {
            txtDescripcion.Text = "";
            txtPrecio.Value = 0;
        }
   }
}
