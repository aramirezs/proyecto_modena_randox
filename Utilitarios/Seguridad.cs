using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utilitarios
{
    public class Seguridad
    {

        #region Propiedades

        /// <summary>
        /// Graba el log de eventos del servicio windows.
        /// </summary>
        public static void SaveLog(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Seguros_SaveLog\SaveLog";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\SaveLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Graba el log de eventos del servicio windows.
        /// </summary>
        public static void LogService(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"E:\WS_Suiza_Laboratorio\ServiceSendModena";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\SendModenaHost_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " +  DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt")  + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceEnvioAutomatico(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"E:\WS_Suiza_Laboratorio\ServiceSendModena";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceEnvioAutomatico_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + "[" + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + "]" + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceEstados(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceUpdateEstados";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceUpdateEstados_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceNotificacionEventos(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceSendEventos";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceSendEventos_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceMedicoDomicilio(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceMedicoDomicilio";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceMedicoDomicilio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceLiquidacionAmericana(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceLiquidacionAmericana";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceLiquidacionAmericana_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceMedicoDomicilioAll(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceMedicoDomicilioAll";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceMedicoDomicilioAll_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceAvisoProvincia(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceAvisoProvincia";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceAvisoProvincia_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceAdjuntarGrupo(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceAdjuntarGrupo";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceAdjuntarGrupo_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServicePruebaEsfuerzo(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServicePruebaEsfuerzo";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServicePruebaEsfuerzo" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceEKG(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceEKG";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceEKG" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceConsentimiento(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros_RimacPreAsegurabilidad\Consentimiento";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\SendEmail_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceTGP(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceTGP";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceTGP_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceGammaGlutamil(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceGammaGlutamil";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceGammaGlutamil_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceAdicional(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\SendAdicional";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\SendAdicional_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceProvincia(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceSendProvincia";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\SendEmail_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceSMSCita(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\SMS_CITA";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\SMS_CITA_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void LogServiceSMSAviso(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\SMS_AVISO";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\SMS_AVISO_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Encriptación Suiza Lab
        /// </summary>
        public static string Encriptar(string sPassword)
        {
            string sEncriptado = string.Empty;
            int iContador = sPassword.Length;

            int[] aux = new int[] { 3, 24, 8, 10, 34, 17, 20, 21, 21, 3, 24, 8, 10, 34, 17, 20 };

            for (int i = 0; i < iContador; i++)
            {
                sEncriptado = sEncriptado + Convert.ToChar(Encoding.ASCII.GetBytes(sPassword.Substring(i, 1))[0] + aux[i]).ToString();
            }

            return sEncriptado;
        }

        /// <summary>
        /// Desencriptación Suiza Lab
        /// </summary>
        public static string Desencriptar(string sPassword)
        {
            string sDesencriptado = string.Empty;
            int iContador = sPassword.Length;

            int[] aux = new int[] { 3, 24, 8, 10, 34, 17, 20, 21, 21, 3, 24, 8, 10, 34, 17, 20 };

            for (int i = 0; i < iContador; i++)
            {
                sDesencriptado = sDesencriptado + Convert.ToChar(Encoding.ASCII.GetBytes(sPassword.Substring(i, 1))[0] - aux[i]).ToString();
            }

            return sDesencriptado;
        }

        /// <summary>
        /// Graba el log de eventos del servicio windows.
        /// </summary>
        public static void LogServiceRellamada(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\WS_Suiza_Seguros\ServiceRellamada";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\ServiceRellamada_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public static void Dps_LogRimacSeguros(string strMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(strMessage))
                {
                    string strFile = string.Empty;
                    string strPath = @"C:\RimacDps\LogExterno";

                    if (!Directory.Exists(strPath))
                        Directory.CreateDirectory(strPath);

                    strFile = strPath + @"\LogExterno_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    strMessage = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " " + strMessage;

                    using (StreamWriter oWriter = File.AppendText(strFile))
                    {
                        oWriter.WriteLine(strMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        //public static string ConsumirServicioWebDps(string NumeroDocumento, string Estado, string Url, string Usuario, string Contrasena, string Identificador)
        //{
        //    string Resultado = string.Empty;

        //    try
        //    {
        //        Interfaz entidad = new Interfaz(Url, Usuario, Contrasena);
        //        entidad.NumeroDocumento = NumeroDocumento;
        //        entidad.Estado = Estado;
        //        entidad.Identificador = Identificador;

        //        entidad.ActualizarDatos();
        //    }
        //    catch (Exception ex)
        //    {
        //        Resultado = ex.Message.ToString();
        //    }

        //    return Resultado;
        //}

        #endregion

    }

}
