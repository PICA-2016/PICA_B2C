using B2C.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Enumerations;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Entities.Pagination;
using PICA_B2C.Infrastructure.CrossCutting.Core.Serialization;
using PICA_B2C.Infrastructure.CrossCutting.IoCBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace B2C.Controllers
{
    /// <summary>
    /// Controller Administration.
    /// </summary>
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        #region Products
        /// <summary>
        /// Product Management.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Product(s) View.</returns>
        public ActionResult Products(int? id)
        {
            //if (id.HasValue)
            //{
            //    return View("Product", id.Value);
            //}

            //TODO: revisar
            
            
            if ((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData) == null)
            {
                var lstItemsSerialized = JsonSerializer.SerializeObject(new List<Item>());

                //Inicializar items en memoria
                var claims = new List<Claim>();

                var thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString());
                if (thumbClaim != null)
                {
                    (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                }
                    (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.UserData, lstItemsSerialized));

                claims = (User.Identity as ClaimsIdentity).Claims.ToList();
                var idClaim = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                if (User.Identity.IsAuthenticated)
                {
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, idClaim);
                }
            }

            return View();
        }

        /// <summary>
        /// Get products.
        /// </summary>
        /// <param name="draw">Draw.</param>
        /// <param name="start">Start.</param>
        /// <param name="length">Length.</param>
        /// <param name="search">Search.</param>
        /// <param name="typeSearch">Type Search.</param>
        /// <returns>Products.</returns>
        public async Task<JsonResult> FilterProducts(int draw, int start, int length, Dictionary<string, string> search, TypeSearch typeSearch)
        {
            Response.Expires = 0;
            string filterSearch = string.Empty;
            if (search.ContainsKey("value"))
            {
                filterSearch = search["value"];
            }

            AnswerPage<Product> answerProduct = new AnswerPage<Product>();
            answerProduct = IoCFactoryBusiness.Resolve<IProductsService>().GetProducts(filterSearch, start, length, typeSearch);

            return Json(new
            {
                draw = draw,
                recordsTotal = answerProduct.Total,
                recordsFiltered = answerProduct.Total,
                data = answerProduct.Results
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Detalle de ProductDetail.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <returns>Result.</returns>
        public ActionResult ProductDetail(int id)
        {
            Product product;

            if (id == 0)
            {
                product = new Product()
                {
                    ProductId = 0,
                };
            }
            else
            {
                product = IoCFactoryBusiness.Resolve<IProductsService>().GetProductById(id).Results.FirstOrDefault();

                if (product == null)
                {
                    ViewData["Result"] = false;
                    ModelState.AddModelError("mensajeError", "product null .");
                    ViewData["ShowMessage"] = "product null ...";
                }
            }

            return View(product);
        }

        /// <summary>
        /// Click Add to Cart.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <returns>Resultado.</returns>
        [HttpPost]
        public async Task<ViewResult> ProductDetail(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0 )
                {
                    ViewData["Result"] = false;
                    ViewData["MostrarMensaje"] = "Se debe especificar el id del producto.";
                    return View("Products");
                }
                else
                {
                    var lstItemsSerialized = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString()).Value;

                    int customerId = !User.Identity.IsAuthenticated ? 0 : Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier.ToString()).Value);

                    lstItemsSerialized = IoCFactoryBusiness.Resolve<IItemsService>().AddItemToCart(product.Id, lstItemsSerialized, customerId);

                    //Guardar en memoria
                    var claims = new List<Claim>();

                    var thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString());
                    if (thumbClaim != null)
                    {
                        (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                    }
                    (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.UserData, lstItemsSerialized));

                    claims = (User.Identity as ClaimsIdentity).Claims.ToList();
                    var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                    if (User.Identity.IsAuthenticated)
                    {
                        AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, id);
                    }
                }

                //    //ViewData["Resultado"] = true;
                //    return PartialView(model);
            }
            ViewData["Result"] = false;
            return View("Products");
        }

        /// <summary>
        /// Get the top 5.
        /// </summary>
        /// <returns>Top 5.</returns>
        public async Task<JsonResult> ProductsTop5()
        {
            Response.Expires = 0;

            AnswerPage<Product> answerProduct = new AnswerPage<Product>();

            answerProduct = IoCFactoryBusiness.Resolve<IProductsService>().GetProductsTop5(new BaseQueryPagination() { Page = 1, PageSize = 5, Contains = string.Empty});

            if (answerProduct.Results.Count > 0)
            {
                return Json(new
                {
                    Items = answerProduct.Results,
                    Total = answerProduct.Results.Count,
                    Message = answerProduct.Results.Count == 0 ? "No hay datos" : string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    Items = new List<Product>(),
                    Total = 0,
                    Mensaje = "No hay datos"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Shopping Cart
        /// <summary>
        /// ShoppingCart Management.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>ShoppingCart(s) View.</returns>
        public ActionResult ShoppingCarts(int? id)
        {
            //if (id.HasValue)
            //{
            //    return View("Product", id.Value);
            //}

            Order order = GetOrder();

            if (order != null)
            {
                ViewData["subtotal"] = order.Items.Sum(itm => itm.Product.ListPrice*itm.Quantity);
            }
            else
            {
                ViewData["subtotal"] = 0;
            }

            return View();
        }


        [HttpPost]
        public ActionResult ShoppingCarts(string action, Customer model)
        {
            //1 validar si no esta autenticado
            //2 Pedir Datos TC y envio
            //3 borrar items de BD

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if(action.Equals("process"))
            {
                return RedirectToAction("ProcessCart");
            }
            if(action.Equals("cancelOrder"))
            {
                int customerId = !User.Identity.IsAuthenticated ? 0 : Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier.ToString()).Value);

                var result = IoCFactoryBusiness.Resolve<IItemsService>().DeleteItemsByCustomerId(customerId);

                if(result)
                {
                    var lstItemsSerialized = JsonSerializer.SerializeObject(new List<Item>());

                    //Guardar en memoria
                    var claims = new List<Claim>();

                    var thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString());
                    if (thumbClaim != null)
                    {
                        (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                    }
                    (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.UserData, lstItemsSerialized));

                    claims = (User.Identity as ClaimsIdentity).Claims.ToList();
                    var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                    if (User.Identity.IsAuthenticated)
                    {
                        AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, id);
                    }
                }

                return RedirectToAction("ShoppingCarts");
            }

            return View();
        }

        /// <summary>
        /// Get products shopping cart.
        /// </summary>
        /// <returns>Top 5</returns>
        public async Task<JsonResult> ProductsCart()
        {
            Response.Expires = 0;

            Order order = GetOrder();

            if (order != null )
            {
                return Json(new
                {
                    Items = order.Items,
                    Total = order.Items.Count,
                    Message = order.Items.Count == 0 ? "No hay datos" : string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    Items = new List<Item>(),
                    Total = 0,
                    Mensaje = "No hay datos"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Process Order.
        /// </summary>
        /// <returns>Partial View.</returns>
        public PartialViewResult ProcessOrder(int id)
        {
            //TODO: popup
            return PartialView();
        }

        /// <summary>
        /// Delete product.
        /// </summary>
        /// <param name="productId">Identifier product.</param>
        /// <returns></returns>
        public ActionResult DeleteProduct(string productId)
        {

            if (string.IsNullOrEmpty(productId))
            {
                ViewData["Result"] = false;
                ViewData["MostrarMensaje"] = "Se debe especificar el id del producto.";
            }
            else
            {
                var lstItemsSerialized = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString()).Value;

                int customerId = !User.Identity.IsAuthenticated ? 0 : Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier.ToString()).Value);

                lstItemsSerialized = IoCFactoryBusiness.Resolve<IItemsService>().DeleteItemToCart(Convert.ToInt32(productId), lstItemsSerialized, customerId);

                //Guardar en memoria
                var claims = new List<Claim>();

                var thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString());
                if (thumbClaim != null)
                {
                    (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                }
                (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.UserData, lstItemsSerialized));

                claims = (User.Identity as ClaimsIdentity).Claims.ToList();
                var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                if (User.Identity.IsAuthenticated)
                {
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, id);
                }
            }

            ViewData["Result"] = false;

            return RedirectToAction("ShoppingCarts");
        }

        /// <summary>
        /// Get order.
        /// </summary>
        /// <returns></returns>
        private Order GetOrder()
        {
            int userId = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier) == null ? 0 : Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier.ToString()).Value);
            var lstItemsSerialized = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString()).Value;

            Order order = IoCFactoryBusiness.Resolve<IOrdersService>().GetOrderByCustomerId(userId, lstItemsSerialized);

            return order;
        }

        /// <summary>
        /// Change the quantity of the product.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <returns>Vista.</returns>
        [HttpPost]
        public ActionResult ParameterUpdate(Item item)
        {
            if (item == null)
            {
                ViewData["Result"] = false;
                ViewData["MostrarMensaje"] = "Se debe especificar el id del producto.";
            }
            else
            {
                var lstItemsSerialized = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString()).Value;

                int customerId = !User.Identity.IsAuthenticated ? 0 : Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier.ToString()).Value);

                lstItemsSerialized = IoCFactoryBusiness.Resolve<IItemsService>().ModifyQuantityToItem(item, lstItemsSerialized, customerId);

                //Guardar en memoria
                var claims = new List<Claim>();

                var thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString());
                if (thumbClaim != null)
                {
                    (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                }
                (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.UserData, lstItemsSerialized));

                claims = (User.Identity as ClaimsIdentity).Claims.ToList();
                var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                if (User.Identity.IsAuthenticated)
                {
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, id);
                }
            }

            ViewData["Result"] = true;

            return RedirectToAction("ShoppingCarts");
        }
        #endregion


        #region Process Order
        public ActionResult ProcessCart()
        {
            

            return View("ProcessCart");
        }

        [HttpPost]
        //[AllowAnonymous]
        public ActionResult ProcessCart(string accion, ShippingInformationViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            int customerId = !User.Identity.IsAuthenticated ? 0 : Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier.ToString()).Value);
            //var lstItemsSerialized = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString()).Value;

            var answerOrder = IoCFactoryBusiness.Resolve<IOrdersService>().ProcessOrder(customerId);

            if (answerOrder)
            {
                var lstItemsSerialized = JsonSerializer.SerializeObject(new List<Item>());

                //Guardar en memoria
                var claims = new List<Claim>();

                var thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString());
                if (thumbClaim != null)
                {
                    (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                }
                (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.UserData, lstItemsSerialized));

                claims = (User.Identity as ClaimsIdentity).Claims.ToList();
                var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                if (User.Identity.IsAuthenticated)
                {
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, id);
                }
            }

            return View(model);
        }

        #endregion

        #region Language Resources
        /// <summary>
        /// Language Resources for Datatables.
        /// </summary>
        /// <returns>List resources.</returns>
        [HttpGet]
        public JsonResult DatatablesLocalizacion()
        {
            return Json(new
            {
                sProcessing = "En proceso...",
                sLengthMenu = "Mostrar _MENU_ registros",
                sZeroRecords = "No se encontraron resultados",
                sEmptyTable = "Ningún dato disponible en esta tabla",
                sInfo = "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                sInfoEmpty = "Mostrando registros del 0 al 0 de un total de 0 registros",
                sInfoFiltered = "(filtrado de un total de _MAX_ registros)",
                sInfoPostFix = "",
                sSearch = "Consultar",
                sUrl = "",
                sInfoThousands = ",",
                sLoadingRecords = "Cargando...",
                oPaginate = new
                {
                    sFirst = "Primero",
                    sLast = "Último",
                    sNext = "Siguiente",
                    sPrevious = "Anterior"
                },
                oAria = new
                {
                    sSortAscending = "Activar para ordenar la columna de manera ascendente",
                    sSortDescending = "Activar para ordenar la columna de manera descendente"
                },
            }, JsonRequestBehavior.AllowGet);
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