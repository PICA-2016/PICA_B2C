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
        /// Get Products.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProducts(BaseQueryPagination query)
        {
            wsProductsReference.consultarProductosClient wsProductsClient = new wsProductsReference.consultarProductosClient();
            var resultsService = wsProductsClient.consultarPRODUCTOS_LISTA(query.Page, query.PageSize);

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = resultsService.FirstOrDefault().CANTIDAD_REGISTROS;

            answer.Results = (from pro in resultsService select new Product()
            {
                Id = pro.ID,
                ProductId = pro.PRODUCTO_ID,
                Name = pro.NOMBRE,
                Description = pro.DESCRIPCION,
                Category = pro.CATEGORIA,
                ListPrice = pro.PRECIO_LISTA,
                Producer = pro.FABRICANTE,
                Image = pro.IMAGEN_URL
            }).ToList();

            return answer;
        }

        /// <summary>
        /// Get Products by Name.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProductsByName(BaseQueryPagination query)
        {
            wsProductsReference.consultarProductosClient wsProductsClient = new wsProductsReference.consultarProductosClient();
            var resultsService = wsProductsClient.consultarPRODUCTOS_NOMBRE(query.Contains, query.Page, query.PageSize);

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = resultsService.FirstOrDefault().CANTIDAD_REGISTROS;

            answer.Results = (from pro in resultsService
                              select new Product()
                              {
                                  Id = pro.ID,
                                  ProductId = pro.PRODUCTO_ID,
                                  Name = pro.NOMBRE,
                                  Description = pro.DESCRIPCION,
                                  Category = pro.CATEGORIA,
                                  ListPrice = pro.PRECIO_LISTA,
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
            wsProductsReference.consultarProductosClient wsProductsClient = new wsProductsReference.consultarProductosClient();
            var resultsService = wsProductsClient.consultarPRODUCTOS_DESCRIPCION(query.Contains, query.Page, query.PageSize);

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = resultsService.FirstOrDefault().CANTIDAD_REGISTROS;

            answer.Results = (from pro in resultsService
                              select new Product()
                              {
                                  Id = pro.ID,
                                  ProductId = pro.PRODUCTO_ID,
                                  Name = pro.NOMBRE,
                                  Description = pro.DESCRIPCION,
                                  Category = pro.CATEGORIA,
                                  ListPrice = pro.PRECIO_LISTA,
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
            wsProductsReference.consultarProductosClient wsProductsClient = new wsProductsReference.consultarProductosClient();
            var resultsService = wsProductsClient.consultarPRODUCTOS_ID(id);
            AnswerPage<Product> answer = new AnswerPage<Product>();

            answer.Page = 1;
            answer.PageSize = 10;
            answer.Total = resultsService.FirstOrDefault().CANTIDAD_REGISTROS;

            answer.Results = (from pro in resultsService
                              select new Product()
                              {
                                  Id = pro.ID,
                                  ProductId = pro.PRODUCTO_ID,
                                  Name = pro.NOMBRE,
                                  Description = pro.DESCRIPCION,
                                  Category = pro.CATEGORIA,
                                  ListPrice = pro.PRECIO_LISTA,
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
            wsProductsReference.consultarProductosClient wsProductsClient = new wsProductsReference.consultarProductosClient();
            var resultsService = wsProductsClient.consultarPRODUCTOS_NOMBRE(query.Contains, query.Page, query.PageSize);

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = resultsService.FirstOrDefault().CANTIDAD_REGISTROS;

            answer.Results = (from pro in resultsService
                              select new Product()
                              {
                                  Id = pro.ID,
                                  ProductId = pro.PRODUCTO_ID,
                                  Name = pro.NOMBRE,
                                  Description = pro.DESCRIPCION,
                                  Category = pro.CATEGORIA,
                                  ListPrice = pro.PRECIO_LISTA,
                                  Producer = pro.FABRICANTE,
                                  Image = pro.IMAGEN_URL
                              }).ToList();

            return answer;
        }
    }
}
