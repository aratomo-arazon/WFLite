/*
 * NullCondition.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class NullCondition : Condition
    {
        public IVariable Value
        {
            private get;
            set;
        }

        protected override bool check()
        {
            return Value.GetValue() == null;
        }
    }
}
