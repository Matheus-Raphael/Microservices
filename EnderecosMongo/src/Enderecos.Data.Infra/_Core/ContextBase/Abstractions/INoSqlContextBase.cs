using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Enderecos.Data.Infra._Core.ContextBase.Abstractions {
    public interface INoSqlContextBase : IDisposable {

        IMongoDatabase db { get; }
        IMongoClient dbClient { get; }
        void addCommand(Func<Task> func);
        Task<int> saveChanges();
        IMongoCollection<T> getCollection<T>(string name);
    }
}
