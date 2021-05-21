using System.Collections.Generic;
using System.Threading.Tasks;
using Enderecos.Application.States.StatesCore.Searches.Abstractions;
using Enderecos.Domain._Core.Caches.Services;
using Enderecos.Domain._Core.Search;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.Entities;
using Enderecos.Domain.States.QueryMessages;

namespace Enderecos.Data.Persistence.States.Searches.Services {

    public class StateFindFromCache : IStateFindFromCache {

        // Constants
        public const string key_cache_state = "cache_state";

        // Dependencies
        private readonly ISearchHandler<StateFindAllNoPageMsg, List<State>> searchState;

        /// <summary>
        /// Construtor
        /// </summary>
        public StateFindFromCache(ISearchHandler<StateFindAllNoPageMsg, List<State>> searchStateParam) {

            searchState = searchStateParam;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<State>> findAll(StateFilter filter) {

            var cache = new CacheService();
            var listState = cache.load<List<State>>(key_cache_state);

            if (listState == null) {

                var msg = new StateFindAllNoPageMsg(filter);
                listState = await searchState.handleAsync(msg);

                cache.save(key_cache_state, listState);
            }

            return listState;
        }
    }
}