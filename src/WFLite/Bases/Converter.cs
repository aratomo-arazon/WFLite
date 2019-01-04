/*
 * Converter.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Bases
{
    public abstract class Converter : IConverter
    {

        public object Convert(object value)
        {
            return convert(value);
        }

        protected abstract object convert(object value);
    }
}
