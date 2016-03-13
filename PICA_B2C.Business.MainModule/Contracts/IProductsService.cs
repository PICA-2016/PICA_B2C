using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Contracts
{
    /// <summary>
    /// Product interface service.
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Get Products.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        AnswerPage<Product> GetProducts(BaseQueryPagination query);

        /// <summary>
        /// Get Products by Name.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        AnswerPage<Product> GetProductsByName(BaseQueryPagination query);

        /// <summary>
        /// Get Products by Description.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        AnswerPage<Product> GetProductsByDescription(BaseQueryPagination query);

        /// <summary>
        /// Get Product by Id.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <returns>Porduct.</returns>
        AnswerPage<Product> GetProductById(int productId);
    }
}
