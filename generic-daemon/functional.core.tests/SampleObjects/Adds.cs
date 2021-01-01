using functional.common.tests.SampleObjects;
using functional.core.requests;

namespace functional.core.tests.SampleObjects
{
    public static class Adds
    {
        public static Add Create() => new Add { MessageId = Guids.Eight(), Name = "John Doe" };
    }
}