using B2C.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Infrastructure.CrossCutting.Core.Serialization;
using PICA_B2C.Infrastructure.CrossCutting.IoCBusiness;
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
                //ViewData["MostrarMensaje"] = message;
                ModelState.AddModelError("mensajeError", message);
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
                    var lstItemsSerialized = JsonSerializer.SerializeObject(new List<Item>());
                    if ((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData) != null)
                    {
                        lstItemsSerialized = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString()).Value;
                    }

                    respuestaAutenticacion.Order.Items = IoCFactoryBusiness.Resolve<IItemsService>().GetItemsByCustomer(respuestaAutenticacion.CustomerId, lstItemsSerialized);

                    await SignInAsync(respuestaAutenticacion, model.RememberMe);

                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    //ViewData["MostrarMensaje"] = "Credenciales incorrectas";
                    ModelState.AddModelError("mensajeError", "Credenciales incorrectas");
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
            return IoCFactoryBusiness.Resolve<ICustomersService>().Authenticate(userName, password);
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

            var lstItemsSerialized = JsonSerializer.SerializeObject(customer.Order.Items);

            claims.Add(new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, customer.Names));
            claims.Add(new Claim(ClaimTypes.Surname, customer.LastNames));
            claims.Add(new Claim(ClaimTypes.Email, !string.IsNullOrEmpty(customer.Email) ? customer.Email : string.Empty));
            claims.Add(new Claim(ClaimTypes.UserData, lstItemsSerialized));

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

        #region Registry
        /// <summary>
        /// Paso dos del registro.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Registry()
        {
            return View("Registry");
        }

        /// <summary>
        /// Aceptar o Cancelar del paso dos
        /// </summary>
        /// <param name="accion">aceptar o volver</param>
        /// <returns>Vista.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registry(string accion, CustomerViewModel model)
        {
            if (accion.Equals("siguiente"))
            {
                if (ModelState.IsValid)
                {
                    Customer customer = new Customer()
                    {
                        Identification = model.Identification,
                        Names = model.Names,
                        LastNames = model.LastNames,
                        Phone = model.Phone,
                        Email = model.Email,
                        UserName = model.UserName,
                        Password = model.Password,
                        CrediCardType = model.CrediCardType,
                        CreditCardNumber = model.CreditCardNumber,
                        Status = model.Status,
                        Street = model.Street,
                        State = model.State,
                        Zip = model.Zip,
                        Country = model.Country,
                        AddresType = model.AddresType,
                        City = model.City,
                    };

                    bool answerCustomer = IoCFactoryBusiness.Resolve<ICustomersService>().RegisterCustomer(customer);

                    if (!answerCustomer)
                    {
                        //ViewData["MostrarMensaje"] = "Cliente no registrodo";
                        ModelState.AddModelError("mensajeError", "Cliente no registrodo");
                    }
                    
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
            }

            return View(model);
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