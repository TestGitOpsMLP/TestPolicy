/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the Microsoft License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace GitOps.MyPolicyName.Core.Handlers
{
    using System;
    using System.Threading.Tasks;
    using GitOps.Abstractions;
    using GitOps.Apps.Abstractions.AppEventHandler;
    using GitOps.Apps.Abstractions.Models;
    using GitOps.MyPolicyName.Core.Helpers;
    using GitOps.MyPolicyName.Core.Primitives.Data;
    using Microsoft.Extensions.Logging;

    public sealed class PullRequestHandler : HandlerBase, IAppEventHandler
    {
        public PullRequestHandler(ILogger<HandlerBase> logger)
            : base(logger)
        {
        }

        public PlatformEventActions EventType => PlatformEventActions.Pull_Request;

        public async Task<object> HandleEvent(
            GitOpsPayload gitOpsPayload,
            AppOutput appOutput,
            params object[] parameters)
        {
            // We can have app behave according to appOutput.
            if (appOutput.Conclusion == Conclusion.Success)
            {
                // TODO: Implement app behaviour on success
                // For example you can forward to other event, actions like build, test etc.
                // return appOutput
            }

            if (!PrimitiveExists(parameters))
            {
                return appOutput;
            }

            appOutput.Conclusion = Conclusion.Success;
            appOutput.Comment = CommentHelpers.Comment(
                Guid.NewGuid().ToString(),
                MergePrimitives<SamplePrimitive>(parameters)?.CommentSuffix);
            return await Task.FromResult(appOutput);
        }
    }
}
