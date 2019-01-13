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
        public IVariable Value
        {
            private get;
            set;
        }

        protected sealed override bool run()
        {
            System.Console.WriteLine(Value.GetValue());

            return true;
        }
    }
}
