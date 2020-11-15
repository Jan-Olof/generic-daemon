using classic.core.commands;
using classic.core.requests;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace classic.core
{
    public static class Interactor
    {
        public static Unit RunInteractor(this Request request) =>
            request.CreateCommand()
                .Match(errors => Unit(), command => Unit()); // TODO: Continue!
    }
}