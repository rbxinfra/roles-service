namespace Roblox.Roles.Service;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Web.Framework.Services;
using Web.Framework.Services.Http;

using Instrumentation;
using Platform.Membership;

/// <summary>
/// Startup class for roles-service.
/// </summary>
public class Startup : HttpStartupBase
{
    /// <inheritdoc cref="StartupBase.Settings"/>
    protected override IServiceSettings Settings => Roles.Service.Settings.Singleton;

    /// <inheritdoc cref="StartupBase.ConfigureServices(IServiceCollection)"/>
    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
            options.SuppressConsumesConstraintForFormFileParameters = true;
        });

        services.AddSingleton<ICounterRegistry, CounterRegistry>();
        services.AddSingleton<MembershipDomainFactories>();

        services.AddSingleton<IRolesOperations, RolesOperations>();
    }
}
