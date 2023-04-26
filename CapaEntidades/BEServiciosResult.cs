using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;

namespace CapaEntidades
{
    [Serializable]
    public class BEServiciosResult : Utilitarios.Base 
    {
        #region Variables Privadas


        private string NUMOS = string.Empty;
        private string PEROS = string.Empty;
        private string ANOOS = string.Empty;
        private string NUMSUC = string.Empty;
        private DateTime FECHA;
        private string YEARORDEN = string.Empty;
        private string ORDNUMERO = string.Empty;
        private string NCOPAC = string.Empty;
        private string SEXPAC = string.Empty;
        private string SEXPAC_C = string.Empty;
        private DateTime FNACPAC;
        private string NCOCIA = string.Empty;
        //private string USUARIO = string.Empty;
        private string SEEKCIA = string.Empty;
        private string NOMBRE_SUCURSAL = string.Empty;
        private string CODIGO_SUCURSAL = string.Empty;
        private string NCOMED = string.Empty;
        private string NUMMED = string.Empty;
        private string RAZEMPCIA = string.Empty;
        private string OBSOSCAB = string.Empty;
        private string NUMPAC = string.Empty;
        private string AÑOPAC = string.Empty;

        private string PATPAC = string.Empty;

        private string MATPAC = string.Empty;
        private string NOMPAC = string.Empty;
        private string USUARIO = string.Empty;

        private string NUMSER = string.Empty;
        private string C_ITEM = string.Empty;
        private string NUMFOX = string.Empty;
        private string DESSER = string.Empty;
        private string OSD_LAB_ENVIO_FLAG = string.Empty;
        private string LAB_ENVIO_FECHA = string.Empty;
        private string OSD_NUMOSCAB = string.Empty;
        private string OSD_PEROSCAB = string.Empty;
        private string OSD_ANOOSCAB = string.Empty;
        private string OSD_NUMSUC = string.Empty;
        private string OSD_NUMOSDET = string.Empty;
        private string OSD_NUMEMP = string.Empty;
        private string OSD_LAB_MUE_NUMSUC = string.Empty;
        private string S_D10 = string.Empty;
        private string ROWWNUM = string.Empty;


        private string EDAD = string.Empty;
        private string EMPRESA = string.Empty;
        private string DATO_CLIENTE = string.Empty;
        private string SEX_CODIGO = string.Empty;
        private string SEXO = string.Empty;
        private string NUMCIA = string.Empty;
        private DateTime FECHA_ORDEN;
        private string FLAG_CERRADO = string.Empty;
        private string ESTADO = string.Empty;
        private string USUARIO_MOD = string.Empty;
        private DateTime FECHA_CREACION;
        private DateTime FECHA_MOD;
        private string FLAG = string.Empty;
        private string FLAG_HIST = string.Empty;








        // private string numeroGrupo = string.Empty;

        private int resultado = 0;
        private string mensaje = string.Empty;
        private string usuarioRegistro = string.Empty;

        private List<BEServicios> listServicioLabBE = null;

        //private List<ServiciosLabDetBE> listServicioLabDetalle = null;
        #endregion


        #region Propiedades

        public string Numos
        {
            get { return NUMOS; }
            set { NUMOS = value; }
        }

        public string Peros
        {
            get { return PEROS; }
            set { PEROS = value; }
        }

        public string Anoos
        {
            get { return ANOOS; }
            set { ANOOS = value; }
        }

        public string Numsuc
        {
            get { return NUMSUC; }
            set { NUMSUC = value; }
        }
        public DateTime Fecha
        {
            get { return FECHA; }
            set { FECHA = value; }
        }

        public string YearOrden
        {
            get { return YEARORDEN; }
            set { YEARORDEN = value; }
        }
        public string OrdNumero
        {
            get { return ORDNUMERO; }
            set { ORDNUMERO = value; }
        }

        public string NcoPac
        {
            get { return NCOPAC; }
            set { NCOPAC = value; }
        }

        public string SexPac
        {
            get { return SEXPAC; }
            set { SEXPAC = value; }
        }
        public string SexPac_C
        {
            get { return SEXPAC_C; }
            set { SEXPAC_C = value; }
        }

        public DateTime FNacPac
        {
            get { return FNACPAC; }
            set { FNACPAC = value; }
        }


        public string Ncocia
        {
            get { return NCOCIA; }
            set { NCOCIA = value; }
        }

