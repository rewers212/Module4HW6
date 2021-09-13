using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW6.DataAccess
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var config = new ConfigService();
            var optionalBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionalBuilder.UseSqlServer(config.ConnectionString);

            return new ApplicationContext(optionalBuilder.Options);
        }
    }
}
