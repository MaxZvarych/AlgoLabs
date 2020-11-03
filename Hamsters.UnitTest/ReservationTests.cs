using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Hamsters.UnitTest
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void QuickSearch_()
        {
            var list = new List<dynamic>();
            var a = new Hamster();
            list.Add(new Hamsters() { Hunger = 1, Greed = 2 });

            Assert.That(result, Is.True);
        }
    }
}
