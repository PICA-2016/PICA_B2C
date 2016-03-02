using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Entities.Models
{
    /// <summary>
    /// Product entity.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product identifier.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Product price.
        /// </summary>
        public int ListPrice { get; set; }

        /// <summary>
        /// Product producer.
        /// </summary>
        public string Producer { get; set; }

        /// <summary>
        /// Name image.
        /// </summary>
        public string Image { get; set; }
    }
}
