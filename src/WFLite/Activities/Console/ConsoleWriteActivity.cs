/*
 * ConsoleWriteActivity.cs
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
    public class ConsoleWriteActivity : SyncActivity
    {
        public IOutVariable? Value
        {
            private get;
            set;
        }

        public ConsoleWriteActivity()
        {
        }

        public ConsoleWriteActivity(IOutVariable value)
        {
            Value = value;
        }

        protected sealed override void initialize()
        {
            this.Require(Value, nameof(Value));
        }

        protected sealed override bool run()
        {
            System.Console.Write(Value!.GetValueAsObject());

            return true;
        }
    }
}
