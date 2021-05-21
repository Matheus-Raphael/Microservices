using Microsoft.EntityFrameworkCore;
using Enderecos.Data.Infra._Core.Context.Abstractions;

namespace Enderecos.Data.Infra._Core.Context {

    public class ContextAppDefault : ContextAppBase, IContextAppDefault {

        //Dependencies


        //Propriedades

        /// <summary>
        /// Construtor
        /// </summary>
        public ContextAppDefault(DbContextOptions<ContextAppDefault> options) : base(options) {
        }

    }
}
