/*
 * ConsoleReadLineActivity.cs
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
    public class ConsoleReadLineActivity : SyncActivity
    {
        public IInVariable<string>? Value
        {
            private get;
            set;
        }

        public ConsoleReadLineActivity()
        {
        }

        public ConsoleReadLineActivity(IInVariable<string> value)
        {
            Value = value;
        }

        protected sealed override void initialize()
        {
            this.Require(Value, nameof(Value));
        }

        protected sealed override bool run()
        {
            var value = System.Console.ReadLine();

            Value!.SetValue(value);

            return true;
        }
    }
}
