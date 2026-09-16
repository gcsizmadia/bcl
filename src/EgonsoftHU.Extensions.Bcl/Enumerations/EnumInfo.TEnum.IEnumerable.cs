// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections;
using System.Collections.Generic;

using EgonsoftHU.Extensions.Bcl.Exceptions;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    public partial class EnumInfo<TEnum> : IEnumerable<EnumInfo<TEnum>>, IEnumerable
    {
        /// <inheritdoc/>
        public IEnumerator<EnumInfo<TEnum>> GetEnumerator()
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => ((IEnumerable<EnumInfo<TEnum, sbyte>>)this).GetEnumerator(),
                TypeCode.Int16 => ((IEnumerable<EnumInfo<TEnum, short>>)this).GetEnumerator(),
                TypeCode.Int32 => ((IEnumerable<EnumInfo<TEnum, int>>)this).GetEnumerator(),
                TypeCode.Int64 => ((IEnumerable<EnumInfo<TEnum, long>>)this).GetEnumerator(),
                TypeCode.Byte => ((IEnumerable<EnumInfo<TEnum, byte>>)this).GetEnumerator(),
                TypeCode.UInt16 => ((IEnumerable<EnumInfo<TEnum, ushort>>)this).GetEnumerator(),
                TypeCode.UInt32 => ((IEnumerable<EnumInfo<TEnum, uint>>)this).GetEnumerator(),
                TypeCode.UInt64 => ((IEnumerable<EnumInfo<TEnum, ulong>>)this).GetEnumerator(),
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<EnumInfo<TEnum>>)this).GetEnumerator();
        }
    }
}
