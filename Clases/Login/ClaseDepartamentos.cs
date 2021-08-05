using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConexionP.Clases;
using Negocio.Clases.Utils;

namespace Negocio.Clases.Login
{
    public class ClaseDepartamentos
    {
        private ClaseSql objetoSql = new ClaseSql();
        private System.Data.DataTable tabla = new System.Data.DataTable();
        private List<string> parametros;
        private List<object> valores;

        public ClaseDepartamentos() { }
        public ClaseDepartamentos(int _idDepartemento) { CargarDepartamento(_idDepartemento); }

        #region "get"

        public int IdDepartamento
        {
            get
            {
                try
                {
                    return Convert.ToInt32(tabla.Rows[0].ItemArray[0]);
                }
                catch
                {
                    return -1;
                }
            }
        }

        public string Departamento
        {
            get
            {
                try
                {
                    return tabla.Rows[0].ItemArray[1].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public string Ubicacion
        {
            get
            {
                try
                {
                    return tabla.Rows[0].ItemArray[2].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public bool? Status
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(tabla.Rows[0].ItemArray[3]);
                }
                catch
                {
                    return null;
                }
            }
        }

        #endregion

        public bool AltaDepartamento(string _departamento, string _ubicacion, int _idEmpresa)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@departamento", "@ubicacion", "@idEmpresa" };
            valores = new List<object>() { "alta", _departamento, _ubicacion, _idEmpresa };
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_CatalogosDepartamentos", parametros, valores);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ModificarDepartamento(int _idDepartamento, string _departamento, string _ubicacion)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@departamento", "@ubicacion", "@idDepartamento" };
            valores = new List<object>() { "modificar", _departamento, _ubicacion, _idDepartamento };
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_CatalogosDepartamentos", parametros, valores);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DesactivarDepartamento(int _idDepartamento)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@idDepartamento" };
            valores = new List<object>() { "desactivar", _idDepartamento };
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_CatalogosDepartamentos", parametros, valores);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActivarDepartamento(int _idDepartamento)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@idDepartamento" };
            valores = new List<object>() { "activar", _idDepartamento };
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_CatalogosDepartamentos", parametros, valores);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExisteDepartamento(string _departamento)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@departamento" };
            valores = new List<object>() { "existe", _departamento };
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_CatalogosDepartamentos", parametros, valores);
                if (objetoSql.Resultado.ToUpper() == _departamento.ToUpper())
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public System.Data.DataTable CargarDepartamentos(int _idDepartamento = -1, bool? _status = null)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@idDepartamento", "@status" };
            valores = new List<object>() { "cargar", MetodosGenerales.IntToNull(_idDepartamento), MetodosGenerales.BoolToNull(_status) };
            return objetoSql.RegresaTabla("SP_CatalogosDepartamentos", parametros, valores);
        }

        private void CargarDepartamento(int _idDepartamento)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@idDepartamento" };
            valores = new List<object>() { "cargar", _idDepartamento };
            tabla = objetoSql.RegresaTabla("SP_CatalogosDepartamentos", parametros, valores);
        }

    }
}

