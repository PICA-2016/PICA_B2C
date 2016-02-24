using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Domain.MainModule.Entities.Pagination
{
    /// <summary>
    /// Based entity to perform a paged query.
    /// </summary>
    public class BaseQueryPagination
    {
        /// <summary>
        /// Constructor.
        /// Initializes Page: 0 Page size: 0 and Total return: true.
        /// </summary>
        public BaseQueryPagination()
        {
            TotalReturn = true;
            PageSize = 0;
            Page = 0;
        }

        /// <summary>
        /// Constructor with initialization parameter query.
        /// </summary>
        /// <param name="totalReturn">Total return query results.</param>
        /// <param name="pageSize">Size of the requested page.</param>
        /// <param name="page">Page number requested.</param>
        public BaseQueryPagination(bool totalReturn, int pageSize, int page)
        {
            TotalReturn = totalReturn;
            PageSize = pageSize;
            Page = page;
        }

        /// <summary>
        /// Text string with which you want to filter the query.
        /// </summary>
        public string Contains
        {
            get;
            set;
        }


        /// <summary>
        /// Page number requested.
        /// </summary>
        public int Page
        {
            get;
            set;
        }

        /// <summary>
        /// It indicates whether you want or not the query returns all query results.
        /// </summary>
        public bool TotalReturn
        {
            get;
            set;
        }

        /// <summary>
        /// Page size requested.
        /// </summary>
        public int PageSize
        {
            get;
            set;
        }
    }
}
