using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TY.LinkConverter.Context;
using TY.LinkConverter.Data.Interface;
using TY.LinkConverter.Data.Service;
using TY.LinkConverter.Test.Helper;

namespace TY.LinkConverter.Test
{
    [TestFixture]
    public class UnitOfWorkTest
    {
        [Test]
        public async Task Test()
        {
            var configuration = ConfigurationHelper.Configuration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DataContext>(a => a.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TY.LinkConverter.Data.Migration")));
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            using (var serviceScope = serviceCollection.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var unitOfWork = serviceScope.ServiceProvider.GetService<IUnitOfWork>())
            {
                Assert.IsNotNull(unitOfWork.ToWebURLService);
                Assert.IsNotNull(unitOfWork.ToDeeplinkService);
                Assert.IsNotNull(unitOfWork.LinkConverterService);

                var recordCount = await unitOfWork.CompleteAsync();
                Assert.AreEqual(0, recordCount);
                recordCount = await unitOfWork.CompleteAsync();
                Assert.AreEqual(0, recordCount);
            }
        }
    }
}