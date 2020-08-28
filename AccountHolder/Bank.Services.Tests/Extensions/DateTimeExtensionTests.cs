using System;
using System.Collections.Generic;
using System.Text;
using  Bank.Services.Extensions;
using NUnit.Framework;

namespace Bank.Services.Tests.Extensions
{
    [TestFixture]
    class DateTimeExtensionTests
    {
        [Test]
        public void WhenDateIsInFutureThenTrue()
        {
            DateTime futureDate = DateTime.Now.AddDays(1);
            bool result = DateTimeExtensions.IsInFuture(futureDate);
            Assert.That(result, Is.True);
        }

        [Test]
        public void WhenDateIsInPastThenFalse()
        {
            DateTime PastDate = DateTime.Now.AddDays(-1);
            bool result = DateTimeExtensions.IsInFuture(PastDate);
            Assert.That(result, Is.False);
        }

    }
}
