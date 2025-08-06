using Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database
{
    public static class MigrateDatabaseExtension
    {
        public static void MigrateDatabase(this IHost host)
        {
            try
            {
                var context = host.Services.GetService<ApplicationContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = host.Services.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }

}
