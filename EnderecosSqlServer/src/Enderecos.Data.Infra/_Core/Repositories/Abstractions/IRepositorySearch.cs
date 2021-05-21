using System;
using System.Threading.Tasks;

namespace Enderecos.Data.Infra._Core.Repositories.Abstractions {

    public interface IRepositorySearch<T> : IDisposable where T : class {

        /// <summary>
        /// 
        /// </summary>
        Task<T> find(object id);

    }
}
