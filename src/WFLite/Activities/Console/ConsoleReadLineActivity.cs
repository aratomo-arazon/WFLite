/*
 * ConsoleReadLineActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.Console
{
    public class ConsoleReadLineActivity : SyncActivity
    {
        public IInVariable<string> Value
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

        protected sealed override bool run()
        {
            var value = System.Console.ReadLine();

            if (Value != null)
            {
                Value.SetValue(value);
            }

            return true;
        }
    }
}
