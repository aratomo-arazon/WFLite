/*
 * Activity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Threading.Tasks;
using WFLite.Enums;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Bases
{
    public abstract class Activity : IActivity
    {
        private bool _initialized;

        public ActivityStatus Status
        {
            get;
            protected set;
        } = ActivityStatus.Created;

        public async Task Start()
        {
            if (!Status.IsCreated())
            {
                return;
            }

            try
            {
                await invokeAsync(start);
            }
            catch
            {
                Status = ActivityStatus.Stopped;
            }
        }

        public void Stop()
        {
            if (Status.IsFinished())
            {
                return;
            }

            try
            {
                invoke(stop);
            }
            catch
            {
                Status = ActivityStatus.Stopped;
            }
        }

        public void Reset()
        {
            if (!Status.IsFinished())
            {
                return;
            }

            try
            {
                invoke(reset);
            }
            catch
            {
                Status = ActivityStatus.Created;
            }
        }

        private async Task invokeAsync(Func<Task> func)
        {
            if (!_initialized)
            {
                initialize();

                _initialized = true;
            }

            await func();
        }

        private void invoke(Action action)
        {
            if (!_initialized)
            {
                initialize();

                _initialized = true;
            }

            action();
        }

        protected abstract void initialize();

        protected abstract Task start();

        protected abstract void stop();

        protected abstract void reset();
    }
}
