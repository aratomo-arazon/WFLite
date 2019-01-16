/*
 * ParallelActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

 using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class ParallelActivity : Activity
    {
        private List<IActivity> _activities = new List<IActivity>();

        public IEnumerable<IActivity> Activities
        {
            private get;
            set;
        }

        public ParallelActivity()
        {
        }

        public ParallelActivity(IEnumerable<IActivity> activities)
        {
            Activities = activities;
        }

        public ParallelActivity(params IActivity[] activities)
        {
            Activities = activities;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            _activities.AddRange(Activities);

            var tasks = new List<Task>();

            Parallel.ForEach(_activities, a => tasks.Add(a.Start()));

            Status = _activities.GetStatus();

            await Task.WhenAll(tasks.ToArray());

            Status = _activities.GetStatus();
        }

        protected sealed override void stop()
        {
            if (_activities.Any())
            {
                foreach (var activity in _activities)
                {
                    activity.Stop();
                }

                Status = Activities.GetStatus();
            }
            else
            {
                Status = ActivityStatus.Stopped;
            }
        }

        protected override void reset()
        {
            foreach (var activity in _activities)
            {
                activity.Reset();
            }

            _activities.Clear();

            Status = Activities.GetStatus();
        }
    }
}
