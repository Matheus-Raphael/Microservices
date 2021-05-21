using Enderecos.Domain.States.DTO.ToApi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enderecos.Application.States.StatesCore.Searches.Abstractions {

    public interface IStateFindAllToApi {

        /// <summary>
        /// 
        /// </summary>
        Task<List<StateResponse>> findAll(StateRequest filter);

    }

}
