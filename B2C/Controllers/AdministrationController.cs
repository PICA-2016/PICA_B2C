using B2C.Models;
using PICA_B2C.Domain.MainModule.Entities.Models;
using PICA_B2C.Domain.MainModule.Entities.Pagination;
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

            AnswerPage<Product> answerProduct = GetList(query);

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
            ProductViewModel model;

            if (id == 0)
            {
                model = new ProductViewModel()
                {
                    ProductId = 0,
                };
            }
            else
            {
                Product product = GetList(new BaseQueryPagination()).Results.FirstOrDefault(pro => pro.ProductId == id);

                if (product == null)
                {
                    ViewData["Result"] = false;
                    ModelState.AddModelError("mensajeError", "product null .");
                    ViewData["ShowMessage"] = "product null ...";
                }

                model = new ProductViewModel()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Code = product.Code,
                    Price = product.Price
                };
            }

            return PartialView(model);
        }


        //TODO: consulta temporal.
        private AnswerPage<Product> GetList(BaseQueryPagination query)
        {
            List<Product> lstProductsTemp = new List<Product>();
            for (int i = 1; i <= 1000; i++)
            {
                lstProductsTemp.Add(new Product() { ProductId = i, Code = "C" + i, Name = "Name" + i * 2, Description = "Description....", Price = (i * 10).ToString() });
            }

            AnswerPage<Product> answer = new AnswerPage<Product>();
            List<Product> lstProducts = null;
            var lstProductsQuery = (from pro in lstProductsTemp
                                    where ((String.IsNullOrEmpty(query.Contains)) || (pro.Code.ToUpper().Contains(query.Contains.ToUpper())) || (pro.Name.ToUpper().Contains(query.Contains.ToUpper())))
                                    select pro).OrderBy(nv => nv.Name).AsQueryable<Product>();

            if (query.TotalReturn)
            {
                answer.Total = lstProductsQuery.Count();
            }

            if (query.Page > 0)
            {
                lstProducts = lstProductsQuery.Skip(query.PageSize * (query.Page - 1)).Take(query.PageSize).ToList();
                answer.PageSize = query.PageSize;

            }
            else
            {
                lstProducts = lstProductsQuery.ToList();
                answer.PageSize = lstProductsQuery.Count();
            }

            answer.Results = lstProducts;
            answer.Page = query.Page;

            return answer;
        }
    }
}