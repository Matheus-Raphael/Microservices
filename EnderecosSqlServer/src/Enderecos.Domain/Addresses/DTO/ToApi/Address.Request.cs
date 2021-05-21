using System.Collections.Generic;

namespace Enderecos.Domain.Addresses.DTO.ToApi {
    public class AddressRequest {

        public List<AddressFilterApi> listRequest { get; set; }
    }
}
