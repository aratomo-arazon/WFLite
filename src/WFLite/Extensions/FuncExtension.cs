/*
 * FuncExtension.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Conditions;
using WFLite.Converters;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Extensions
{
    public static class FuncExtension
    {
        public static IVariable ToVariable(this Func<object> func)
        {
            return new FuncVariable(func);
        }

        public static IVariable ToVariable(this Func<object> func, IConverter converter = null)
        {
            return new FuncVariable(func, converter);
        }

        public static IConverter ToConverter(this Func<object, object> func)
        {
            return new FuncConverter(func);
        }

        public static ICondition ToCondition(this Func<bool> func)
        {
            return new FuncCondition(func);
        }

        public static IActivity ToActivity(this Func<bool> func)
        {
            return new SyncActivity(func);
        }

        public static IActivity ToActivity(this Func<CancellationToken, Task<bool>> func)
        {
            return new AsyncActivity(func);
        }
    }
}
