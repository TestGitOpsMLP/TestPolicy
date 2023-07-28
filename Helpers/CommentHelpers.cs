/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the Microsoft License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace GitOps.MyPolicyName.Core.Helpers
{
    using GitOps.Apps.Abstractions.Models;

    internal static class CommentHelpers
    {
        internal static Comment Comment(
            string id, string suffix)
        {
            var badge = new Badge(
                $"Policy {nameof(MyPolicyName)} - {id}",
                $"Test new policy",
                Severity.Error);

            var details = $"MarkdownText for the comment. {suffix}";

            return new Comment
            {
                Badge = badge,
                MarkdownText = details
            };
        }
    }
}
