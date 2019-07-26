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

namespace AppVet.Facturacion
{
    public partial class frmFacturacion : Form
    {
        Gestion ObjGes = new Gestion();
        int Total = 0,Devuelta=0;
        public frmFacturacion()
        {
            InitializeComponent();
            LLenarcbProducto();
        }

        private void LLenarcbProducto()
        {
           
            cbProductos.DataSource = ObjGes.cbProducto();
            cbProductos.ValueMember = "ID_PRODUCTO";
            cbProductos.DisplayMember = "DESCRIPCION";
        }
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            List<ProductoView> ListPro = new List<ProductoView>();
            foreach (DataGridViewRow Row in dgvProductosAgregados.Rows)
            {
                if (Convert.ToInt32(Row.Cells[0].Value) != 0)
                {
                    ProductoView pro = new ProductoView();
                    pro.ID_PRODUCTO = Convert.ToInt32(Row.Cells[0].Value);
                    pro.CANTIDAD = Convert.ToInt32(Row.Cells[2].Value);
                    pro.PRECIO = Convert.ToInt32(Row.Cells[3].Value);
                    ListPro.Add(pro);
                }

            }
            if (ObjGes.GuardarFactura(Total.ToString(), ListPro))
            {
                Devuelta = Convert.ToInt32(txtDevuelta.Value) - Convert.ToInt32(Total);
                MessageBox.Show("Devuelta " + Devuelta);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al guardar la factura");
            }
        }
       
        private void btnAgregarPro_Click(object sender, EventArgs e)
        {
            object ID_Producto = cbProductos.SelectedValue;
            int sw = 0;
            foreach (DataGridViewRow Row in dgvProductosAgregados.Rows)
            {
                if (Row.Cells[0].Value !=null)
                { 
                    if (Row.Cells[0].Value.ToString() == ID_Producto.ToString())
                    {
                        sw = 1;
                        break;
                    }
                }

            }
            if (sw == 0)
            {
                List<ProductoView> Producto = ObjGes.ConsultProducto(Convert.ToInt32(ID_Producto));
                DataGridViewRow row = (DataGridViewRow)dgvProductosAgregados.Rows[0].Clone();
                row.Cells[0].Value = ID_Producto;
                row.Cells[1].Value = Producto.ElementAt(0).DESCRIPCION;
                row.Cells[2].Value = txtCantidad.Value;
                row.Cells[3].Value = Producto.ElementAt(0).PRECIO;
                row.Cells[4].Value = txtCantidad.Value * Producto.ElementAt(0).PRECIO;
                dgvProductosAgregados.Rows.Add(row);
                Total = Total + Convert.ToInt32(row.Cells[4].Value.ToString());
                lblTotal.Text = Total.ToString();
            }
        }

        private void dgvProductosAgregados_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Total = Total - Convert.ToInt32(e.Row.Cells[4].Value);
            lblTotal.Text = Total.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            cbProductos.SelectedIndex = 0;
            txtCantidad.Value = 1;
            lblTotal.Text = "0";
            txtDevuelta.Value = 0;
            dgvProductosAgregados.DataSource = null;
            dgvProductosAgregados.Rows.Clear();
            dgvProductosAgregados.Refresh();
            Total = 0;
            Devuelta = 0;
        }
    }
}
