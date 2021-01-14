using Functional.Common.DataTypes.Validate;
using System;

namespace Functional.Common.DataTypes.Try
{
    public delegate Validate<T> Try<T>();

    public static class Tr
    {
        public static Try<T> Try<T>(Func<T> f) => () => f();
    }
}