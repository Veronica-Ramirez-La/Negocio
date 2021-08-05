using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

using System.Web;
using ConexionP.Clases;

namespace Negocio.Clases.Utils
{
    public static class MetodosGenerales
    {

        public static object StringToNull(string valor)
        {
            if (valor == "" || valor == string.Empty)
                return DBNull.Value;
            return valor;
        }
        public static object IntToNull(int valor)
        {
            if (valor <= 0)
                return DBNull.Value;
            return valor;
        }
        public static object DoubleToNull(double valor)
        {
            if (valor <= 0)
                return DBNull.Value;
            return valor;
        }

        public static object BoolToNull(bool? valor)
        {
            if (valor == null)
                return DBNull.Value;
            return valor;
        }
        public static object DateToNull(DateTime? valor)
        {
            if (valor == null || (Convert.ToDateTime(valor) == Convert.ToDateTime("01/01/1900")))
                return DBNull.Value;
            return valor;
        }
        public static bool IngresarSoloNumerosEnterosWeb(System.Web.UI.WebControls.TextBox text)
        {
            if (text.Text != "")
            {
                try
                {
                    Convert.ToInt32(text.Text.Trim());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public static bool ValidarMailWeb(System.Web.UI.WebControls.TextBox email)
        {
            if (email is System.Web.UI.WebControls.TextBox)
            {
                if (((System.Web.UI.WebControls.TextBox)email).Text.Trim() != "" || ((System.Web.UI.WebControls.TextBox)email).Text.Trim() != string.Empty)
                {
                    System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    if (reg.IsMatch(((System.Web.UI.WebControls.TextBox)email).Text))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
