using B2C.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        /// <summary>
        /// GET: Account
        /// </summary>
        /// <returns>View.</returns>
        public ActionResult Index()
        {
            return View();
        }

        #region Login
        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="returnUrl">Source url.</param>
        /// <param name="message">Message</param>
        /// <returns>View.</returns>
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
        /// Login to the application.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <param name="returnUrl">Source url.</param>
        /// <returns>View.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var respuestaAutenticacion = AuthenticateUser(model.UserName.Trim(), model.Password);

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
                return RedirectToAction("Products", "Administration");
            }
        }

        /// <summary>
        /// Perform user authentication.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="password">User password.</param>
        /// <returns>Service response.</returns>
        private Customer AuthenticateUser(string userName, string password)
        {
            var customerService = new CustomersService();

            return customerService.Authenticate(userName, password);
        }

        /// <summary>
        /// Sign In Async.
        /// </summary>
        /// <param name="customer">Customer.</param>
        /// <param name="isPersistent">Is Persistent.</param>
        /// <returns>SignIn.</returns>
        private async Task SignInAsync(Customer customer, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var claims = new List<Claim>();

            var lstProductId = customer.Order.Items.Select(sc => sc.ProductId).ToList();
            var lstQuantity = customer.Order.Items.Select(sc => sc.Quantity).ToList();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, customer.Names));
            claims.Add(new Claim(ClaimTypes.Surname, customer.LastNames));
            claims.Add(new Claim(ClaimTypes.Email, !string.IsNullOrEmpty(customer.Email) ? customer.Email : string.Empty));
            claims.Add(new Claim(ClaimTypes.UserData, string.Join(",", lstProductId)));
            claims.Add(new Claim(ClaimTypes.SerialNumber, string.Join(",", lstQuantity)));

            var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, id);
        }
        #endregion

        #region LogOff
        /// <summary>
        /// Log Off.
        /// </summary>
        /// <returns>Redirect Login.</returns>
        [HttpPost]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
        #endregion

        /// <summary>
        /// Authentication Manager.
        /// </summary>
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}