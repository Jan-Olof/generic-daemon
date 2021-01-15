using Functional.Common.Tests.SampleObjects;
using Functional.Core.Requests;

namespace Functional.Core.Tests.SampleObjects
{
    public static class Adds
    {
        public static Add Create() => new Add { MessageId = Guids.Eight(), Name = "John Doe" };
    }
}