        public string Numcia
        {
            get { return NUMCIA; }
            set { NUMCIA = value; }
        }
        //public string Usuario
        //{
        //    get { return USUARIO; }
        //    set { USUARIO = value; }
        //}
        public string Seekcia
        {
            get { return SEEKCIA; }
            set { SEEKCIA = value; }
        }
        public string Nombre_Sucursal
        {
            get { return NOMBRE_SUCURSAL; }
            set { NOMBRE_SUCURSAL = value; }
        }
        public string Codigo_Sucursal
        {
            get { return CODIGO_SUCURSAL; }
            set { CODIGO_SUCURSAL = value; }
        }
        public string NComed
        {
            get { return NCOMED; }
            set { NCOMED = value; }
        }

        //55
        public string NumMed
        {
            get { return NUMMED; }
            set { NUMMED = value; }
        }
        public string RazemCia
        {
            get { return RAZEMPCIA; }
            set { RAZEMPCIA = value; }
        }
        public string ObsosCab
        {
            get { return OBSOSCAB; }
            set { OBSOSCAB = value; }
        }
        public string NumPac
        {
            get { return NUMPAC; }
            set { NUMPAC = value; }
        }

        public string AnioPac
        {
            get { return AÑOPAC; }
            set { AÑOPAC = value; }
        }

        public string PatPac
        {
            get { return PATPAC; }
            set { PATPAC = value; }
        }
        public string MatPac
        {
            get { return MATPAC; }
            set { MATPAC = value; }
        }
        public string NomPac
        {
            get { return NOMPAC; }
            set { NOMPAC = value; }
        }
        public string Usuario
        {
            get { return USUARIO; }
            set { USUARIO = value; }
        }



        //public string NumeroGrupo
        //{
        //    get { return numeroGrupo; }
        //    set { numeroGrupo = value; }
        //}

        public int Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public string UsuarioRegistro
        {
            get { return usuarioRegistro; }
            set { usuarioRegistro = value; }
        }

        //
        public string Numser
        {
            get { return NUMSER; }
            set { NUMSER = value; }
        }
        public string C_Item
        {
            get { return C_ITEM; }
            set { C_ITEM = value; }
        }
        public string Numfox
        {
            get { return NUMFOX; }
            set { NUMFOX = value; }
        }
        public string Desser
        {
            get { return DESSER; }
            set { DESSER = value; }
        }
        public string Osd_lab_envio_flag
        {
            get { return OSD_LAB_ENVIO_FLAG; }
            set { OSD_LAB_ENVIO_FLAG = value; }
        }
        public string Lab_evnio_fecha
        {
            get { return LAB_ENVIO_FECHA; }
            set { LAB_ENVIO_FECHA = value; }
        }
        public string Osd_Numoscab
        {
            get { return OSD_NUMOSCAB; }
            set { OSD_NUMOSCAB = value; }
        }
        public string Osd_Peroscab
        {
            get { return OSD_PEROSCAB; }
            set { OSD_PEROSCAB = value; }

        }
        public string Osd_Anooscab
        {
            get { return OSD_ANOOSCAB; }
            set { OSD_ANOOSCAB = value; }
        }
        public string Osd_Numsuc
        {
            get { return OSD_NUMSUC; }
            set { OSD_NUMSUC = value; }
        }
        public string Osd_Numosdet
        {
            get { return OSD_NUMOSDET; }
            set { OSD_NUMOSDET = value; }
        }
        public string Osd_Numemp
        {
            get { return OSD_NUMEMP; }
            set { OSD_NUMEMP = value; }
        }
        public string Osd_Lab_mue_numsuc
        {
            get { return OSD_LAB_MUE_NUMSUC; }
            set { OSD_LAB_MUE_NUMSUC = value; }
        }
        public string S_d10
        {
            get { return S_D10; }
            set { S_D10 = value; }
        }

        public string RowNum
        {
            get { return ROWWNUM; }
            set { ROWWNUM = value; }
        }
        //


        public string Edad
        {
            get { return EDAD; }
            set { EDAD = value; }
        }
        public string Empresa
        {
            get { return EMPRESA; }
            set { EMPRESA = value; }
        }
        public string DatoCliente
        {
            get { return DATO_CLIENTE; }
            set { DATO_CLIENTE = value; }
        }
        public string SexCodigo
        {
            get { return SEX_CODIGO; }
            set { SEX_CODIGO = value; }
        }

        public string Sexo
        {
            get { return SEXO; }
            set { SEXO = value; }
        }
        //i


        public DateTime FechaOrden
        {
            get { return FECHA_ORDEN; }
            set { FECHA_ORDEN = value; }
        }
        public string FlagCerado
        {
            get { return FLAG_CERRADO; }
            set { FLAG_CERRADO = value; }
        }

