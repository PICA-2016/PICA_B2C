using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2C.Models
{
    /// <summary>
    /// Product Model.
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// Product identifier.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product price.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Image.
        /// </summary>
        public byte[] Image { get; set; }
    }
}