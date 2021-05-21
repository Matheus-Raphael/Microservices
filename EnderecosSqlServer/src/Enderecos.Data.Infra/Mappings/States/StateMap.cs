using Enderecos.Data.Infra._Core.Context;
using Enderecos.Domain.States.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enderecos.Data.Infra.Mappings.States {

    public class StateMap : BaseEntityMapping<State> {

        /// <summary>
        /// 
        /// </summary>
        public override void setupEntity(EntityTypeBuilder<State> builder) {

            //Table Setup
            setupTable(builder);

            //Fields Setup
            setupFields(builder);

            //Foreign Keys
            setupRelationships(builder);

            //Indexes
            setupIndexes(builder);
        }

        private void setupTable(EntityTypeBuilder<State> builder) {
            builder.ToTable("tb_state");
            builder.HasKey(x => x.id);
        }

        /// <summary>
        /// 
        /// </summary>
        private void setupFields(EntityTypeBuilder<State> builder) {
            builder.HasKey(o => o.id);
        }

        /// <summary>
        /// 
        /// </summary>
        private void setupRelationships(EntityTypeBuilder<State> builder) { }

        /// <summary>
        /// 
        /// </summary>
        private void setupIndexes(EntityTypeBuilder<State> builder) { }
    }
}
