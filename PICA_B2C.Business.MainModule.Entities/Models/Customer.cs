using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Entities.Models
{
    /// <summary>
    /// Customer entity.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer name.
        /// </summary>
        public string Names { get; set; }

        /// <summary>
        /// Customer lastname.
        /// </summary>
        public string LastNames { get; set; }

        /// <summary>
        /// Customer email.
        /// </summary>
        public string Email { get; set; }

        ///// <summary>
        ///// Identifiers orders.
        ///// </summary>
        //public List<int> OrdersId { get; set; }

        ///// <summary>
        ///// List orders.
        ///// </summary>
        //public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        public Order Order { get; set; }
    }
}
