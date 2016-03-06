using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Entities.Pagination;
using PICA_B2C.Infrastructure.CrossCutting.IoC;
using PICA_B2C.ServiceAgent.MainModule.Contracts;
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
            try
            {
                return IoCFactory.Resolve<IProductsServiceAgent>().GetProducts(query);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while querying products", ex);
            }
        }

        /// <summary>
        /// Get Products by Name.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProductsByName(BaseQueryPagination query)
        {
            try
            {
                return IoCFactory.Resolve<IProductsServiceAgent>().GetProductsByName(query);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while querying products by Name", ex);
            }
        }

        /// <summary>
        /// Get Products by Description.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProductsByDescription(BaseQueryPagination query)
        {
            try
            {
                return IoCFactory.Resolve<IProductsServiceAgent>().GetProductsByDescription(query);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while querying products by Description", ex);
            }
        }

        /// <summary>
        /// Get Product by Id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Porduct.</returns>
        public Product GetProductById(int id)
        {
            try
            {
                return IoCFactory.Resolve<IProductsServiceAgent>().GetProductById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while querying the product by id", ex);
            }
        }
    }
}
