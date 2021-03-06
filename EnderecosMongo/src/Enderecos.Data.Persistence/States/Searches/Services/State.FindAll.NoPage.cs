using Enderecos.Application.States.StatesCore.Searches.Abstractions;
using Enderecos.Data.Infra._Core.Context.Abstractions;
using Enderecos.Data.Infra._Core.QueryProducers.Abstractions;
using Enderecos.Data.Persistence.States.Searches.Abstractions;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enderecos.Data.Persistence.States.Searches.Services {

    public class StateFindAllNoPage : StateSearchBase, IStateFindAllNoPage {

        /// <summary>
        /// Construtor
        /// </summary>
        public StateFindAllNoPage(INoSqlContext _context,
                                  QueryProducerDefault<State, StateDTO, StateFilter> _queryProducer) : base(_context, _queryProducer) {
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<State>> findAll(StateFilter filter) {

            var query = queryProducer.chooseQuery(filter);

            var listState = await query.SortBy(x => x.nameState).ToListAsync();

            return listState;
        }

    }

}
