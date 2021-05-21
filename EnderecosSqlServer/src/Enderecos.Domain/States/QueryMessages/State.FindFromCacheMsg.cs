using Enderecos.Domain._Core.Search;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.Entities;
using System.Collections.Generic;

namespace Enderecos.Domain.States.QueryMessages {

    /// <summary>
    /// 
    /// </summary>
    public class StateFindFromCacheMsg : ISearchBase<List<State>> {

        //Props
        public StateFilter filter { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public StateFindFromCacheMsg(StateFilter _filter) {

            filter = _filter;
        }

    }

}
