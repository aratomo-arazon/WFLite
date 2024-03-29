﻿/*
 * NullCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class NullCondition : Condition
    {
        public IOutVariable? Value
        {
            private get;
            set;
        }

        public NullCondition()
        {
        }

        public NullCondition(IOutVariable value)
        {
            Value = value;
        }

        protected sealed override void initialize()
        {
            this.Require(Value, nameof(Value));
        }

        protected sealed override bool check()
        {
            return Value!.GetValueAsObject() == null;
        }
    }
}
