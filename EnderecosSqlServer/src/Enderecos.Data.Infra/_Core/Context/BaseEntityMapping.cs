using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enderecos.Data.Infra._Core.Context {

    public abstract class BaseEntityMapping<TBase> : IEntityTypeConfiguration<TBase> where TBase : class {

        /// <summary>
        /// 
        /// </summary>
        public void Configure(EntityTypeBuilder<TBase> builder) {

            setupEntity(builder);
        }

        public abstract void setupEntity(EntityTypeBuilder<TBase> builder);
    }

}