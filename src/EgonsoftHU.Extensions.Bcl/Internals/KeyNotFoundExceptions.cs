// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Collections.Generic;

namespace EgonsoftHU.Extensions.Bcl.Internals
{
    internal static class KeyNotFoundExceptions
    {
        internal static KeyNotFoundException KeyNotFound<TKey>(TKey key)
            where TKey : notnull
        {
            var ex = new KeyNotFoundException();

            ex.Data[ExceptionDataKeys.Key] = key;
            ex.Data[ExceptionDataKeys.KeyType] = TypeHelper.GetTypeName<TKey>();

            return ex;
        }
    }
}
