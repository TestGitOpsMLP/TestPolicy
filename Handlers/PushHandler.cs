/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the Microsoft License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace GitOps.MyPolicyName.Core.Handlers
{
    using System.Threading.Tasks;
    using GitOps.Abstractions;
    using GitOps.Apps.Abstractions.AppEventHandler;
    using GitOps.Apps.Abstractions.Models;

    internal sealed class PushHandler : IAppEventHandler
    {
        public PlatformEventActions EventType => PlatformEventActions.Push;

        public async Task<object> HandleEvent(
            GitOpsPayload gitOpsPayload,
            AppOutput appOutput,
            params object[] parameters)
        {
            // We can have app behave according to appOutput.
            if (appOutput.Conclusion == Conclusion.Success)
            {
                // TODO: Implement app behaviour on success.
                // For example you can forward to other event, actions like build, test etc.
                // return appOutput
            }

            // TODO: Implement app behaviour on failure
            return await Task.FromResult(appOutput);
        }
    }
}
