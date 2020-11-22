using classic.core.commands;
using classic.core.requests;
using LaYumba.Functional;
using System;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace classic.core
{
    public static class Interactor
    {
        public static Unit RunInteractor(this Request request, Func<DateTime> now, Func<Guid> guid) =>
            request.CreateCommand(now, guid)
                .Map(cmd => ShowCommand(cmd))
                .Match(errors => Unit(), command => Unit()); // TODO: Continue after CommandFactory!

        private static Command ShowCommand(Command cmd) => cmd;
    }
}