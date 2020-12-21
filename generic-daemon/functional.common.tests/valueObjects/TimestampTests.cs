using functional.common.errors;
using functional.common.valueObjects;
using functional.common.valueObjects.validate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using functional.common.helpers;

namespace functional.common.tests.valueObjects
{
    [TestClass]
    public class TimestampTests
    {
        [TestMethod]
        public void TestShouldCreateTimestamp_Validate()
        {
            // Given
            var now = new DateTime(2020, 12, 21, 7, 7, 7);
            var origin = Origin.Create(nameof(TimestampTests), nameof(TestShouldCreateTimestamp_Validate));

            // When
            var result = Timestamp.Create(now, origin);

            // Then
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(now, result.GetOrException().Value);
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_Validate_Func()
        {
            // Given
            Func<DateTime> now() => () => new DateTime(2020, 12, 21, 7, 7, 7);
            var origin = Origin.Create(nameof(TimestampTests), nameof(TestShouldCreateTimestamp_Validate_Func));

            // When
            var result = Timestamp.Create(now(), origin);

            // Then
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(now().Invoke(), result.GetOrException().Value);
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_Option()
        {
            // Given
            var now = new DateTime(2020, 12, 21, 7, 7, 7);

            // When
            var result = Timestamp.Create(now);

            // Then
            Assert.IsTrue(result.IsSome);
            Assert.AreEqual(now, result.GetOrException());
        }
    }
}