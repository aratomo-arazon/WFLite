﻿/*
 * DirectoryExistsCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.IO;
using System.Threading;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Conditions.IO
{
    public class DirectoryExistsCondition : Condition
    {
        public IOutVariable<string>? Path
        {
            private get;
            set;
        }

        public DirectoryExistsCondition()
        {
        }

        public DirectoryExistsCondition(IOutVariable<string> path)
        {
            Path = path;
        }

        protected sealed override void initialize()
        {
            this.Require(Path, nameof(Path));
        }

        protected sealed override bool check()
        {
            var path = Path!.GetValue();

            return Directory.Exists(path);
        }
    }
}
