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
        protected override object getValue()
        {
            return null;
        }

        protected override void setValue(object value)
        {
        }
    }
}
