using functional.common.errors;
using functional.common.helpers;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using static LanguageExt.Prelude;

namespace functional.common.valueObjects.validate
{
    public static class Validate
    {
        public static Validate<TR> Apply<T, TR>(this Validate<Func<T, TR>> valF, Validate<T> valT) =>
            valF.Match(
              Valid: (f) => valT.Match(
                 Valid: (t) => V.Valid(f(t)),
                 Invalid: (err) => V.Invalid(err)),
              Invalid: (errF) => valT.Match(
                 Valid: (_) => V.Invalid(errF),
                 Invalid: (errT) => V.Invalid(errF.Concat(errT))));

        public static Validate<Func<T2, TR>> Apply<T1, T2, TR>(this Validate<Func<T1, T2, TR>> @this, Validate<T1> arg) =>
            Apply(@this.Map(func => curry(func)), arg);

        public static Validate<Func<T2, T3, TR>> Apply<T1, T2, T3, TR>(this Validate<Func<T1, T2, T3, TR>> @this, Validate<T1> arg) =>
            Apply(@this.Map(func => CurryFirst(func)), arg);

        public static Validate<TR> Bind<T, TR>(this Validate<T> val, Func<T, Validate<TR>> f) =>
            val.Match(
               Invalid: (err) => V.Invalid(err),
               Valid: (r) => f(r));

        public static Validate<T> Do<T>(this Validate<T> @this, Action<T> action)
        {
            @this.ForEach(action);
            return @this;
        }

        public static Validate<Unit> ForEach<T>(this Validate<T> @this, Action<T> act) =>
            Map(@this, act.ToFunc());

        /// <summary>
        /// Get all errors.
        /// </summary>
        public static IEnumerable<Error> GetErrors<T>(this Validate<T> validate) =>
            validate.Match(e => e, t => new List<Error>());

        public static T GetOrElse<T>(this Validate<T> opt, T defaultValue) =>
            opt.Match(
              (errs) => defaultValue,
              (t) => t);

        public static T GetOrElse<T>(this Validate<T> opt, Func<T> fallback) =>
            opt.Match(
              (errs) => fallback(),
              (t) => t);

        /// <summary>
        /// Get the valid object, or throw InvalidOperationException. (So, this can only be used when we know that the object is valid.)
        /// </summary>
        public static T GetOrException<T>(this Validate<T> validate) =>
            validate.Match(
                e => throw new InvalidOperationException("The object is invalid."),
                t => t);

        public static Validate<TRr> Map<TR, TRr>(this Validate<TR> @this, Func<TR, TRr> f) =>
            @this.IsValid
              ? V.Valid(f(@this.Value))
              : V.Invalid(@this.Errors);

        public static Validate<Func<T2, TR>> Map<T1, T2, TR>(this Validate<T1> @this, Func<T1, T2, TR> func) =>
            @this.Map(curry(func));

        public static Validate<TR> Select<T, TR>(this Validate<T> @this, Func<T, TR> map) =>
            @this.Map(map);

        // LINQ
        public static Validate<TRr> SelectMany<T, TR, TRr>(this Validate<T> @this, Func<T, Validate<TR>> bind, Func<T, TR, TRr> project) =>
            @this.Match(
              Invalid: (err) => V.Invalid(err),
              Valid: (t) => bind(t).Match(
                 Invalid: (err) => V.Invalid(err),
                 Valid: (r) => V.Valid(project(t, r))));

        private static Func<T1, Func<T2, T3, TR>> CurryFirst<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> @this) =>
            t1 => (t2, t3) => @this(t1, t2, t3);

        public struct Invalid
        {
            internal IEnumerable<Error> Errors;

            public Invalid(IEnumerable<Error> errors)
            {
                Errors = errors;
            }
        }
    }
}