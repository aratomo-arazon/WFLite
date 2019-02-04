/*
 * ConsoleWriteLineActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.Console
{
    public class ConsoleWriteLineActivity : SyncActivity
    {
        public IOutVariable Value
        {
            private get;
            set;
        }

        public ConsoleWriteLineActivity()
        {
        }

        public ConsoleWriteLineActivity(IOutVariable value)
        {
            Value = value;
        }

        protected sealed override bool run()
        {
            System.Console.WriteLine(Value.GetValueAsObject());

            return true;
        }
    }
}
