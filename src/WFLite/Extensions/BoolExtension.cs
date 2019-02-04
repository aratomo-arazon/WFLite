/*
 * BoolExtension.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Conditions;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Extensions
{
    public static class BoolExtension
    {
        public static ICondition ToCondition(this bool result)
        {
            return new TrueCondition(new AnyVariable<bool>(result));
        }
    }
}
