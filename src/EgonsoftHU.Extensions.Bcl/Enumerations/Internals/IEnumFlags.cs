// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals
{
    internal interface IEnumFlags<TUnderlying>
        where TUnderlying : struct, IComparable<TUnderlying>
    {
        TUnderlying Construct(params TUnderlying[] values);

        TUnderlying[] Deconstruct(TUnderlying value);

        bool IsPowerOf2(TUnderlying value);
    }
}
