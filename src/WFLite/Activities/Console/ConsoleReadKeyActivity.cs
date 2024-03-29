﻿/*
 * ConsoleReadKeyActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities.Console
{
    public class ConsoleReadKeyActivity : SyncActivity
    {
        public IInVariable<ConsoleKeyInfo>? KeyInfo
        {
            private get;
            set;
        }

        public ConsoleReadKeyActivity()
        {
        }

        public ConsoleReadKeyActivity(IInVariable<ConsoleKeyInfo> keyInfo)
        {
            KeyInfo = keyInfo;
        }

        protected sealed override void initialize()
        {
            this.Require(KeyInfo, nameof(KeyInfo));
        }

        protected sealed override bool run()
        {
            var keyInfo = System.Console.ReadKey();

            KeyInfo!.SetValue(keyInfo);

            return true;
        }
    }
}
