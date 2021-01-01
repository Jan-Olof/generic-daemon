using functional.common.entities.messages;
using functional.common.helpers;
using functional.common.tests.SampleObjects;
using functional.core.requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace functional.core.tests
{
    [TestClass]
    public class MessageMappingTests
    {
        [TestMethod]
        public void TestShouldCreateRequest_Add()
        {
            // Given
            var message = (Message.Create(Guids.Two(),
                "{\"name\": \"Jane Doe\"}",
                new DateTime(2021, 1, 1),
                MessageTypes.NewThing));

            // When
            var result = message.CreateRequest();

            // Then
            Assert.IsTrue(result.IsSome);

            var add = (Add)result.GetOrException();

            Assert.AreEqual("Jane Doe", add.Name);
            Assert.AreEqual(Guids.Two(), add.MessageId);
        }

        [TestMethod]
        public void TestShouldCreateRequest_None()
        {
            // Given
            var message = (Message.Create(Guids.Two(),
                "{\"name\": \"Jane Doe\"}",
                new DateTime(2021, 1, 1),
                MessageTypes.Unknown));

            // When
            var result = message.CreateRequest();

            // Then
            Assert.IsTrue(result.IsNone);
        }

        [TestMethod]
        public void TestShouldCreateRequest_Remove()
        {
            // Given
            var message = (Message.Create(Guids.Two(),
                "{\"id\": \"5998b4d5-ff78-415f-9ffa-62df1e27dfe8\",\"name\": \"Jane Doe\"}",
                new DateTime(2021, 1, 1),
                MessageTypes.ThingRemoved));

            // When
            var result = message.CreateRequest();

            // Then
            Assert.IsTrue(result.IsSome);

            var remove = (Remove)result.GetOrException();

            Assert.AreEqual("5998b4d5-ff78-415f-9ffa-62df1e27dfe8", remove.Id.ToString());
            Assert.AreEqual(Guids.Two(), remove.MessageId);
        }

        [TestMethod]
        public void TestShouldCreateRequest_Update()
        {
            // Given
            var message = (Message.Create(Guids.Two(),
                "{\"id\": \"5998b4d5-ff78-415f-9ffa-62df1e27dfe8\",\"name\": \"Jane Doe\"}",
                new DateTime(2021, 1, 1),
                MessageTypes.ThingChanged));

            // When
            var result = message.CreateRequest();

            // Then
            Assert.IsTrue(result.IsSome);

            var update = (Update)result.GetOrException();

            Assert.AreEqual("Jane Doe", update.Name);
            Assert.AreEqual("5998b4d5-ff78-415f-9ffa-62df1e27dfe8", update.Id.ToString());
            Assert.AreEqual(Guids.Two(), update.MessageId);
        }
    }
}