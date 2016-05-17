using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Entities.Models
{
    /// <summary>
    /// Order entity.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Identifiers items.
        /// </summary>
        public List<int> ItemsId { get; set; }

        /// <summary>
        /// Identifier customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// List items.
        /// </summary>
        public virtual ICollection<Item> Items { get; set; }

        /// <summary>
        /// Shipping Information.
        /// </summary>
        public virtual ShippingInformation ShippingInformation { get; set; }
    }
}
