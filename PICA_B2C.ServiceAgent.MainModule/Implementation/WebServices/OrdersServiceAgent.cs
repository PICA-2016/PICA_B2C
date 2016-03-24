using PICA_B2C.Business.MainModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.ServiceAgent.MainModule.Implementation.WebServices
{
    /// <summary>
    /// Class service agent Order.
    /// </summary>
    public class OrdersServiceAgent
    {
        /// <summary>
        /// Get order by customer id.
        /// </summary>
        /// <param name="customerId">Identifier customer.</param>
        /// <param name="productsId">List of productIds.</param>
        /// <returns>Order.</returns>
        public Order GetOrderByCustomerId(int customerId, List<int> productsId)
        {
            throw new NotImplementedException();
        }
    }
}
