using System.Collections.Generic;
using System.Threading.Tasks;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.Entities;

namespace Enderecos.Application.States.StatesCore.Searches.Abstractions {

    public interface IStateFindFromCache {

        /// <summary>
        /// 
        /// </summary>
        Task<List<State>> findAll(StateFilter filter);

    }
}