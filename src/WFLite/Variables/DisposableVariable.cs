/*
 * DisposableVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class DisposableVariable : NewVariable<IDisposable>
    {
        public DisposableVariable()
        {
        }

        public DisposableVariable(Func<IDisposable> func, IConverter converter = null)
            : base(func, converter)
        {
        }
    }
}
