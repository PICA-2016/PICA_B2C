using B2C.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PICA_B2C.Business.MainModule.Entities.Enumerations;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Entities.Pagination;
using PICA_B2C.Business.MainModule.Services;
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

            BaseQueryPagination query = new BaseQueryPagination()
            {
                Contains = filterSearch,
                TotalReturn = true,
                Page = start / length + 1,
                PageSize = length
            };

            ProductsService productsService = new ProductsService();
            AnswerPage<Product> answerProduct = new AnswerPage<Product>();

            switch (typeSearch)
            {
                case TypeSearch.Code:
                    {
                        int value;
                        if (int.TryParse(filterSearch, out value))
                        {
                            answerProduct = productsService.GetProductById(Convert.ToInt32(filterSearch));
                        }
                        else
                        {
                            answerProduct = productsService.GetProducts(query);
                        }
                            
                        break;
                    }
                case TypeSearch.Name:
                    {
                        answerProduct = productsService.GetProductsByName(query);
                        break;
                    }
                case TypeSearch.Description:
                    {
                        answerProduct = productsService.GetProductsByDescription(query);
                        break;
                    }
                default:
                    {
                        answerProduct = productsService.GetProductsByName(query);
                        break;
                    }
            }

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
                ProductsService productsService = new ProductsService();
                product = productsService.GetProductById(id).Results.FirstOrDefault();

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
                
                if (!User.Identity.IsAuthenticated)
                {
                    ViewData["Result"] = false;
                    ViewData["MostrarMensaje"] = "usuario no autenticado.";
                    return View("Products");
                }
                else
                {
                    //TODO: se esta actualizando solo en memoria.
                    var lstPorductIs = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString()).Value;
                    var lstQuantitys = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.SerialNumber.ToString()).Value;
                    List<int> productsIds = string.IsNullOrEmpty(lstPorductIs) ? new List<int>() : lstPorductIs.Split(',').Select(p => Convert.ToInt32(p)).ToList();
                    List<int> quantitys = string.IsNullOrEmpty(lstQuantitys) ? new List<int>() : lstQuantitys.Split(',').Select(q => Convert.ToInt32(q)).ToList();

                    if (productsIds.Any(p => p == product.Id))
                    {
                        for(int i=0; i< productsIds.Count(); i++)
                        {
                            if(productsIds[i] == product.Id)
                            {
                                quantitys[i] = quantitys[i] + 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        productsIds.Add(product.Id);
                        quantitys.Add(1);
                    }

                    var claims = new List<Claim>();

                    //productsIds
                    var thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString());
                    if (thumbClaim != null)
                    {
                        (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                    }
                    (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.UserData, string.Join(",", productsIds)));

                    //quantitys
                    thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.SerialNumber.ToString());
                    if (thumbClaim != null)
                    {
                        (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                    }
                    (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.SerialNumber, string.Join(",", quantitys)));

                    claims = (User.Identity as ClaimsIdentity).Claims.ToList();
                    var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, id);

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

            ProductsService productsService = new ProductsService();
            AnswerPage<Product> answerProduct = new AnswerPage<Product>();

            //TODO: falta el metodo de TOP5 en el Servicio Web
            answerProduct = productsService.GetProductsByName(new BaseQueryPagination() { Page = 1, PageSize = 5, Contains = string.Empty});

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

            Order order = null;
            if (User.Identity.IsAuthenticated)
            {
                order = GetOrder();
            }

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


        /// <summary>
        /// Get products shopping cart.
        /// </summary>
        /// <returns>Top 5</returns>
        public async Task<JsonResult> ProductsCart()
        {
            Response.Expires = 0;

            Order order = null;
            if (User.Identity.IsAuthenticated)
            {
                order = GetOrder();
            }

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
                //TODO: se esta actualizando solo en memoria.
                var lstPorductIs = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString()).Value;
                var lstQuantitys = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.SerialNumber.ToString()).Value;
                List<int> productsIds = lstPorductIs.Split(',').Select(p => Convert.ToInt32(p)).ToList();
                List<int> quantitys = lstQuantitys.Split(',').Select(q => Convert.ToInt32(q)).ToList();

                for(int i=0; i< productsIds.Count(); i++)
                {
                    if (productsIds[i] == Convert.ToInt32(productId))
                    {
                        productsIds.RemoveAt(i);
                        quantitys.RemoveAt(i);
                        i = productsIds.Count();
                    }
                }

                var claims = new List<Claim>();

                //productsIds
                var thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString());
                if (thumbClaim != null)
                {
                    (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                }
                (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.UserData, string.Join(",", productsIds)));

                //quantitys
                thumbClaim = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.SerialNumber.ToString());
                if (thumbClaim != null)
                {
                    (User.Identity as ClaimsIdentity).RemoveClaim(thumbClaim);
                }
                (User.Identity as ClaimsIdentity).AddClaim(new Claim(ClaimTypes.SerialNumber, string.Join(",", quantitys)));

                claims = (User.Identity as ClaimsIdentity).Claims.ToList();
                var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, id);
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
            int userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier.ToString()).Value);

            var lstPorductIs = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.UserData.ToString()).Value;
            var lstQuantitys = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.SerialNumber.ToString()).Value;
            List<int> productsIds = string.IsNullOrEmpty(lstPorductIs) ? new List<int>() : lstPorductIs.Split(',').Select(p => Convert.ToInt32(p)).ToList();
            List<int> quantitys = string.IsNullOrEmpty(lstQuantitys) ? new List<int>() : lstQuantitys.Split(',').Select(q => Convert.ToInt32(q)).ToList();

            OrdersService ordersService = new OrdersService();
            Order order = ordersService.GetOrderByCustomerId(userId, productsIds, quantitys);

            return order;
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


        public PartialViewResult ParameterUpdate(int parametroId, int cantidad)
        {
            return PartialView(new Item() { ProductId = parametroId, Quantity = cantidad });
        }

        [HttpPost]
        public PartialViewResult ParameterUpdate(Item model, int cantidad)
        {
            return PartialView(model);
        }

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