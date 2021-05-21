using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Enderecos.Data.Infra._Core.Context.Abstractions;
using Enderecos.Domain.States.Entities;
using Enderecos.Domain.Addresses.Entities;

namespace Enderecos.Data.Infra._Core.Context {

    public abstract class ContextAppBase : DbContext, IContextAppBase {

        //Dependencies

        //Propriedades
        public DbSet<State> state { get; protected set; }
        public DbSet<Address> address { get; protected set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public ContextAppBase(DbContextOptions options) : base(options) {

            setTrackingBehavior();
        }

        /// <summary>
        /// 
        /// </summary>
        private void setTrackingBehavior() {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder) {

            //All mappings entities register
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
