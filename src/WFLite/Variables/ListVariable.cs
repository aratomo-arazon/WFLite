/*
 * ListVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections.Generic;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class ListVariable : AnyVariable<IList<object>>
    {
        public ListVariable()
        {
        }

        public ListVariable(IList<object> value, IConverter converter = null)
            : base(value, converter)
        {
        }
    }
}