        public string Estado
        {
            get { return ESTADO; }
            set { ESTADO = value; }
        }

        //p

        public string UsuarioMod
        {
            get { return USUARIO_MOD; }
            set { USUARIO_MOD = value; }
        }
        public DateTime FechaCreacion
        {
            get { return FECHA_CREACION; }
            set { FECHA_CREACION = value; }
        }
        public DateTime FechaModificacion
        {
            get { return FECHA_MOD; }
            set { FECHA_MOD = value; }
        }


        public string Flag
        {
            get { return FLAG; }
            set { FLAG = value; }
        }
        public string FlagHist
        {
            get { return FLAG_HIST; }
            set { FLAG_HIST = value; }
        }
        //
        public List<BEServicios> ListServicioLabDE
        {
            get { return listServicioLabBE; }
            set { listServicioLabBE = value; }
        }


        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Carga los datos del DataReader en la Entidad
        /// </summary>
        /// <param name="objDataReader">Datos a cargar en la Entidad</param>
        public void Cargar(System.Data.IDataReader objDataReader)
        {
            CargarVariable(objDataReader, "NUMOSC", out NUMOS);
            CargarVariable(objDataReader, "PEROSC", out PEROS);
            CargarVariable(objDataReader, "ANOOSC", out ANOOS);
            CargarVariable(objDataReader, "NUMSUC", out NUMSUC);
            CargarVariable(objDataReader, "FECHA", out FECHA);
            CargarVariable(objDataReader, "YEARORDEN", out YEARORDEN);
            CargarVariable(objDataReader, "ORDNUMERO", out ORDNUMERO);
            CargarVariable(objDataReader, "NCOPAC", out NCOPAC);
            CargarVariable(objDataReader, "SEXOPAC", out SEXPAC);
            CargarVariable(objDataReader, "SEXOPAC_C", out SEXPAC_C);
            CargarVariable(objDataReader, "FNACPAC", out FNACPAC);
            CargarVariable(objDataReader, "NCOCIA", out NCOCIA);
            CargarVariable(objDataReader, "NUMCIA", out NUMCIA);
            CargarVariable(objDataReader, "SEEKCIA", out SEEKCIA);
            CargarVariable(objDataReader, "NOMBRE_SUCURSAL", out NOMBRE_SUCURSAL);
            CargarVariable(objDataReader, "CODIGO_SUCURSAL", out CODIGO_SUCURSAL);
            CargarVariable(objDataReader, "NCOMED", out NCOMED);
            CargarVariable(objDataReader, "NUMMED", out NUMMED);
            CargarVariable(objDataReader, "RAZEMPCIA", out RAZEMPCIA);
            CargarVariable(objDataReader, "OBSOSCAB", out OBSOSCAB);
            CargarVariable(objDataReader, "NUMPAC", out NUMPAC);
            CargarVariable(objDataReader, "ANOPAC", out AÑOPAC);
            CargarVariable(objDataReader, "PATPAC", out PATPAC);
            CargarVariable(objDataReader, "MATPAC", out MATPAC);
            CargarVariable(objDataReader, "NOMPAC", out NOMPAC);
            CargarVariable(objDataReader, "USUARIO", out USUARIO);

            CargarVariable(objDataReader, "NUMSER", out    NUMSER);
            CargarVariable(objDataReader, "OSD_NUMFOX", out NUMFOX);
            CargarVariable(objDataReader, "DESSER", out DESSER);
            CargarVariable(objDataReader, "OSD_LAB_ENVIO_FLAG", out OSD_LAB_ENVIO_FLAG);
            CargarVariable(objDataReader, "OSD_LAB_ENVIO_FECHA", out LAB_ENVIO_FECHA);
            CargarVariable(objDataReader, "OSD_NUMOSCAB", out OSD_NUMOSCAB);
            CargarVariable(objDataReader, "OSD_PEROSCAB", out OSD_PEROSCAB);
            CargarVariable(objDataReader, "OSD_ANOOSCAB", out OSD_ANOOSCAB);
            CargarVariable(objDataReader, "OSD_NUMSUC", out OSD_NUMSUC);
            CargarVariable(objDataReader, "OSD_NUMOSDET", out OSD_NUMOSDET);
            CargarVariable(objDataReader, "OSD_NUMEMP", out OSD_NUMEMP);
            CargarVariable(objDataReader, "OSD_LAB_MUE_NUMSUC", out OSD_LAB_MUE_NUMSUC);
            CargarVariable(objDataReader, "S_D10", out S_D10);
            CargarVariable(objDataReader, "ROWNUM", out ROWWNUM);

        }

        #endregion

    }
}



