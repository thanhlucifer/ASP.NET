using System.Web;
using System.Web.Mvc;

namespace Sang4_Tuan3_2011064477_PhamVanThanh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
