using B2C.Models;
using PICA_B2C.Business.MainModule.Entities.Enumerations;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Entities.Pagination;
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
        /// Detalle de ProfesionalesSalud.
        /// </summary>
        /// <param name="id">Identificador del ProfesionalSalud.</param>
        /// <returns>Resultado.</returns>
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
        /// Get the top 5
        /// </summary>
        /// <returnsTop 5></returns>
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
            return View();
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
    }
}