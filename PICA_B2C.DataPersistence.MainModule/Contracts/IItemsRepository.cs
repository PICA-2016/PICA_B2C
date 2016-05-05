using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.DataPersistence.MainModule.Contracts
{
    public interface IItemsRepository
    {
        /// <summary>
        /// Get the items of a customer.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <returns>List items.</returns>
        List<PICA_B2C.Business.MainModule.Entities.Models.Item> GetItemsByCustomer(int customerId);

        /// <summary>
        /// Add new item.
        /// </summary>
        /// <param name="item">Item to add.</param>
        /// <param name="customerId">Customer Id.</param>
        /// <returns>True if the operation was successful.</returns>
        bool AddItem(PICA_B2C.Business.MainModule.Entities.Models.Item item, int customerId);

        /// <summary>
        /// Remove items from a customer.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <returns>True if the operation was successful.</returns>
        bool DeleteItemsByCustomerId(int customerId);
    }
}
