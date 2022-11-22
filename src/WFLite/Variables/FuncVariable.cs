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
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class FuncVariable : OutVariable
    {
        public Func<object>? Func
        {
            private get;
            set;
        }

        public FuncVariable()
        {
        }

        public FuncVariable(Func<object> func, IConverter? converter = null)
            : base(converter)
        {
            Func = func;
        }

        protected sealed override void initialize()
        {
            this.Require(Func, nameof(Func));
        }

        protected sealed override object getValue()
        {
            return Func!.Invoke();
        }
    }

    public class FuncVariable<TValue> : OutVariable<TValue>
    {
        private Func<object?>? _func;

        public Func<TValue?>? Func
        {
            get
            {
                return new Func<TValue?>(() => (TValue?)_func!());
            }
            set
            {
                _func = () => value!();
            }
        }

        public FuncVariable()
        {
        }

        public FuncVariable(Func<TValue?> func, IConverter<TValue>? converter = null)
            : base(converter)
        {
            Func = func;
        }

        public FuncVariable(Func<object?> func, IConverter<TValue> converter)
        {
            _func = func;
        }

        protected sealed override void initialize()
        {
            this.Require(Func, nameof(Func));
        }

        protected sealed override object? getValue()
        {
            return _func!();
        }
    }
}
