using System.Web.Mvc;

namespace ShoppingVegefoods.Areas.Administartor
{
    public class AdministartorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administartor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administartor",
                "quan-ly/trang-chu/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "ShoppingVegefoods.Areas.Administartor.Controllers" }
            );

            context.MapRoute(
                "AdministartorProduct",
                "quan-ly/san-pham/{action}/{id}",
                new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                new[] { "ShoppingVegefoods.Areas.Administartor.Controllers" }
            );

            context.MapRoute(
                "AdministartorCatalog",
                "quan-ly/loai-san-pham/{action}/{id}",
                new { controller = "Catalog", action = "Index", id = UrlParameter.Optional },
                new[] { "ShoppingVegefoods.Areas.Administartor.Controllers" }
            );

            context.MapRoute(
                "Administartor_default",
                "Administartor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "ShoppingVegefoods.Areas.Administartor.Controllers" }
            );
        }
    }
}