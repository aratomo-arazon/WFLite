/*
 * FuncVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class FuncVariable : Variable
    {
        public Func<object> Func
        {
            private get;
            set;
        }

        public FuncVariable()
        {
        }

        public FuncVariable(Func<object> func, IConverter converter = null)
            : base(converter)
        {
            Func = func;
        }

        protected sealed override object getValue()
        {
            return Func?.Invoke();
        }

        protected sealed override void setValue(object value)
        {
            throw new NotSupportedException();
        }
    }
}
