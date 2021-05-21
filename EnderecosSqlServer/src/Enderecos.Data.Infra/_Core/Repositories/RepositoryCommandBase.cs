using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Enderecos.Data.Infra._Core.Repositories.Abstractions;
using Enderecos.Data.Infra._Core.Context;

namespace Enderecos.Data.Infra._Core.Repositories {

    public abstract class RepositoryCommandBase<T> : IRepositoryBase<T> where T : class {

        //Dependencies
        protected readonly ContextAppDefault context;
        internal DbSet<T> dbSet;

        /// <summary>
        /// 
        /// </summary>
        public RepositoryCommandBase(ContextAppDefault _context) {
            context = _context;
            dbSet = context.Set<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual T find(object id) {
            return dbSet.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> commit() {
            int results = await context.SaveChangesAsync();

            return results > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            context.Dispose();
        }
    }
}
