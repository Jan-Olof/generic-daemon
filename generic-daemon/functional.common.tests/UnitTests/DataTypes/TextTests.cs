using Functional.Common.DataTypes;
using Functional.Common.DataTypes.Validate;
using Functional.Common.Errors;
using Functional.Common.Helpers;
using Functional.Tests.SampleObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Functional.Tests.UnitTests.DataTypes
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void TestShouldCompareEquality_Equal()
        {
            // Given
            string str = "Test";
            var text = Text.Create("Test").GetOrException();

            // When
            bool result = str == text;

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestShouldCompareEquality_NotEqual()
        {
            // Given
            string str = "Tests";
            var text = Text.Create("Test").GetOrException();

            // When
            bool result = str == text;

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestShouldCompareNotEquality_Equal()
        {
            // Given
            string str = "Test";
            var text = Text.Create("Test").GetOrException();

            // When
            bool result = str != text;

            // Then
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestShouldCompareNotEquality_NotEqual()
        {
            // Given
            string str = "Tests";
            var text = Text.Create("Test").GetOrException();

            // When
            bool result = str != text;

            // Then
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestShouldConvertTextToString()
        {
            // Given
            var text = Text.Create("Test").GetOrException();

            // When
            string result = text;

            // Then
            Assert.AreEqual(text.ToString(), result);
        }

        [TestMethod]
        public void TestShouldCreateText_Option_Some()
        {
            // Given
            string str = "Test";

            // When
            var result = Text.Create(str);

            // Then
            Assert.IsTrue(result.IsSome);
            Assert.AreEqual(str, result.GetOrException().ToString());
        }

        [TestMethod]
        public void TestShouldCreateText_Validate_Invalid()
        {
            // Given
            var origin = Origin.Create(Guids.One(), nameof(TimestampTests), nameof(TestShouldCreateText_Validate_Valid));
            string str = "  ";

            // When
            var result = Text.Create(str, origin);

            // Then
            Assert.IsTrue(result.IsInvalid());
        }

        [TestMethod]
        public void TestShouldCreateText_Validate_Valid()
        {
            // Given
            var origin = Origin.Create(Guids.One(), nameof(TimestampTests), nameof(TestShouldCreateText_Validate_Valid));
            string str = "Test";

            // When
            var result = Text.Create(str, origin);

            // Then
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(str, result.GetOrException().ToString());
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_Option_None()
        {
            // Given
            string str = "  ";

            // When
            var result = Text.Create(str);

            // Then
            Assert.IsTrue(result.IsNone);
        }
    }
}