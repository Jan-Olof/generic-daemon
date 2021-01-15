using System;
using Functional.Common.Entities.Messages;
using LanguageExt;

namespace Functional.Daemon.DependencyInjection
{
    public interface IMessageHandling
    {
        Unit HandleMessages(Func<Message, Unit> processMessage);
    }
}