/*
 * DictionaryVariable.cs
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
    public class DictionaryVariable : AnyVariable<IDictionary<string, object>>
    {
        public DictionaryVariable()
        {
        }

        public DictionaryVariable(IDictionary<string, object> value, IConverter converter = null)
            : base(value, converter)
        {
        }
    }
}
