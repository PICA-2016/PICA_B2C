using PICA_B2C.Business.MainModule.Contracts;
using PICA_B2C.Business.MainModule.Entities.Models;
using PICA_B2C.Business.MainModule.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Business.MainModule.Services
{
    /// <summary>
    /// Class service Product.
    /// </summary>
    public class ProductsService : IProductsService
    {
        /// <summary>
        /// Get Products.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns>Products.</returns>
        public AnswerPage<Product> GetProducts(BaseQueryPagination query)
        {
            List<Product> lstProductsTemp = new List<Product>();
            for (int i = 1; i <= 1000; i++)
            {
                temp = GetRamdom();

                lstProductsTemp.Add(new Product() {
                    Id = i,
                    ProductId = i,
                    Name = "Name " + temp,
                    Description = "Description.." + temp,
                    Category = "Category " + temp,
                    ListPrice = (i * 10),
                    Producer = "Producer " + temp,
                    Image = GetImage(),
            });
            }

            AnswerPage<Product> answer = new AnswerPage<Product>();
            List<Product> lstProducts = null;
            var lstProductsQuery = (from pro in lstProductsTemp
                                    where ((String.IsNullOrEmpty(query.Contains)) 
                                    || (pro.ProductId.ToString().Equals(query.Contains))
                                    || (pro.Name.ToUpper().Contains(query.Contains.ToUpper()))
                                    || (pro.Description.ToUpper().Contains(query.Contains.ToUpper()))
                                    )
                                    select pro).OrderBy(pro => pro.Id).AsQueryable<Product>();

            if (query.TotalReturn)
            {
                answer.Total = lstProductsQuery.Count();
            }

            if (query.Page > 0)
            {
                lstProducts = lstProductsQuery.Skip(query.PageSize * (query.Page - 1)).Take(query.PageSize).ToList();
                answer.PageSize = query.PageSize;

            }
            else
            {
                lstProducts = lstProductsQuery.ToList();
                answer.PageSize = lstProductsQuery.Count();
            }

            answer.Results = lstProducts;
            answer.Page = query.Page;

            return answer;
        }

        /// <summary>
        /// Get Product by Id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Porduct.</returns>
        public Product GetProductById(int id)
        {
            return GetProducts(new BaseQueryPagination()).Results.FirstOrDefault(pro => pro.Id == id);
        }


        //TODO: temporal .... borrar
        private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private string temp;
        private Random random = new Random();
        private List<string> lstImages = new List<string>()
        {
            "http://ecx.images-amazon.com/images/I/41oZNEzk3NL.jpg",
            "http://www.lamcomputer.com/images/logitech%20x530/x530b.jpg",
            "http://sonyglobal.scene7.com/is/image/gwtprod/5ba9ed28c11595e42572c84b174da6bc?fmt=png-alpha&wid=1000",
            "http://photos2.appleinsidercdn.com/gallery/13592-8515-150715-iPod_touch-l.jpg",
            "http://www.omicrono.com/wp-content/uploads/2015/02/alienware-portatil.jpg"
        };
        private Random randomImg = new Random();
        private string GetRamdom()
        {
            return chars[random.Next(chars.Length)].ToString() + chars[random.Next(chars.Length)].ToString() + chars[random.Next(chars.Length)].ToString();
        }
        private string GetImage()
        {
            return lstImages[randomImg.Next(lstImages.Count()-1)];
        }
    }
}
