using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Entities.Models
{
    /// <summary>
    /// ShoppingCart entity.
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int ShoppingCartId { get; set; }

        /// <summary>
        /// Product identifier.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product.
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// quantity of the product.
        /// </summary>
        public int Quantity { get; set; }
    }
}
