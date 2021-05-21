using System;
using Enderecos.Data.Infra._Core.Context;
using Enderecos.Data.Infra._Core.Context.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enderecos.Infra.IoC._Core.Injectors {

    public static class DatabaseConfiguration {

        /// <summary>
        /// Setting up database informations
        /// </summary>
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration) {

            if (services == null) {
                throw new ArgumentNullException(nameof(services));
            }

            string primaryConex = configuration.GetConnectionString("primaryConnection");
            string readConex = configuration.GetConnectionString("secondaryConnection");

            services.AddDbContext<ContextAppDefault>(options =>
                options.UseSqlServer(
                    primaryConex
                )
            );

            services.AddDbContext<ContextAppReadonly>(options =>
                 options.UseSqlServer(
                    readConex
                )
            );

            services.AddScoped<IContextAppDefault, ContextAppDefault>();
            services.AddScoped<IContextAppReadonly, ContextAppReadonly>();
        }
    }
}
