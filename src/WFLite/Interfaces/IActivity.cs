/*
 * IActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading.Tasks;
using WFLite.Enums;

namespace WFLite.Interfaces
{
    public interface IActivity
    {
        ActivityStatus Status { get; }

        Task Start();

        void Stop();

        void Reset();
    }
}
