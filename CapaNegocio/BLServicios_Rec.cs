using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class BLServicios_Rec
    {
        #region Metodos Públicos

        public static BEServicios_Rec Lab_Mod_Sui_Result_Update(BEServicios_Rec entidad)
        {
            try
            {
                entidad = CapaDatos.DAServicios_Rec.Lab_Mod_Sui_Result_Update(entidad);
            }
            catch (Exception ex)
            {
                entidad = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return entidad;
        }
        public static BEServicios_Rec Lab_Mod_Sui_Result_Coment_Update(BEServicios_Rec entidad)
        {
            try
            {
                entidad = CapaDatos.DAServicios_Rec.Lab_Mod_Sui_Result_Coment_Update(entidad);
            }
            catch (Exception ex)
            {
                entidad = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return entidad;
        }
        public static List<BEServicios_Rec> Orden_Result_Select(string YearOrden, string ExaCodigo)
        {
            List<BEServicios_Rec> ListServicioLab = null;
            try
            {
                ListServicioLab = CapaDatos.DAServicios_Rec.Orden_Result_Select(YearOrden, ExaCodigo);
            }
            catch (Exception ex)
            {
                ListServicioLab = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return ListServicioLab;
        }
        public static BEServicios_Rec Validar_Servicios_Det(BEServicios_Rec entidad)
        {
            try
            {
                entidad = CapaDatos.DAServicios_Rec.Validar_Servicios_Det(entidad);
            }
            catch (Exception ex)
            {
                entidad = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return entidad;
        }

      
        #endregion
    }
}
