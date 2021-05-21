using Enderecos.Data.Infra._Core.Context.Abstractions;
using System.Linq;

namespace Enderecos.Data.Infra._Core.QueryProducers.Abstractions {

    public abstract class QueryProducerBase<TResultEntity, TResultDTO, TFilter> where TResultEntity : class
                                                                                where TResultDTO : class
                                                                                where TFilter : class {

        //Dependencies
        protected readonly IContextAppBase context;

        /// <summary>
        /// Construtor
        /// </summary>
        protected QueryProducerBase(IContextAppBase _context) {
            context = _context;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract IQueryable<TResultEntity> chooseQuery(TFilter filter);

        /// <summary>
        /// 
        /// </summary>
        public abstract IQueryable<TResultDTO> chooseQueryDTO(TFilter filter);
    }
}
