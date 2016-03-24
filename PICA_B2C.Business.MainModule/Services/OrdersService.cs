using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
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
    /// Class service Order.
    /// </summary>
    public class OrdersService : IOrdersService
    {
        /// <summary>
        /// Get order by customer id.
        /// </summary>
        /// <param name="customerId">Identifier customer.</param>
        /// <param name="lstProductsId">List of productIds.</param>
        /// <param name="lstQuantitys"></param>
        /// <returns>Order.</returns>
        public Order GetOrderByCustomerId (int customerId, List<int> lstProductsId, List<int> lstQuantitys)
        {
            Order order = new Order()
            {
                CustomerId = customerId,
                Items = new List<Item>(),
                OrderId = customerId,
            };

            Product product = null;
            for(int i = 0; i<lstProductsId.Count; i++)
            {
                product = IoCFactory.Resolve<IProductsServiceAgent>().GetProductById(lstProductsId[i]).Results.FirstOrDefault();
                order.Items.Add(new Item { ItemId = i, Product = product, ProductId = product.ProductId, Quantity = lstQuantitys[i] });
            }

            return order;
        }
    }
}
