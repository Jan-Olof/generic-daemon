using functional.common.errors;
using functional.common.helpers;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using static LanguageExt.Prelude;

namespace functional.common.valueObjects.validation
{
    public static class Validation
    {
        public struct Invalid
        {
            internal IEnumerable<Error> Errors;

            public Invalid(IEnumerable<Error> errors)
            {
                Errors = errors;
            }
        }

        public static T GetOrElse<T>(this Validation<T> opt, T defaultValue) =>
            opt.Match(
              (errs) => defaultValue,
              (t) => t);

        public static T GetOrElse<T>(this Validation<T> opt, Func<T> fallback) =>
            opt.Match(
              (errs) => fallback(),
              (t) => t);

        public static Validation<TR> Apply<T, TR>(this Validation<Func<T, TR>> valF, Validation<T> valT) =>
            valF.Match(
              Valid: (f) => valT.Match(
                 Valid: (t) => V.Valid(f(t)),
                 Invalid: (err) => V.Invalid(err)),
              Invalid: (errF) => valT.Match(
                 Valid: (_) => V.Invalid(errF),
                 Invalid: (errT) => V.Invalid(errF.Concat(errT))));

        public static Validation<Func<T2, TR>> Apply<T1, T2, TR>(this Validation<Func<T1, T2, TR>> @this, Validation<T1> arg) =>
            Apply(@this.Map(func => curry(func)), arg);

        public static Validation<Func<T2, T3, TR>> Apply<T1, T2, T3, TR>(this Validation<Func<T1, T2, T3, TR>> @this, Validation<T1> arg) =>
            Apply(@this.Map(func => CurryFirst(func)), arg);

        public static Validation<TRr> Map<TR, TRr>(this Validation<TR> @this, Func<TR, TRr> f) =>
            @this.IsValid
              ? V.Valid(f(@this.Value))
              : V.Invalid(@this.Errors);

        public static Validation<Func<T2, TR>> Map<T1, T2, TR>(this Validation<T1> @this, Func<T1, T2, TR> func) =>
            @this.Map(curry(func));

        public static Validation<Unit> ForEach<T>(this Validation<T> @this, Action<T> act) =>
            Map(@this, act.ToFunc());

        public static Validation<T> Do<T>(this Validation<T> @this, Action<T> action)
        {
            @this.ForEach(action);
            return @this;
        }

        public static Validation<TR> Bind<T, TR>(this Validation<T> val, Func<T, Validation<TR>> f) =>
            val.Match(
               Invalid: (err) => V.Invalid(err),
               Valid: (r) => f(r));

        // LINQ

        public static Validation<TR> Select<T, TR>(this Validation<T> @this, Func<T, TR> map) =>
            @this.Map(map);

        public static Validation<TRr> SelectMany<T, TR, TRr>(this Validation<T> @this, Func<T, Validation<TR>> bind, Func<T, TR, TRr> project) =>
            @this.Match(
              Invalid: (err) => V.Invalid(err),
              Valid: (t) => bind(t).Match(
                 Invalid: (err) => V.Invalid(err),
                 Valid: (r) => V.Valid(project(t, r))));

        /// <summary>
        /// Get all errors.
        /// </summary>
        public static IEnumerable<Error> GetErrors<T>(this Validation<T> validation) =>
            validation.Match(e => e, t => new List<Error>());

        /// <summary>
        /// Get the valid object, or throw InvalidOperationException. (So, this can only be used when we know that the object is valid.)
        /// </summary>
        public static T GetObject<T>(this Validation<T> validation) =>
            validation.Match(
                e => throw new InvalidOperationException("The object is invalid."),
                t => t);

        private static Func<T1, Func<T2, T3, TR>> CurryFirst<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> @this) =>
            t1 => (t2, t3) => @this(t1, t2, t3);
    }
}