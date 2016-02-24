using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Domain.MainModule.Entities.Pagination
{
    /// <summary>
    ///  Entity that encapsulates the response from a paged query.
    /// </summary>
    /// <typeparam name="T">Type of results.</typeparam>
    public class AnswerPage<T>
    {


        /// <summary>
        /// Generic constructor.
        /// </summary>
        public AnswerPage()
        {
            this.Page = 0;
            this.PageSize = 0;
            this.Total = 0;
            this.Results = new List<T>();
        }

        /// <summary>
        /// Builder with all initialization parameters.
        /// </summary>
        /// <param name="results">List of results of the consultation on the current page.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="page">Page number that is returning.</param>
        /// <param name="total">Total results of the consultation.</param>

        public AnswerPage(List<T> results, int pageSize, int page, int total)
        {
            this.Page = page;
            this.PageSize = pageSize;
            this.Total = total;
            this.Results = results;
        }

        /// <summary>
        /// Page number that is returning.
        /// </summary>
        public int Page
        {
            get;
            set;
        }

        /// <summary>
        /// Results of the requested page.
        /// </summary>
        public List<T> Results
        {
            get;
            set;
        }

        /// <summary>
        /// Page size requested in the query.
        /// </summary>
        public int PageSize
        {
            get;
            set;
        }

        /// <summary>
        /// Total results of the query.
        /// </summary>
        public int Total
        {
            get;
            set;
        }

    }
}
