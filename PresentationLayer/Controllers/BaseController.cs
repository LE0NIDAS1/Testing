using PresentationLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class BaseController : Controller
    {

        protected string game;

        /// <summary>
        /// Retorna el nombre del controlador
        /// </summary>
        protected string ControllerName
        {
            get { return this.RouteData.Values["controller"].ToString(); }
        }

        /// <summary>
        /// Método por defecto para verificar permisos (rechaza todo acceso). Debe ser sobreescrito a través de VerificaAutorizacion
        /// </summary>
        /// <param name="controllerName">Controlador</param>
        /// <param name="actionName">Acción</param>
        /// <param name="extraData">Datos extra</param>
        /// <param name="throwException">indica si debe enviar una excepción o solo retornar verificado/no verificado</param>
        /// <returns>Una excepción o false (dependiendo del valor de throwException) ya que este método está pensado para ser sobreescrito (y en caso contrario no autorizar accesos)</returns>
        public static bool VerifyPermissionsDefault(string game, string controllerName, string actionName, object extraData, bool throwException)
        {
            if (throwException)
                throw new UnauthorizedAccessException();
            return false;
        }
        /// <summary>
        /// Mensaje para desplegar en la pantalla 
        /// </summary>
        /// <param name="msg">Mensaje</param>
        protected void MensajeDesplegar(string msg)
        {
            TempData["MensajeDesplegar"] = msg;
        }

        /// <summary>
        /// Called when an unhandled exception occurs in the action.
        /// En caso de excepciones conocidas las reenvía automáticamente a la página de error correcta
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            string msg;
            string action;
            Exception ex;
            System.Data.Entity.Validation.DbEntityValidationException validationException;

            Type exceptionType = filterContext.Exception.GetType();

            if (RouteData.Values["action"] != null)
                action = RouteData.Values["action"].ToString();
            else
                action = "";
            if (exceptionType == typeof(Exception))
            {
                ViewBag.game = game;
                ViewBag.TituloError = ((Exception)filterContext.Exception);
                msg = filterContext.Exception.Message;

                ex = filterContext.Exception.InnerException;
                while (ex != null)
                {
                    msg += ex + ex.StackTrace;
                    validationException = ex as System.Data.Entity.Validation.DbEntityValidationException;
                    if (validationException != null)
                    {
                        foreach (var validation in validationException.EntityValidationErrors)
                        {
                            foreach (var error in validation.ValidationErrors)
                            {
                                msg += error.ErrorMessage + Environment.NewLine;
                            }
                        }
                    }

                    ex = ex.InnerException;
                }

                ViewBag.MensajeError = msg;
                //ViewBag.UsuarioActual = AtlasUtilidades.ClsFuncionesPublicas.UsuarioNombreRetornar(game);

                filterContext.Result = View("Error");
                filterContext.ExceptionHandled = true;

                return;
            }

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                filterContext.Result = View("ErrorNoAutorizado");
                filterContext.ExceptionHandled = true;


                return;
            }

            base.OnException(filterContext);
        }

        /// <summary>
        /// Called before the action result that is returned by an action method is executed.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string mensaje;

            base.OnResultExecuting(filterContext);

            ViewBag.ControllerName = this.RouteData.Values["controller"];
            mensaje = TempData["MensajeDesplegar"] as string;
            if (mensaje != null)
            {
                ViewBag.MensajeInformacionMostrar = mensaje;
            }
        }

        /// <summary>
        /// Redirecciona hacia otra controller/acción enviando los parámetros especiales si están seteados
        /// </summary>
        /// <param name="actionName">Acción a la que se redirecciona</param>
        /// <param name="routeValues">Parámetros del ruteo</param>
        /// <returns>Se redirecciona hacia la acción indicada de este controlador</returns>
        protected new RedirectToRouteResult RedirectToAction(string actionName, object routeValues)
        {
            System.Web.Routing.RouteValueDictionary routeValuesDic;
            string controllerName;

            controllerName = this.RouteData.Values["controller"].ToString();
            routeValuesDic = new System.Web.Routing.RouteValueDictionary(routeValues);
            return RedirectToAction(actionName, controllerName, routeValuesDic);
        }

        /// <summary>
        /// Redirecciona hacia otra controller/acción enviando los parámetros especiales si están seteados
        /// </summary>
        /// <param name="actionName">Acción a la que se redirecciona</param>
        /// <param name="controllerName">Controller hacia el que se redirecciona</param>
        /// <param name="routeValues">Parámetros del ruteo</param>
        /// <returns>Se redirecciona hacia el controlador/acción indicado</returns>
        protected override RedirectToRouteResult RedirectToAction(string actionName, string controllerName, System.Web.Routing.RouteValueDictionary routeValues)
        {
            if (routeValues == null)
            {
                routeValues = new System.Web.Routing.RouteValueDictionary();
            }
            return base.RedirectToAction(actionName, controllerName, routeValues);
        }

        /// <summary>
        /// Muestra otra vista
        /// </summary>
        /// <param name="view">Vista del controlador</param>
        /// <returns>Se redirecciona hacia la vista indicada</returns>
        public ActionResult ShowView(string view)
        {
            return View(view);
        }

        /// <summary>
        /// Es útil para debugging, ya que cuando hay un error en un campo (ModelState.IsValid=false), no es 
        /// fácil determinar cuál es el campo con el problema.
        /// </summary>
        /// <param name="modelStateDic">Diccionario con los valores de ModelState</param>
        /// <returns>Devuelve un diccionario de los campos con error y el error</returns>
        public Dictionary<string, string> ObtieneCamposConError(ModelStateDictionary modelStateDic)
        {
            string error;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var field in modelStateDic.Keys)
            {
                if (!modelStateDic.IsValidField(field))
                {
                    error = "";
                    foreach (var fieldError in modelStateDic[field].Errors)
                    {
                        error += fieldError.ErrorMessage + Environment.NewLine;
                    }
                    dic.Add(field, error);
                }
            }
            return dic;
        }
    }
}