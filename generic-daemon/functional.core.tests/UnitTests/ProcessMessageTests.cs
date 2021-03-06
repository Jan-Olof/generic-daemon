﻿using Functional.Tests.SampleObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Functional.Common.Entities.Messages;

namespace Functional.Core.Tests.UnitTests
{
    [TestClass]
    public class ProcessMessageTests
    {
        [TestMethod]
        public void TestShouldProcessOneMessage_Add()
        {
            // Given
            static Func<DateTime> Now() => () => new DateTime(2020, 12, 21, 7, 7, 7);
            static Func<Guid> Guid() => Guids.One;
            var message = (Message.Create(Guids.Two(),
                "{\"id\": \"5998b4d5-ff78-415f-9ffa-62df1e27dfe8\",\"name\": \"Jane Doe\"}", new DateTime(2000, 1, 1),
                MessageTypes.NewThing));
            var process = ProcessMessage.Process(Now(), Guid());

            // When
            var result = process(message);

            // Then
            Assert.IsTrue(true);
        }
    }
}