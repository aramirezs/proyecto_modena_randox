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
    public class DAServicios
    {
        #region Conexión BD

        private static EntLib.Data.Oracle.OracleDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("CadConOracle") as EntLib.Data.Oracle.OracleDatabase;

        #endregion

        #region Métodos Privados

        public static List<BEServicios> ServiciosLab_EnvioPen_Modena_cab(string Numsuc, string YearOrden, string CodMuestra)
        {
            BEServicios oMedico = null;
            List<BEServicios> ListServiciosLab = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_LAB_PEND_ENVIO_MOD_CAB") as DbCommand;

                // InParameter
                db.AddInParameter(cmd, "XXNUMSUC", DbType.String, Numsuc);
                db.AddInParameter(cmd, "P_YEARORDEN", DbType.String, YearOrden);
                db.AddInParameter(cmd, "P_COD_MUESTRA", DbType.String, CodMuestra);


                if (db.GetType().Name == "OracleDatabase")
                {
                    cmd.Parameters.Add(Globales.CreaParametroCursor("RC1"));
                }

                ListServiciosLab = new List<BEServicios>();

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oMedico = new BEServicios();
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
        public static List<BEServicios> ServiciosLab_EnvioPen_Modena_det(string Numoscab,string Peroscab,string Anooscab,string Numsuc, string MueCodigo)
        {
            BEServicios oMedico = null;
            List<BEServicios> ListServiciosLab = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_LAB_PEND_ENVIO_MOD_DET") as DbCommand;

                // InParameter
                db.AddInParameter(cmd, "P_NUMOSCAB", DbType.String, Numoscab);
                db.AddInParameter(cmd, "P_PEROSCAB", DbType.String, Peroscab);
                db.AddInParameter(cmd, "P_ANOOSCAB", DbType.String, Anooscab);
                db.AddInParameter(cmd, "P_NUMSUC", DbType.String, Numsuc);
                db.AddInParameter(cmd, "P_MUE_CODIGO", DbType.String, MueCodigo);


                if (db.GetType().Name == "OracleDatabase")
                {
                    cmd.Parameters.Add(Globales.CreaParametroCursor("RC1"));
                }

                ListServiciosLab = new List<BEServicios>();

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oMedico = new BEServicios();
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
        public static List<BEServicios> ServiciosLab_XLis_Modena(string Lis, string Numser, string LabSuc)
        {
            BEServicios oMedico = null;
            List<BEServicios> ListServiciosLab = null;

            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_LAB_SERVICIO_XLIS") as DbCommand;

                // InParameter
                db.AddInParameter(cmd, "P_LIS", DbType.String, Lis);
                db.AddInParameter(cmd, "P_NUMSER", DbType.String, Numser);
                db.AddInParameter(cmd, "P_LABSUC", DbType.String, LabSuc);

                if (db.GetType().Name == "OracleDatabase")
                {
                    cmd.Parameters.Add(Globales.CreaParametroCursor("RC1"));
                }

                ListServiciosLab = new List<BEServicios>();

                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        oMedico = new BEServicios();
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

        public static BEServicios Lab_Orden_Cab_Insert(BEServicios entidad)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_LAB_P_LAB_ORDEN_CAB_INSERT") as DbCommand;

                //db.AddInParameter(cmd, "P_NUMPAC", DbType.String, entidad.NumPac);
                //db.AddInParameter(cmd, "P_ANOPAC", DbType.String, entidad.AnioPac);
                //db.AddInParameter(cmd, "P_NUMCIA", DbType.String, entidad.Numcia);
                db.AddInParameter(cmd, "P_YEARORDEN", DbType.String, entidad.YearOrden);
                               
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
        public static BEServicios Lab_Orden_Servicio_Insert(BEServicios entidad)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_LAB_P_ORDEN_SERVICIO_INSERT") as DbCommand;

                db.AddInParameter(cmd, "P_YEARORDEN", DbType.String, entidad.YearOrden);
                db.AddInParameter(cmd, "P_ORDNUMER", DbType.String, entidad.OrdNumero);
                db.AddInParameter(cmd, "P_NUMSER", DbType.String, entidad.Numser);
                db.AddInParameter(cmd, "P_CANT", DbType.String, entidad.C_Item);

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

        public static BEServicios Lab_Orden_Result_Insert(BEServicios entidad)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_LAB_ORDEN_RESULT_INSERT") as DbCommand;

                db.AddInParameter(cmd, "P_YEARORDEN", DbType.String, entidad.YearOrden);
                db.AddInParameter(cmd, "P_ORDNUMER", DbType.String, entidad.OrdNumero);
                db.AddInParameter(cmd, "P_LITEM", DbType.String, entidad.Item);
                db.AddInParameter(cmd, "P_TB_IMPRESO", DbType.String, entidad.Tb_Impreso);
                db.AddInParameter(cmd, "P_LIS_CODIGO", DbType.String, entidad.LisCodigo);
                db.AddInParameter(cmd, "P_MUE_CODIGO", DbType.String, entidad.MueCodigo);
                db.AddInParameter(cmd, "P_RESULT_VALOR", DbType.String, entidad.Result_Valor);
                db.AddInParameter(cmd, "P_RESULT_TIPODAT", DbType.String, entidad.Result_TipoDat);
                db.AddInParameter(cmd, "P_FLAG_REPORTE", DbType.String, entidad.Flag_Reporte);
                db.AddInParameter(cmd, "P_FLAG_CONFIDE", DbType.String, entidad.Flag_Confide);
                db.AddInParameter(cmd, "P_FLAG_CERRADO", DbType.String, entidad.FlagCerado);

                db.AddInParameter(cmd, "P_EXA_CODIGO", DbType.String, entidad.Exa_Codigo);
                db.AddInParameter(cmd, "P_EXA_NOMBRE", DbType.String, entidad.Exa_Nombre);
                db.AddInParameter(cmd, "P_NUMFOX", DbType.String, entidad.Numfox);
                db.AddInParameter(cmd, "P_NUMSER", DbType.String, entidad.Numser);
                db.AddInParameter(cmd, "P_FLAG_PERFIL", DbType.String, entidad.Flag_Perfil);
                db.AddInParameter(cmd, "P_NOMBRE_PERFIL", DbType.String, entidad.Nombre_Perfil);
                db.AddInParameter(cmd, "P_METO_CODIGO", DbType.String, entidad.Meto_codigo);
                db.AddInParameter(cmd, "P_METO_DESCRIP", DbType.String, entidad.Meto_Descrip);
                db.AddInParameter(cmd, "P_SEC_CODIGO", DbType.String, entidad.SecCodigo);
                db.AddInParameter(cmd, "P_SEC_DESCRIP", DbType.String, entidad.SecDescrip);
                db.AddInParameter(cmd, "P_SUBTITULO", DbType.String, entidad.SubTitulo);
                db.AddInParameter(cmd, "P_SUBTIPER", DbType.String, entidad.SubTiper);
                db.AddInParameter(cmd, "P_TB_TEXTO", DbType.String, entidad.Tb_Texto);

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
        public static BEServicios Lab_Orden_Result_Texto_Insert(BEServicios entidad)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_LAB_ORDEN_RESULT_TXT_INSERT") as DbCommand;

                db.AddInParameter(cmd, "P_YEARORDEN", DbType.String, entidad.YearOrden);
                db.AddInParameter(cmd, "P_ORDNUMERO", DbType.String, entidad.OrdNumero);
                db.AddInParameter(cmd, "P_NUMSER", DbType.String, entidad.Numser);
                db.AddInParameter(cmd, "P_LITEM", DbType.String, entidad.Item);

                db.AddInParameter(cmd, "P_COMENTA_FIJO", DbType.String, entidad.Comenta_Fijo);
                db.AddInParameter(cmd, "P_LIS_CODIGO", DbType.String, entidad.LisCodigo);

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
        public static BEServicios Servicio_Cab_flagEnvMig_Update(BEServicios entidad)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_MOD_SUI_ENV_SRV_DET_UPDATE") as DbCommand;

                db.AddInParameter(cmd, "P_yearorden", DbType.String, entidad.YearOrden);

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
