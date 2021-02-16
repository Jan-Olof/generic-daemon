using Functional.Common.DataTypes.Validate;
using Functional.Common.Errors;
using System;

namespace Functional.Common.DataTypes.Try
{
    public static class TryExt
    {
        public static Validate<T> Run<T>(this Try<T> @try)
        {
            try { return @try(); }
            catch (Exception ex) { return ex.CreateExceptionError(); }
        }

        // TODO: Use these?

        //public static Try<R> Map<T, R>
        //    (this Try<T> @try, Func<T, R> f)
        //    => ()
        //        => @try.Run()
        //            .Match<Validate<R>>(
        //                ex => ex,
        //                t => f(t));

        //public static Try<Func<T2, R>> Map<T1, T2, R>
        //    (this Try<T1> @try, Func<T1, T2, R> func)
        //    => @try.Map(func.Curry());

        //public static Try<R> Bind<T, R>
        //    (this Try<T> @try, Func<T, Try<R>> f)
        //    => ()
        //        => @try.Run().Match(
        //            Exception: ex => ex,
        //            Success: t => f(t).Run());

        //// LINQ

        //public static Try<R> Select<T, R>(this Try<T> @this, Func<T, R> func) => @this.Map(func);

        //public static Try<RR> SelectMany<T, R, RR>
        //    (this Try<T> @try, Func<T, Try<R>> bind, Func<T, R, RR> project)
        //    => ()
        //        => @try.Run().Match(
        //            ex => ex,
        //            t => bind(t).Run()
        //                .Match<Validate<RR>>(
        //                    ex => ex,
        //                    r => project(t, r))
        //        );
    }
}