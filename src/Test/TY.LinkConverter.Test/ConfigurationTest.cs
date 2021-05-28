using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TY.LinkConverter.Test.Helper;

namespace TY.LinkConverter.Test
{
    [TestFixture]
    public class ConfigurationTest
    {
        [Test]
        public void Test()
        {
            var configuration = ConfigurationHelper.Configuration();

            string defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            Assert.IsNotEmpty(defaultConnectionString, "Database default connection string is empty!");

            var sentryDsn = configuration.GetValue<string>("SentryDSN");
            Assert.IsNotEmpty(sentryDsn, "Sentry DSN is empty!");
        }
    }
}