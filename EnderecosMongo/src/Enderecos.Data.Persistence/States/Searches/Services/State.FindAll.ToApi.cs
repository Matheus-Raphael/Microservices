using Enderecos.Application.States.StatesCore.Searches.Abstractions;
using Enderecos.Domain._Core.Search;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.DTO.ToApi;
using Enderecos.Domain.States.Entities;
using Enderecos.Domain.States.QueryMessages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Enderecos.Data.Persistence.States.Searches.Services {

    public class StateFindAllToApi : IStateFindAllToApi {

        // Dependencies
        private readonly ISearchHandler<StateFindAllNoPageMsg, List<State>> searchState;

        public StateFindAllToApi(ISearchHandler<StateFindAllNoPageMsg, List<State>> searchStateParam) {

            searchState = searchStateParam;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<StateResponse>> findAll(StateRequest filter) {

            var response = new List<StateResponse>();

            var filterState = new StateFilter();
            filterState.ids = new string[] { filter.id };
            filterState.setQuery(StateProjections.basicOne.Key);
            var msg = new StateFindAllNoPageMsg(filterState);

            var responseQuery = await searchState.handleAsync(msg);

            if (!responseQuery.Any()) {
                return response;
            }

            responseQuery.ForEach(x => {
                var StateResponse = new StateResponse();
                StateResponse.fromEntity(x);
                response.Add(StateResponse);
            });

            return response;
        }

    }

}
