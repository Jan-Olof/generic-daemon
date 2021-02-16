// ReSharper disable CheckNamespace

using Functional.Common.DataTypes.Validate;
using System;

namespace Functional
{
    public delegate Validate<T> Try<T>();

    public static partial class F
    {
        public static Try<T> Try<T>(Func<T> f) => () => f();
    }
}