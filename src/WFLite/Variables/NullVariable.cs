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
    public class NullVariable : Variable
    {
        protected sealed override object getValue()
        {
            return null;
        }

        protected sealed override void setValue(object value)
        {
        }
    }
}
