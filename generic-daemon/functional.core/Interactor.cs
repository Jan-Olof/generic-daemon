using Functional.Core.Commands;
using Functional.Core.Requests;
using Functional.Common.DataTypes.Validate;
using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace Functional.Core
{
    public static class Interactor
    {
        public static Unit RunInteractor(this Request request, Func<DateTime> now, Func<Guid> guid) =>
            request.CreateCommand(now, guid)
                .Map(cmd => ShowCommand(cmd))
                .Match(errors => unit, command => unit); // TODO: Continue after CommandFactory!

        private static Command ShowCommand(Command cmd) => cmd; // TODO: Remove!
    }
}