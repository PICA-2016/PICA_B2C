using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Entities.Pagination;
using PICA_B2C.ServiceAgent.MainModule.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.ServiceAgent.MainModule.Implementation.WebServices
{
    /// <summary>
    /// Class service agent Product.
    /// </summary>
    public class ProductsServiceAgent : IProductsServiceAgent
    {
        /// <summary>
        /// Get Products by Name.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProductsByName(BaseQueryPagination query)
        {
            var wsProductsClient = new wsConsultasProductosReference.consultasEspecialesProductosPortTypeClient();
            var resultsService = wsProductsClient.wsBuscarproductosXNombre(query.Contains, query.Page, query.PageSize);

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = resultsService == null ? 0 : Convert.ToInt32(resultsService.FirstOrDefault().CANTIDAD_REGISTROS);

            answer.Results = resultsService == null ? new List<Product>() : (from pro in resultsService
                                                                             select new Product()
                                                                             {
                                                                                 Id = Convert.ToInt32(pro.ID),
                                                                                 ProductId = Convert.ToInt32(pro.PRODUCTO_ID),
                                                                                 Name = pro.NOMBRE,
                                                                                 Description = pro.DESCRIPCION,
                                                                                 Category = pro.CATEGORIA,
                                                                                 ListPrice = Convert.ToInt32(pro.PRECIO_LISTA),
                                                                                 Producer = pro.FABRICANTE,
                                                                                 Image = pro.IMAGEN_URL
                                                                             }).ToList();

            return answer;
        }

        /// <summary>
        /// Get Products by Description.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProductsByDescription(BaseQueryPagination query)
        {
            var wsProductsClient = new wsConsultasProductosReference.consultasEspecialesProductosPortTypeClient();
            var resultsService = wsProductsClient.wsBuscarProductosXDescripcion(query.Contains, query.Page, query.PageSize);

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = resultsService == null ? 0 : Convert.ToInt32(resultsService.FirstOrDefault().CANTIDAD_REGISTROS);

            answer.Results = resultsService == null ? new List<Product>() : (from pro in resultsService
                              select new Product()
                              {
                                  Id = Convert.ToInt32(pro.ID),
                                  ProductId = Convert.ToInt32(pro.PRODUCTO_ID),
                                  Name = pro.NOMBRE,
                                  Description = pro.DESCRIPCION,
                                  Category = pro.CATEGORIA,
                                  ListPrice = Convert.ToInt32(pro.PRECIO_LISTA),
                                  Producer = pro.FABRICANTE,
                                  Image = pro.IMAGEN_URL
                              }).ToList();

            return answer;
        }

        /// <summary>
        /// Get Product by Id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Porduct.</returns>
        public AnswerPage<Product> GetProductById(int id)
        {
            var wsProductsClient = new wsConsultasProductosReference.consultasEspecialesProductosPortTypeClient();
            var resultsService = wsProductsClient.wsBuscarproductoXID(id);
            AnswerPage<Product> answer = new AnswerPage<Product>();

            answer.Page = 1;
            answer.PageSize = 10;
            answer.Total = resultsService == null ? 0 : resultsService.Count();

            answer.Results = resultsService == null ? new List<Product>() : (from pro in resultsService
                              select new Product()
                              {
                                  Id = Convert.ToInt32(pro.ID),
                                  ProductId = Convert.ToInt32(pro.PRODUCTO_ID),
                                  Name = pro.NOMBRE,
                                  Description = pro.DESCRIPCION,
                                  Category = pro.CATEGORIA,
                                  ListPrice = Convert.ToInt32(pro.PRECIO_LISTA),
                                  Producer = pro.FABRICANTE,
                                  Image = pro.IMAGEN_URL
                              }).ToList();

            return answer;
        }

        /// <summary>
        /// Get the top 5.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProductsTop5(BaseQueryPagination query)
        {
            var wsTopProductsClient = new wsTopProductsReference.topProductosPortTypeClient();
            var resultService = wsTopProductsClient.wsTopCinco(Convert.ToInt32(query.Contains));

            var wsProductsClient = new wsConsultasProductosReference.consultasEspecialesProductosPortTypeClient();

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = resultService == null ? 0 : resultService.Count();
            answer.Results = new List<Product>();

            if (resultService != null)
            {
                foreach (var pro in resultService)
                {
                    var resultsService = wsProductsClient.wsBuscarproductoXID(Convert.ToInt32(pro.PRODID));
                    var product = resultsService.FirstOrDefault();
                    answer.Results.Add(
                         new Product()
                         {
                             Id = Convert.ToInt32(product.ID),
                             ProductId = Convert.ToInt32(product.PRODUCTO_ID),
                             Name = product.NOMBRE,
                             Description = product.DESCRIPCION,
                             Category = product.CATEGORIA,
                             ListPrice = Convert.ToInt32(product.PRECIO_LISTA),
                             Producer = product.FABRICANTE,
                             Image = product.IMAGEN_URL
                         });
                }
            }

            return answer;
        }
    }
}
