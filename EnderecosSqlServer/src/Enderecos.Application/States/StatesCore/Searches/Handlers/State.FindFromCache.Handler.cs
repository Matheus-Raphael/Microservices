using System.Collections.Generic;
using System.Threading.Tasks;
using Enderecos.Application.States.StatesCore.Searches.Abstractions;
using Enderecos.Domain._Core.Search;
using Enderecos.Domain.States.Entities;
using Enderecos.Domain.States.QueryMessages;

namespace Enderecos.Application.States.StatesCore.Searches.Handlers {

    /// <summary>
    /// 
    /// </summary>
    public class StateFindFromCacheHandler : ISearchHandler<StateFindFromCacheMsg, List<State>> {

        //Dependencies
        private readonly IStateFindFromCache searchState;

        /// <summary>
        /// Construtor
        /// </summary>
        public StateFindFromCacheHandler(IStateFindFromCache searchStateParam) {
            searchState = searchStateParam;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<State>> handleAsync(StateFindFromCacheMsg request) {

            var result = await searchState.findAll(request.filter);

            return result;
        }
    }
}
