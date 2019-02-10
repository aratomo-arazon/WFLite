/*
 * FuncAsyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Threading;
using System.Threading.Tasks;

namespace WFLite.Activities
{
    public class FuncAsyncActivity : AsyncActivity
    {
        public Func<CancellationToken, Task<bool>> Func
        {
            private get;
            set;
        }

        public FuncAsyncActivity()
        {
        }

        public FuncAsyncActivity(Func<CancellationToken, Task<bool>> func)
        {
            Func = func;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            return await Func(cancellationToken);
        }
    }
}
