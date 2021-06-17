using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    //group the common methods needed by all the repositories.
    public class BaseRepository
    {
        private readonly IConfiguration _config;

        protected BaseRepository(IConfiguration config)
        {
            _config = config;
        }

        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_config.GetConnectionString("OnlineShopConnection"));         
            
        }
    }     
}
