using DnsClient;
using Enderecos.Data.Infra._Core.ContextBase.Abstractions;
using Enderecos.Data.Infra._Core.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enderecos.Data.Infra._Core.ContextBase {
    //public abstract class NoSqlContextBase : INoSqlContextBase, IDisposable {
    public abstract class NoSqlContextBase : INoSqlContextBase {

        //Dependencies
        protected IMongoDatabase database;
        protected MongoClient noSqlClient;
        protected IClientSessionHandle _session;
        protected readonly List<Func<Task>> listCommands;
        protected NoSqlSettings noSqlSettings { get; set; }


        /// <summary>
        /// Propertiers
        /// </summary>
        public IMongoDatabase db => database;
        public IMongoClient dbClient => noSqlClient;
        public IClientSessionHandle dbSession => _session;

        /// <summary>
        /// Construct method
        /// </summary>
        protected NoSqlContextBase(NoSqlSettings _noSqlSettings) {
            noSqlSettings = _noSqlSettings;

            /*
            // Configure mongo (You can inject the config, just to simplify)
            IDictionary<string, string> configSectionNoSql = this.Configuration.GetSection(noSqlSettings.keySettings).GetChildren().ToDictionary(x => x.Key, x => x.Value);
            configSectionNoSql.TryGetValue(noSqlSettings.keyConnection, out string conex);
            configSectionNoSql.TryGetValue(noSqlSettings.keyDbName, out string database);
            */

            RetryPolicy retryPolicy = Policy.Handle<DnsResponseException>()
                                            .WaitAndRetry(new[] {
                                                TimeSpan.FromSeconds(3),
                                                TimeSpan.FromSeconds(6),
                                                TimeSpan.FromSeconds(9)
                                              });

            MongoClientSettings clientSettings = MongoClientSettings.FromConnectionString(noSqlSettings.connection);
            clientSettings.UseTls = noSqlSettings.flagTls;
            clientSettings.AllowInsecureTls = noSqlSettings.flagAllowInsecureTls;

            retryPolicy.Execute(() => {
                noSqlClient = new MongoClient(clientSettings);
                database = noSqlClient.GetDatabase(noSqlSettings.database, new MongoDatabaseSettings());
            });

            // Set Guid to CSharp style (with dash -)
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            // Every command will be stored and it'll be processed at SaveChanges
            listCommands = new List<Func<Task>>();

            registerConventions();

        }

        private void registerConventions() {

            var pack = new ConventionPack{
                           new IgnoreExtraElementsConvention(true),
                           new IgnoreIfDefaultConvention(true)
                       };

            ConventionRegistry.Register("Default_Conventions", pack, t => true);

        }

        /// <summary>
        /// Carregar uma colecao do banco NoSql
        /// </summary>
        public IMongoCollection<T> getCollection<T>(string name) {

            return database.GetCollection<T>(name);
        }


        /// <summary>
        /// Adicionar comando na fila de execucao
        /// </summary>
        public void addCommand(Func<Task> func) {

            listCommands.Add(func);

        }

        /// <summary>
        /// Enviar comandos para NoSQL
        /// </summary>
        public async Task<int> saveChanges() {

            var commandTasks = listCommands.Select(c => c());

            await Task.WhenAll(commandTasks);

            return listCommands.Count;
        }


        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {

            GC.SuppressFinalize(this);
        }
    }
}