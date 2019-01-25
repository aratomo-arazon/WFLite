/*
 * NullVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class NullVariable : Variable
    {
        public NullVariable(IConverter converter = null)
            : base(converter)       
        {
        }

        protected sealed override object getValue()
        {
            return null;
        }

        protected sealed override void setValue(object value)
        {
            throw new NotSupportedException();
        }
    }
}
