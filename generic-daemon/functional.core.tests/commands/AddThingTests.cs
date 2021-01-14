using functional.common.tests.SampleObjects;
using functional.core.commands;
using Functional.Common.DataTypes.Validate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace functional.core.tests.commands
{
    [TestClass]
    public class AddThingTests
    {
        [TestMethod]
        public void TestShouldCreateAddThing_Valid()
        {
            // Given
            static Func<DateTime> Now() => () => new DateTime(2020, 12, 22, 7, 7, 7);
            static Func<Guid> Guid() => Guids.One;
            const string name = "Cool Name";

            // When
            var result = Guid().CreateAddThing(Now(), name, Guids.Two());

            // Then
            Assert.IsTrue(result.IsValid);
            var addThing = (AddThing)result.GetOrException();

            Assert.AreEqual(Now().Invoke(), addThing.Created);
            Assert.AreEqual(Guid().Invoke(), addThing.Id);
            Assert.AreEqual(name, addThing.Name);
        }

        [DataRow(1999, "   ", 3)]
        [DataRow(2020, "   ", 2)]
        [DataRow(2020, "A Name", 1)]
        [DataTestMethod]
        public void TestShouldCreateAddThing_Invalid(int year, string name, int expected)
        {
            // Given
            Func<DateTime> Now() => () => new DateTime(year, 12, 22, 7, 7, 7);
            static Func<Guid> Guid() => () => System.Guid.Empty;

            // When
            var result = Guid().CreateAddThing(Now(), name, Guids.Two());

            // Then
            Assert.IsTrue(result.IsInvalid());
            var errors = result.GetErrors().ToImmutableList();

            Assert.AreEqual(expected, errors.Count);
            Assert.AreEqual("The GUID 00000000-0000-0000-0000-000000000000 is invalid.", errors.First().Message);
            Assert.AreEqual("Origin: CreateAddThing in AddThingExt with Id: 8846492a-0556-4a9e-8f31-b7cba11e650d.", errors.First().Origin.ToString());
        }
    }
}