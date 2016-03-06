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
    public class ProductsServiceAgent : IProductsServiceAgent
    {
        /// <summary>
        /// Get Products.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProducts(BaseQueryPagination query)
        {
            wsProductsReference.ws_productosClient wsProductsClient = new wsProductsReference.ws_productosClient();
            var resultsService = wsProductsClient.consultarPRODUCTOS_LISTA(query.Page, query.PageSize);

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = query.PageSize;  //TODO: en servicio debe retornar el numero total

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
            wsProductsReference.ws_productosClient wsProductsClient = new wsProductsReference.ws_productosClient();
            var resultsService = wsProductsClient.consultarPRODUCTOS_NOMBRE(query.Contains, query.Page, query.PageSize);

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = query.PageSize;  //TODO: en servicio debe retornar el numero total

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
            wsProductsReference.ws_productosClient wsProductsClient = new wsProductsReference.ws_productosClient();
            var resultsService = wsProductsClient.consultarPRODUCTOS_DESCRIPCION(query.Contains, query.Page, query.PageSize);

            AnswerPage<Product> answer = new AnswerPage<Product>();
            answer.Page = query.Page;
            answer.PageSize = query.PageSize;
            answer.Total = query.PageSize;  //TODO: en servicio debe retornar el numero total

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
        public Product GetProductById(int id)
        {
            wsProductsReference.ws_productosClient wsProductsClient = new wsProductsReference.ws_productosClient();
            var resultsService = wsProductsClient.consultarPRODUCTOS_ID(id);
            var porductResult = resultsService.FirstOrDefault();

            Product product = new Product()
            {
                Id = porductResult.ID,
                ProductId = porductResult.PRODUCTO_ID,
                Name = porductResult.NOMBRE,
                Description = porductResult.DESCRIPCION,
                Category = porductResult.CATEGORIA,
                ListPrice = porductResult.PRECIO_LISTA,
                Producer = porductResult.FABRICANTE,
                Image = porductResult.IMAGEN_URL
            };

            return product;
        }
    }
}
