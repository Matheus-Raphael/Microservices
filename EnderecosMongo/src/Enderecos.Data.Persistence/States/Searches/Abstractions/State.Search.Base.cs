using Enderecos.Data.Infra._Core.Context.Abstractions;
using Enderecos.Data.Infra._Core.QueryProducers.Abstractions;
using Enderecos.Data.Infra._Core.Respositories;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.Entities;

namespace Enderecos.Data.Persistence.States.Searches.Abstractions {

    public class StateSearchBase : BaseRepo<State> {

        //Dependencies
        protected readonly QueryProducerBase<State, StateDTO, StateFilter> queryProducer;

        /// <summary>
        /// Construtor
        /// </summary>
        public StateSearchBase(INoSqlContext _context,
                               QueryProducerBase<State, StateDTO, StateFilter> _queryProducer) : base(_context) {

            queryProducer = _queryProducer;
        }

    }

}
