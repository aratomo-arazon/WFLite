/*
 * ToStringConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

namespace WFLite.Converters
{
    public class ToStringConverter : Bases.Converter<string>
    {
        protected sealed override void initialize()
        {
        }

        protected sealed override string? convert(object? value)
        {
            return value!.ToString();
        }
    }
}
