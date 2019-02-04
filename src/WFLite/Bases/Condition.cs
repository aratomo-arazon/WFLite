/*
 * Condition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Bases
{
    public abstract class Condition : ICondition
    {
        public bool Check()
        {
            return check();
        }

        protected abstract bool check();
    }
}
