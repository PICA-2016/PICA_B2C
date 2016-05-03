﻿using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Enumerations;
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
        /// <param name="filterSearch">filter Search.</param>
        /// <param name="start">Start.</param>
        /// <param name="length">Length.</param>
        /// <param name="typeSearch">Type Search.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProducts(string filterSearch, int start, int length, TypeSearch typeSearch)
        {
            try
            {
                AnswerPage<Product> answerProduct = new AnswerPage<Product>();

                BaseQueryPagination query = new BaseQueryPagination()
                {
                    Contains = filterSearch,
                    TotalReturn = true,
                    Page = start / length + 1,
                    PageSize = length
                };

                switch (typeSearch)
                {
                    case TypeSearch.Code:
                        {
                            int value;
                            if (int.TryParse(filterSearch, out value))
                            {
                                answerProduct = IoCFactory.Resolve<IProductsServiceAgent>().GetProductById(Convert.ToInt32(filterSearch));
                            }
                            else
                            {
                                answerProduct = IoCFactory.Resolve<IProductsServiceAgent>().GetProducts(query);
                            }

                            break;
                        }
                    case TypeSearch.Name:
                        {
                            answerProduct = IoCFactory.Resolve<IProductsServiceAgent>().GetProductsByName(query);
                            break;
                        }
                    case TypeSearch.Description:
                        {
                            answerProduct = IoCFactory.Resolve<IProductsServiceAgent>().GetProductsByDescription(query);
                            break;
                        }
                    default:
                        {
                            answerProduct = IoCFactory.Resolve<IProductsServiceAgent>().GetProductsByName(query);
                            break;
                        }
                }
                return answerProduct;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al consultar los productos", ex);
            }
        }

        /// <summary>
        /// Get the top 5.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProductsTop5(BaseQueryPagination query)
        {
            try
            {
                return IoCFactory.Resolve<IProductsServiceAgent>().GetProductsByName(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al consultar los productos del top 5", ex);
            }
        }

        /// <summary>
        /// Get Product by Id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Porduct.</returns>
        public AnswerPage<Product> GetProductById(int id)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstPorductIs">Product identifiers.</param>
        /// <param name="lstQuantitys">Quantitys.</param>
        /// <param name="product">Product to add.</param>
        /// <param name="productsIds">Product identifiers</param>
        /// <param name="quantitys">Quantitys</param>
        public void AddProductToCart(string lstPorductIs, string lstQuantitys, Product product, out List<int> productsIds, out List<int> quantitys)
        {
            productsIds = string.IsNullOrEmpty(lstPorductIs) ? new List<int>() : lstPorductIs.Split(',').Select(p => Convert.ToInt32(p)).ToList();
            quantitys = string.IsNullOrEmpty(lstQuantitys) ? new List<int>() : lstQuantitys.Split(',').Select(q => Convert.ToInt32(q)).ToList();

            if (productsIds.Any(p => p == product.Id))
            {
                for (int i = 0; i < productsIds.Count(); i++)
                {
                    if (productsIds[i] == product.Id)
                    {
                        quantitys[i] = quantitys[i] + 1;
                        break;
                    }
                }
            }
            else
            {
                productsIds.Add(product.Id);
                quantitys.Add(1);
            }
        }
    }
}
