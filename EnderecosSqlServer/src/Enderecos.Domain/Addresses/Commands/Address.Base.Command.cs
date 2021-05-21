using Enderecos.Domain.Addresses.DTO.ToApi;
using System.Collections.Generic;

namespace Enderecos.Domain.Addresses.Commands {
    public class AddressBaseCommand {

        //Propertiers
        public AddressRequest request { get; set; }
        //public AddressRequest request { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public AddressBaseCommand(AddressRequest requestParam) {
            request = requestParam;
        }
        //public AddressBaseCommand(AddressRequest requestParam) {
        //    request = requestParam;
        //}

    }
}