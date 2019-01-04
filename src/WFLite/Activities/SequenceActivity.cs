/*
 * SequenceActivity.cs
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
    public class SequenceActivity : Activity
    {
        private List<IActivity> _activities = new List<IActivity>();

        private IActivity _current;

        public IEnumerable<IActivity> Activities
        {
            private get;
            set;
        }

        protected override void initialize()
        {
        }

        protected override async Task start()
        {
            foreach (var activity in Activities)
            {
                _current = activity;
                _activities.Add(_current);

                var task = _current.Start();

                Status = Activities.GetStatus();

                await task;

                if (_current.Status.IsStopped())
                {
                    break;
                }
            }

            Status = _activities.GetStatus();
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
            foreach (var activity in _activities)
            {
                activity.Reset();
            }

            _activities.Clear();

            Status = Activities.GetStatus();
        }
    }
}
