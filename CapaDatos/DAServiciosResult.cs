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
    public class DAServiciosResult
    {
        #region Conexión BD

        private static EntLib.Data.Oracle.OracleDatabase db = EntLib.Data.DatabaseFactory.CreateDatabase("CadConOracle") as EntLib.Data.Oracle.OracleDatabase;

        #endregion

            #region Métodos Privados
        public static BEServicios Lab_Orden_Result_Insert(BEServicios entidad)
        {
            try
            {
                DbCommand cmd = db.GetStoredProcCommand("CONTROL.PKG_LABORATORIOA.SP_LAB_ORDEN_RESULT_INSERT") as DbCommand;

                db.AddInParameter(cmd, "P_NUMPAC", DbType.String, entidad.NumPac);
                db.AddInParameter(cmd, "P_ANOPAC", DbType.String, entidad.AnioPac);
                db.AddInParameter(cmd, "P_NUMCIA", DbType.String, entidad.Numcia);
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
            #endregion
    }
}
