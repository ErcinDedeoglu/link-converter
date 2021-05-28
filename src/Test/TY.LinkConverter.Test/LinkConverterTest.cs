using System;
using System.Collections.Generic;
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
    public class LinkConverterTest
    {
        [Test]
        public void Test()
        {
            var configuration = ConfigurationHelper.Configuration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DataContext>(a => a.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TY.LinkConverter.Data.Migration")));
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            using (var serviceScope = serviceCollection.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var unitOfWork = serviceScope.ServiceProvider.GetService<IUnitOfWork>())
            {
                List<Tuple<string, string>> list = new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>("https://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892&merchantId=1050", "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=1050"),
                    new Tuple<string, string>("https://www.trendyol.com/brand/name-p-1925865", "ty://?Page=Product&ContentId=1925865"),
                    new Tuple<string, string>("https://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892", "ty://?Page=Product&ContentId=1925865&CampaignId=439892"),
                    new Tuple<string, string>("https://www.trendyol.com/brand/name-p-1925865?merchantId=105064", "ty://?Page=Product&ContentId=1925865&MerchantId=105064"),
                    new Tuple<string, string>("https://www.trendyol.com/sr?q=elbise", "ty://?Page=Search&Query=elbise"),
                    new Tuple<string, string>("https://www.trendyol.com/sr?q=%C3%BCt%C3%BC", "ty://?Page=Search&Query=%C3%BCt%C3%BC")
                };
                string link;

                foreach (var item in list)
                {
                    link = unitOfWork.LinkConverterService.ToDeeplink(item.Item1);
                    Assert.AreEqual(item.Item2, link);
                }
                
                link = unitOfWork.LinkConverterService.ToDeeplink("https://www.trendyol.com/Hesabim/Favoriler");
                Assert.AreEqual("ty://?Page=Home", link);

                link = unitOfWork.LinkConverterService.ToDeeplink("https://www.trendyol.com/Hesabim/#/Siparisleri");
                Assert.AreEqual("ty://?Page=Home", link);

                link = unitOfWork.LinkConverterService.ToDeeplink(" ");
                Assert.AreEqual("ty://?Page=Home", link);

                link = unitOfWork.LinkConverterService.ToDeeplink(string.Empty);
                Assert.AreEqual("ty://?Page=Home", link);

                link = unitOfWork.LinkConverterService.ToDeeplink(null);
                Assert.AreEqual("ty://?Page=Home", link);

                foreach (var item in list)
                {
                    link = unitOfWork.LinkConverterService.ToWebURL(item.Item2);
                    Assert.AreEqual(item.Item1, link);
                }

                link = unitOfWork.LinkConverterService.ToWebURL("ty://?Page=Favorites");
                Assert.AreEqual("https://www.trendyol.com", link);

                link = unitOfWork.LinkConverterService.ToWebURL("ty://?Page=Orders");
                Assert.AreEqual("https://www.trendyol.com", link);

                link = unitOfWork.LinkConverterService.ToWebURL(" ");
                Assert.AreEqual("https://www.trendyol.com", link);

                link = unitOfWork.LinkConverterService.ToWebURL(string.Empty);
                Assert.AreEqual("https://www.trendyol.com", link);

                link = unitOfWork.LinkConverterService.ToWebURL(null);
                Assert.AreEqual("https://www.trendyol.com", link);
            }
        }
    }
}