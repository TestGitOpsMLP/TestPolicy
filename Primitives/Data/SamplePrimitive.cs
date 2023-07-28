/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the Microsoft License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace GitOps.MyPolicyName.Core.Primitives.Data
{
    using GitOps.Primitives.Abstractions;

    /// <summary>
    /// Use this to define the primitive.
    /// The primitive is the unit of computation that this app will act on.
    /// It can be thought of as a configuration for the app, that will be
    /// checked in by the user in source code as a policy configuration.
    ///
    /// The app can define any kind of model here and then implement a
    /// corresponding behavior of this primitive.
    /// </summary>
    public sealed class SamplePrimitive : IPrimitive
    {
        public string CommentSuffix { get; set; }
    }
}
