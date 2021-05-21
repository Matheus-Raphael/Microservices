using System.Threading.Tasks;

namespace Enderecos.Domain._Core.Search {
    public interface ISearchHandler<TSearch, TResult> where TSearch : ISearchBase<TResult> {
        Task<TResult> handleAsync(TSearch query);
    }
}