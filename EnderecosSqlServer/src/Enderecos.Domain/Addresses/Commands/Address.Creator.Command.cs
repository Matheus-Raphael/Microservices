using Enderecos.Domain.Addresses.DTO.ToApi;
namespace Enderecos.Domain.Addresses.Commands {

    public class AddressCreatorCommand : AddressBaseCommand {

        /// <summary>
        /// Construtor
        /// </summary>
        public AddressCreatorCommand(AddressRequest ListRequest) : base(ListRequest) {

        }
    }
}