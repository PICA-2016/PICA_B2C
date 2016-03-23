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
        /// Identifiers shopping cart.
        /// </summary>
        public List<int> ShoppingCartsId { get; set; }

        /// <summary>
        /// List shopping cart.
        /// </summary>
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
