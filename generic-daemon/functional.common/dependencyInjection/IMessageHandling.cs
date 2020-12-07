using functional.common.entities.messages;
using LanguageExt;
using System;

namespace functional.common.dependencyInjection
{
    public interface IMessageHandling
    {
        Unit HandleMessages(Func<Message, Unit> processMessage);
    }
}