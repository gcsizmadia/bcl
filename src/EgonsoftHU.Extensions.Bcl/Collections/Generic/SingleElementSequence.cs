// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Collections;
using System.Collections.Generic;

namespace EgonsoftHU.Extensions.Bcl.Collections.Generic
{
    internal struct SingleElementSequence<T> : IEnumerable<T>
    {
        private readonly T value;

        internal SingleElementSequence(T value)
        {
            this.value = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SingleElementEnumerator(ref this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SingleElementEnumerator(ref this);
        }

        private struct SingleElementEnumerator : IEnumerator<T>
        {
            private readonly SingleElementSequence<T> parent;

            private bool canMoveNext;

            internal SingleElementEnumerator(ref SingleElementSequence<T> parent)
            {
                this.parent = parent;
                canMoveNext = true;
            }

            public readonly T Current => parent.value;

            readonly object? IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (!canMoveNext)
                {
                    return false;
                }

                canMoveNext = false;
                return true;
            }

            public void Reset()
            {
                canMoveNext = true;
            }

            public readonly void Dispose()
            {
            }
        }
    }
}
