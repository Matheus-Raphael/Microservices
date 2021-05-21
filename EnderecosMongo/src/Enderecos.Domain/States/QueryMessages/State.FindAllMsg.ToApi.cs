using Enderecos.Domain._Core.Search;
using Enderecos.Domain.States.DTO.ToApi;
using System.Collections.Generic;

namespace Enderecos.Domain.States.QueryMessages {

    /// <summary>
    /// 
    /// </summary>
    public class StateFindAllMsgToApi : ISearchBase<List<StateResponse>> {

        //Props
        public StateRequest filter { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public StateFindAllMsgToApi(StateRequest _filter) {

            filter = _filter;
        }

    }

}
