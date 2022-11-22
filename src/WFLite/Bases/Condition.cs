/*
 * Condition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Data;
using WFLite.Interfaces;

namespace WFLite.Bases
{
    public abstract class Condition : ICondition
    {
        public bool Check()
        {
            initialize();
            return check();
        }

        protected virtual void initialize()
        {
        }

        protected abstract bool check();
    }
}
