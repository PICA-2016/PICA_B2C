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
        /// <param name="lstItemsSerialized">Serialized list items.</param>
        /// <returns>List items.</returns>
        List<Item> GetItemsByCustomer(int customerId, string lstItemsSerialized);

        /// <summary>
        /// Add item to cart.
        /// </summary>
        /// <param name="productId">Product identifier to add.</param>
        /// <param name="lstItemsSerialized">Serialized list items.</param>
        /// <param name="customerId">Customer identifier.</param>
        /// <returns>Serialized list items.</returns>
        string AddItemToCart(int productId, string lstItemsSerialized, int customerId);

        /// <summary>
        /// Delete item to cart.
        /// </summary>
        /// <param name="product">Product to delete.</param>
        /// <param name="lstItemsSerialized">Serialized list items.</param>
        /// <param name="customerId">Customer identifier.</param>
        /// <returns>Serialized list items.</returns>
        string DeleteItemToCart(int productId, string lstItemsSerialized, int customerId);

        /// <summary>
        /// Modify the quantity of an item from the cart.
        /// </summary>
        /// <param name="item">Item to modify.</param>
        /// <param name="lstItemsSerialized">Serialized list items.</param>
        /// <param name="customerId">Customer identifier.</param>
        /// <returns>Serialized list items.</returns>
        string ModifyQuantityToItem(Item item, string lstItemsSerialized, int customerId);
    }
}
