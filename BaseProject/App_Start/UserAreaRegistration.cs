using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteleriaShadday.App_Start
{
    public class UserAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Default"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    "ExampleNameRoute",
            //     "Productos/GridProductos/Categoria/{categoria}",
            //    new { controller = "Productos", action = "Categorias", categoria = UrlParameter.Optional },
            //    namespaces: new string[] { "BaseProject.User.Controllers" }
            //);

            context.MapRoute(
                "Default",
                 "{controller}/{action}/{id}",
                new { controller = "Home", action = "Main", id = UrlParameter.Optional },
                namespaces: new string[] { "BaseProject.User.Controllers", "BaseProject.Error.Controllers" }
            );
        }
    }
}