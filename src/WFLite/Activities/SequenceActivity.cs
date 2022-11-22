/*
 * SequenceActivity.cs
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
    public class SequenceActivity : Activity
    {
        private List<IActivity> _activities = new List<IActivity>();

        private IActivity? _current;

        private IEnumerator<IActivity>? _enumerator;

        public IEnumerable<IActivity>? Activities
        {
            private get;
            set;
        }

        public SequenceActivity()
        {
        }

        public SequenceActivity(IEnumerable<IActivity> activities)
        {
            Activities = activities;
        }

        public SequenceActivity(params IActivity[] activities)
        {
            Activities = activities;
        }

        protected sealed override void initialize()
        {
            this.Require(Activities, nameof(Activities));
        }

        protected sealed override async Task start()
        {
            if (_current == null)
            {
                _enumerator = Activities!.GetEnumerator();

                if (!_enumerator.MoveNext())
                {
                    Status = ActivityStatus.Completed;

                    return;
                }

                _current = _enumerator.Current;

                _activities!.Add(_current);

                var task = _current.Start();

                Status = _activities.GetStatus();

                await task;

                if (_current.Status.IsStopped())
                {
                    Status = ActivityStatus.Stopped;
                }
                else
                {
                    Status = _activities.GetStatus();
                }

                if (Status.IsStopped() || Status.IsSuspended())
                {
                    return;
                }
            }
            else
            {
                var task = _current.Start();

                Status = _activities!.GetStatus();

                await task;

                if (_current.Status.IsStopped())
                {
                    Status = ActivityStatus.Stopped;
                }
                else
                {
                    Status = _activities!.GetStatus();
                }

                if (Status.IsStopped() || Status.IsSuspended())
                {
                    return;
                }
            }

            while (_enumerator!.MoveNext())
            {
                _current = _enumerator.Current;

                _activities!.Add(_current);

                var task = _current.Start();

                Status = _activities.GetStatus();

                await task;

                if (_current.Status.IsStopped())
                {
                    Status = ActivityStatus.Stopped;
                }
                else
                {
                    Status = _activities.GetStatus();
                }

                if (Status.IsStopped() || Status.IsSuspended())
                {
                    return;
                }
            }

            Status = _activities!.GetStatus();
        }

        protected sealed override void stop()
        {
            if (_current != null)
            {
                _current.Stop();

                Status = _activities!.GetStatus();
            }
            else
            {
                Status = ActivityStatus.Stopped;
            }
        }

        protected sealed override void reset()
        {
            foreach (var activity in _activities!)
            {
                activity.Reset();
            }

            _activities.Clear();

            Status = ActivityStatus.Created;
        }
    }
}
