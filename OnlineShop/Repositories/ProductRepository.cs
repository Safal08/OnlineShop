using Dapper;
using Microsoft.Extensions.Configuration;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<int> CreateAsync(Product entity)
        {
            try
            {
                var query = @"INSERT INTO Product (Name, Price, Quantity) VALUES
                            (@Name, @Price, @Quantity)";
                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Price", entity.Price, DbType.Decimal);
                parameters.Add("Quantity", entity.Quantity, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> DeleteAsync(Product entity)
        {
            try
            {
                var query = @"DELETE *FROM Product WHERE Id=@Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT * FROM Product";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Product>(query)).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var query = @"SELECT * FROM Product WHERE Id= @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Product>(query, parameters));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            try
            {
                var query = @"UPDATE Product SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE ID = @Id ";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Price", entity.Price, DbType.Decimal);
                parameters.Add("Quantity", entity.Quantity, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
