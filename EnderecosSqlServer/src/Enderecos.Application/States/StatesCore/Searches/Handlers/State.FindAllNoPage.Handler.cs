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
    public class StateFindAllNoPageHandler : ISearchHandler<StateFindAllNoPageMsg, List<State>> {

        //Dependencies
        private readonly IStateFindAllNoPage searchState;

        /// <summary>
        /// Construtor
        /// </summary>
        public StateFindAllNoPageHandler(IStateFindAllNoPage searchStateParam) {
            searchState = searchStateParam;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<State>> handleAsync(StateFindAllNoPageMsg request) {

            var listState = await searchState.findAll(request.filter);

            return listState;
        }
    }
}
