/*
 * ForEachActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Extensions;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Activities
{
    public class ForEachActivity : Activity
    {
        private IActivity _current;

        public IVariable Collection
        {
            private get;
            set;
        }

        public IVariable Key
        {
            private get;
            set;
        }

        public IVariable Value
        {
            private get;
            set;
        }

        public IActivity Activity
        {
            private get;
            set;
        }

        protected override void initialize()
        {
            if (Key == null)
            {
                Key = new NullVariable();
            }
        }

        protected override async Task start()
        {
            var values = Collection.GetValue();

            if (values is IList<object>)
            {
                Status = await start(values as IList<object>, value => Value.SetValue(value));
            }
            else if (values is IDictionary<string, object>)
            {
                Status = await start(values as IDictionary<string, object>, pair =>
                {
                    Key.SetValue(pair.Key);
                    Value.SetValue(pair.Value);
                });
            }
            else
            {
                Status = ActivityStatus.Stopped;
            }
        }

        protected override void stop()
        {
            if (_current != null)
            {
                _current.Stop();

                Status = _current.Status;
            }
            else
            {
                Status = ActivityStatus.Stopped;
            }
        }

        protected override void reset()
        {
            if (_current != null)
            {
                _current.Reset();
                _current = null;
            }

            Status = Activity.Status;
        }

        private async Task<ActivityStatus> start<TItem>(IEnumerable<TItem> values, Action<TItem> setAction)
        {
            if (!values.Any())
            {
                return ActivityStatus.Completed;
            }

            _current = Activity;

            foreach (var value in values)
            {
                setAction(value);

                _current.Reset();

                var task = Activity.Start();

                Status = _current.Status;

                await task;

                if (_current.Status.IsStopped())
                {
                    break;
                }
            }

            return _current.Status;
        }
    }
}
