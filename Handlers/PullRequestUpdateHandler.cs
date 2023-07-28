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

    internal sealed class PullRequestUpdateHandler : HandlerBase, IAppEventHandler
    {
        public PullRequestUpdateHandler(ILogger<HandlerBase> logger)
            : base(logger)
        {
        }

        public PlatformEventActions EventType => PlatformEventActions.Git_Pullrequest_Updated;

        public async Task<object> HandleEvent(
            GitOpsPayload gitOpsPayload,
            AppOutput appOutput,
            params object[] parameters)
        {
            // check if the primitive exists
            if (!PrimitiveExists(parameters))
            {
                return appOutput;
            }

            appOutput.Comment = CommentHelpers.Comment(
                Guid.NewGuid().ToString(),
                MergePrimitives<SamplePrimitive>(parameters)?.CommentSuffix);
            return await Task.FromResult(appOutput);
        }
    }
}
