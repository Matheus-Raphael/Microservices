using Enderecos.Data.Infra._Core.Context.Abstractions;

namespace Enderecos.Data.Infra._Core.QueryProducers.Abstractions {

    public abstract class QueryProducerDefault<TResultEntity, TResultDTO, TFilter> : QueryProducerBase<TResultEntity, TResultDTO, TFilter> where TResultEntity : class
                                                                                                                                           where TResultDTO : class
                                                                                                                                           where TFilter : class {

        /// <summary>
        /// 
        /// </summary>
        protected QueryProducerDefault(IContextAppReadonly _context) : base(_context) {
        }
    }
}
