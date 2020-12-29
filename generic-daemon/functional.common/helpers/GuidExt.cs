using functional.common.errors;
using functional.common.valueObjects.validate;
using LanguageExt;
using System;
using static functional.common.valueObjects.validate.V;
using static LanguageExt.Prelude;

namespace functional.common.helpers
{
    public static class GuidExt
    {
        /// <summary>
        /// Create and validate a Guid.
        /// </summary>
        public static Validate<Guid> CreateAndValidate(this Guid guid, Origin origin) =>
            IsValid(guid)
                ? Valid(guid)
                : Invalid(ErrorFactory.GuidInvalid(guid.ToString(), origin));

        public static bool IsEmpty(this Guid guid) =>
            guid.Equals(Guid.Empty);

        public static Validate<Unit> IsEqual(this Guid guid, Guid guid2, Error error) =>
            guid.Equals(guid2) ? Valid(unit) : Invalid(error);

        public static Validate<Unit> IsEqual(this Guid? guid, Guid guid2, Error error) =>
            guid.Equals(guid2) ? Valid(unit) : Invalid(error);

        public static Validate<Unit> IsNotEqual(this Guid guid, Guid guid2, Error error) =>
            guid.Equals(guid2) ? Invalid(error) : Valid(unit);

        public static Validate<Unit> IsNotEqual(this Guid? guid, Guid guid2, Error error) =>
            guid.Equals(guid2) ? Invalid(error) : Valid(unit);

        public static Guid ToGuid(this Guid? guid) =>
            guid ?? Guid.Empty;

        public static Guid ToGuid(this Option<Guid> guid) =>
            guid.Match(g => g, () => Guid.Empty);

        public static Option<Guid> ToOption(this Guid guid) =>
            guid.IsEmpty() ? None : Some(guid);

        private static bool IsValid(this Guid guid) =>
            !guid.IsEmpty();
    }
}