using Pklr.Api.Integrations.FileStore;

namespace Pklr.Api.Integrations;

public static class IntegrationServiceExtensions
{
    public static IServiceCollection AddIntegrations(
        this IServiceCollection services,
        FileStoreOptions fileStoreOptions)
    {
        services.AddSingleton(fileStoreOptions);
        
        if (fileStoreOptions.Type == FileStoreType.LocalFileStore)
        {
            services.AddSingleton<IFileStore, LocalFileStore>();
        }
        else
        {
            services.AddSingleton<IFileStore, FileStore.FileStore>();
        }
        
        return services;
    }
}