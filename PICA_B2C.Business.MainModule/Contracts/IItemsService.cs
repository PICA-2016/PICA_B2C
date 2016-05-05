using PICA_B2C.Business.MainModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Contracts
{
    public interface IItemsService
    {
        /// <summary>
        /// Get the items of a customer.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <returns>List items.</returns>
        List<Item> GetItemsByCustomer(int customerId);
    }
}
