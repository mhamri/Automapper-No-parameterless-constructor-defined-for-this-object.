using System;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.WithDryIoc
{
    public static class Ioc
    {
        public static IServiceProvider AddDryIoc<TCompositionRoot>(this IServiceCollection services)
        {
            var container = new Container()
                .WithDependencyInjectionAdapter(services, throwIfUnresolved: type => type.Name.EndsWith("Controller"));
            container.RegisterMany<TCompositionRoot>();
            container.Resolve<TCompositionRoot>();
            return container.Resolve<IServiceProvider>();
        }
    }
}
