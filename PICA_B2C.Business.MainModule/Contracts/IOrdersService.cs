using PICA_B2C.Business.MainModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Contracts
{
    /// <summary>
    /// Order interface service.
    /// </summary>
    public interface IOrdersService
    {
        /// <summary>
        /// Get order by customer id.
        /// </summary>
        /// <param name="customerId">Identifier customer.</param>
        /// <param name="lstProductsId">List of productIds.</param>
        /// <param name="lstQuantitys"></param>
        /// <returns>Order.</returns>
        Order GetOrderByCustomerId(int customerId, string lstItemsSerialized);

        /// <summary>
        /// process the order.
        /// </summary>
        /// <param name="order">Order to process.</param>
        /// <returns>True if the operation was successful.</returns>
        bool ProcessOrder(Order order);
    }
}
