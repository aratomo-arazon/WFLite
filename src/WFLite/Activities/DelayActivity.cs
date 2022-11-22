/*
 * DelayActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class DelayActivity : AsyncActivity
    {
        public IOutVariable<int>? Duration
        {
            private get;
            set;
        }

        public DelayActivity()
        {
        }

        public DelayActivity(IOutVariable<int> duration)
        {
            Duration = duration;
        }

        protected sealed override void initialize()
        {
            this.Require(Duration, nameof(Duration));
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var duration = Duration!.GetValue();

            await Task.Delay(duration, cancellationToken);

            return true;
        }
    }
}
