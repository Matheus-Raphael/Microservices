using System.Collections.Generic;
using System.Threading.Tasks;
using Enderecos.Application.States.StatesCore.Searches.Abstractions;
using Enderecos.Domain._Core.Search;
using Enderecos.Domain.States.DTO.ToApi;
using Enderecos.Domain.States.QueryMessages;

namespace Enderecos.Application.States.StatesCore.Searches.Handlers {

    /// <summary>
    /// 
    /// </summary>
    public class StateFindAllToApiHandler : ISearchHandler<StateFindAllMsgToApi, List<StateResponse>> {

        //Dependencies
        private readonly IStateFindAllToApi searchState;

        /// <summary>
        /// Construtor
        /// </summary>
        public StateFindAllToApiHandler(IStateFindAllToApi searchStateParam) {
            searchState = searchStateParam;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<StateResponse>> handleAsync(StateFindAllMsgToApi request) {

            var result = await searchState.findAll(request.filter);

            return result;
        }
    }
}
