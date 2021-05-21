using System.Threading.Tasks;
using Enderecos.Application.Addresses.Commands.Abstractions;
using Enderecos.Data.Infra._Core.Context;
using Enderecos.Data.Persistence.Addresses.Commands.Abstractions;
using Enderecos.Domain.Addresses.DTO;
using Enderecos.Domain.Addresses.Entities;

namespace Enderecos.Data.Persistence.Addresses.Commands.Services {
    public class AddressCreator : AddressCommandBase, IAddressCreator {

        /// <summary>
        /// Construtor
        /// </summary>
        public AddressCreator(ContextAppDefault _context) : base(_context) {}

        /// <summary>
        /// 
        /// </summary>
        public async Task<Address> create(AddressForm form) {

            this.context.Add(form.infoAddress);

            await this.context.SaveChangesAsync();

            return form.infoAddress;
        }
    }
}