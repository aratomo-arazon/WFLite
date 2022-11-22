/*
 * AssignActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class AssignActivity : SyncActivity
    {
        public IInVariable? To
        {
            private get;
            set;
        }

        public IOutVariable? Value
        {
            private get;
            set;
        }

        public IConverter? Converter
        {
            private get;
            set;
        }

        public AssignActivity()
        {
        }

        public AssignActivity(IInVariable to, IOutVariable value, IConverter? converter = null)
        {
            To = to;
            Value = value;
            Converter = converter;
        }

        protected sealed override void initialize()
        {
            this.Require(To, nameof(To));
            this.Require(Value, nameof(Value));
        }

        protected sealed override bool run()
        {
            if (Converter == null)
            {
                To!.SetValue(Value!.GetValueAsObject());
            }
            else
            {
                To!.SetValue(Converter.ConvertToObject(Value!.GetValueAsObject()));
            }

            return true;
        }
    }

    public class AssignActivity<TValue> : SyncActivity
    {
        public IInVariable<TValue>? To
        {
            private get;
            set;
        }

        public IOutVariable<TValue>? Value
        {
            private get;
            set;
        }

        public IConverter<TValue>? Converter
        {
            private get;
            set;
        }

        public AssignActivity()
        {
        }


        public AssignActivity(IInVariable<TValue> to, IOutVariable<TValue> value, IConverter<TValue>? converter = null)
        {
            To = to;
            Value = value;
            Converter = converter;
        }

        protected sealed override void initialize()
        {
            this.Require(To, nameof(To));
            this.Require(Value, nameof(Value));
        }

        protected sealed override bool run()
        {
            if (Converter == null)
            {
                To!.SetValue(Value!.GetValue());
            }
            else
            {
                To!.SetValue(Converter.Convert(Value!.GetValueAsObject()));
            }

            return true;
        }
    }

    public class AssignActivity<TTo, TValue> : SyncActivity
    {
        public IInVariable<TTo>? To
        {
            private get;
            set;
        }

        public IOutVariable<TValue>? Value
        {
            private get;
            set;
        }

        public IConverter<TValue, TTo>? Converter
        {
            private get;
            set;
        }

        public AssignActivity()
        {
        }


        public AssignActivity(IInVariable<TTo> to, IOutVariable<TValue> value, IConverter<TValue, TTo>? converter = null)
        {
            To = to;
            Value = value;
            Converter = converter;
        }

        protected sealed override void initialize()
        {
            this.Require(To, nameof(To));
            this.Require(Value, nameof(Value));
        }

        protected sealed override bool run()
        {
            if (Converter == null)
            {
                To!.SetValue(Value!.GetValue());
            }
            else
            {
                To!.SetValue(Converter.Convert(Value!.GetValue()));
            }

            return true;
        }
    }
}
