using System.Web;
using System.Web.Mvc;

namespace HoursPMO
{
    /// <summary>
    /// Ne znam šta je ovo
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Ne znam šta je ovo
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
