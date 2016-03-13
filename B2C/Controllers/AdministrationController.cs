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
                        answerProduct = productsService.GetProductsByName(query); //TODO: falta metodo de busqueda por codigo en el Servicio Web
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
                product = productsService.GetProductById(id);

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
    }
}