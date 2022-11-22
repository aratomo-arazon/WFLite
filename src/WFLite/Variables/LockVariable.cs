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

namespace WFLite.Variables
{
    public class LockVariable : OutVariable<SemaphoreSlim>
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        protected sealed override void initialize()
        {
        }

        protected sealed override object getValue()
        {
            return _semaphoreSlim;
        }
    }
}
