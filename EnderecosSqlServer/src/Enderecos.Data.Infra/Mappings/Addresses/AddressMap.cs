using Enderecos.Data.Infra._Core.Context;
using Enderecos.Domain.Addresses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enderecos.Data.Infra.Mappings.States {

    public class AddressMap : BaseEntityMapping<Address> {

        /// <summary>
        /// 
        /// </summary>
        public override void setupEntity(EntityTypeBuilder<Address> builder) {

            //Table Setup
            setupTable(builder);

            //Fields Setup
            setupFields(builder);

            //Foreign Keys
            setupRelationships(builder);

            //Indexes
            setupIndexes(builder);
        }

        private void setupTable(EntityTypeBuilder<Address> builder) {
            builder.ToTable("tb_address");
            builder.HasKey(x => x.id);
        }

        /// <summary>
        /// 
        /// </summary>
        private void setupFields(EntityTypeBuilder<Address> builder) {
            builder.HasKey(o => o.id);
        }

        /// <summary>
        /// 
        /// </summary>
        private void setupRelationships(EntityTypeBuilder<Address> builder) { }

        /// <summary>
        /// 
        /// </summary>
        private void setupIndexes(EntityTypeBuilder<Address> builder) { }
    }
}
