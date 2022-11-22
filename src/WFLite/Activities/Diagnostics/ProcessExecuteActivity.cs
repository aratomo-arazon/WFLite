/*
 * ProcessExecuteActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using System;
using System.Diagnostics;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities.Diagnostics
{
    public class ProcessExecuteActivity : SyncActivity
    {
        public IOutVariable<ProcessStartInfo>? StartInfo
        {
            private get;
            set;
        }

        public IOutVariable<Action<DataReceivedEventArgs>>? DataReceiveAction
        {
            private get;
            set;
        }

        public IOutVariable<Action<DataReceivedEventArgs>>? ErrorReceiveAction
        {
            private get;
            set;
        }

        public IOutVariable<int>? Timeout
        {
            private get;
            set;
        }

        public IInVariable<int>? ExitCode
        {
            private get;
            set;
        }

        public IInVariable<DateTime>? StartTime
        {
            private get;
            set;
        }

        public IInVariable<DateTime>? ExitTime
        {
            private get;
            set;
        }

        public IConverter<int, bool>? ResultConverter
        {
            private get;
            set;
        }

        public ProcessExecuteActivity()
        {
        }

        public ProcessExecuteActivity(
            IOutVariable<ProcessStartInfo> startInfo,
            IOutVariable<Action<DataReceivedEventArgs>>? dataReceiveAction = null,
            IOutVariable<Action<DataReceivedEventArgs>>? errorReceiveAction = null,
            IOutVariable<int>? timeout = null,
            IInVariable<int>? exitCode = null,
            IInVariable<DateTime>? startTime = null,
            IInVariable<DateTime>? exitTime = null,
            IConverter<int, bool>? resultConverter = null)
        {
            StartInfo = startInfo;
            DataReceiveAction = dataReceiveAction;
            ErrorReceiveAction = errorReceiveAction;
            Timeout = timeout;
            ExitCode = exitCode;
            StartTime = startTime;
            ExitTime = exitTime;
            ResultConverter = resultConverter;
        }

        protected sealed override void initialize()
        {
            this.Require(StartInfo, nameof(StartInfo));
        }

        protected sealed override bool run()
        {
            var startInfo = StartInfo!.GetValue();

            using (var process = new Process() { StartInfo = startInfo! })
            {
                if (DataReceiveAction != null)
                {
                    process.OutputDataReceived += (_, e) => DataReceiveAction.GetValue()!(e);
                }

                if (ErrorReceiveAction != null)
                {
                    process.ErrorDataReceived += (_, e) => ErrorReceiveAction.GetValue()!(e);
                }

                if (!process.Start())
                {
                    return false;
                }

                if (startInfo!.RedirectStandardOutput)
                {
                    process.BeginOutputReadLine();
                }

                if (startInfo!.RedirectStandardError)
                {
                    process.BeginErrorReadLine();
                }

                if (Timeout == null)
                {
                    process.WaitForExit();
                }
                else
                {
                    process.WaitForExit(Timeout.GetValue());
                }

                if (startInfo!.RedirectStandardInput)
                {
                    process.CancelOutputRead();
                }

                if (startInfo!.RedirectStandardError)
                {
                    process.CancelErrorRead();
                }

                var exitCode = process.ExitCode;

                if (ExitCode != null)
                {
                    ExitCode.SetValue<int>(exitCode);
                }

                if (StartTime != null)
                {
                    StartTime.SetValue<DateTime>(process.StartTime);
                }

                if (ExitTime != null)
                {
                    ExitTime.SetValue<DateTime>(process.ExitTime);
                }

                if (ResultConverter == null)
                {
                    return exitCode == 0;
                }
                else
                {
                    return ResultConverter.Convert(exitCode);
                }
            }
        }
    }
}
