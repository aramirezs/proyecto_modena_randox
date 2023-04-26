using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

using EntLib = Microsoft.Practices.EnterpriseLibrary;
using System.Data;
using System.Data.Common;
using Utilitarios;

namespace CapaDatos
{
    public class DAServicios_Rec
    {
        #region Conexión BD

        private static EntLib.Data.Oracle.OracleDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("CadConOracle") as EntLib.Data.Oracle.OracleDatabase;

        #endregion

        #region Métodos Privados

        public static BEServicios_Rec Lab_Mod_Sui_Result_Update(BEServicios_Rec entidad)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_MOD_SUI_RESULT_UPDATE") as DbCommand;

                db.AddInParameter(cmd, "P_yearorden", DbType.String, entidad.YearOrden);
                db.AddInParameter(cmd, "P_numfox", DbType.String, entidad.Numfox);
                db.AddInParameter(cmd, "P_exa_codigo", DbType.String, entidad.Exa_Codigo);
                //db.AddInParameter(cmd, "P_exa_codigo_inf", DbType.String, entidad.Exa_Codigo_Inf);
                db.AddInParameter(cmd, "P_unidad_nombre", DbType.String, entidad.Unidad_Nombre);
                db.AddInParameter(cmd, "P_fecha_validacion", DbType.DateTime, entidad.FechaValidacion);
                db.AddInParameter(cmd, "P_usu_validacion", DbType.String, entidad.Usuario_Validacion);
                db.AddInParameter(cmd, "P_flag_fuera_rango", DbType.String, entidad.Fuera_Rango);
                db.AddInParameter(cmd, "P_valor_referencial", DbType.String, entidad.Valor_referencial);
                db.AddInParameter(cmd, "P_tb_antibio", DbType.String, entidad.Tb_Antibio);
                db.AddInParameter(cmd, "P_flag_cerrado", DbType.String, entidad.FlagCerado);
                db.AddInParameter(cmd, "P_cant_dec", DbType.String, entidad.Cantidad_dec);
             //   db.AddInParameter(cmd, "P_result_comenta", DbType.String, entidad.Comenta_Fijo);
                db.AddInParameter(cmd, "P_result_valor", DbType.String, entidad.Result_Valor);
                db.AddInParameter(cmd, "P_flag_reporte", DbType.String, entidad.Flag_Reporte);               

                // OutParameter
                db.AddOutParameter(cmd, "Resultado", DbType.Int32, 4);
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 100);

                db.ExecuteNonQuery(cmd);

                entidad.Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                entidad.Resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }

            return entidad;
        }
        //
        public static BEServicios_Rec Lab_Mod_Sui_Result_Coment_Update(BEServicios_Rec entidad)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_MOD_SUI_RESULT_CMT_UPDATE") as DbCommand;

                db.AddInParameter(cmd, "P_yearorden", DbType.String, entidad.YearOrden);
             //   db.AddInParameter(cmd, "P_numfox", DbType.String, entidad.Numfox);
                db.AddInParameter(cmd, "P_exa_codigo", DbType.String, entidad.Exa_Codigo);
                db.AddInParameter(cmd, "P_exa_codigo_inf", DbType.String, entidad.Exa_Codigo_Inf);
                db.AddInParameter(cmd, "P_result_comenta", DbType.String, entidad.Result_Comenta);
                // OutParameter
                db.AddOutParameter(cmd, "Resultado", DbType.Int32, 4);
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 100);

                db.ExecuteNonQuery(cmd);

                entidad.Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                entidad.Resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }

            return entidad;
        }

        public static List<BEServicios_Rec> Orden_Result_Select(string YearOrden, string ExaCodigo)
        {
            BEServicios_Rec oMedico = null;
            List<BEServicios_Rec> ListServiciosLab = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_LAB_ORDEN_RESULT_SELECT") as DbCommand;

                // InParameter
                db.AddInParameter(cmd, "P_YEARORDEN", DbType.String, YearOrden);
                db.AddInParameter(cmd, "P_EXA_CODIGO", DbType.String, ExaCodigo);
                //db.AddInParameter(cmd, "P_EXA_CODIGO_INF", DbType.String, ExaCodigo_inf);

                if (db.GetType().Name == "OracleDatabase")
                {
                    cmd.Parameters.Add(Globales.CreaParametroCursor("RC1"));
                }

                ListServiciosLab = new List<BEServicios_Rec>();

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oMedico = new BEServicios_Rec();
                        oMedico.Cargar(dataReader);
                        ListServiciosLab.Add(oMedico);
                    }
                }

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }

            return ListServiciosLab;

        }
        public static BEServicios_Rec Validar_Servicios_Det(BEServicios_Rec entidad)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_MOD_SUI_SRV_DET_VAL_UPDATE") as DbCommand;

                db.AddInParameter(cmd, "P_yearorden", DbType.String, entidad.YearOrden);
                db.AddInParameter(cmd, "P_Numfox", DbType.String, entidad.Numfox);

                // OutParameter
                db.AddOutParameter(cmd, "Resultado", DbType.Int32, 4);
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 100);

                db.ExecuteNonQuery(cmd);

                entidad.Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                entidad.Resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }

            return entidad;
        }
        
     
        #endregion
    }
}

