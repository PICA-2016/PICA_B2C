using PICA_B2C.DataPersistence.MainModule.Contracts;
using PICA_B2C.DataPersistence.MainModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.DataPersistence.MainModule.Implementation
{
    /// <summary>
    /// Class repository for Item entity.
    /// </summary>
    public class ItemsRepository : IItemsRepository
    {
        /// <summary>
        /// Get the items of a customer.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <returns>List items.</returns>
        public List<PICA_B2C.Business.MainModule.Entities.Models.Item> GetItemsByCustomer(int customerId)
        {
            using (AES_Pica_Items context = new AES_Pica_Items())
            {
                var query = from itm in context.Items where itm.ClienteId == customerId select itm;

                var lstItems = query.Select(itm => new PICA_B2C.Business.MainModule.Entities.Models.Item
                {
                    ItemId = itm.ItemId,
                    Quantity = itm.Cantidad,
                     //= itm.ClienteId,
                    ProductId = itm.ProductoId
                }).ToList();

                return lstItems.ToList();
            }
        }

        /// <summary>
        /// Add new item.
        /// </summary>
        /// <param name="item">Item to add.</param>
        /// <param name="customerId">Customer Id.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool AddItem(PICA_B2C.Business.MainModule.Entities.Models.Item item, int customerId)
        {
            Item newItem = new Item
            {
                ItemId = item.ItemId,
                Cantidad = item.Quantity,
                ClienteId = customerId,
                ProductoId = item.ProductId
            };

            using (AES_Pica_Items context = new AES_Pica_Items())
            {
                context.Items.Add(newItem);
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Remove items from a customer.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool DeleteItemsByCustomerId(int customerId)
        {
            using (AES_Pica_Items context = new AES_Pica_Items())
            {
                var lstItems = (from it in context.Items
                               where it.ClienteId == customerId
                               select it);

                if ((lstItems != null))
                {
                    foreach (var itm in lstItems)
                    {
                        context.Items.Attach(itm);
                        //context.Entry(itm).State = System.Data.EntityState.Deleted;
                    }

                    context.SaveChanges();
                }

                return true;
            }
        }
    }
}
