/*
 * ConsoleReadActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities.Console
{
    public class ConsoleReadActivity : SyncActivity
    {
        public IInVariable<int>? Value
        {
            private get;
            set;
        }

        public ConsoleReadActivity()
        {
        }

        public ConsoleReadActivity(IInVariable<int> value)
        {
            Value = value;
        }

        protected sealed override void initialize()
        {
            this.Require(Value, nameof(Value));
        }

        protected sealed override bool run()
        {
            var value = System.Console.Read();

            Value!.SetValue(value);

            return true;
        }
    }
}
