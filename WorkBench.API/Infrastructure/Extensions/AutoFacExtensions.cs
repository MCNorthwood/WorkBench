using Autofac.Extensions.DependencyInjection;
using Autofac;
using System.Reflection;

namespace WorkBench.API.Infrastructure.Extensions;

public static class AutoFacExtensions
{
    public static IHostBuilder AddAutoFacServices(this ConfigureHostBuilder host)
    {
        host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>((container) =>
            {
                container.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.FizzBuzz")).AsImplementedInterfaces();
                container.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.CaesarCipher")).AsImplementedInterfaces();
                container.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Rules")).AsImplementedInterfaces();
                container.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Rules.Bespoke")).AsImplementedInterfaces();
            });

        return host;
    }
}
