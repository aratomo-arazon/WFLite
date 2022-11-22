/*
 * PathCombineVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections.Generic;
using System.IO;
using System.Linq;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Variables.IO
{
    public class PathCombineVariable : OutVariable<string>
    {
        public IEnumerable<IOutVariable<string>>? Paths
        {
            private get;
            set;
        }

        public PathCombineVariable()
        {
        }

        public PathCombineVariable(IEnumerable<IOutVariable<string>> paths)
        {
            Paths = paths;
        }

        public PathCombineVariable(params IOutVariable<string>[] paths)
        {
            Paths = paths;
        }

        protected sealed override void initialize()
        {
            this.Require(Paths, nameof(Paths));
        }

        protected sealed override object getValue()
        {
            return Path.Combine(Paths!.Select(p => p.GetValue()!).ToArray());
        }
    }
}
