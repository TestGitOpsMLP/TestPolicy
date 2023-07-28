/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the Microsoft License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace GitOps.MyPolicyName.Core
{
    using System.Diagnostics.CodeAnalysis;
    using GitOps.Apps.Abstractions;
    using GitOps.Clients.Azure.BlobStorage;
    using GitOps.Primitives;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    [ExcludeFromCodeCoverage]
    public sealed class MyPolicyNameStartup : AppStartupBase
    {
        /// <summary>
        /// This method is called when the app is initialized by the GitOps app server.
        /// Here the app can register items that will be added to the app's dependency
        /// injection container, just like a Startup.cs in a .NET web app.
        /// </summary>
        /// <param name="serviceCollection">Service collection.</param>
        /// <param name="configuration">Configuration.</param>
        public override void ConfigureServices(
            IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            // TODO here you can use serviceCollection to inject objects
            // the serviceCollection is coming with a default set of objects injected
            // for the first party apps, see docs (https://github.com/microsoft/GitOps)
            serviceCollection.AddSingleton<IPrimitiveCollection>(_ =>
            {
                var azureBlobSettings = configuration.GetSection(nameof(AzureBlobSettings)).Get<AzureBlobSettings>();
                var blobStorage = new BlobStorage(
                    azureBlobSettings.AccountName,
                    azureBlobSettings.AccountKey,
                    true);
                serviceCollection.TryAddSingleton<IBlobStorage>(
                    p => blobStorage);
                return new PrimitiveCollection(new BlobStorage(
                    azureBlobSettings.AccountName,
                    azureBlobSettings.AccountKey,
                    true));
            });
        }
    }
}
