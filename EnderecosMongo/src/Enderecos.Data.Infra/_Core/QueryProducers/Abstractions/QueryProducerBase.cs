using Enderecos.Data.Infra._Core.Context.Abstractions;
using MongoDB.Driver;

namespace Enderecos.Data.Infra._Core.QueryProducers.Abstractions {

    public abstract class QueryProducerBase<TResultEntity, TResultDTO, TFilter> where TResultEntity : class
                                                                                where TResultDTO : class
                                                                                where TFilter : class {

        //Dependencies
        protected readonly INoSqlContext context;

        /// <summary>
        /// Construtor
        /// </summary>
        protected QueryProducerBase(INoSqlContext _context) {
            context = _context;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract IFindFluent<TResultEntity, TResultEntity> chooseQuery(TFilter filter);

        /// <summary>
        /// 
        /// </summary>
        public abstract IFindFluent<TResultDTO, TResultDTO> chooseQueryDTO(TFilter filter);

    }

}
