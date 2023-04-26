using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web;
using Forms = System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Utilitarios
{
    public class Util : System.Web.UI.Page
    {

        public static Forms.Form MainForm = null;

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static string Encriptar(string p_password)
        {
            string v_encriptada = "";
            int[] aux = new int[] { 3, 24, 8, 10, 34, 17, 20, 21, 21, 3, 24, 8, 10, 34, 17, 20 };
            int v_contador = p_password.Length;
            for (int i = 0; i < v_contador; i++)
            {
                v_encriptada = v_encriptada + Convert.ToChar(Encoding.ASCII.GetBytes(p_password.Substring(i, 1))[0] + aux[i]).ToString();
            }
            return v_encriptada;
        }

        public static string Desencriptar(string p_password)
        {
            string v_desencriptada = ""; ;
            int[] aux = new int[] { 3, 24, 8, 10, 34, 17, 20, 21, 21, 3, 24, 8, 10, 34, 17, 20 };
            int v_contador = p_password.Length;
            for (int i = 0; i < v_contador; i++)
            {
                v_desencriptada = v_desencriptada + Convert.ToChar(Encoding.ASCII.GetBytes(p_password.Substring(i, 1))[0] - aux[i]).ToString();
            }
            return v_desencriptada;
        }

        public static void CargaCombo<T>(List<T> lstDatos, DropDownList oCombo, string sColVal, string sColDes, string sMsgInicial)
        {
            oCombo.DataSource = lstDatos;
            oCombo.DataValueField = sColVal;
            oCombo.DataTextField = sColDes;
            oCombo.DataBind();
            if (!string.IsNullOrEmpty(sMsgInicial))
                oCombo.Items.Insert(0, new ListItem(sMsgInicial, "%"));
        }

        public static void MostrarLoad(Page page)
        {
            //try
            //{
            //    ScriptManager.RegisterStartupScript(page, page.GetType(), "MostrarLoad", "MostrarLoad();", true);
            //}
            //catch (Exception ex)
            //{
            //    Util.MostrarMensaje(ex.Message.ToString());
            //}
        }

        //public static void OcultarLoad(Page page)
        //{
        //    try
        //    {
        //        ScriptManager.RegisterStartupScript(page, page.GetType(), "OcultarLoad", "OcultarLoad();", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Util.MostrarMensaje(ex.Message.ToString());
        //    }
        //}

        //public static void OcultarMenuLateral(Page page)
        //{
        //    try
        //    {
        //        ScriptManager.RegisterStartupScript(page, page.GetType(), "OcultarBarraLateral", "OcultarBarraLateral();", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Util.MostrarMensaje(ex.Message.ToString());
        //    }
        //}

        public static void MostrarLoad(UserControl page)
        {
            //try
            //{
            //    ScriptManager.RegisterStartupScript(page, page.GetType(), "MostrarLoad", "MostrarLoad();", true);
            //}
            //catch (Exception ex)
            //{
            //    Util.MostrarMensaje(ex.Message.ToString());
            //}
        }

        //public static void OcultarLoad(UserControl page)
        //{
        //    try
        //    {
        //        ScriptManager.RegisterStartupScript(page, page.GetType(), "OcultarLoad", "OcultarLoad();", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Util.MostrarMensaje(ex.Message.ToString());
        //    }
        //}

        public static void CargaCombo(DataSet oDsDatos, DropDownList oCombo, string sColVal, string sColDes, string sMsgInicial)
        {
            oCombo.DataSource = oDsDatos;
            oCombo.DataValueField = sColVal;
            oCombo.DataTextField = sColDes;
            oCombo.DataBind();
            if (!string.IsNullOrEmpty(sMsgInicial))
                oCombo.Items.Insert(0, new ListItem(sMsgInicial, "%"));
        }

        //public static void MostrarMensaje(string message)
        //{
        //   //  Cleans the message to allow single quotation marks 
        //    string cleanMessage = message.Replace("'", "\\'");
        //    string script = "alert('" + cleanMessage + "');";

        //    // Gets the executing web page 
        //    Page page = HttpContext.Current.CurrentHandler as Page;

        //   //  Checks if the handler is a Page and that the script isn't allready on the Page 
        //    if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        //    {

        //        ScriptManager.RegisterClientScriptBlock(page, typeof(Page), page.ClientID, script, true);

        //    }
        //}

        //public static void MostrarMensajeUrl(string message, string url)
        //{
        //     Cleans the message to allow single quotation marks 
        //    string cleanMessage = message.Replace("'", "\\'");
        //    string script = "alert('" + cleanMessage + "');window.location.href='" + url + "';";

        //     Gets the executing web page 
        //    Page page = HttpContext.Current.CurrentHandler as Page;

        //     Checks if the handler is a Page and that the script isn't allready on the Page 
        //    if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        //    {
        //        ScriptManager.RegisterClientScriptBlock(page, typeof(Page), page.ClientID, script, true);
        //    }
        //}

        public static void LimpiarControles(ControlCollection controles)
        {
            foreach (System.Web.UI.Control control in controles)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                    ((TextBox)control).Enabled = true;
                }
                else if (control is DropDownList)
                {
                    ((DropDownList)control).ClearSelection();
                    ((DropDownList)control).Enabled = true;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                    ((RadioButton)control).Enabled = true;
                }
                else if (control is RadioButtonList)
                {
                    ((RadioButtonList)control).ClearSelection();
                    ((RadioButtonList)control).Enabled = true;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                    ((CheckBox)control).Enabled = true;
                }
                else if (control.HasControls())
                    //Aquí se detécta un Control que contenga otros Controles, así ningún control se quedará sin ser limpiado.
                    LimpiarControles(control.Controls);
            }
        }

        public static DateTime GetFormatDateTime(string strFecha)
        {
            DateTime dFecha;

            if (string.IsNullOrEmpty(strFecha))
                dFecha = DateTime.Parse(DateTime.Now.ToShortDateString() + " 00:00", new CultureInfo("es-PE", false));
            else
                dFecha = DateTime.Parse(strFecha, new CultureInfo("es-PE", false));

            return dFecha;
        }

        /// <summary>
        /// Valida que se ingrese sólo números enteros
        /// </summary>
        public static void ValidarEntero_KeyPress(Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '\b' || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24)
            {
                e.Handled = false;
            }
        }

        /// <summary>
        /// Valida que se ingrese sólo números decimales
        /// </summary>
        public static void ValidarDecimal_KeyPress(object sender, Forms.KeyPressEventArgs e, int numDecimales)
        {
            char wDecimal = char.Parse(Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (((Forms.TextBox)sender).Text.Contains(wDecimal))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                int point = ((Forms.TextBox)sender).Text.IndexOf(wDecimal);

                if (((Forms.TextBox)sender).Text.Length > (point + numDecimales))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == wDecimal || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24)
                {
                    e.Handled = false;
                }

            }

            if (e.KeyChar == '\b')
                e.Handled = false;

        }

        /// <summary>
        /// Valida que se ingrese sólo letras
        /// </summary>
        public static void ValidarLetras_KeyPress(Forms.KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '\b' || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Valida que se ingrese sólo letras y números
        /// </summary>
        public static void ValidarAlfanumerico_KeyPress(Forms.KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '\b' || e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Valida que se ingrese sólo letras y números
        /// </summary>
        public static void ValidarTelefono_KeyPress(Forms.KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '\b' || e.KeyChar == 42 || e.KeyChar == 35)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Valida que se ingrese correctamente el formato de correo
        /// </summary>
        public static bool ValidarEmail(string email)
        {
            bool blnOk = true;

            string expresion = string.Empty;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                    blnOk = true;
                else
                    blnOk = false;
            }
            else
            {
                blnOk = false;
            }

            return blnOk;
        }

        /// <summary>
        /// Valida que se ingrese correctamente el número IP
        /// </summary>
        public static bool ValidarIP(string ip, out string msge)
        {
            bool blnOk = false;
            msge = string.Empty;
            IPAddress ot;

            if (ip.Replace(" ", "") == "...")
            {
                blnOk = false;
                msge = "Debe ingresar la dirección IP";
            }
            else
            {
                blnOk = IPAddress.TryParse(ip, out ot);
                msge = (blnOk) ? "OK" : "La dirección IP no es válida.";
            }

            return blnOk;
        }

        /// <summary>
        /// Valida que se ingrese correctamente el número de ruc
        /// </summary>
        public static bool ValidarRuc(string numeroRUC)
        {
            try
            {
                Int32 number = 0;
                if (Int32.TryParse(numeroRUC, out number))
                    return false;
                if (numeroRUC.Trim().Length != 11)
                    return false;
                int verificador = Convert.ToInt16(numeroRUC.Trim().Substring(0, 2));
                if (verificador != 10 && verificador != 20 && verificador != 15 && verificador != 17)
                    return false;
                int sum = 0;
                int[] arrayFactor = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                for (int i = 0; i < numeroRUC.Trim().Length - 1; i++)
                {
                    if (i != 10)
                        sum += Convert.ToInt16(numeroRUC.Trim().Substring(i, 1)) * arrayFactor[i];
                }
                int chk = (11 - (sum % 11));
                if (chk == 10)
                    chk = 0;
                if (chk == 11)
                    chk = 1;
                return (Convert.ToInt16(numeroRUC.Trim().Substring(10, 1)) == chk);
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
                return false;
            }
        }

        public static string GetPublicIp()
        {
            string ip = String.Empty;
            try
            {
                var context = System.Web.HttpContext.Current;

                if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                    ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                else if (!String.IsNullOrWhiteSpace(context.Request.UserHostAddress))
                    ip = context.Request.UserHostAddress;

                if (ip == "::1")
                    ip = "127.0.0.1";
            }
            catch (Exception)
            {
                ip = "0.0.0.0";
            }
            return ip;
        }

        //public static bool MandarSms(string Telefono, string Mensaje)
        //{
        //    bool flag = false;

        //    try
        //    {
        //        var client = new RestClient("http://api.convergia.com/sms/1/text/single");
        //        var request = new RestRequest(Method.POST);
        //        request.AddHeader("accept", "application/json");
        //        request.AddHeader("content-type", "application/json");
        //        request.AddHeader("authorization", "Basic U1VJWkFMQUI6T2NBTkFtMFY=");
        //        request.AddParameter("application/json", "{\"from\":\"SuizaLab\", \"to\":\"" + Telefono + "\",\"text\":\"" + Mensaje + "\"}", ParameterType.RequestBody);
        //        IRestResponse response = client.Execute(request);

        //        if (string.IsNullOrEmpty(response.ErrorMessage))
        //        {
        //            var obj = JObject.Parse(response.Content);

        //            if (obj["messages"][0]["status"]["groupName"].ToString().ToUpper() != "PENDING")
        //            {
        //                flag = true;
        //            }
        //            else
        //            {
        //                flag = false;
        //            }
        //        }
        //        else
        //        {
        //            flag = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        flag = false;
        //    }

        //    return flag;

        //}

        //public static bool VerificarEntregaSms()
        //{
        //    bool flag = false;
        //    try
        //    {
        //        var client = new RestClient("http://api.convergia.com/sms/1/reports?limit=2");
        //        var request = new RestRequest(Method.GET);
        //        request.AddHeader("accept", "application/json");
        //        request.AddHeader("authorization", "Basic U1VJWkFMQUI6T2NBTkFtMFY=");
        //        IRestResponse response = client.Execute(request);

        //        if (string.IsNullOrEmpty(response.ErrorMessage))
        //        {
        //            var obj = JObject.Parse(response.Content);

        //            if (!string.IsNullOrEmpty(obj["results"].ToString().Replace("[", "").Replace("]", "")))
        //            {
        //                if (obj["results"][0]["status"]["groupName"].ToString().ToUpper() == "DELIVERED")
        //                {
        //                    flag = true;
        //                }
        //                else
        //                {
        //                    flag = false;
        //                }
        //            }
        //            else
        //            {
        //                flag = VerificarEntregaSms();
        //            }
        //        }
        //        else
        //        {
        //            flag = false;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        flag = false;
        //    }

        //    return flag;
        //}

    }
}
