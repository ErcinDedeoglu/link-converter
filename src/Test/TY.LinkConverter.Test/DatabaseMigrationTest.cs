using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TY.LinkConverter.Context;
using TY.LinkConverter.Test.Helper;

namespace TY.LinkConverter.Test
{
    [TestFixture]
    public class DatabaseMigrationTest
    {
        [Test]
        public void Test()
        {
            var configuration = ConfigurationHelper.Configuration();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DataContext>(a => a.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TY.LinkConverter.Data.Migration")));

            using (var serviceScope = serviceCollection.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var dataContext = serviceScope.ServiceProvider.GetService<DataContext>())
            {
                dataContext.Database.Migrate();
            }
        }
    }
}