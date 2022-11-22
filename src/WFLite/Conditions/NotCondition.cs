/*
 * NotCondition.cs
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
    public class NotCondition : Condition
    {
        public ICondition? Condition
        {
            private get;
            set;
        }

        public NotCondition()
        {
        }

        public NotCondition(ICondition condition)
        {
            Condition = condition;
        }

        protected sealed override void initialize()
        {
            this.Require(Condition, nameof(Condition));
        }

        protected sealed override bool check()
        {
            return !Condition!.Check();
        }
    }
}
