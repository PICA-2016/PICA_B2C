using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Services
{
    /// <summary>
    /// Class service Product.
    /// </summary>
    public class ProductsService : IProductsService
    {
        /// <summary>
        /// Get Products.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProducts(BaseQueryPagination query)
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

        /// <summary>
        /// Get Product by Id.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <returns>Porduct.</returns>
        public Product GetProductById(int productId)
        {
            return GetProducts(new BaseQueryPagination()).Results.FirstOrDefault(pro => pro.ProductId == productId);
        }

    }
}
