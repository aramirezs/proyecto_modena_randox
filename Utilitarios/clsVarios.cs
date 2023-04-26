using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Configuration;


namespace Utilitarios
{
    public class clsVarios
    {
        public void gvi_open_sheet(Form lwn_local, Form lwn_mdi, FormWindowState lwn_state)
        {
            lwn_local.MdiParent = lwn_mdi;
            lwn_local.WindowState = lwn_state;
            lwn_local.Show();

        }

        public DialogResult gvi_open_resp(Form lwn_local, Form lwn_parent, FormWindowState lwn_state)
        {
            lwn_local.StartPosition = FormStartPosition.CenterParent;
            lwn_local.WindowState = lwn_state;
            return lwn_local.ShowDialog(lwn_parent);

        }

        public DialogResult gvi_open_resp(Form lwn_local, FormWindowState lwn_state)
        {
            lwn_local.StartPosition = FormStartPosition.CenterParent;
            lwn_local.WindowState = lwn_state;
            return lwn_local.ShowDialog();

        }

        public bool fn_filtrar_grilla(DataGridView dgv, string p_valor, int p_index)
        {
            if (!string.IsNullOrWhiteSpace(p_valor))
            {
                DataView dt = ((DataView)dgv.DataSource);
                StringBuilder s_order = new StringBuilder();

                if (dgv.SortedColumn != null)
                {
                    string v_columna_orden = dgv.SortedColumn.DataPropertyName;
                    string v_orden = " ";

                    if (dgv.SortOrder == SortOrder.Ascending)
                    {
                        v_orden = "asc";
                    }
                    else if (dgv.SortOrder == SortOrder.Descending)
                    {
                        v_orden = "desc";
                    }

                    s_order.Append(v_columna_orden);
                    s_order.Append(" ");
                    s_order.Append(v_orden);

                    dt.Sort = s_order.ToString();
                }

                string v_columna = dgv.Columns[p_index].DataPropertyName;
                StringBuilder s_filtro = new StringBuilder();
                s_filtro.Append(v_columna);
                s_filtro.Append(" like '");
                s_filtro.Append(p_valor);
                s_filtro.Append("%'");

                DataTable dt_aux = new DataTable();
                dt_aux = dt.ToTable();
                DataRow[] v_filas = dt_aux.Select(s_filtro.ToString());
                if (v_filas.Length > 0)
                {
                    int v_index = dt_aux.Rows.IndexOf(v_filas[0]);
                    dgv.FirstDisplayedScrollingRowIndex = v_index;
                    dgv.Rows[v_index].Selected = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public String fnNombreForm(Form olForm)
        {
            return olForm.Name;

        }

        public byte[] fn_LeerArchivo(string p_path_archivo)
        {
            try
            {
                return System.IO.File.ReadAllBytes(p_path_archivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }

}

