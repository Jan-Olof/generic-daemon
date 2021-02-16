using Functional.Tests.SampleObjects;
using Functional.Core.Commands;
using Functional.Core.Tests.SampleObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Functional.Common.DataTypes.Validate;

namespace Functional.Core.Tests.UnitTests.Commands
{
    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void TestShouldCreateCommand_AddThing()
        {
            // Given
            static Func<DateTime> Now() => () => new DateTime(2020, 12, 21, 7, 7, 7);
            static Func<Guid> Guid() => Guids.One;
            var add = Adds.Create();

            // When
            var result = add.CreateCommand(Now(), Guid());

            // Then
            Assert.IsTrue(result.IsValid);

            var addThing = (AddThing)result.GetOrException();

            Assert.AreEqual("John Doe", addThing.Name);
        }
    }
}