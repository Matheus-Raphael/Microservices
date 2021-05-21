using Enderecos.Data.Infra._Core.Context;
using Enderecos.Data.Infra._Core.Context.Abstractions;
using Enderecos.Data.Infra._Core.Settings;
using Enderecos.Domain.States.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using System.Collections.Generic;
using System.Linq;

namespace Enderecos.Infra.IoC._Core.Injectors {

    public static class DataInjector {

        /// <summary>
        /// 
        /// </summary>
        public static void AddInfraDataConfiguration(this IServiceCollection services,
                                                      IConfiguration configuration) {

            //Context
            IDictionary<string, string> configSectionNoSql = configuration.GetSection("MongoSettings").GetChildren().ToDictionary(x => x.Key, x => x.Value);
            configSectionNoSql.TryGetValue("Connection", out string conex);
            configSectionNoSql.TryGetValue("DatabaseName", out string database);
            configSectionNoSql.TryGetValue("FlagTls", out string flagTls);
            configSectionNoSql.TryGetValue("FlagAllowInsecureTls", out string flagAllowInsecureTls);

            var noSqlSettings = new NoSqlSettings(conex, database);
            noSqlSettings.flagTls = flagTls != "" ? flagTls.Equals("S") : noSqlSettings.flagTls;
            noSqlSettings.flagAllowInsecureTls = flagAllowInsecureTls != "" ? flagAllowInsecureTls.Equals("S") : noSqlSettings.flagAllowInsecureTls;

            services.AddScoped<INoSqlContext>(x => new NoSqlContext(_noSqlSettings: noSqlSettings));

            ConfigureClassMaps();
        }

        private static void ConfigureClassMaps() {

            BsonClassMap.RegisterClassMap<StateBase>(cm => {
                cm.AutoMap();
                cm.MapIdMember(c => c.id);
                cm.MapIdProperty(c => c.id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }

    }
}
