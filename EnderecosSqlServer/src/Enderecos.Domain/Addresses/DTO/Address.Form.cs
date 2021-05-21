using Enderecos.Domain.Addresses.Entities;

namespace Enderecos.Domain.Addresses.DTO {
    public class AddressForm {

        public Address infoAddress { get; set; }

        public AddressForm(string nameParam, int idStateParam) {

            infoAddress = new Address();
            infoAddress.name = nameParam;
            infoAddress.idState = idStateParam;
        }
    }
}