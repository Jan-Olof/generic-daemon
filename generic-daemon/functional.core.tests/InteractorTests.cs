using functional.common.tests.SampleObjects;
using functional.core.tests.SampleObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace functional.core.tests
{
    [TestClass]
    public class InteractorTests
    {
        [TestMethod]
        public void TestShouldRunInteractor()
        {
            // Given
            Func<DateTime> now() => () => new DateTime(2020, 12, 21, 7, 7, 7);
            static Func<Guid> Guid() => Guids.One;
            var add = Adds.Create();

            // When
            var result = add.RunInteractor(now(), Guid());

            // Then
            Assert.IsTrue(true);
        }
    }
}