/*
 * AndCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections.Generic;
using System.Linq;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class AndCondition : Condition
    {
        public IEnumerable<ICondition>? Conditions
        {
            private get;
            set;
        }

        public AndCondition()
        {
        }

        public AndCondition(IEnumerable<ICondition> conditions)
        {
            Conditions = conditions;
        }

        public AndCondition(params ICondition[] conditions)
        {
            Conditions = conditions;
        }

        protected sealed override void initialize()
        {
            this.Require(Conditions, nameof(Conditions));
        }

        protected sealed override bool check()
        {
            return Conditions!.All(c => c.Check());
        }
    }
}
