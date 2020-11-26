using System;
using LanguageExt;

namespace functional.common.messages
{
    public interface IMessageHandling
    {
        Unit HandleMessages(Func<Message, Unit> processMessage);
    }
}