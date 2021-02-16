using Functional.Tests.SampleObjects;
using Functional.Core.Requests;
using Functional.Core.Tests.SampleObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Functional.Core.Tests.UnitTests.Requests
{
    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void TestShouldCreateAdd_Update()
        {
            // Given
            var add = Adds.Create();

            // When
            var result = add.Create(Guids.Nine());

            // Then
            var updated = (Add)result;
            Assert.AreEqual(Guids.Nine(), updated.MessageId);
            Assert.AreEqual(add.Name, updated.Name);
        }
    }
}