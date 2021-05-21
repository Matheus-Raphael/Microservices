using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Enderecos.Infra.IoC._Core.Injectors {

    public static class InfraConfiguration {

        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureConfiguration(this IServiceCollection services,
                                                          IConfiguration configuration) {

            if (services == null) {
                throw new ArgumentNullException(nameof(services));
            }


            //Register interfaces and services from utils or external packages
            //services.AddLibsConfiguration();

            // Register injectors from data layers
            services.AddDatabaseConfiguration(configuration);

            // Register Injectors from Application Layer
            services.AddApplicationConfigurations(configuration);
        }
    }
}
