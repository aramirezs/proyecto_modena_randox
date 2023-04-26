using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;


namespace CapaNegocio
{
    public class BLServicios
    {
        #region Metodos Públicos

        public static List<BEServicios> ServiciosLab_EnvioPen_Modena_cab(string Numsuc ,string YearOrden, string CodMuestra)
        {
            List<BEServicios> ListServicioLab = null;
            try
            {
                ListServicioLab = CapaDatos.DAServicios.ServiciosLab_EnvioPen_Modena_cab(Numsuc,YearOrden,CodMuestra);
            }
            catch (Exception ex)
            {
                ListServicioLab = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return ListServicioLab;
        }
        public static List<BEServicios> ServiciosLab_EnvioPen_Modena_det(string Numoscab, string Peroscab, string Anooscab, string Numsuc, string MueCodigo)
        {
            List<BEServicios> ListServicioLab = null;
            try
            {
               ListServicioLab = CapaDatos.DAServicios.ServiciosLab_EnvioPen_Modena_det(Numoscab,Peroscab,Anooscab,Numsuc,MueCodigo);
            }
            catch (Exception ex)
            {
                ListServicioLab = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return ListServicioLab;
        }
        public static List<BEServicios> ServiciosLab_XLis_Modena(string Lis, string Numser, string LabSuc)
        {
            List<BEServicios> ListServicioLab = null;
            try
            {
               ListServicioLab = CapaDatos.DAServicios.ServiciosLab_XLis_Modena(Lis,Numser,LabSuc);
            }
            catch (Exception ex)
            {
                ListServicioLab = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return ListServicioLab;
        }
        
        public static BEServicios Lab_Orden_Cab_Insert(BEServicios entidad)
        {
            try
            {
                entidad = CapaDatos.DAServicios.Lab_Orden_Cab_Insert(entidad);
            }
            catch (Exception ex)
            {
                entidad = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return entidad;
        }

        public static BEServicios Lab_Orden_Servicio_Insert(BEServicios entidad)
        {
            try
            {
                entidad = CapaDatos.DAServicios.Lab_Orden_Servicio_Insert(entidad);
            }
            catch (Exception ex)
            {
                entidad = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return entidad;
        }

        public static BEServicios Lab_Orden_Result_Insert(BEServicios entidad)
        {
            try
            {
                entidad = CapaDatos.DAServicios.Lab_Orden_Result_Insert(entidad);
            }
            catch (Exception ex)
            {
                entidad = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return entidad;
        }
        public static BEServicios Lab_Orden_Result_Texto_Insert(BEServicios entidad)
        {
            try
            {
                entidad = CapaDatos.DAServicios.Lab_Orden_Result_Texto_Insert(entidad);
            }
            catch (Exception ex)
            {
                entidad = null;
                Utilitarios.Seguridad.LogService(ex.Message.ToString());
            }
            return entidad;
        }
        public static BEServicios Servicio_Cab_flagEnvMig_Update(BEServicios entidad)
        {
            try
            {
                entidad = CapaDatos.DAServicios.Servicio_Cab_flagEnvMig_Update(entidad);
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
