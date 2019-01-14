﻿/*
 * LessThanCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class LessThanCondition : Condition
    {
        public IVariable Value1
        {
            private get;
            set;
        }

        public IVariable Value2
        {
            private get;
            set;
        }

        protected sealed override bool check()
        {
            var value1 = Value1.GetValue() as IComparable;
            var value2 = Value2.GetValue() as IComparable;

            if (value1 == null || value2 == null)
            {
                return false;
            }

            return value1.CompareTo(value2) < 0;
        }
    }
}