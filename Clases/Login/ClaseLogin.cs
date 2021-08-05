using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionP.Clases;

namespace Negocio.Clases.Login
{
    public class ClaseLogin
    {
        #region Variables
        private ClaseSql objetoSql = new ClaseSql();
        private System.Data.DataTable tabla = new System.Data.DataTable();
        private List<string> parametros;
        private List<object> valores;
        #endregion

        public int Id
        {
            get
            {
                try
                {
                    return Convert.ToInt32(tabla.Rows[0].ItemArray[0].ToString());
                }
                catch
                {
                    return -1;
                }
            }
        }

        public string usuario
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

        public string contrasena
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

        public ClaseLogin() { }
        public ClaseLogin(string _nombreUsuario, string _contrasena) { ValidarAcceso(_nombreUsuario, _contrasena); }


        public void ValidarAcceso(string _usuario, string _pasword)
        {
            string patron = "reinaMadre";
            parametros = new List<string>() { "@Usuario", "@Contrasenia", "Patron" };
            valores = new List<object>() { _usuario, _pasword, patron };
            tabla = objetoSql.RegresaTabla("SP_ValidarUsuario", parametros, valores);

                      
        }
    }
}
