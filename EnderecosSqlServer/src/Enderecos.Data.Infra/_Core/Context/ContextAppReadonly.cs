using Microsoft.EntityFrameworkCore;
using Enderecos.Data.Infra._Core.Context.Abstractions;

namespace Enderecos.Data.Infra._Core.Context {

    public class ContextAppReadonly : ContextAppBase, IContextAppReadonly {

        //Dependencies


        //Propriedades

        /// <summary>
        /// Construtor
        /// </summary>
        public ContextAppReadonly(DbContextOptions<ContextAppReadonly> options) : base(options) {
        }

    }
}
