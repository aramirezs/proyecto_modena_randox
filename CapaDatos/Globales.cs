using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.OracleClient;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;

namespace CapaDatos
{
    internal static class Globales
    {
        public static DbParameter CreaParametroCursor(string NombreCursor)
        {
            OracleParameter param = new OracleParameter(NombreCursor, OracleType.Cursor, 0, ParameterDirection.Output, true, 0, 0, String.Empty, DataRowVersion.Current, Convert.DBNull);
            return param;
        }

        internal static string Encriptar(string p_password)
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

        public const string PaqueteMuestrasRechazadas = "SIGESER.PKG_CIAS_MSJE_V2.";

        public const string PaqueteSuizaResultados = "CONTROL.PKG_SUIZARESULT_GEN.";


        public const string PaqueteSuizaResultadosL = "CONTROL.PKG_LABORATORIOA.";

    }
}
