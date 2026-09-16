// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    internal partial class EnumInfo<TEnum, TUnderlying> : IEnumerable<EnumInfo<TEnum, TUnderlying>>
    {
        IEnumerator<EnumInfo<TEnum, TUnderlying>> IEnumerable<EnumInfo<TEnum, TUnderlying>>.GetEnumerator()
        {
            return
                HasFlagsAttribute && flags.Count > 0
                    ? new Enumerator(flags)
                    : new Enumerator(this.AsSingleElementSequence().ToList().AsReadOnly());
        }

        private sealed class Enumerator : IEnumerator<EnumInfo<TEnum, TUnderlying>>, IEnumerator
        {
            private readonly ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> flags;

            private int index = -1;

            private bool isDisposed;

            internal Enumerator(ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> flags)
            {
                this.flags = flags;
            }

            public EnumInfo<TEnum, TUnderlying> Current => flags[index];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                return ++index < flags.Count;
            }

            public void Reset()
            {
                index = -1;
            }

            private void Dispose(bool isDisposing)
            {
                if (!isDisposed)
                {
                    if (isDisposing)
                    {
                    }

                    isDisposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(isDisposing: true);
                System.GC.SuppressFinalize(this);
            }
        }
    }
}
