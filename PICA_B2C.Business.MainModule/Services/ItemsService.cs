using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.DataPersistence.MainModule.Contracts;
using PICA_B2C.Infrastructure.CrossCutting.Core.Serialization;
using PICA_B2C.Infrastructure.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Services
{
    /// <summary>
    /// Class service Item.
    /// </summary>
    public class ItemsService : IItemsService
    {
        /// <summary>
        /// Get the items of a customer.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <param name="lstItemsSerialized">Serialized list items.</param>
        /// <returns>List items.</returns>
        public List<Item> GetItemsByCustomer(int customerId, string lstItemsSerialized)
        {
            try
            {
                List<Item> lstItems = JsonSerializer.DeserializeObject<List<Item>>(lstItemsSerialized);
                List<Item> itemsCurrent = IoCFactory.Resolve<IItemsRepository>().GetItemsByCustomer(customerId);

                foreach (var itm in lstItems)
                {
                    Item item = itemsCurrent.FirstOrDefault(it => it.ProductId == itm.ProductId);
                    if (item != null)
                    {
                        item.Quantity += itm.Quantity;
                        IoCFactory.Resolve<IItemsRepository>().ModifyQuantityToItem(item);
                    }
                    else
                    {
                        IoCFactory.Resolve<IItemsRepository>().AddItem(itm, customerId);
                    }
                }

                return IoCFactory.Resolve<IItemsRepository>().GetItemsByCustomer(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al consultar los items del cliente", ex);
            }
        }

        /// <summary>
        /// Add item to cart.
        /// </summary>
        /// <param name="productId">Product identifier to add.</param>
        /// <param name="lstItemsSerialized">Serialized list items.</param>
        /// <param name="customerId">Customer identifier.</param>
        /// <returns>Serialized list items.</returns>
        public string AddItemToCart(int productId, string lstItemsSerialized, int customerId)
        {
            List<Item> lstItems = JsonSerializer.DeserializeObject<List<Item>>(lstItemsSerialized);

            Item item = lstItems.FirstOrDefault(itm => itm.ProductId == productId);

            if (item != null)
            {
                item.Quantity += 1;

                if (item.ItemId != 0)
                {
                    IoCFactory.Resolve<IItemsRepository>().ModifyQuantityToItem(item);
                    lstItems = IoCFactory.Resolve<IItemsRepository>().GetItemsByCustomer(customerId);
                }
            }
            else if (customerId != 0)
            {
                item = new Item
                {
                    ProductId = productId,
                    Quantity = 1,
                };

                IoCFactory.Resolve<IItemsRepository>().AddItem(item, customerId);
                lstItems = IoCFactory.Resolve<IItemsRepository>().GetItemsByCustomer(customerId);
            }
            else
            {
                lstItems.Add(new Item
                {
                    ProductId = productId,
                    Quantity = 1
                });
            }

            lstItemsSerialized = JsonSerializer.SerializeObject(lstItems);
            return lstItemsSerialized;
        }

        /// <summary>
        /// Delete item to cart.
        /// </summary>
        /// <param name="product">Product to delete.</param>
        /// <param name="lstItemsSerialized">Serialized list items.</param>
        /// <param name="customerId">Customer identifier.</param>
        /// <returns>Serialized list items.</returns>
        public string DeleteItemToCart(int productId, string lstItemsSerialized, int customerId)
        {
            List<Item> lstItems = JsonSerializer.DeserializeObject<List<Item>>(lstItemsSerialized);

            Item item = lstItems.FirstOrDefault(itm => itm.ProductId == productId);

            if (item.ItemId != 0)
            {
                IoCFactory.Resolve<IItemsRepository>().DeleteItem(item);
                lstItems = IoCFactory.Resolve<IItemsRepository>().GetItemsByCustomer(customerId);
            }
            else
            {
                lstItems.Remove(item);
            }

            lstItemsSerialized = JsonSerializer.SerializeObject(lstItems);
            return lstItemsSerialized;
        }

        /// <summary>
        /// Modify the quantity of an item from the cart.
        /// </summary>
        /// <param name="item">Item to modify.</param>
        /// <param name="lstItemsSerialized">Serialized list items.</param>
        /// <param name="customerId">Customer identifier.</param>
        /// <returns>Serialized list items.</returns>
        public string ModifyQuantityToItem(Item item, string lstItemsSerialized, int customerId)
        {
            List<Item> lstItems = JsonSerializer.DeserializeObject<List<Item>>(lstItemsSerialized);

            Item itemCurrent = lstItems.FirstOrDefault(itm => itm.ProductId == item.ProductId);
            itemCurrent.Quantity = item.Quantity;

            if (itemCurrent.ItemId != 0)
            {
                IoCFactory.Resolve<IItemsRepository>().ModifyQuantityToItem(itemCurrent);
                lstItems = IoCFactory.Resolve<IItemsRepository>().GetItemsByCustomer(customerId);
            }

            lstItemsSerialized = JsonSerializer.SerializeObject(lstItems);
            return lstItemsSerialized;
        }

    }
}
