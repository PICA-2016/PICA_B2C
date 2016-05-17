using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.DataPersistence.MainModule.Contracts;
using PICA_B2C.Infrastructure.CrossCutting.Core.Serialization;
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
        public Order GetOrderByCustomerId (int customerId, string lstItemsSerialized)
        {
            try
            {
                List<Item> lstItems = JsonSerializer.DeserializeObject<List<Item>>(lstItemsSerialized);

                Order order = new Order()
                {
                    CustomerId = customerId,
                    Items = lstItems,
                    OrderId = customerId,
                };

                Product product = null;
                foreach (var itm in order.Items)
                {
                    product = IoCFactory.Resolve<IProductsServiceAgent>().GetProductById(itm.ProductId).Results.FirstOrDefault();
                    itm.Product = product;
                }

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al consultar la orden del cliente.", ex);
            }
        }

        /// <summary>
        /// process the order.
        /// </summary>
        /// <param name="order">Order to process.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool ProcessOrder(Order order)
        {
            try
            {
                order.Items = IoCFactory.Resolve<IItemsRepository>().GetItemsByCustomer(order.CustomerId);

                Product product = null;
                foreach (var itm in order.Items)
                {
                    product = IoCFactory.Resolve<IProductsServiceAgent>().GetProductById(itm.ProductId).Results.FirstOrDefault();
                    itm.Product = product;
                }

                bool answerServiceAgent = IoCFactory.Resolve<IOrdersServiceAgent>().ProcessOrder(order);

                if (answerServiceAgent)
                {
                    bool answerItems = IoCFactory.Resolve<IItemsRepository>().DeleteItemsByCustomerId(order.CustomerId);
                }

                return answerServiceAgent;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al procesar la orden", ex);
            }
        }
    }
}
