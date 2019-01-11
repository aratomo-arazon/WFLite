/*
 * DelegateCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class DelegateCondition : Condition
    {
        public ICondition Condition
        {
            private get;
            set;
        }

        protected override bool check()
        {
            return Condition.Check();
        }
    }
}
