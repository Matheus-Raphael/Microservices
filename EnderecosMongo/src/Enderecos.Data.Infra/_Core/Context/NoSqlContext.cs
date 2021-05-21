using Enderecos.Data.Infra._Core.Context.Abstractions;
using Enderecos.Data.Infra._Core.ContextBase;
using Enderecos.Data.Infra._Core.Settings;
using Enderecos.Data.Infra.Mappings;
using Enderecos.Domain.States.Entities;
using MongoDB.Driver;

namespace Enderecos.Data.Infra._Core.Context {

    public class NoSqlContext : NoSqlContextBase, INoSqlContext {

        /// <summary>
        /// 
        /// </summary>
        public NoSqlContext(NoSqlSettings _noSqlSettings) : base(_noSqlSettings) {

        }

        //Entidades
        public IMongoCollection<State> state => database.GetCollection<State>(CollectionsName.state);
    }

}
