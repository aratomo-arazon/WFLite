/*
 * ConsoleReadKeyActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.Console
{
    public class ConsoleReadKeyActivity : SyncActivity
    {
        public IVariable KeyInfo
        {
            private get;
            set;
        }

        public ConsoleReadKeyActivity()
        {
        }

        public ConsoleReadKeyActivity(IVariable keyInfo)
        {
            KeyInfo = keyInfo;
        }

        protected sealed override bool run()
        {
            var keyInfo = System.Console.ReadKey();

            if (KeyInfo != null)
            {
                KeyInfo.SetValue(keyInfo);
            }

            return true;
        }
    }
}
