/*
 * TryCatchActivity.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

 using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class TryCatchActivity : Activity
    {
        private IList<IActivity> _activities = new List<IActivity>();

        private IActivity _current;

        public IActivity Try
        {
            private get;
            set;
        }

        public IActivity Catch
        {
            private get;
            set;
        }

        public IActivity Finally
        {
            private get;
            set;
        }

        protected override void initialize()
        {
            if (Catch == null)
            {
                Catch = new NullActivity();
            }

            if (Finally == null)
            {
                Finally = new NullActivity();
            }
        }

        protected override async Task start()
        {
            _activities.Add(Try);
            _activities.Add(Finally);

            await start(Try);

            if (Try.Status.IsStopped())
            {
                _activities.Remove(Try);
                _activities.Add(Catch);

                await start(Catch);
            }

            await start(Finally);
        }

        protected override void stop()
        {
            if (_current != null)
            {
                _current.Stop();

                Status = _activities.GetStatus();
            }
            else
            {
                Status = ActivityStatus.Stopped;
            }
        }

        protected override void reset()
        {
            if (!_activities.Contains(Try))
            {
                _activities.Add(Try);
            }

            foreach (var activity in _activities)
            {
                activity.Reset();
            }

            Status = _activities.GetStatus();

            _activities.Clear();
        }

        private async Task start(IActivity activity)
        {
            if (activity.Status.IsFinished())
            {
                return;
            }

            _current = activity;

            var task = _current.Start();
            
            Status = _current.Status;

            await task;

            Status = _activities.GetStatus();
        }
    }
}
