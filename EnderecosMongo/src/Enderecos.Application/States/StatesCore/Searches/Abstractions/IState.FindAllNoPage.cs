using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enderecos.Application.States.StatesCore.Searches.Abstractions {

    public interface IStateFindAllNoPage {

        /// <summary>
        /// 
        /// </summary>
        Task<List<State>> findAll(StateFilter filter);

    }

}
