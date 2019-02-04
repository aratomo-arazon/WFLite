/*
 * NullVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;

namespace WFLite.Variables
{
    public class NullVariable : OutVariable
    {
        protected sealed override object getValue()
        {
            return null;
        }
    }

    public class NullVariable<TValue> : OutVariable<TValue>
    {
        protected sealed override object getValue()
        {
            return null;
        }
    }
}
