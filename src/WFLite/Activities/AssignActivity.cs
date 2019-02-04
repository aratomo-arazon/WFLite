/*
 * AssignActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class AssignActivity : Activity
    {
        public IInVariable To
        {
            private get;
            set;
        }

        public IOutVariable Value
        {
            private get;
            set;
        }

        public IConverter Converter
        {
            private get;
            set;
        }

        public AssignActivity()
        {
        }

        public AssignActivity(IInVariable to, IOutVariable value, IConverter converter = null)
        {
            To = to;
            Value = value;
            Converter = converter;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            if (Converter == null)
            {
                To.SetValue(Value.GetValueAsObject());
            }
            else
            {
                To.SetValue(Converter.ConvertToObject(Value.GetValueAsObject()));
            }

            await Task.CompletedTask;

            Status = ActivityStatus.Completed;
        }

        protected sealed override void stop()
        {
            Status = ActivityStatus.Stopped;
        }

        protected sealed override void reset()
        {
            Status = ActivityStatus.Created;
        }
    }

    public class AssignActivity<TValue> : Activity
    {
        public IInVariable<TValue> To
        {
            private get;
            set;
        }

        public IOutVariable<TValue> Value
        {
            private get;
            set;
        }

        public IConverter<TValue> Converter
        {
            private get;
            set;
        }

        public AssignActivity()
        {
        }


        public AssignActivity(IInVariable<TValue> to, IOutVariable<TValue> value, IConverter<TValue> converter = null)
        {
            To = to;
            Value = value;
            Converter = converter;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            if (Converter == null)
            {
                To.SetValue(Value.GetValue());
            }
            else
            {
                To.SetValue(Converter.Convert(Value.GetValueAsObject()));
            }

            await Task.CompletedTask;

            Status = ActivityStatus.Completed;
        }

        protected sealed override void stop()
        {
            Status = ActivityStatus.Stopped;
        }

        protected sealed override void reset()
        {
            Status = ActivityStatus.Created;
        }
    }

    public class AssignActivity<TTo, TValue> : Activity
    {
        public IInVariable<TTo> To
        {
            private get;
            set;
        }

        public IOutVariable<TValue> Value
        {
            private get;
            set;
        }

        public IConverter<TValue, TTo> Converter
        {
            private get;
            set;
        }

        public AssignActivity()
        {
        }


        public AssignActivity(IInVariable<TTo> to, IOutVariable<TValue> value, IConverter<TValue, TTo> converter)
        {
            To = to;
            Value = value;
            Converter = converter;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            if (Converter == null)
            {
                To.SetValue(Value.GetValue());
            }
            else
            {
                To.SetValue(Converter.Convert(Value.GetValue()));
            }

            await Task.CompletedTask;

            Status = ActivityStatus.Completed;
        }

        protected sealed override void stop()
        {
            Status = ActivityStatus.Stopped;
        }

        protected sealed override void reset()
        {
            Status = ActivityStatus.Created;
        }
    }
}
