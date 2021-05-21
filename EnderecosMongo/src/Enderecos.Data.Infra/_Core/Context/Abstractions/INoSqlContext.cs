using Enderecos.Data.Infra._Core.ContextBase.Abstractions;
using Enderecos.Domain.States.Entities;
using MongoDB.Driver;

namespace Enderecos.Data.Infra._Core.Context.Abstractions {

    public interface INoSqlContext : INoSqlContextBase {

        IMongoCollection<State> state { get; }
    }

}
