using Functional.Common.DataTypes.Validate;
using Functional.Common.Errors;
using LanguageExt;
using System;
using static Functional.F;
using static LanguageExt.Prelude;

namespace Functional.Common.Helpers
{
    public static class GuidExt
    {
        /// <summary>
        /// Create and validate a Guid.
        /// </summary>
        public static Validate<Guid> CreateAndValidate(this Guid guid, Origin origin) =>
            IsValid(guid)
                ? Valid(guid)
                : Invalid(guid.ToString().CreateGuidInvalidError(origin));

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