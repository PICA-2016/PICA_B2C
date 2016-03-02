using B2C.Models;
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
        /// <returns>Products.</returns>
        public async Task<JsonResult> FilterProducts(int draw, int start, int length, Dictionary<string, string> search)
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
            AnswerPage<Product> answerProduct = productsService.GetProducts(query);

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
        public PartialViewResult ProductDetail(int id)
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

            return PartialView(product);
        }

    }
}