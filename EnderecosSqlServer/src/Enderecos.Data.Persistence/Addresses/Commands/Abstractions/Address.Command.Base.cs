using Enderecos.Data.Infra._Core.Context;
using Enderecos.Data.Infra._Core.Repositories;
using Enderecos.Domain.Addresses.Entities;

namespace Enderecos.Data.Persistence.Addresses.Commands.Abstractions {
    public class AddressCommandBase : RepositoryCommandBase<Address> {

        /// <summary>
        /// Construtor
        /// </summary>
        public AddressCommandBase(ContextAppDefault _context) : base(_context) {

        }
    }
}