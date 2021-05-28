using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Sentry;
using TY.LinkConverter.Test.Helper;

namespace TY.LinkConverter.Test
{
    [TestFixture]
    public class SentryTest
    {
        [Test]
        public void Test()
        {
            var configuration = ConfigurationHelper.Configuration();
            var sentryHelper = new SentryHelper(configuration.GetValue<string>("SentryDSN"));
            string sentryId = sentryHelper.Capture("TY.LinkConverter UNIT TEST").ToString();

            Assert.IsNotEmpty(sentryId);
        }

        public class SentryHelper
        {
            private readonly string _dsn;

            public SentryHelper(string dsn)
            {
                _dsn = dsn;
            }

            public bool Capture(string json)
            {
                var result = false;
                var sentryId = new SentryClient(new SentryOptions()
                {
                    Dsn = _dsn
                }).CaptureMessage(json);

                if (!string.IsNullOrWhiteSpace(sentryId.ToString())) result = true;

                return result;
            }
        }
    }
}