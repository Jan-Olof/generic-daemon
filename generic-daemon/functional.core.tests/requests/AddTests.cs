using functional.common.tests.SampleObjects;
using functional.core.requests;
using functional.core.tests.SampleObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace functional.core.tests.requests
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