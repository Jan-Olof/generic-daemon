using functional.common.valueObjects.validate;
using functional.core.commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace functional.core.tests.commands
{
    [TestClass]
    public class AddThingTests
    {
        [TestMethod]
        public void TestShouldCreateAddThing()
        {
            // Given
            Func<DateTime> now() => () => new DateTime(2020, 12, 22, 7, 7, 7);
            Func<Guid> guid() => () => Guid.Parse("3e60685f-b6e3-4006-a1bc-0f338afadabd");
            string name = "Cool Name";

            // When
            var result = AddThing.Create(now(), guid(), name);

            // Then
            Assert.IsTrue(result.IsValid);
            var addThing = (AddThing)result.GetOrException();

            Assert.AreEqual(now().Invoke(), addThing.Created);
            Assert.AreEqual(guid().Invoke(), addThing.Id);
            Assert.AreEqual(name, addThing.Name);
        }
    }
}