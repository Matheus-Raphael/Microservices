using Enderecos.Data.Infra._Core.Context.Abstractions;
using Enderecos.Data.Infra._Core.Respositories.Abstractions;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Enderecos.Data.Infra._Core.Respositories {

    public abstract class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class {

        //Dependencias
        protected readonly INoSqlContext context;

        protected IClientSessionHandle session;

        protected DateTime transactionStartDateTime;

        protected virtual string collectionName { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        protected BaseRepo(INoSqlContext _context) {

            context = _context;
        }

        /// <summary>
        /// Start Transaction
        /// </summary>
        public async Task startTransaction() {

            transactionStartDateTime = DateTime.Now;

            session = await context.dbClient.StartSessionAsync();

            session.StartTransaction();
        }

        /// <summary>
        /// Commit Transaction
        /// </summary>
        public async Task commitTransaction() {

            await session.CommitTransactionAsync();
        }

        /// <summary>
        /// Abort Transaction
        /// </summary>
        public async Task abortTransaction() {

            await session.AbortTransactionAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose() {

            GC.SuppressFinalize(this);
        }

    }

}
