using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    //We can directly call ProductRepository methods in our ASP.NET Core Web Application but it is always good practice to create an application services layer between your web application and repositories.This application service layer allows us to define all the business logics which you can’t define in repositories that contain data access logic in them.
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);
        public Task<int> CreateProductAsync(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeletePropertyAsync(Product product);

    }
}
