/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the Microsoft License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace GitOps.MyPolicyName.Core
{
    using System.Linq;
    using System.Threading.Tasks;
    using GitOps.Abstractions;
    using GitOps.Apps.Abstractions;
    using GitOps.Apps.Abstractions.AppEventHandler;
    using GitOps.Apps.Abstractions.Models;
    using GitOps.MyPolicyName.Core.Primitives.Data;
    using GitOps.Primitives;

    public sealed class MyPolicyName : AppBase
    {
        private readonly IPrimitiveCollection primitiveCollection;
        private readonly AppEventHandlerOrchestrator appEventHandlerOrchestrator;

        public MyPolicyName(
            AppEventHandlerOrchestrator appEventHandlerOrchestrator,
            IPrimitiveCollection primitiveCollection)
        {
            this.appEventHandlerOrchestrator = appEventHandlerOrchestrator;
            this.primitiveCollection = primitiveCollection;
        }

        public override string Id { get; protected set; } = nameof(MyPolicyName);

        public override async Task<AppOutput> Run(GitOpsPayload gitOpsPayload)
        {
            var appOutput = new AppOutput
            {
                Conclusion = Conclusion.Neutral
            };

            // grab all the primitives, usually each repository will have 2, one repo level and another one org level
            var primitives = (await primitiveCollection.Get(gitOpsPayload))
                .Where(p => p is SamplePrimitive)
                .Cast<SamplePrimitive>();

            await appEventHandlerOrchestrator.HandleEvent(
                gitOpsPayload,
                appOutput,
                primitives,
                Id);

            return appOutput;
        }
    }
}
