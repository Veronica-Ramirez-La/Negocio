using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConexionP.Clases;
using Negocio.Clases.Utils;


namespace Negocio.Clases.Login
{
    public class ClaseEmpleado
    {
        private ClaseSql objetoSql = new ClaseSql();
        private System.Data.DataTable tabla = new System.Data.DataTable();
        private List<string> parametros;
        private List<object> valores;

        public ClaseEmpleado() { }


        public ClaseEmpleado(int _idEmpleado) { CargarEmpleado(_idEmpleado); }

        #region "get"
        public int IdEmpleado
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

        public string Nombre
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

        public string ApellidoPaterno
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

        public string ApellidoMaterno
        {
            get
            {
                try
                {
                    return tabla.Rows[0].ItemArray[3].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public string Correo
        {
            get
            {
                try
                {
                    return tabla.Rows[0].ItemArray[4].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public string Genero
        {
            get
            {
                try
                {
                    return tabla.Rows[0].ItemArray[5].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public string Telefono
        {
            get
            {
                try
                {
                    return tabla.Rows[0].ItemArray[6].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public string Celular
        {
            get
            {
                try
                {
                    return tabla.Rows[0].ItemArray[7].ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public DateTime? FechaNacimiento
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(tabla.Rows[0].ItemArray[8]);
                }
                catch
                {
                    return null;
                }
            }
        }

        public DateTime? FechaIngreso
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(tabla.Rows[0].ItemArray[9]);
                }
                catch
                {
                    return null;
                }
            }
        }




        public bool? Status
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(tabla.Rows[0].ItemArray[10]);
                }
                catch
                {
                    return null;
                }
            }
        }


        #endregion


        public int AltaEmpleado( string _nombre, string _apellidoPaterno, string _apellidoMaterno, string _correo , string _genero, 
                                 string _telefono, string _celular, DateTime? _fechaNacimiento, DateTime? _fechaIngreso )
        {
            parametros = new List<string>() { "@tipoMovimiento", "@nombre", "@apellidoPaterno", "@apellidoMaterno", "@correo", "@genero",
                                              "@telefono", "@celular","@fechaNacimiento", "@fechaIngreso"             };
            valores = new List<object>() { "alta",   _nombre, _apellidoPaterno, _apellidoMaterno, _correo, _genero,
                                            _telefono, _celular,  _fechaNacimiento, _fechaIngreso };
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_Empleado", parametros, valores);              
                return Convert.ToInt32(objetoSql.Resultado);
            }
            catch
            {
                return -1;
            }
        }

        public bool ModificaEmpleado(int _idEmpleado, string _nombre, string _apellidoPaterno, string _apellidoMaterno, string _correo, string _genero,
                                 string _telefono, string _celular, DateTime? _fechaNacimiento)
        {
            
            parametros = new List<string>() { "@tipoMovimiento","@idEmpleado", "@nombre", "@apellidoPaterno", "@apellidoMaterno", "@correo", "@genero",
                                              "@telefono", "@celular","@fechaNacimiento"             };
            valores = new List<object>() { "modificar", _idEmpleado,  _nombre, _apellidoPaterno, _apellidoMaterno, _correo, _genero,
                                            _telefono, _celular,  _fechaNacimiento };
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_Empleado", parametros, valores);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DesactivarEmpleado(int _idEmpleado)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@idEmpleado"};
            valores = new List<object>() { "desactivar", _idEmpleado};
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_Empleado", parametros, valores);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActivarEmpleado(int _idEmpleado)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@idEmpleado" };
            valores = new List<object>() { "activar", _idEmpleado };
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_Empleado", parametros, valores);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExisteEmpleado(string _nombre, string _apellidoPaterno, string _apellidoMaterno)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@nombre", "@apellidoPaterno", "@apellidoMaterno" };
            valores = new List<object>() { "existeEmpleado", _nombre, _apellidoPaterno, _apellidoMaterno };
            try
            {
                objetoSql.EjecutaProcedimientoAlmacenado("SP_Empleado", parametros, valores);
                if (objetoSql.Resultado != "")
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void CargarEmpleado(int _idEmpleado)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@idEmpleado" };
            valores = new List<object>() { "cargar", _idEmpleado };
            tabla = objetoSql.RegresaTabla("SP_Empleado", parametros, valores);
        }

        public System.Data.DataTable CargarEmpleados(int _idEmpleado = -1, bool? _status = null)
        {
            parametros = new List<string>() { "@tipoMovimiento", "@idEmpleado", "@status" };
            valores = new List<object>() { "cargar", MetodosGenerales.IntToNull(_idEmpleado), MetodosGenerales.BoolToNull(_status) };
            return objetoSql.RegresaTabla("SP_Empleado", parametros, valores);
        }

        public System.Data.DataTable BuscadorEmpleados(int _idEmpleado = -1, string _nombre = "", string _apellidoPaterno = "", string _apellidoMaterno = "", bool? _status = null)
        {
            parametros = new List<string>() { "@tipoMovimiento",  "@idEmpleado", "@nombre", "@apellidoPaterno", "@apellidoMaterno",  "@status"};
            valores = new List<object>() { "buscadorEmpleados", MetodosGenerales.IntToNull( _idEmpleado), MetodosGenerales.StringToNull(_nombre), MetodosGenerales.StringToNull(_apellidoPaterno), MetodosGenerales.StringToNull(_apellidoMaterno), MetodosGenerales.BoolToNull(_status)};
            return objetoSql.RegresaTabla("SP_Empleado", parametros, valores);
        }

    }
}
