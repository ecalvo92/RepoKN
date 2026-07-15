using System.Web.Mvc;
using System.Web.Routing;

namespace KN_WEB.Models
{
    public class LogActionFilter : ActionFilterAttribute
    {
        //Debe ejecutarse antes para validar que el usuario haya iniciado sesión
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["ConsecutivoUsuario"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Index" }
                    });

                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }

    public class TutorActionFilter : ActionFilterAttribute
    {
        //Debe ejecutarse antes para validar que el usuario sea un tutor
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["ConsecutivoRol"].ToString() != "2")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Principal" }
                    });

                return;
            }

            base.OnActionExecuting(filterContext);
        }

    }

}