using System;
using System.Threading.Tasks;

namespace Enderecos.Data.Infra._Core.Repositories.Abstractions {

    public interface IRepositoryBase<T> : IDisposable where T : class {

        Task<bool> commit();

    }
}
