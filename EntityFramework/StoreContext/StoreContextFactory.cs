using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.StoreContext
{
    public class StoreContextFactory
    {

        private readonly string _connectionString;


        public StoreContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Datacontext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<Datacontext>();

            options.UseSqlServer(_connectionString).UseSnakeCaseNamingConvention();

            return new Datacontext(options.Options);
        }
    }

}

