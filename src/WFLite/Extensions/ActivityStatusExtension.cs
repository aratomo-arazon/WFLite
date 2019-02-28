/*
 * ActivityStatusExtension.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections.Generic;
using System.Linq;
using WFLite.Enums;
using WFLite.Interfaces;

namespace WFLite.Extensions
{
    public static class ActivityStatusExtension
    {
        public static bool IsCreated(this ActivityStatus status)
        {
            return status == ActivityStatus.Created;
        }

        public static bool IsExecuting(this ActivityStatus status)
        {
            return status == ActivityStatus.Executing;
        }

        public static bool IsSuspended(this ActivityStatus status)
        {
            return status == ActivityStatus.Suspended;
        }

        public static bool IsStopping(this ActivityStatus status)
        {
            return status == ActivityStatus.Stopping;
        }

        public static bool IsRunning(this ActivityStatus status)
        {
            return
                status == ActivityStatus.Executing ||
                status == ActivityStatus.Stopping;
        }

        public static bool IsCompleted(this ActivityStatus status)
        {
            return status == ActivityStatus.Completed;
        }

        public static bool IsStopped(this ActivityStatus status)
        {
            return status == ActivityStatus.Stopped;
        }

        public static bool IsFinished(this ActivityStatus status)
        {
            return
                status == ActivityStatus.Completed ||
                status == ActivityStatus.Stopped;
        }

        public static bool CanStart(this ActivityStatus status)
        {
            return
                status == ActivityStatus.Created ||
                status == ActivityStatus.Suspended;
        }

        public static bool CanStop(this ActivityStatus status)
        {
            return !status.IsFinished();
        }

        public static bool CanReset(this ActivityStatus status)
        {
            return status.IsFinished();
        }

        public static ActivityStatus GetStatus(this IEnumerable<IActivity> activities)
        {
            if (activities.All(a => a.Status.IsCreated()))
            {
                return ActivityStatus.Created;
            }

            if (activities.All(a => a.Status.IsFinished()))
            {
                if (activities.Any(a => a.Status.IsStopped()))
                {
                    return ActivityStatus.Stopped;
                }
                else
                {
                    return ActivityStatus.Completed;
                }
            }

            if (activities.Any(a => a.Status.IsStopped() || a.Status.IsStopping()))
            {
                return ActivityStatus.Stopping;
            }
            else if (activities.Any(a => a.Status.IsSuspended()))
            {
                return ActivityStatus.Suspended;
            }
            else
            {
                return ActivityStatus.Executing;
            }
        }
    }
}
