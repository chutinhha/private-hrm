﻿#region License
// Copyright © 2013 Łukasz Świątkowski
// http://www.lukesw.net/
//
// This library is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library.  If not, see <http://www.gnu.org/licenses/>.
#endregion

namespace Luminous.ExpressionParser
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("{Name}({ParametersCount})")]
    public abstract class StatementBase : IStatement
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public decimal Invoke(params decimal[] parameters)
        {
            throw new NotImplementedException();
        }
        public abstract decimal Invoke(params IEvaluableElement[] parameters);
        public virtual int ParametersCount { get { return 1; } }
        public abstract string Name { get; }
    }
}