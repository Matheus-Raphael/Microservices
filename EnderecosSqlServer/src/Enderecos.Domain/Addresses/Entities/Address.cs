namespace Enderecos.Domain.Addresses.Entities {

    public class Address : AddressBase {

    }

    public class AddressBase {

        public int id { get; set; }

        public string name { get; set; }

        public int idState { get; set; }
    }
}