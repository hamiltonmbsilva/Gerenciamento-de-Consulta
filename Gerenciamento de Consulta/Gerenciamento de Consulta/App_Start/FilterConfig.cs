using System.Web;
using System.Web.Mvc;

namespace Gerenciamento_de_Consulta
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
