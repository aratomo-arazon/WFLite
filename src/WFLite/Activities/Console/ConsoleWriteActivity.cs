/*
 * ConsoleWriteActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
using WFLite.Interfaces;

namespace WFLite.Activities.Console
{
    public class ConsoleWriteActivity : SyncActivity
    {
        public IVariable Value
        {
            private get;
            set;
        }

        public ConsoleWriteActivity()
        {
        }

        public ConsoleWriteActivity(IVariable value)
        {
            Value = value;
        }

        protected sealed override bool run()
        {
            System.Console.Write(Value.GetValue());

            return true;
        }
    }
}
