// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.CompilerServices;

namespace Internal.TypeSystem
{
    /// <summary>
    /// Represents a generic instantiation - a collection of generic parameters
    /// or arguments of a generic type or a generic method.
    /// </summary>
    public struct Instantiation
    {
        private TypeDesc[] _genericParameters;

        public Instantiation(params TypeDesc[] genericParameters)
        {
            _genericParameters = genericParameters;
        }

        [IndexerName("GenericParameters")]
        public TypeDesc this[int index]
        {
            get
            {
                return _genericParameters[index];
            }
        }

        public int Length
        {
            get
            {
                return _genericParameters.Length;
            }
        }

        public bool IsNull
        {
            get
            {
                return _genericParameters == null;
            }
        }

        /// <summary>
        /// Combines the given generic definition's hash code with the hashes
        /// of the generic parameters in this instantiation
        /// </summary>
        public int ComputeGenericInstanceHashCode(int genericDefinitionHashCode)
        {
            return NativeFormat.TypeHashingAlgorithms.ComputeGenericInstanceHashCode(genericDefinitionHashCode, _genericParameters);
        }

        public static readonly Instantiation Empty = new Instantiation(TypeDesc.EmptyTypes);

        public Enumerator GetEnumerator()
        {
            return new Enumerator(_genericParameters);
        }

        /// <summary>
        /// Enumerator for iterating over the types in an instantiation
        /// </summary>
        public struct Enumerator
        {
            private TypeDesc[] _collection;
            private int _currentIndex;

            public Enumerator(TypeDesc[] collection)
            {
                _collection = collection;
                _currentIndex = -1;
            }

            public TypeDesc Current
            {
                get
                {
                    return _collection[_currentIndex];
                }
            }

            public bool MoveNext()
            {
                _currentIndex++;
                if (_currentIndex >= _collection.Length)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
