using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Enderecos.Data.Infra._Core.Repositories.Abstractions;
using Enderecos.Data.Infra._Core.Context.Abstractions;

namespace Enderecos.Data.Infra._Core.Repositories {

    public abstract class RepositorySearchBase<T> : IRepositorySearch<T> where T : class {

        //Dependencies
        private readonly IContextAppBase context;
        private DbSet<T> dbSet;

        /// <summary>
        /// 
        /// </summary>
        public RepositorySearchBase(IContextAppBase _context) {
            context = _context;
            dbSet = context.Set<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task<T> find(object id) {
            return await dbSet.FindAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            context.Dispose();
        }
    }
}
