/*
 * DisposableVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;

namespace WFLite.Variables
{
    public class DisposableVariable : FuncVariable<IDisposable>
    {
        public DisposableVariable()
        {
        }

        public DisposableVariable(Func<IDisposable> func)
            : base(func)
        {
        }
    }
}
