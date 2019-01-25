/*
 * NewVariable.cs
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
    public class NewVariable : Variable
    {
        public Func<object> Func
        {
            protected get;
            set;
        }

        public NewVariable()
        {
        }

        public NewVariable(Func<object> func, IConverter converter = null)
            : base(converter)
        {
            Func = func;
        }

        protected sealed override object getValue()
        {
            return Func();
        }

        protected sealed override void setValue(object value)
        {
            throw new NotSupportedException();
        }
    }

    public class NewVariable<TValue> : NewVariable
    {
        public new Func<TValue> Func
        {
            private get
            {
                return () => (TValue)base.Func();
            }
            set
            {
                base.Func = () => value();
            }
        }

        public NewVariable()
        {
        }

        public NewVariable(Func<TValue> func, IConverter converter = null)
            : base(() => func(), converter)
        {
        }
    }
}
