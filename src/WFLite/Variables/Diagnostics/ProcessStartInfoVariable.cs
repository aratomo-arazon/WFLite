/*
 * ProcessStartInfoVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Text;
using System.Diagnostics;
using WFLite.Bases;
using WFLite.Interfaces;
using System.Security;
using WFLite.Extensions;

namespace WFLite.Variables.Diagnostics
{
    public class ProcessStartInfoVariable : OutVariable<ProcessStartInfo>
    {
        public IOutVariable<string>? FileName
        {
            private get;
            set;
        }

        public IOutVariable<string>? Arguments
        {
            private get;
            set;
        }

        public IOutVariable<bool>? CreateNoWindow
        {
            private get;
            set;
        }

        public IOutVariable<bool>? UseShellExecute
        {
            private get;
            set;
        }

        public IOutVariable<bool>? RedirectStandardInput
        {
            private get;
            set;
        }

        public IOutVariable<bool>? RedirectStandardOutput
        {
            private get;
            set;
        }

        public IOutVariable<bool>? RedirectStandardError
        {
            private get;
            set;
        }

        public IOutVariable<string>? Domain
        {
            private get;
            set;
        }

        public IOutVariable<string>? UserName
        {
            private get;
            set;
        }

        public IOutVariable<SecureString>? Password
        {
            private get;
            set;
        }

        public IOutVariable<bool>? ErrorDialog
        {
            private get;
            set;
        }

        public IOutVariable<IntPtr>? ErrorDialogParentHandle
        {
            private get;
            set;
        }

        public IOutVariable<bool>? LoadUserProfile
        {
            private get;
            set;
        }

        public IOutVariable<string>? PasswordInClearText
        {
            private get;
            set;
        }

        public IOutVariable<Encoding>? StandardOutputEncoding
        {
            private get;
            set;
        }

        public IOutVariable<Encoding>? StandardErrorEncoding
        {
            private get;
            set;
        }

        public IOutVariable<string>? Verb
        {
            private get;
            set;
        }

        public IOutVariable<ProcessWindowStyle>? WindowStyle
        {
            private get;
            set;
        }

        public IOutVariable<string>? WorkingDirectory
        {
            private get;
            set;
        }

        public ProcessStartInfoVariable()
        {
        }

        public ProcessStartInfoVariable(
            IOutVariable<string> fileName,
            IOutVariable<string>? arguments = null,
            IOutVariable<bool>? createNoWindow = null,
            IOutVariable<bool>? useShellExecute = null,
            IOutVariable<bool>? redirectStandardInput = null,
            IOutVariable<bool>? redirectStandardOutput = null,
            IOutVariable<bool>? redirectStandardError = null,
            IOutVariable<string>? domain = null,
            IOutVariable<string>? userName = null,
            IOutVariable<SecureString>? password = null,
            IOutVariable<bool>? errorDialog = null,
            IOutVariable<IntPtr>? errorDialogParentHandle = null,
            IOutVariable<bool>? loadUserProfile = null,
            IOutVariable<string>? passwordInClearText = null,
            IOutVariable<Encoding>? standardOutputEncoding = null,
            IOutVariable<Encoding>? standardErrorEncoding = null,
            IOutVariable<string>? verb = null,
            IOutVariable<ProcessWindowStyle>? windowStyle = null,
            IOutVariable<string>? workingDirectory = null)
        {
            FileName = fileName;
            Arguments = arguments;
            CreateNoWindow = createNoWindow;
            UseShellExecute = useShellExecute;
            RedirectStandardInput = redirectStandardInput;
            RedirectStandardOutput = redirectStandardOutput;
            RedirectStandardError = redirectStandardError;
            Domain = domain;
            UserName = userName;
            Password = password;
            ErrorDialog = errorDialog;
            ErrorDialogParentHandle = errorDialogParentHandle;
            LoadUserProfile = loadUserProfile;
            PasswordInClearText = passwordInClearText;
            StandardOutputEncoding = standardOutputEncoding;
            StandardErrorEncoding = standardErrorEncoding;
            Verb = verb;
            WindowStyle = windowStyle;
            WorkingDirectory = workingDirectory;
        }

        protected sealed override void initialize()
        {
            this.Require(FileName, nameof(FileName));
        }

        protected sealed override object getValue()
        {
            var processStartInfo = new ProcessStartInfo();

            if (FileName != null)
            {
                processStartInfo.FileName = FileName.GetValue();
            }

            if (Arguments != null)
            {
                processStartInfo.Arguments = Arguments.GetValue();
            }

            if (CreateNoWindow != null)
            {
                processStartInfo.CreateNoWindow = CreateNoWindow.GetValue();
            }

            if (UseShellExecute != null)
            {
                processStartInfo.UseShellExecute = UseShellExecute.GetValue();
            }

            if (RedirectStandardInput != null)
            {
                processStartInfo.RedirectStandardInput = RedirectStandardInput.GetValue();
            }

            if (RedirectStandardOutput != null)
            {
                processStartInfo.RedirectStandardOutput = RedirectStandardOutput.GetValue();
            }

            if (RedirectStandardError != null)
            {
                processStartInfo.RedirectStandardError = RedirectStandardError.GetValue();
            }

            if (Domain != null)
            {
                processStartInfo.Domain = Domain.GetValue();
            }

            if (UserName != null)
            {
                processStartInfo.UserName = UserName.GetValue();
            }

            if (Password != null)
            {
                processStartInfo.Password = Password.GetValue();
            }

            if (ErrorDialog != null)
            {
                processStartInfo.ErrorDialog = ErrorDialog.GetValue();
            }

            if (ErrorDialogParentHandle != null)
            {
                processStartInfo.ErrorDialogParentHandle = ErrorDialogParentHandle.GetValue();
            }

            if (LoadUserProfile != null)
            {
                processStartInfo.LoadUserProfile = LoadUserProfile.GetValue();
            }

            if (PasswordInClearText != null)
            {
                processStartInfo.PasswordInClearText = PasswordInClearText.GetValue();
            }

            if (StandardOutputEncoding != null)
            {
                processStartInfo.StandardOutputEncoding = StandardOutputEncoding.GetValue();
            }

            if (StandardErrorEncoding != null)
            {
                processStartInfo.StandardErrorEncoding = StandardErrorEncoding.GetValue();
            }

            if (Verb != null)
            {
                processStartInfo.Verb = Verb.GetValue();
            }

            if (WindowStyle != null)
            {
                processStartInfo.WindowStyle = WindowStyle.GetValue();
            }

            if (WorkingDirectory != null)
            {
                processStartInfo.WorkingDirectory = WorkingDirectory.GetValue();
            }

            return processStartInfo;
        }
    }
}
