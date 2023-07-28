/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the Microsoft License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace GitOps.MyPolicyName.Core.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using GitOps.MyPolicyName.Core.Primitives.Data;
    using Microsoft.Extensions.Logging;

    public abstract class HandlerBase
    {
        private readonly ILogger<HandlerBase> logger;

        protected HandlerBase(
            ILogger<HandlerBase> logger)
        {
            this.logger = logger;
        }

        protected bool PrimitiveExists(object[] parameters)
        {
            if (parameters.Length == 0
                || !((IEnumerable<SamplePrimitive>)parameters[0]).Any())
            {
                return false;
            }

            logger.LogInformation("No primitives found");
            return true;
        }

        protected T MergePrimitives<T>(object[] parameters)
            where T : new()
        {
            // define your own merge strategy here is case is need it.
            // primitives can come from different scope where the policy is getting pushed
            // so in case you have it from multiple scopes then you are in charge for the merge strategies
            // as an example we will get the first one
            var allPrimitives = (IEnumerable<T>)parameters[0];

            // TODO add merge strategies in case is need it
            return allPrimitives.FirstOrDefault();
        }
    }
}
