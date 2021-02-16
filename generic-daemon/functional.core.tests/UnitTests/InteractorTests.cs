using System;
using Functional.Tests.SampleObjects;
using Functional.Core.Tests.SampleObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Functional.Core.Tests.UnitTests
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