using System;
using Functional.Common.Entities.Messages;
using LanguageExt;

namespace functional.daemon.dependencyInjection
{
    public interface IMessageHandling
    {
        Unit HandleMessages(Func<Message, Unit> processMessage);
    }
}