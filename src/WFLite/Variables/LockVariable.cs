/*
 * LockVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Threading;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class LockVariable : Variable
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public LockVariable()
        {
        }

        public LockVariable(IConverter converter = null)
            : base(converter)
        {
        }

        protected sealed override object getValue()
        {
            return _semaphoreSlim;
        }

        protected sealed override void setValue(object value)
        {
            throw new NotSupportedException();
        }
    }
}
