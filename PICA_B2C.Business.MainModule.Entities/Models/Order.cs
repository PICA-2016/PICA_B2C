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
        /// List items.
        /// </summary>
        public virtual ICollection<Item> Items { get; set; }
    }
}
