/*
 * OrCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class OrCondition : Condition
    {
        public IEnumerable<ICondition>? Conditions
        {
            private get;
            set;
        }

        public OrCondition()
        {
        }

        public OrCondition(IEnumerable<ICondition> conditions)
        {
            Conditions = conditions;
        }

        public OrCondition(params ICondition[] conditions)
        {
            Conditions = conditions;
        }

        protected sealed override void initialize()
        {
            this.Require(Conditions, nameof(Conditions));
        }

        protected sealed override bool check()
        {
            return Conditions!.Any(c => c.Check());
        }
    }
}
