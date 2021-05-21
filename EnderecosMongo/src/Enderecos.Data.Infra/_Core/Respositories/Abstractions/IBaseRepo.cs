using System;
using System.Threading.Tasks;

namespace Enderecos.Data.Infra._Core.Respositories.Abstractions {

    public interface IBaseRepo<in TEntity> : IDisposable where TEntity : class {

        Task startTransaction();

        Task commitTransaction();

        Task abortTransaction();
    }

}
