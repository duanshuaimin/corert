// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using global::System;
using global::System.Collections.Generic;
using global::Internal.Metadata.NativeFormat;

using global::Internal.Reflection.Core.NonPortable;

namespace Internal.Reflection.Core.Execution
{
    //
    // This class abstracts the underlying Redhawk (or whatever execution engine) runtime that sets and gets fields.
    //
    public abstract class FieldAccessor
    {
        protected FieldAccessor() { }
        public abstract Object GetField(Object obj);
        public abstract void SetField(Object obj, Object value);
    }
}
