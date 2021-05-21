using System.Threading.Tasks;

namespace Enderecos.Domain._Core.Command {

    public interface ICommandHandler<TCommand, TResult> {

        /// <summary>
        /// 
        /// </summary>
        Task<TResult> handleAsync(TCommand model);
    }
}
