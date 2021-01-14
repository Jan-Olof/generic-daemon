using Functional.Common.Helpers;
using functional.common.tests.SampleObjects;
using Functional.Common.DataTypes;
using Functional.Common.DataTypes.Validate;
using Functional.Common.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace functional.common.tests.valueObjects
{
    [TestClass]
    public class TimestampTests
    {
        [TestMethod]
        public void TestShouldCompareEquality_Equal()
        {
            // Given
            var dateTime1 = new DateTime(2020, 12, 21, 7, 7, 7);
            var dateTime2 = new DateTime(2020, 12, 21, 7, 7, 7);
            var timestamp1 = Timestamp.Create(dateTime1).GetOrException();
            var timestamp2 = Timestamp.Create(dateTime2).GetOrException();

            // When
            bool result = timestamp1 == timestamp2;

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestShouldCompareEquality_NotEqual()
        {
            // Given
            var dateTime1 = new DateTime(2020, 12, 21, 7, 7, 6);
            var dateTime2 = new DateTime(2020, 12, 21, 7, 7, 7);
            var timestamp1 = Timestamp.Create(dateTime1).GetOrException();
            var timestamp2 = Timestamp.Create(dateTime2).GetOrException();

            // When
            bool result = timestamp1 == timestamp2;

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestShouldCompareNotEquality_Equal()
        {
            // Given
            var dateTime1 = new DateTime(2020, 12, 21, 7, 7, 7);
            var dateTime2 = new DateTime(2020, 12, 21, 7, 7, 7);
            var timestamp1 = Timestamp.Create(dateTime1).GetOrException();
            var timestamp2 = Timestamp.Create(dateTime2).GetOrException();

            // When
            bool result = timestamp1 != timestamp2;

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestShouldCompareNotEquality_NotEqual()
        {
            // Given
            var dateTime1 = new DateTime(2020, 12, 21, 7, 7, 6);
            var dateTime2 = new DateTime(2020, 12, 21, 7, 7, 7);
            var timestamp1 = Timestamp.Create(dateTime1).GetOrException();
            var timestamp2 = Timestamp.Create(dateTime2).GetOrException();

            // When
            bool result = timestamp1 != timestamp2;

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestShouldConvertTimestampToDateTime()
        {
            // Given
            var dateTime = new DateTime(2020, 12, 21, 7, 7, 7);
            var timestamp = Timestamp.Create(dateTime).GetOrException();

            // When
            DateTime result = timestamp;

            // Then
            Assert.AreEqual(dateTime.ToString("f"), result.ToString("f"));
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_Option_None()
        {
            // Given
            var now = new DateTime(1800, 12, 21, 7, 7, 7);

            // When
            var result = Timestamp.Create(now);

            // Then
            Assert.IsTrue(result.IsNone);
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_Option_Some()
        {
            // Given
            var now = new DateTime(2020, 12, 21, 7, 7, 7);

            // When
            var result = Timestamp.Create(now);

            // Then
            Assert.IsTrue(result.IsSome);
            Assert.AreEqual(now, result.GetOrException());
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_Validate_Func_Invalid()
        {
            // Given
            Func<DateTime> now() => () => new DateTime(1899, 12, 21, 7, 7, 7);
            var origin = Origin.Create(Guids.Four(), nameof(TimestampTests), nameof(TestShouldCreateTimestamp_Validate_Func_Invalid));

            // When
            var result = Timestamp.Create(now(), origin);

            // Then
            Assert.IsTrue(result.IsInvalid());
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_Validate_Func_Valid()
        {
            // Given
            Func<DateTime> now() => () => new DateTime(2020, 12, 21, 7, 7, 7);
            var origin = Origin.Create(Guids.Three(), nameof(TimestampTests), nameof(TestShouldCreateTimestamp_Validate_Func_Valid));

            // When
            var result = Timestamp.Create(now(), origin);

            // Then
            Assert.IsTrue(result.IsValid);
            DateTime actual = result.GetOrException();
            Assert.AreEqual(now().Invoke(), actual);
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_Validate_Invalid()
        {
            // Given
            var now = new DateTime(1850, 12, 21, 7, 7, 7);
            var origin = Origin.Create(Guids.Two(), nameof(TimestampTests), nameof(TestShouldCreateTimestamp_Validate_Invalid));

            // When
            var result = Timestamp.Create(now, origin);

            // Then
            Assert.IsTrue(result.IsInvalid());
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_Validate_Valid()
        {
            // Given
            var now = new DateTime(2020, 12, 21, 7, 7, 7);
            var origin = Origin.Create(Guids.One(), nameof(TimestampTests), nameof(TestShouldCreateTimestamp_Validate_Valid));

            // When
            var result = Timestamp.Create(now, origin);

            // Then
            Assert.IsTrue(result.IsValid);
            DateTime actual = result.GetOrException();
            Assert.AreEqual(now, actual);
        }
    }
}