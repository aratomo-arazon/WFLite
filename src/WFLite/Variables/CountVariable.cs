/*
 * CountVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Collections.Generic;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class CountVariable : Variable
    {
        public IVariable Collection
        {
            private get;
            set;
        }

        public CountVariable()
        {
        }

        public CountVariable(IVariable collection, IConverter converter = null)
            : base(converter)
        {
            Collection = collection;
        }

        protected sealed override object getValue()
        {
            var value = Collection.GetValue();

            if (value is IList<object>)
            {
                return (value as IList<object>).Count;
            }
            else if (value is IDictionary<string, object>)
            {
                return (value as IDictionary<string, object>).Count;
            }
            else
            {
                return 0;
            }
        }

        protected sealed override void setValue(object value)
        {
            throw new NotSupportedException();
        }
    }
}
