using System.Web.Mvc;

namespace KN_ProyectoWeb.Services
{
    public class Seguridad : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sesion = filterContext.HttpContext.Session;

            if (sesion["ConsecutivoUsuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}