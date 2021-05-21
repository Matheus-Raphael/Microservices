using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Enderecos.Data.Persistence.States.Searches.QueryProduces;
using Enderecos.Data.Persistence.States.Searches.Services;
using Enderecos.Data.Infra._Core.QueryProducers.Abstractions;
using Enderecos.Application.States.StatesCore.Searches.Abstractions;
using Enderecos.Application.States.StatesCore.Searches.Handlers;
using Enderecos.Domain.States.QueryMessages;
using Enderecos.Domain.States.Entities;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.DTO.ToApi;
using Enderecos.Domain._Core.Search;

namespace Enderecos.Infra.IoC._Core.Injectors {

    public static class ApplicationInjector {

        /// <summary>
        /// 
        /// </summary>
        public static void AddApplicationConfigurations(this IServiceCollection services,
                                                        IConfiguration configuration) {

            RegisterState(services);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RegisterState(IServiceCollection services) {

            //Handlers
            services.AddScoped<ISearchHandler<StateFindAllNoPageMsg, List<State>>, StateFindAllNoPageHandler>();
            services.AddScoped<ISearchHandler<StateFindAllMsgToApi, List<StateResponse>>, StateFindAllToApiHandler>();

            //Query Producers
            services.AddScoped<QueryProducerDefault<State, StateDTO, StateFilter>, StateQueryProducer>();

            //Validators

            //Services
            services.AddScoped<IStateFindAllNoPage, StateFindAllNoPage>();
            services.AddScoped<IStateFindAllToApi, StateFindAllToApi>();
        }
    }

}
