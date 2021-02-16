using Functional.Common.DataTypes.Try;
using Functional.Common.DataTypes.Validate;
using Functional.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static Functional.F;

namespace Functional.Common.Tests.UnitTests.DataTypes
{
    [TestClass]
    public class TryTests
    {
        [TestMethod]
        public void TestShouldTryException()
        {
            // Given

            // When
            var result = Try(() => new Uri("github")).Run();

            // Then
            Assert.AreEqual(true, result.IsInvalid());

            var error = result.GetErrors().Single();

            Assert.AreEqual(true, error.IsException());
            Assert.AreEqual("Invalid URI: The format of the URI could not be determined.", error.Message);
            Assert.AreEqual("Invalid URI: The format of the URI could not be determined.", error.Exception.GetOrException().Message);
        }

        [TestMethod]
        public void TestShouldTryNoException()
        {
            // Given
            const string uri = "http://github.com";

            // When
            var result = Try(() => new Uri(uri)).Run();

            // Then
            Assert.AreEqual(true, result.IsValid);
            Assert.AreEqual($"{uri}/", result.GetOrException().AbsoluteUri);
        }
    }
}