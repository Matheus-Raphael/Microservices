using Enderecos.Data.Infra._Core.Context.Abstractions;
using Enderecos.Data.Infra._Core.QueryProducers.Abstractions;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.Entities;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Enderecos.Data.Persistence.States.Searches.QueryProduces {

    public class StateQueryProducer : QueryProducerDefault<State, StateDTO, StateFilter> {

        /// <summary>
        /// Construtor
        /// </summary>
        public StateQueryProducer(INoSqlContext _context) : base(_context) {

        }

        /// <summary>
        /// 
        /// </summary>
        private IFindFluent<State, State> baseQuery(StateFilter filter) {

            var baseQuery = context.state;

            var filteredQuery = baseFilter(baseQuery, filter);

            return filteredQuery;
        }

        /// <summary>
        /// 
        /// </summary>
        private IFindFluent<State, State> baseFilter(IMongoCollection<State> baseQuery, StateFilter filter) {

            var builder = Builders<State>.Filter;

            var filterQuery = builder.Empty;

            if (filter.ids.Any(x => x != null)) {
                filterQuery = filterQuery &
                              builder.Where(x => filter.ids.Contains(x.id));
            }

            return baseQuery.Find(filterQuery);
        }

        /// <summary>
        /// 
        /// </summary>
        private IFindFluent<State, State> queryOne(StateFilter filter) {

            return baseQuery(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        public override IFindFluent<State, State> chooseQuery(StateFilter filter) {

            if (filter.queryNumber == StateProjections.basicOne.Key) {
                return queryOne(filter);
            }

            throw new ArgumentException("No valid query has been provided!");
        }

        public override IFindFluent<StateDTO, StateDTO> chooseQueryDTO(StateFilter filter) {
            throw new NotImplementedException();
        }

    }

}
