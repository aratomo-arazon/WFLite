/*
 * ListItemVariable.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
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
    public class ListItemVariable : Variable
    {
        public IVariable List
        {
            private get;
            set;
        }

        public IVariable Index
        {
            private get;
            set;
        }

        protected override object getValue()
        {
            var list = List.GetValue() as IList<object>;
            var index = Convert.ToInt32(Index.GetValue());
            return list[index];
        }

        protected override void setValue(object value)
        {
            var list = List.GetValue() as IList<object>;
            var index = Convert.ToInt32(Index.GetValue());
            list[index] = value;
        }
    }
}
