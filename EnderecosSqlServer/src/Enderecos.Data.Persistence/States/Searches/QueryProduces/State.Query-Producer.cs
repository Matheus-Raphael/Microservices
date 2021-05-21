using Enderecos.Data.Infra._Core.Context.Abstractions;
using Enderecos.Data.Infra._Core.QueryProducers.Abstractions;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Enderecos.Data.Persistence.States.Searches.QueryProduces {

    public class StateQueryProducer : QueryProducerDefault<State, StateDTO, StateFilter> {

        /// <summary>
        /// Construtor
        /// </summary>
        public StateQueryProducer(IContextAppReadonly _context) : base(_context) {

        }

        /// <summary>
        /// 
        /// </summary>
        private IQueryable<State> baseQuery(StateFilter filter) {

            var baseQuery = from item in context.state
                            select item;

            var filteredQuery = baseFilter(baseQuery, filter);

            return filteredQuery;
        }

        /// <summary>
        /// 
        /// </summary>
        private IQueryable<State> baseFilter(IQueryable<State> baseQuery, StateFilter filter) {

            if (filter.ids != null && filter.ids.Any(x => x > 0)) {
                baseQuery = baseQuery.Where(x => filter.ids.Contains(x.id));
            }

            return baseQuery;
        }

        /// <summary>
        /// 
        /// </summary>
        private IQueryable<State> queryOne(StateFilter filter) {

            return baseQuery(filter).AsNoTracking().Select(StateProjections.basicOne.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        public override IQueryable<State> chooseQuery(StateFilter filter) {

            if (filter.queryNumber == StateProjections.basicOne.Key) {
                return queryOne(filter);
            }

            throw new ArgumentException("No valid query has been provided!");
        }

        public override IQueryable<StateDTO> chooseQueryDTO(StateFilter filter) {
            throw new NotImplementedException();
        }

    }

}
