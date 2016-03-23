using B2C.Models;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace B2C.Controllers
{
    /// <summary>
    /// Controller Account.
    /// </summary>
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        #region Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewData["MostrarMensaje"] = message;
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// Ingresar a la aplicacion.
        /// </summary>
        /// <param name="model">Modelo.</param>
        /// <param name="returnUrl">Url origen.</param>
        /// <returns>Vista.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var respuestaAutenticacion = AutenticarUsuario(model.UserName.Trim(), model.Password);

                if (respuestaAutenticacion != null)
                {

                    await SignInAsync(respuestaAutenticacion, model.RememberMe);

                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ViewData["MostrarMensaje"] = "Credenciales incorrectas";
                }
            }

            return View(model);
        }

        /// <summary>
        /// Redirecting to a url specified.
        /// </summary>
        /// <param name="returnUrl">URL that should be redirected.</param>
        /// <returns>Redirect to the url.</returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        #region Authentication
        /// <summary>
        /// Realizar la transacción de autenticación del usuario
        /// </summary>
        /// <param name="login">User name.</param>
        /// <param name="password">User password.</param>
        /// <returns>Service response.</returns>
        private Customer AutenticarUsuario(string userName, string password)
        {
            var customerService = new CustomersService();

            return customerService.Authenticate(userName, password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="isPersistent"></param>
        /// <returns></returns>
        private async Task SignInAsync(Customer usuario, bool isPersistent)
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //var claims = new List<Claim>();

            //List<string> lst = new List<string>();
            //lst = usuario.Roles.Select(r => r.AutorizacionesMenu.Select(am => am.Ruta)).ToList().SelectMany(l => l).ToList();

            //claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()));
            //claims.Add(new Claim(ClaimTypes.Name, usuario.Nombres));
            //claims.Add(new Claim(ClaimTypes.Surname, usuario.Apellidos));
            //claims.Add(new Claim(ClaimTypes.Email, usuario.CorreoElectronico));
            //claims.Add(new Claim(ClaimTypes.Authentication, string.Join(", ", usuario.Roles.Select(r => r.Nombre))));

            //#region Extraer ClienteId

            //long clienteId = 0;
            //try
            //{
            //    HttpContextBase currentContext = new HttpContextWrapper(System.Web.HttpContext.Current);
            //    RouteData routeData = RouteTable.Routes.GetRouteData(currentContext);
            //    try
            //    {
            //        string idTemp = routeData.GetRequiredString("clienteId");
            //        long.TryParse(idTemp, out clienteId);
            //    }
            //    catch (Exception)
            //    {

            //    }

            //}
            //catch (Exception ex)
            //{
            //    //  string error = ex.Message;

            //}

            //#endregion

            //claims.Add(new Claim(ClaimTypes.Sid, clienteId.ToString()));

            //claims.Add(new Claim(ClaimTypes.Role, string.Join(",", usuario.Roles.Select(r => r.RolId))));
            //claims.Add(new Claim(ClaimTypes.UserData, string.Join(",", lst)));
            //claims.Add(new Claim(ClaimTypes.Thumbprint, usuario.ImagenPerfilId.HasValue ? usuario.ImagenPerfilId.ToString() : ""));
            //var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            //AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, id);
        }
        #endregion

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}
    }
}