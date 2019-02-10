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

namespace WFLite.Variables.Diagnostics
{
    public class ProcessStartInfoVariable : OutVariable<ProcessStartInfo>
    {
        public IOutVariable<string> FileName
        {
            private get;
            set;
        }

        public IOutVariable<string> Arguments
        {
            private get;
            set;
        }

        public IOutVariable<bool> CreateNoWindow
        {
            private get;
            set;
        }

        public IOutVariable<bool> UseShellExecute
        {
            private get;
            set;
        }

        public IOutVariable<bool> RedirectStandardInput
        {
            private get;
            set;
        }

        public IOutVariable<bool> RedirectStandardOutput
        {
            private get;
            set;
        }

        public IOutVariable<bool> RedirectStandardError
        {
            private get;
            set;
        }

        public IOutVariable<string> Domain
        {
            private get;
            set;
        }

        public IOutVariable<string> UserName
        {
            private get;
            set;
        }

        public IOutVariable<SecureString> Password
        {
            private get;
            set;
        }

        public IOutVariable<bool> ErrorDialog
        {
            private get;
            set;
        }

        public IOutVariable<IntPtr> ErrorDialogParentHandle
        {
            private get;
            set;
        }

        public IOutVariable<bool> LoadUserProfile
        {
            private get;
            set;
        }

        public IOutVariable<string> PasswordInClearText
        {
            private get;
            set;
        }
        public IOutVariable<Encoding> StandardInputEncoding
        {
            private get;
            set;
        }

        public IOutVariable<Encoding> StandardOutputEncoding
        {
            private get;
            set;
        }

        public IOutVariable<Encoding> StandardErrorEncoding
        {
            private get;
            set;
        }

        public IOutVariable<string> Verb
        {
            private get;
            set;
        }

        public IOutVariable<ProcessWindowStyle> WindowStyle
        {
            private get;
            set;
        }

        public IOutVariable<string> WorkingDirectory
        {
            private get;
            set;
        }

        public ProcessStartInfoVariable()
        {
        }

        public ProcessStartInfoVariable(
            IOutVariable<string> fileName = null,
            IOutVariable<string> arguments = null,
            IOutVariable<bool> createNoWindow = null,
            IOutVariable<bool> useShellExecute = null,
            IOutVariable<bool> redirectStandardInput = null,
            IOutVariable<bool> redirectStandardOutput = null,
            IOutVariable<bool> redirectStandardError = null,
            IOutVariable<string> domain = null,
            IOutVariable<string> userName = null,
            IOutVariable<SecureString> password = null,
            IOutVariable<bool> errorDialog = null,
            IOutVariable<IntPtr> errorDialogParentHandle = null,
            IOutVariable<bool> loadUserProfile = null,
            IOutVariable<string> passwordInClearText = null,
            IOutVariable<Encoding> standardInputEncoding = null,
            IOutVariable<Encoding> standardOutputEncoding = null,
            IOutVariable<Encoding> standardErrorEncoding = null,
            IOutVariable<string> verb = null,
            IOutVariable<ProcessWindowStyle> windowStyle = null,
            IOutVariable<string> workingDirectory = null)
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
            StandardInputEncoding = standardInputEncoding;
            StandardOutputEncoding = standardOutputEncoding;
            StandardErrorEncoding = standardErrorEncoding;
            Verb = verb;
            WindowStyle = windowStyle;
            WorkingDirectory = workingDirectory;
        }

        protected sealed override object getValue()
        {
            return new ProcessStartInfo()
            {
                FileName = FileName == null ? default : FileName.GetValue(),
                Arguments = Arguments == null ? default : Arguments.GetValue(),
                CreateNoWindow = CreateNoWindow == null ? default : CreateNoWindow.GetValue(),
                UseShellExecute = UseShellExecute == null ? default : UseShellExecute.GetValue(),
                RedirectStandardInput = RedirectStandardInput == null ? default : RedirectStandardInput.GetValue(),
                RedirectStandardOutput = RedirectStandardOutput == null ? default : RedirectStandardOutput.GetValue(),
                RedirectStandardError = RedirectStandardError == null ? default : RedirectStandardError.GetValue(),
                Domain = Domain == null ? default : Domain.GetValue(),
                UserName = UserName == null ? default : UserName.GetValue(),
                Password = Password == null ? default : Password.GetValue(),
                ErrorDialog = ErrorDialog == null ? default : ErrorDialog.GetValue(),
                ErrorDialogParentHandle = ErrorDialogParentHandle == null ? default : ErrorDialogParentHandle.GetValue(),
                LoadUserProfile = LoadUserProfile == null ? default : LoadUserProfile.GetValue(),
                PasswordInClearText = PasswordInClearText == null ? default : PasswordInClearText.GetValue(),
                StandardInputEncoding = StandardInputEncoding == null ? default : StandardInputEncoding.GetValue(),
                StandardOutputEncoding = StandardOutputEncoding == null ? default : StandardOutputEncoding.GetValue(),
                StandardErrorEncoding = StandardErrorEncoding == null ? default : StandardErrorEncoding.GetValue(),
                Verb = Verb == null ? default : Verb.GetValue(),
                WindowStyle = WindowStyle == null ? default : WindowStyle.GetValue(),
                WorkingDirectory = WorkingDirectory == null ? default : WorkingDirectory.GetValue()
            };
        }
    }
}
